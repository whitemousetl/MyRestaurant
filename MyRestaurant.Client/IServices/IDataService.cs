using MyRestaurant.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Client.IServices;
public interface IDataService
{
    List<Dish>? GetDishes();
}
