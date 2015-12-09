using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.Logic.PersonManagement.Contracts;

using Microsoft.AspNet.Mvc;

using WebClient.Models.Home;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonManager _manager;
        private readonly IPersonStatistics _statistics;

        public HomeController(IPersonManager manager, IPersonStatistics statistics)
        {
            _manager = manager;
            _statistics = statistics;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexModel
            {
                Adults = _manager.GetAllAdults().ToList(),
                Children = _manager.GetAllChildren().ToList(),
                Statistics = _statistics.GetAgeStatistic()
            };
            

            return View(model);
        }
    }
}
