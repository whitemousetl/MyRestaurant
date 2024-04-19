using MyRestaurant.Client.IServices;
using MyRestaurant.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Client.Services;
public class DataService : IDataService
{
    public List<Dish>? GetDishes()
    {
        string jsonFilePath = "Data/Menu.json";
        string json = File.ReadAllText(jsonFilePath);

        
        List<Dish>? dishes = JsonConvert.DeserializeObject<List<Dish>>(json);

        return dishes;
            
    }
}
