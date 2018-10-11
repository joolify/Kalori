using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    public interface IFoodRepository : IRepository<Food>
    {
        Food Get(int? id);
        CategoryType GetCategoryType(int? id);
    }
}