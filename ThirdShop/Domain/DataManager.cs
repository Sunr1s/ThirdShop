using ThirdShop.Domain.Repositories.Abstract;

namespace ThirdShop.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public IUserCartsRepository Usercarts { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository, IUserCartsRepository userCartsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            Usercarts = userCartsRepository;
        }
    }
}
