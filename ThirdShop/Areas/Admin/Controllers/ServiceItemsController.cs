using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdShop.Domain;
using ThirdShop.Domain.Entities;
using ThirdShop.Service;

namespace ThirdShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile, IFormFile miniImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    
                    model.TitleImagePath = titleImageFile.FileName;
                    //model.MiniImagePath = miniImagePath.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);

                    }
                    //using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", miniImagePath.FileName), FileMode.Create))
                    //{
                    //    miniImagePath.CopyTo(stream);
                    //}
                }



                if (miniImageFile != null)
                {
                    //model.TitleImagePath = titleImageFile.FileName;
                    model.MiniImagePath = miniImageFile.FileName;
                    //using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    //{
                    //    titleImageFile.CopyTo(stream);

                    //}
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", miniImageFile.FileName), FileMode.Create))
                    {
                        miniImageFile.CopyTo(stream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}