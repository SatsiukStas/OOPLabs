using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.ViewModels;

namespace kursach.Views;

public partial class SettingTourView : ContentPage
{
    private SettingTourViewModel settingTourViewModel;
    public SettingTourView(SettingTourViewModel settingTourViewModel)
    {
        InitializeComponent();
        this.settingTourViewModel = settingTourViewModel;
        BindingContext = settingTourViewModel;
    }
}