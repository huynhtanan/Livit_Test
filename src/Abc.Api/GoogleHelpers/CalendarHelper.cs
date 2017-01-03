using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Abc.Api.ViewModels;
using System.Collections.Generic;
using Abc.Dal.Models;

namespace Abc.Api.GoogleHelpers
{
	public static class CalendarHelper
	{
		private static CalendarService GetCalendarService(string accessToken, string refreshToken, string userId)
		{
			var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
			{
				ClientSecrets = new ClientSecrets
				{
					ClientId = GoogleAPIInfo.ClientID,
					ClientSecret = GoogleAPIInfo.ClientSecret
				},
				Scopes = new[] { CalendarService.Scope.Calendar }
			});
			var credential = new UserCredential(flow, userId, new TokenResponse
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			});
			CalendarService service = new CalendarService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "Livit Test Google API",
			});
			return service;
		}
		public static IList<CalendarListEntry> GetCalendarList(string accessToken, string refreshToken, string userId)
		{
			var service = GetCalendarService(accessToken, refreshToken, userId);
			return service.CalendarList.List().Execute().Items;
		}
		public static Event InsertEvent(AbsenceCalendarViewModel ab, string accessToken, string refreshToken, string userId)
		{
			var Recurrence = ab.Recurrence ?? string.Empty;
			var attendeeEmails = ab.AttendeeEmails ?? string.Empty;
			var Attendees = new List<EventAttendee>();
			foreach (var attendee in attendeeEmails.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
			{
				Attendees.Add(new EventAttendee { Email = attendee });
			}
			var reminderMethods = ab.ReminderMethods ?? string.Empty;
			var Overrides = new List<EventReminder>();
			foreach (var r in reminderMethods.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
			{
				Overrides.Add(new EventReminder { Method = r, Minutes = 60 });
			}

			var newEvent = new Event
			{
				Summary = ab.Summary,
				Location = ab.Location,
				Description = ab.Description,
				Start = new EventDateTime()
				{
					DateTime = ab.StartDate,
					TimeZone = ab.StartTimeZone,
				},
				End = new EventDateTime()
				{
					DateTime = ab.EndDate,
					TimeZone = ab.EndTimeZone,
				}
			};
			if (Recurrence.Length > 0)
				newEvent.Recurrence = new string[] { Recurrence };
			if (Attendees.Count > 0)
				newEvent.Attendees = Attendees;
			if (Overrides.Count > 0)
			{
				newEvent.Reminders = new Event.RemindersData()
				{
					UseDefault = false,
					Overrides = Overrides
				};
			}

			var service = GetCalendarService(accessToken, refreshToken, userId);
			string calendarId = "primary";
			EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
			Event createdEvent = request.Execute();
			return createdEvent;
		}
	}
}
