using MyRestaurant.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Client.ViewModels;
public class DishMenuItemViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public Dish? Dish { get; set; }

	private bool isSelected;

	public bool IsSelected
    {
		get { return isSelected; }
		set 
		{
			isSelected = value; 
			PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsSelected)));
		}
	}



}
