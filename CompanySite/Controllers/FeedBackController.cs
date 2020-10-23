using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySite.Domain;
using CompanySite.Domain.Entities;
using CompanySite.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CompanySite.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IFeedBackRepository feedBackRepository;

        public FeedBackController(IFeedBackRepository feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FeedBack model)
        {
            if (ModelState.IsValid)
            {
                feedBackRepository.SaveFeedBack(model);
                return RedirectToAction();
            }

            return View(model);
        }
    }
}
