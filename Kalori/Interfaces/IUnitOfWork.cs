using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kalori.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFoodRepository Foods { get; }
        IProductRepository Products { get; }
        IShoppinglistRepository Shoppinglists { get; }
        int Complete();
    }
}