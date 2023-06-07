using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;
using kursach.ViewModels;

namespace kursach.Views;

public partial class DetailTourView : ContentPage
{
    public DetailTourView(DetailTourViewModel detailTourViewModel)
    {
        InitializeComponent();
        BindingContext = detailTourViewModel;
    }
}