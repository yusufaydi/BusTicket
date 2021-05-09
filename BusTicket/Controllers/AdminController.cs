using BusTicket.Data;
using BusTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Admin()
        {
            var ticketList = from t in _db.Ticket
                            join r in _db.Route on t.RouteId equals r.Id
                            join u in _db.User on t.UserId equals u.Id
                             where t.RecordStatus == "A"
                            select new AdminSummary
                            {
                                UserName = u.UserName,
                                RoutePrice =t.Price,
                                TicketId = t.Id
                            };

            ViewBag.ticketList = ticketList.ToList();
            return View();

        }
  
        public ActionResult HandleDeleteButtonClick(int ticketId)
        {
            IncreaseSeatCount(ticketId);
            DeleteTicket(ticketId);
            UpdateSeatPriceOfRoute(ticketId);
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }

        private void DeleteTicket(int ticketId)
        {
            var deletedTicket = _db.Ticket.SingleOrDefault(x => x.Id == ticketId);
            deletedTicket.RecordStatus = "P";

        }

        private void IncreaseSeatCount(int ticketId)
        {
            int routeId = _db.Ticket.Where(x => x.Id == ticketId).FirstOrDefault().RouteId;
            var route = _db.Route.SingleOrDefault(x => x.Id == routeId);
            route.FilledSeatCount -= 1;

        }
        private void UpdateSeatPriceOfRoute(int ticketId)
        {
            int routeId = _db.Ticket.SingleOrDefault(x => x.Id == ticketId).RouteId;
            var route = _db.Route.SingleOrDefault(x => x.Id == routeId);
            var bus = _db.Bus.SingleOrDefault(x => x.Id == route.BusId);

            int rate = route.FilledSeatCount / 5;
            if (route.FilledSeatCount % 5 == 0)
            {
                decimal startPrice = (route.RoutPrice - (10 * (rate - 1)));
                route.RoutPrice = startPrice + (startPrice * 0.10m * rate);
            }
        }
    }
}