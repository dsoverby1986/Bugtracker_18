using Bugtracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bugtracker.Extensions
{
    public static class TicketExtensions
    {
        private static List<string> ComparableTicketProperties = new List<string>(new string[] { "Title", "Description", "AssignedUserId", "TicketStatusId", "TicketPriorityId", "ProjectId" });

        public static List<PropertyInfo> Difference(this Ticket oldTicket, Ticket newTicket)
        {
            List<PropertyInfo> differences = new List<PropertyInfo>();

            var oldTicketProperties = oldTicket.GetType().GetProperties();
            var newTicketProperties = newTicket.GetType().GetProperties();

            PropertyInfo newTicketProperty;
            object newTicketPropertyValue;
            object oldTicketPropertyValue;

            foreach(var oldTicketProperty in oldTicketProperties)
            {
                if (ComparableTicketProperties.Contains(oldTicketProperty.Name))
                {
                    newTicketProperty = newTicketProperties.Single(p => p.Name == oldTicketProperty.Name);

                    newTicketPropertyValue = newTicketProperty.GetValue(newTicket, null);
                    oldTicketPropertyValue = oldTicketProperty.GetValue(oldTicket, null);

                    if (oldTicketPropertyValue != newTicketPropertyValue)
                        differences.Add(oldTicketProperty);
                }
            }

            return differences;
        }
    }
}