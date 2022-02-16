
using System;
using Microsoft.AspNetCore.Mvc;
using ThirdShop.Domain;
using ThirdShop.Domain.Entities;
using ThirdShop.Service;
using Microsoft.AspNetCore.Authorization;
namespace ThirdShop.Controllers
{
    public class CartController : Controller
    {
        private readonly DataManager dataManager;
       

        public CartController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

      
        public IActionResult Index(Guid id)
        {
            return View(dataManager.ServiceItems.GetServiceItemById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(string Title, string ProductCode, double Price, string MiniImage, string Subtitle,Guid id)
        {
            UserCart model = new UserCart()
            {
                Title = Title,
                ProductCode = ProductCode,
                Price = Price,
                MiniImagePath = MiniImage,
                Undertitle = Subtitle
            }; 
           
            dataManager.Usercarts.SaveUserCart(model);
            return View(dataManager.Usercarts.GetUserCarts());
        }
        [Authorize]
       
        public IActionResult Outputcart()
        { 
            return View(dataManager.Usercarts.GetUserCarts());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            
            dataManager.Usercarts.DeleteUserCart(id);
            return RedirectToAction(nameof(CartController.Outputcart), nameof(CartController).CutController());
        }

    }
}
