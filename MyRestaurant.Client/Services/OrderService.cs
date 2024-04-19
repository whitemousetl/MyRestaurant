using MyRestaurant.Client.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Client.Services;
public class OrderService : IOrderService
{
    public void PlaceOrder(List<string?>? dishes)
    {
        if (dishes != null)
        {
            // Filter out null values and convert nullable strings to non-nullable strings
            var dishesNonNull = dishes.Where(item => item != null).Select(item => item!);

            // Convert the sequence to an array
            var dishesToArray = dishesNonNull.ToArray();

            if (dishesToArray.Length > 0)
            {
                // Write the non-null strings to the file
                System.IO.File.WriteAllLines(@"G:\order.txt", dishesToArray);
            }
        }

        //if (dishes != null)
        //{
        //    var dishesToArray = dishes.ToArray();
        //    if (dishesToArray.Length > 0 && dishesToArray.All(item => !string.IsNullOrEmpty(item)))
        //    {
        //        System.IO.File.WriteAllLines(@"G:\order.txt", dishesToArray);
        //    }
        //}
            
    }
}
