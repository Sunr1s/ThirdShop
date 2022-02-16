using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThirdShop.Domain;

namespace ThirdShop.Models.ViewsComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager; 

        public SideBarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
         
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.ServiceItems.GetServiceItems()));
        }
    }
}
