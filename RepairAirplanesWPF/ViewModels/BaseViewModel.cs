using GalaSoft.MvvmLight.Command;
using RepairAirplanesWPF.Classes;
using RepairAirplanesWPF.Views;
using RepairAirplanesWPF.Views.EditDataViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RepairAirplanesWPF.ViewModels
{
    public class BaseViewModel: DependencyObject
    {
        #region DependencyProperties
        public static DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(Page), typeof(BaseViewModel));
        public static DependencyProperty Repair_listProperty = DependencyProperty.Register("Repair_list", typeof(object), typeof(BaseViewModel));
        #endregion
        public BaseViewModel(Page currentPage)
        {
            CurrentPage = currentPage;
        }
        #region DataCollections
        public ObservableCollection<object> Repair_list => new ObservableCollection<object>();

        #endregion
        public Page CurrentPage
        {
            get
            {
                return GetValue(CurrentPageProperty) as Page;
            }
            set
            {
                SetValue(CurrentPageProperty, value);
            }
        }

        #region Commands
        public ICommand EnginePage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new EnginePage(), sender);
        });
        public ICommand EditEnginePage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new EditEngine(), sender);
        });
        public ICommand AddCoolingSystem_Command => new MenuNavigateCommand((sender) =>
        {

        });
        public ICommand RepairHistoryPage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new RepairHistoryPage(), sender);
        });
        #endregion


       
        private object currentPageButton = null;
        private void SetPage(Page page, object sender = null)
        {
            if (sender != null)
            {
                if (sender is Button button)
                {
                    if (this.currentPageButton is Button lastButton)
                    {
                        lastButton.IsEnabled = true;
                    }
                    this.currentPageButton = button;
                    button.IsEnabled = false;
                }
            }
            page.DataContext = this;
            this.CurrentPage = page;
        }
    }
}
