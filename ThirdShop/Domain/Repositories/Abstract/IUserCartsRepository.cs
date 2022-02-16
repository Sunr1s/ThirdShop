using System;
using System.Linq;
using ThirdShop.Domain.Entities;

namespace ThirdShop.Domain.Repositories.Abstract
{
    public interface IUserCartsRepository
    {
        IQueryable<UserCart> GetUserCarts();
        UserCart GetUserCartById(Guid id);
        void SaveUserCart(UserCart entity);
        void DeleteUserCart(Guid id);
    }
}
