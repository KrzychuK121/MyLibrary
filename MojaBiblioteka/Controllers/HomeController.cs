using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MojaBiblioteka.Data;
using MojaBiblioteka.Models;
using MojaBiblioteka.Models.Entities.Connector;
using MojaBiblioteka.Models.ViewModels.Messages;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Claims;

namespace MojaBiblioteka.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyLibraryContext _context;

        public HomeController
        (
            ILogger<HomeController> logger,
            MyLibraryContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            if (!User.IsInRole("Client"))
                return View();

            //rt.DueDate.Subtract(DateTime.Now.AtMidnight()).TotalDays <= 0

            var ifSoonExpire = false;
            var ifExpierd = false;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dueDates = _context.RentalTransactionList
                .Where
                (
                    rt => rt.UserId.Equals(userId) &&
                    rt.Status != (int) BookStatus.Cancelled &&
                    rt.Status != (int) BookStatus.Returned &&
                    rt.Status != (int) BookStatus.Closed
                )
                .Select(rt => rt.DueDate);

            if (!dueDates.Any())
                return View();

            foreach(var dueDate in dueDates) 
            {
                if
                (
                    !ifSoonExpire &&
                    dueDate.Subtract(DateTime.Now.AtMidnight()).TotalDays <= 7 &&
                    dueDate.Subtract(DateTime.Now.AtMidnight()).TotalDays > 0
                )
                    ifSoonExpire = true;

                if(!ifExpierd && dueDate.Subtract(DateTime.Now.AtMidnight()).TotalDays <= 0)
                    ifExpierd = true;
            }

            var linkMessage = " Sprawdź które to książki klikając \"Moje wypożyczenia\" ";


            if (ifSoonExpire)
            {
                ViewData["messageSoonExpire"] = "Niedługo termin Twoich zamówień dobiegnie końca." + linkMessage;
                ViewData["typeSoonExpire"] = Types.Warning;
            }

            if (ifExpierd)
            {
                ViewData["messageExpired"] = "Posiadasz książki, które powinieneś już zwrócić." + linkMessage;
                ViewData["typeExpired"] = Types.Error;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}