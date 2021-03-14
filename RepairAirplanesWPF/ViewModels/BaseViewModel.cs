using GalaSoft.MvvmLight.Command;
using RepairAirplanesWPF.Classes;
using RepairAirplanesWPF.Views;
using RepairAirplanesWPF.Views.EditDataViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RepairAirplanesWPF.ViewModels
{
    public class BaseViewModel: DependencyObject, INotifyPropertyChanged
    {
        public RepairAirplanesDataManager DataManager = new RepairAirplanesDataManager(new Repair_airplanesConnection());
        public BaseViewModel(Page currentPage)
        {
            CurrentPage = currentPage;
        }

        #region DataCollections
        public ObservableCollection<object> Repair_list => new ObservableCollection<object>();
        private ObservableCollection<Engine> _Engine_list = new ObservableCollection<Engine>();
        public ObservableCollection<Engine> Engine_list
        {
            get
            {
                return _Engine_list;
            }
            set
            {
                _Engine_list = value;
                PropertyChanged?.Invoke(_Engine_list, new PropertyChangedEventArgs("Engine_list"));
            }
        }

        #endregion

        #region LoadData
        private async void LoadEngineList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetEngine_List();
                Dispatcher.Invoke(() => { this.Engine_list = result;});
            });
        }
        #endregion

        #region Commands
        public ICommand EngineListPage_Open => new MenuNavigateCommand((sender) =>
        {
            LoadEngineList();
            SetPage(new EngineListPage() { DataContext = this }, sender);
            
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

        #region CurrentPageManagement
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
        #endregion
        
        #region DependencyProperties
        public static DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(Page), typeof(BaseViewModel));
        public static DependencyProperty Repair_listProperty = DependencyProperty.Register("Repair_list", typeof(object), typeof(BaseViewModel));
        //public static DependencyProperty Engine_listProperty = DependencyProperty.Register("Engine_list", typeof(ObservableCollection<Engine>), typeof(BaseViewModel));

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
