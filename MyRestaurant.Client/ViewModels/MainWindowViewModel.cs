using MyRestaurant.Client.Command;
using MyRestaurant.Client.IServices;
using MyRestaurant.Client.Models;
using MyRestaurant.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyRestaurant.Client.ViewModels;
public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    //public ICommand PlaceOrderCommand {  get{ return new MyCommand(PlaceOrder); } }

    //public ICommand SelectMenuItemCommand { get { return new MyCommand(SelectMenuItem); } }

    public ICommand PlaceOrderCommand {  get; set; }

    public ICommand SelectMenuItemCommand { get; set; }

    private int count;

    public int Count
    {
        get { return count; }
        set
        {
            count = value; 
            
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Count)));
        }
    }

    private Restaurant? restaurant;

    public Restaurant? Restaurant
    {
        get { return restaurant; }
        set 
        {
            restaurant = value; 
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Restaurant)));
        }
    }

    private List<DishMenuItemViewModel>? dishMenu;

    public List<DishMenuItemViewModel>? DishMenu
    {
        get { return dishMenu; }
        set 
        { 
            dishMenu = value; 
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(DishMenu)));
        }
    }



    public MainWindowViewModel()
    {
        this.LoadRestaruant();
        this.LoadDishMenu();
        PlaceOrderCommand = new MyCommand(PlaceOrder);
        SelectMenuItemCommand = new MyCommand(SelectMenuItem);

    }

    private void LoadRestaruant()
    {
        this.Restaurant = new Restaurant
        {
            Name = "WhiteMouseTL",
            Address = "广东省广州市增城区仁吉中路608号雅致轩16栋2单元2904房",
            Phone = "13672511324 or 15219655698"
        };
    }

    private void LoadDishMenu()
    {
        DataService ds = new();
        var dishes = ds.GetDishes();
        this.DishMenu = [];
        if(dishes != null)
        {
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }
    }

    private void PlaceOrder()
    {
        if(this.DishMenu != null)
        {
            var selectedDishes = this.DishMenu.Where(temp => temp.IsSelected == true).Select(temp => temp?.Dish?.Name).ToList();

            IOrderService orderService = new OrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功");

            this.DishMenu.Where(temp => temp.IsSelected)
                 .ToList()
                 .ForEach(temp => temp.IsSelected = false);
        }
        
    }

    private void SelectMenuItem()
    {
        if(DishMenu != null)
            this.Count = this.DishMenu.Count(temp => temp.IsSelected == true);
    }
}
