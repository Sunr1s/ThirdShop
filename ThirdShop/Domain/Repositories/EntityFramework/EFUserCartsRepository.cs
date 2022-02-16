using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ThirdShop.Domain.Entities;
using ThirdShop.Domain.Repositories.Abstract;

namespace ThirdShop.Domain.Repositories.EntityFramework
{
    public class EFUserCartsRepository : IUserCartsRepository
    {
        private readonly AppDbContext context;
        public EFUserCartsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<UserCart> GetUserCarts()
        {
            return context.UserCarts;
        }

        public UserCart GetUserCartById(Guid id)
        {
            return context.UserCarts.FirstOrDefault(x => x.Id == id);
        }

        public void SaveUserCart(UserCart entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteUserCart(Guid id)
        {
            context.UserCarts.Remove(new UserCart() { Id = id });
            context.SaveChanges();
        }
    }
}
