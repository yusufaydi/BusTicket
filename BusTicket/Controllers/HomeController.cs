using BusTicket.Data;
using BusTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult BuyTicket()
        {
            var viewmodel = new ViewModel();
            viewmodel.LocationList = new Dictionary<int, Location>();
            foreach (var item in _db.Location.ToList())
            {
                viewmodel.LocationList.Add(item.Id, item);
            }

            viewmodel.RouteList = new Dictionary<int, Route>();
            foreach (var item in _db.Route.ToList())
            {
                viewmodel.RouteList.Add(item.Id, item);
            }

            ViewBag.viewModel = viewmodel;
            return View(new ViewModel() { LocationList = viewmodel.LocationList, RouteList = viewmodel.RouteList });
        }

        [HttpPost]
        public IActionResult BuyTicket(SearchTicket searchTicket)
        {
            var viewmodel = new ViewModel();
            viewmodel.LocationList = new Dictionary<int, Location>();
            foreach (var item in _db.Location.ToList())
            {
                viewmodel.LocationList.Add(item.Id, item);
            }

            viewmodel.RouteList = new Dictionary<int, Route>();
            var routeList = _db.Route.Where(x => x.DepartureTime == searchTicket.DepartureTime && x.StartLocationId == searchTicket.LocationId).ToList();
            foreach (var item in routeList)
            {
                viewmodel.RouteList.Add(item.Id, item);
            }

            ViewBag.viewModel = viewmodel;
            return View(new ViewModel() { LocationList = viewmodel.LocationList, RouteList = viewmodel.RouteList });
        }

        [HttpGet]
        public IActionResult Confirm (int routeId)
        {
            ViewBag.routeId = routeId.ToString();
            return View();
        }
        [HttpPost]
        public IActionResult Confirm(UserConfirm userConfirm)
        {
            var userId = _db.User.Where(x => x.UserName == userConfirm.UserName).FirstOrDefault().Id;
            var route = _db.Route.SingleOrDefault(x => x.Id == Convert.ToInt32(userConfirm.RouteId));
            _db.Ticket.Add(new Ticket { RouteId = Convert.ToInt32(userConfirm.RouteId), LastUpdateDate = DateTime.Now, UserId = userId, Price = route.RoutPrice, RecordStatus= "A" });

            route.FilledSeatCount += 1;
            UpdateSeatPriceOfRoute(route.Id);
            _db.SaveChanges();

            return RedirectToAction("BuyTicket", "Home");
        }

        private void UpdateSeatPriceOfRoute(int routeId)
        {
            var route = _db.Route.SingleOrDefault(x => x.Id == routeId);

            int rate = route.FilledSeatCount / 5;
            if (route.FilledSeatCount % 5 == 0)
            {
                decimal startPrice = (route.RoutPrice - (10 * (rate - 1)));
                route.RoutPrice = startPrice + (startPrice * 0.10m * rate);
            }
            
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}