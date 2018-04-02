using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bugtracker.Models
{
    public class TicketViewModel
    {
        public TicketViewModel() { }

        public TicketViewModel(ApplicationDbContext db)
        {
            Projects = new SelectList(db.Projects.ToList(), "Id", "Name");
            TicketStatuses = new SelectList(db.TicketStatuses.ToList(), "Id", "Name");
            TicketPriorities = new SelectList(db.TicketPriorities.ToList(), "Id", "Name");
            AssignedToUsers = new SelectList(db.Users.ToList(), "Id", "DisplayName");
        }

        public TicketViewModel(Ticket ticket, ApplicationDbContext db)
        {
            Ticket = ticket;
            Projects = new SelectList(db.Projects.ToList(), "Id", "Name", ticket.ProjectId);
            TicketStatuses = new SelectList(db.TicketStatuses.ToList(), "Id", "Name", ticket.TicketStatusId);
            TicketPriorities = new SelectList(db.TicketPriorities.ToList(), "Id", "Name", ticket.TicketPriorityId);
            AssignedToUsers = new SelectList(db.Users.ToList(), "Id", "DisplayName", ticket.AssignedUserId);
        }

        public Ticket Ticket { get; set; }
        public SelectList Projects { get; set; }
        public SelectList TicketStatuses { get; set; }
        public SelectList TicketPriorities { get; set; }
        public SelectList AssignedToUsers { get; set; }
    }

    public static class CreateTicketViewModelExtensions
    {
        private static ApplicationDbContext _db;

        private static Dictionary<CreateTicketViewModelSelectList, SelectList> CreateTicketViewModelSelectLists = new Dictionary<CreateTicketViewModelSelectList, SelectList>()
        {
            { CreateTicketViewModelSelectList.Projects, new SelectList(_db.Projects.ToList(), "Id", "Name") },
            { CreateTicketViewModelSelectList.AssignedToUsers, new SelectList(_db.Projects.ToList(), "Id", "DisplayName") },
            { CreateTicketViewModelSelectList.TicketsStatuses, new SelectList(_db.TicketStatuses.ToList(), "Id", "Name") },
            { CreateTicketViewModelSelectList.TicketPriorities, new SelectList(_db.TicketPriorities.ToList(), "Id", "Name") }
        };

        public static void PopulateSelectLists(this TicketViewModel model, ApplicationDbContext db)
        {
            _db = db;
            List<SelectList> selectLists = GetSelectLists(db);
            model.Projects = selectLists[0];
            model.AssignedToUsers = selectLists[1];
            model.TicketStatuses = selectLists[2];
            model.TicketPriorities = selectLists[3];
        }

        public static void PopulateSelectLists(this TicketViewModel model, Ticket ticket, ApplicationDbContext db)
        {
            _db = db;
            List<SelectList> selectLists = GetSelectLists(db);
            model.Projects = new SelectList(selectLists[0].Items, "Id", "Name", ticket.ProjectId);
            model.AssignedToUsers = new SelectList(selectLists[1].Items, "Id", "DisplayName", ticket.AssignedUserId);
            model.TicketStatuses = new SelectList(selectLists[2].Items, "Id", "Name", ticket.TicketStatusId);
            model.TicketPriorities = new SelectList(selectLists[3].Items, "Id", "Name", ticket.TicketPriorityId);
        }

        private static List<SelectList> GetSelectLists(ApplicationDbContext db)
        {
            return new List<SelectList>(new SelectList[] {
                CreateTicketViewModelSelectLists[CreateTicketViewModelSelectList.Projects],
                CreateTicketViewModelSelectLists[CreateTicketViewModelSelectList.AssignedToUsers],
                CreateTicketViewModelSelectLists[CreateTicketViewModelSelectList.TicketsStatuses],
                CreateTicketViewModelSelectLists[CreateTicketViewModelSelectList.TicketPriorities],
            });
        }
    }

    enum CreateTicketViewModelSelectList
    {
        Projects,
        AssignedToUsers,
        TicketsStatuses,
        TicketPriorities
    };
}