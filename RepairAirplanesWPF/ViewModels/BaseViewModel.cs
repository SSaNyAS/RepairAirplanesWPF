using GalaSoft.MvvmLight.Command;
using RepairAirplanesWPF.Classes;
using RepairAirplanesWPF.Extensions;
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
    public class BaseViewModel : DependencyObject
    {
        public RepairAirplanesDataManager DataManager = new RepairAirplanesDataManager(new RepairAirplanesConnection());
        public BaseViewModel(Page currentPage)
        {
            CurrentPage = currentPage;
        }

        #region DataCollections
        public ObservableCollection<Repair_list> Repair_list
        {
            get
            {
                return (ObservableCollection<Repair_list>)GetValue(Repair_listProperty);
            }
            set
            {
                SetValue(Repair_listProperty, value);
                Dispatcher.Invoke(() => { this.Repair_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Repair_list> RepairToAccept_list
        {
            get
            {
                return (ObservableCollection<Repair_list>)GetValue(RepairToAccept_listProperty);
            }
            set
            {
                SetValue(RepairToAccept_listProperty, value);
                Dispatcher.Invoke(() => { this.RepairToAccept_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Repair_list> FinishedRepair_list
        {
            get
            {
                return (ObservableCollection<Repair_list>)GetValue(FinishedRepair_listProperty);
            }
            set
            {
                SetValue(FinishedRepair_listProperty, value);
                Dispatcher.Invoke(() => { this.FinishedRepair_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Airplane> Airplane_list
        {
            get
            {
                return (ObservableCollection<Airplane>)GetValue(Airplane_listProperty);
            }
            set
            {
                SetValue(Airplane_listProperty, value);
                Dispatcher.Invoke(() => { this.Airplane_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Flight_log> FlightLog_list
        {
            get
            {
                return (ObservableCollection<Flight_log>)GetValue(FlightLog_listProperty);
            }
            set
            {
                SetValue(FlightLog_listProperty, value);
                Dispatcher.Invoke(() => { this.FlightLog_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Person> Person_list
        {
            get
            {
                return (ObservableCollection<Person>)GetValue(Person_listProperty);
            }
            set
            {
                SetValue(Person_listProperty, value);
                Dispatcher.Invoke(() => { this.Person_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Study_group> StudyGroup_list
        {
            get
            {
                return (ObservableCollection<Study_group>)GetValue(StudyGroup_listProperty);
            }
            set
            {
                SetValue(StudyGroup_listProperty, value);
                Dispatcher.Invoke(() => { this.StudyGroup_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Permission_group> Permission_group_list
        {
            get
            {
                return (ObservableCollection<Permission_group>)GetValue(Permission_group_listProperty);
            }
            set
            {
                SetValue(Permission_group_listProperty, value);
                Dispatcher.Invoke(() => { this.Permission_group_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Engine> Engine_list
        {
            get
            {
                return (ObservableCollection<Engine>)GetValue(Engine_listProperty);
            }
            set
            {
                SetValue(Engine_listProperty, value);
                Dispatcher.Invoke(() => { this.Engine_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Engines_fuel_type> Engines_fuel_type_list
        {
            get
            {
                return (ObservableCollection<Engines_fuel_type>)GetValue(Engines_fuel_type_listProperty);
            }
            set
            {
                SetValue(Engines_fuel_type_listProperty, value);
                Dispatcher.Invoke(() => { this.Engines_fuel_type_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Fuel_type> Fuel_type_list
        {
            get
            {
                return (ObservableCollection<Fuel_type>)GetValue(Fuel_type_listProperty);
            }
            set
            {
                SetValue(Fuel_type_listProperty, value);
                Dispatcher.Invoke(() => { this.Fuel_type_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Cooling_system> Cooling_system_list
        {
            get
            {
                return (ObservableCollection<Cooling_system>)GetValue(Cooling_system_listProperty);
            }
            set
            {
                SetValue(Cooling_system_listProperty, value);
                Dispatcher.Invoke(() => { this.Cooling_system_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Repair_work> Repair_work_list
        {
            get
            {
                return (ObservableCollection<Repair_work>)GetValue(Repair_work_listProperty);
            }
            set
            {
                SetValue(Repair_work_listProperty, value);
                Dispatcher.Invoke(() => { this.Repair_work_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Repair_status> Repair_status_list
        {
            get
            {
                return (ObservableCollection<Repair_status>)GetValue(Repair_status_listProperty);
            }
            set
            {
                SetValue(Repair_status_listProperty, value);
                Dispatcher.Invoke(() => { this.Repair_status_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Repair_part> Repair_part_list
        {
            get
            {
                return (ObservableCollection<Repair_part>)GetValue(Repair_part_listProperty);
            }
            set
            {
                SetValue(Repair_part_listProperty, value);
                Dispatcher.Invoke(() => { this.Repair_part_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Engineer> Engineer_list
        {
            get
            {
                return (ObservableCollection<Engineer>)GetValue(Engineer_listProperty);
            }
            set
            {
                SetValue(Engineer_listProperty, value);
                Dispatcher.Invoke(() => { this.Engineer_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Pilot> Pilot_list
        {
            get
            {
                return (ObservableCollection<Pilot>)GetValue(Pilot_listProperty);
            }
            set
            {
                SetValue(Pilot_listProperty, value);
                Dispatcher.Invoke(() => { this.Pilot_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Student_pilot> StudentPilot_list
        {
            get
            {
                return (ObservableCollection<Student_pilot>)GetValue(StudentPilot_listProperty);
            }
            set
            {
                SetValue(StudentPilot_listProperty, value);
                Dispatcher.Invoke(() => { this.StudentPilot_listChangedEvent?.Invoke(); });
            }
        }
        public ObservableCollection<Instructor> Instructor_list
        {
            get
            {
                return (ObservableCollection<Instructor>)GetValue(Instructor_listProperty);
            }
            set
            {
                SetValue(Instructor_listProperty, value);
                Dispatcher.Invoke(() => { this.Instructor_listChangedEvent?.Invoke(); });
            }
        }
        #endregion

        #region LoadData
        public async Task LoadEngineList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetEngine_List();
                Dispatcher.Invoke(() => { this.Engine_list = result; });
            });
        }
        public async Task LoadRepairList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRepair_List();
                Dispatcher.Invoke(() => { this.Repair_list = result; });
            });
        }
        public async Task LoadRepairToAcceptList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRepairToAccept_List();
                Dispatcher.Invoke(() => { this.RepairToAccept_list = result; });
            });
        }
        public async Task LoadFinishedRepairList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetFinishedRepair_List();
                Dispatcher.Invoke(() => { this.FinishedRepair_list = result; });
            });
        }
        public async Task LoadPersonList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetPerson_List();
                Dispatcher.Invoke(() => { this.Person_list = result; });
            });
        }
        public async Task LoadFlightLogList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetFlightLog_List();
                Dispatcher.Invoke(() => { this.FlightLog_list = result; });
            });
        }
        public async Task LoadAirplaneList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetAirplane_List();
                Dispatcher.Invoke(() => { this.Airplane_list = result; });
            });
        }
        public async Task LoadPermissionGroupList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetPermissionGroup_List();
                Dispatcher.Invoke(() => { this.Permission_group_list = result; });
            });
        }
        public async Task LoadEnginesFuelTypeList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetEngineFuelType_List();
                Dispatcher.Invoke(() => { this.Engines_fuel_type_list = result; });
            });
        }
        public async Task LoadFuelTypeList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetFuelType_List();
                Dispatcher.Invoke(() => { this.Fuel_type_list = result; });
            });
        }
        public async Task LoadCoolingSystemList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetCoolingSystem_List();
                Dispatcher.Invoke(() => { this.Cooling_system_list = result; });
            });
        }
        public async Task LoadStudyGroupList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetStudyGroup_List();
                Dispatcher.Invoke(() => { this.StudyGroup_list = result; });
            });
        }
        public async Task LoadRepairWorkList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRepairWork_List();
                Dispatcher.Invoke(() => { this.Repair_work_list = result; });
            });
        }
        public async Task LoadRepairStatusList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRepairStatus_List();
                Dispatcher.Invoke(() => { this.Repair_status_list = result; });
            });
        }
        public async Task LoadRequiredRepairWorkList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRequiredRepairWork_List();
            });
        }
        public async Task LoadRequiredRepairPartList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRequiredRepairPart_List();
            });
        }
        public async Task LoadRepairPartList()
        {
            await Task.Run(() =>
            {
                var result = DataManager.GetRepairPart_List();
                Dispatcher.Invoke(() => { this.Repair_part_list = result; });
            });
        }
        public async Task LoadEngineerList()
        {
            await LoadPersonList();
            await Task.Run(() =>
            {
                var result = DataManager.GetEngineer_List();
                Dispatcher.Invoke(() => { this.Engineer_list = result; });
            });
        }
        public async Task LoadPilotList()
        {
            await LoadPersonList();
            await Task.Run(() =>
            {
                var result = DataManager.GetPilot_List();
                Dispatcher.Invoke(() => { this.Pilot_list = result; });
            });
        }
        public async Task LoadStudentPilotList()
        {
            await LoadPersonList();
            await LoadPilotList();
            await Task.Run(() =>
            {
                var result = DataManager.GetStudentPilot_List();
                Dispatcher.Invoke(() => { this.StudentPilot_list = result; });
            });
        }
        public async Task LoadInstructorList()
        {
            await LoadPersonList();
            await LoadPilotList();
            await Task.Run(() =>
            {
                var result = DataManager.GetInstructor_List();
                Dispatcher.Invoke(() => { this.Instructor_list = result; });
            });
        }
        #endregion

        #region Commands
        public ICommand EngineListPage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new EngineListPage(this) { DataContext = this }, sender);
        });
        public ICommand ManualListPage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new ManualListPage(this) { DataContext = this }, sender);
        });
        public ICommand WelcomePage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new WelcomePage() { DataContext = this }, sender);
        });
        public ICommand PrintPerson => new MenuNavigateCommand((sender) =>
        {
            Person_list.PrintData(sender as Button);
        });
        public ICommand PrintRepairInfo => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Repair_list repair)
                {
                    repair.PrintData(sender as Button);
                }
            }
        });
        public ICommand PrintStudentPilot => new MenuNavigateCommand((sender) =>
        {
            StudentPilot_list.PrintData(sender as Button);
        });
        public ICommand PersonListPage_Open => new MenuNavigateCommand((sender) =>
        {
            var newPage = new PersonListPage(this) { DataContext = this };
            SetPage(newPage, sender);
        });
        public ICommand StudentPilotListPage_Open => new MenuNavigateCommand((sender) =>
        {
            var newPage = new StudentPilotListPage(this) { DataContext = this };
            SetPage(newPage, sender);
        });
        public ICommand InstructorListPage_Open => new MenuNavigateCommand((sender) =>
        {
            var newPage = new InstructorListPage(this) { DataContext = this };
            SetPage(newPage, sender);
        });
        public ICommand EngineerListPage_Open => new MenuNavigateCommand((sender) =>
        {
            var newPage = new EngineerListPage(this) { DataContext = this };
            SetPage(newPage, sender);
        });
        public ICommand RepairToAcceptListPage_Open => new MenuNavigateCommand((sender) =>
        {
            var newPage = new RepairAcceptList(this) { DataContext = this };
            SetPage(newPage, sender);
        });
        public ICommand EditEngine_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Engine engine)
                {
                    var window = new EditEngine(this) { DataContext = engine };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadEngineList();
                    }

                }
            }
        });
        public ICommand RemoveEngine => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Engine engine)
                {
                    DataManager.RemoveEngine(engine);
                    DataManager.SaveChanges();
                    _ = LoadEngineList();
                }
            }
        });
        public ICommand EditRepairWorkList_Open => new MenuNavigateCommand((sender) =>
        {
            _ = LoadRepairWorkList();
            var window = new SimpleItemsList(this, this.Repair_work_list) { DataContext = this.Repair_work_list };
            window.ShowDialog();
        });
        public ICommand EditRepairPartList_Open => new MenuNavigateCommand((sender) =>
        {
            _ = LoadRepairPartList();
            var window = new SimpleItemsList(this, this.Repair_part_list) { DataContext = this.Repair_part_list };
            window.ShowDialog();
        });
        public ICommand EditStudyGroupList_Open => new MenuNavigateCommand((sender) =>
        {
            _ = LoadStudyGroupList();
            var window = new SimpleItemsList(this, this.StudyGroup_list) { DataContext = this.StudyGroup_list };
            window.ShowDialog();
        });
        public ICommand EditCoolingSystemList_Open => new MenuNavigateCommand((sender) =>
        {
            _ = LoadCoolingSystemList();
            var window = new SimpleItemsList(this, this.Cooling_system_list) { DataContext = this.Cooling_system_list };
            window.ShowDialog();
        });
        public ICommand EditSimpleItem => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Repair_part repair_Part)
                {
                    var window = new EditRepairPart(this) { DataContext = repair_Part };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadRepairPartList();
                    }
                }
                if (element.DataContext is Repair_work repair_Work)
                {
                    var window = new SimpleEditWindow(this) { DataContext = repair_Work };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadRepairWorkList();
                    }
                }
                if (element.DataContext is Study_group study_Group)
                {
                    var window = new SimpleEditWindow(this) { DataContext = study_Group };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadStudyGroupList();
                    }
                }
                if (element.DataContext is Cooling_system cooling_System)
                {
                    var window = new SimpleEditWindow(this) { DataContext = cooling_System };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadCoolingSystemList();
                    }
                }
            }
        });
        public ICommand RemoveSimpleItem => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Repair_part repair_Part)
                {
                    DataManager.RemoveRepairPart(repair_Part);
                        _ = LoadRepairPartList();
                }
                if (element.DataContext is Repair_work repair_Work)
                {
                    var window = new SimpleEditWindow(this) { DataContext = repair_Work };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.RemoveRepairWork(repair_Work);
                        _ = LoadRepairWorkList();
                    }
                }
                if (element.DataContext is Study_group study_Group)
                {
                    DataManager.RemoveStudyGroup(study_Group);
                        _ = LoadStudyGroupList();
                }
                if (element.DataContext is Cooling_system cooling_System)
                {
                    DataManager.RemoveCoolingSystem(cooling_System);
                }
            }
        });
        public ICommand EditPerson_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Person person)
                {
                    var window = new EditPerson(this) { DataContext = person };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadPersonList();
                    }

                }
            }
        });
        public ICommand RemovePerson => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Person person)
                {
                    DataManager.RemovePerson(person);
                    DataManager.SaveChanges();
                    _ = LoadPersonList();
                }
            }
        });
        public ICommand AddCoolingSystem_Show => new MenuNavigateCommand((sender) =>
        {
            var newCoolingSystem = new Cooling_system();
            var window = new SimpleEditWindow(this) { DataContext = newCoolingSystem };
            var result = window.ShowDialog();
            if (result == true)
            {
                DataManager.AddCoolingSystem(newCoolingSystem);
                _ = LoadCoolingSystemList();
            }

        });
        public ICommand AddPerson_Show => new MenuNavigateCommand((sender) =>
        {
            var newPerson = new Person();
            var window = new EditPerson(this) { DataContext = newPerson };
            var result = window.ShowDialog();
            if (result == true)
            {
                newPerson.permission_group = 1;
                DataManager.AddPerson(newPerson);
                _ = LoadPersonList();
            }
        });

        public ICommand AddStudentPilot_Show => new MenuNavigateCommand((sender) =>
        {
            var newPerson = new Person();
            var newPilot = new Pilot();
            newPilot.Person = newPerson;

            var newStudentPilot = new Student_pilot();
            newStudentPilot.Pilot = newPilot;
            var window = new EditStudentPilot(this) { DataContext = newStudentPilot };
            var result = window.ShowDialog();
            if (result == true)
            {
                newPerson.permission_group = 4;
                DataManager.AddStudentPilot(newStudentPilot);
                _ = LoadStudentPilotList();
            }
        });
        public ICommand EditStudentPilot_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Student_pilot student_Pilot)
                {
                    var window = new EditStudentPilot(this) { DataContext = student_Pilot };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadStudentPilotList();
                    }
                }
            }

        });
        public ICommand RemoveStudentPilot => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Student_pilot student_Pilot)
                {
                    DataManager.RemoveStudentPilot(student_Pilot);
                    DataManager.SaveChanges();
                    _ = LoadStudentPilotList();
                }
            }

        });
        public ICommand AddEngineer_Show => new MenuNavigateCommand((sender) =>
        {
            var newPerson = new Person();
            var newEngineer = new Engineer();
            newEngineer.Person = newPerson;

            var window = new EditEngineer(this) { DataContext = newEngineer };
            var result = window.ShowDialog();
            if (result == true)
            {
                newPerson.permission_group = 2;
                DataManager.AddEngineer(newEngineer);
                _ = LoadEngineerList();
            }
        });
        public ICommand EditEngineer_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Engineer engineer)
                {
                    var window = new EditEngineer(this) { DataContext = engineer };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadEngineerList();
                    }
                }
            }
        });
        public ICommand RemoveEngineer => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Engineer engineer)
                {
                    DataManager.RemoveEngineer(engineer);
                    DataManager.SaveChanges();
                    _ = LoadEngineerList();
                }
            }
        });

        public ICommand EditInstructor_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Instructor instructor)
                {
                    var window = new EditInstructor(this) { DataContext = instructor };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadInstructorList();
                        _ = LoadPersonList();
                    }
                }
            }
        });
        public ICommand RemoveInstructor => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Instructor instructor)
                {
                    DataManager.RemoveInstructor(instructor);
                    DataManager.SaveChanges();
                    _ = LoadInstructorList();
                    _ = LoadPersonList();
                }
            }
        });
        public ICommand AddInstuctor_Show => new MenuNavigateCommand((sender) =>
        {
            var newPerson = new Person();
            var newPilot = new Pilot();
            var newInstructor = new Instructor();
            newPilot.Person = newPerson;
            newInstructor.Pilot = newPilot;

            var window = new EditInstructor(this) { DataContext = newInstructor };
            var result = window.ShowDialog();
            if (result == true)
            {
                newPerson.permission_group = 10002;
                DataManager.AddInstructor(newInstructor);
                _ = LoadInstructorList();
                _ = LoadPersonList();
            }
        });
        public ICommand AddEngine_Show => new MenuNavigateCommand((sender) =>
        {
            var newEngine = new Engine();
            var window = new EditEngine(this) { DataContext = newEngine };
            var result = window.ShowDialog();
            if (result == true)
            {
                DataManager.AddEngine(newEngine);
                _ = LoadEngineList();
            }
        });
        public ICommand AddRepairWork_Show => new MenuNavigateCommand((sender) =>
        {
            var newWork = new Repair_work();
            var window = new SimpleEditWindow(this) { DataContext = newWork };
            var result = window.ShowDialog();
            if (result == true)
            {
                DataManager.AddRepairWork(newWork);
                _ = LoadRepairWorkList();
            }
        });
        public ICommand AddStudyGroup_Show => new MenuNavigateCommand((sender) =>
        {
            var newGroup = new Study_group();
            var window = new SimpleEditWindow(this) { DataContext = newGroup };
            var result = window.ShowDialog();
            if (result == true)
            {
                DataManager.AddStudyGroup(newGroup);
                _ = LoadStudyGroupList();
            }
        });
        public ICommand AddRepairStatus_Show => new MenuNavigateCommand((sender) =>
        {
            var newStatus = new Repair_status();
            var window = new SimpleEditWindow(this) { DataContext = newStatus };
            var result = window.ShowDialog();
            if (result == true)
            {
                DataManager.AddRepairStatus(newStatus);
                _ = LoadRepairStatusList();
            }
        });
        public ICommand AddRepairPart_Show => new MenuNavigateCommand((sender) =>
        {
            var newPart = new Repair_part();
            var window = new EditRepairPart(this) { DataContext = newPart };
            var result = window.ShowDialog();
            if (result == true)
            {
                DataManager.AddRepairPart(newPart);
                _ = LoadRepairPartList();
            }
        });
        public ICommand AddRepairListItem_Show => new MenuNavigateCommand((sender) =>
        {
            var newRepairList = new Repair_list();
            var window = new EditRepairList(this) { DataContext = newRepairList };
            var result = window.ShowDialog();
            if (result == true)
            {
                if (newRepairList.Required_repair_work.Count == 0)
                {
                    ShowError("Количество работ должно быть больше 0");
                    return;
                }
                newRepairList.start_repair_date = DateTime.Now;
                DataManager.AddRepairList(newRepairList);
                _ = LoadRepairList();
            }
        });
        public ICommand AddRequredRepairWork_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Repair_list repair_List)
                {
                    var newRequiredWork = new Required_repair_work() { count = 1 };
                    var window = new EditRequiredRepairWorkList(this) { DataContext = newRequiredWork };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        newRequiredWork.Repair_list = repair_List;
                        repair_List.Required_repair_work.Add(newRequiredWork);
                        var find = DataManager.Connection.Repair_work.Find(newRequiredWork.repair_work_id);
                        if (find != null)
                        {
                            newRequiredWork.Repair_work = find;
                        }
                    }
                }
            }
        });
        public ICommand RemoveRequredRepairWork => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Required_repair_work repair_Work)
                {
                    repair_Work.Repair_list.Required_repair_work.Remove(repair_Work);
                }
            }
        });
        public ICommand RemoveRequredRepairPart => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Required_repair_part repair_Part)
                {
                    repair_Part.Required_repair_work.Required_repair_part.Remove(repair_Part);
                }
            }
        });
        public ICommand ConfirmRequredRepairWork_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Repair_list repair_List)
                {
                    var window = new ConfirmRequiredRepairList(this) { DataContext = repair_List };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        DataManager.SaveChanges();
                        _ = LoadRepairList();
                    }
                }
            }
        });
        public ICommand ConfirmRequredRepairWork => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Required_repair_work required_Repair_Work)
                {
                    var successStatusCode = 2;
                    required_Repair_Work.status_id = successStatusCode;
                    required_Repair_Work.end_date = DateTime.Now;
                    if (required_Repair_Work.Repair_list.Required_repair_work.Count((work) => work.status_id == successStatusCode) == required_Repair_Work.Repair_list.Required_repair_work.Count)
                    {
                        required_Repair_Work.Repair_list.end_repair_date = DateTime.Now;
                    }
                    DataManager.SaveChanges();
                    _ = LoadRepairList();
                }
            }
        });
        public ICommand AddRequredRepairPart_Show => new MenuNavigateCommand((sender) =>
        {
            if (sender is FrameworkElement element)
            {
                if (element.DataContext is Required_repair_work required_Repair_Work)
                {
                    var newRequiredPart = new Required_repair_part() { count = 1};
                    var window = new EditRequiredRepairPartList(this) { DataContext = newRequiredPart };
                    var result = window.ShowDialog();
                    if (result == true)
                    {
                        var find = DataManager.Connection.Repair_part.Find(newRequiredPart.repair_part_id);
                        if (find != null)
                        {
                            newRequiredPart.Repair_part = find;
                        }

                        if (required_Repair_Work.Required_repair_part.FirstOrDefault((part) => part.repair_part_id == find.id) == default(Required_repair_part))
                        {
                            newRequiredPart.Required_repair_work = required_Repair_Work;
                            required_Repair_Work.Required_repair_part.Add(newRequiredPart);
                        }
                        else
                        {
                            ShowError("Данный товар уже присутствует");
                        }
                        
                    }
                }
            }
        });
        public ICommand RepairHistoryPage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new RepairHistoryPage(this), sender);
        });
        public ICommand FlightHistoryPage_Open => new MenuNavigateCommand((sender) =>
        {
            SetPage(new FlightHistoryPage(this), sender);
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
        public static DependencyProperty Repair_listProperty = DependencyProperty.Register("Repair_list", typeof(ObservableCollection<Repair_list>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Repair_list>()));
        public static DependencyProperty RepairToAccept_listProperty = DependencyProperty.Register("RepairToAccept_list", typeof(ObservableCollection<Repair_list>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Repair_list>()));
        public static DependencyProperty FinishedRepair_listProperty = DependencyProperty.Register("FinishedRepair_list", typeof(ObservableCollection<Repair_list>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Repair_list>()));
        public static DependencyProperty Person_listProperty = DependencyProperty.Register("Person_list", typeof(ObservableCollection<Person>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Person>()));
        public static DependencyProperty Engine_listProperty = DependencyProperty.Register("Engine_list", typeof(ObservableCollection<Engine>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Engine>()));
        public static DependencyProperty Permission_group_listProperty = DependencyProperty.Register("Permission_group_list", typeof(ObservableCollection<Permission_group>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Permission_group>()));
        public static DependencyProperty Engines_fuel_type_listProperty = DependencyProperty.Register("Engines_fuel_type_list", typeof(ObservableCollection<Engines_fuel_type>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Engines_fuel_type>()));
        public static DependencyProperty Fuel_type_listProperty = DependencyProperty.Register("Fuel_type_list", typeof(ObservableCollection<Fuel_type>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Fuel_type>()));
        public static DependencyProperty Cooling_system_listProperty = DependencyProperty.Register("Cooling_system_list", typeof(ObservableCollection<Cooling_system>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Cooling_system>()));
        public static DependencyProperty FlightLog_listProperty = DependencyProperty.Register("FlightLog_list", typeof(ObservableCollection<Flight_log>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Flight_log>()));
        public static DependencyProperty Airplane_listProperty = DependencyProperty.Register("Airplane_list", typeof(ObservableCollection<Airplane>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Airplane>()));
        public static DependencyProperty Repair_work_listProperty = DependencyProperty.Register("Repair_work_list", typeof(ObservableCollection<Repair_work>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Repair_work>()));
        public static DependencyProperty Repair_status_listProperty = DependencyProperty.Register("Repair_status_list", typeof(ObservableCollection<Repair_status>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Repair_status>()));
        public static DependencyProperty Repair_part_listProperty = DependencyProperty.Register("Repair_part_list", typeof(ObservableCollection<Repair_part>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Repair_part>()));
        public static DependencyProperty Engineer_listProperty = DependencyProperty.Register("Engineer_list", typeof(ObservableCollection<Engineer>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Engineer>()));
        public static DependencyProperty Pilot_listProperty = DependencyProperty.Register("Pilot_list", typeof(ObservableCollection<Pilot>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Pilot>()));
        public static DependencyProperty StudentPilot_listProperty = DependencyProperty.Register("StudentPilot_list", typeof(ObservableCollection<Student_pilot>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Student_pilot>()));
        public static DependencyProperty Instructor_listProperty = DependencyProperty.Register("Instructor_list", typeof(ObservableCollection<Instructor>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Instructor>()));
        public static DependencyProperty StudyGroup_listProperty = DependencyProperty.Register("StudyGroup_list", typeof(ObservableCollection<Study_group>), typeof(BaseViewModel), new PropertyMetadata(new ObservableCollection<Study_group>()));
        #endregion

        #region Events
        public event Action Repair_listChangedEvent;
        public event Action FinishedRepair_listChangedEvent;
        public event Action RepairToAccept_listChangedEvent;
        public event Action Person_listChangedEvent;
        public event Action Engine_listChangedEvent;
        public event Action Permission_group_listChangedEvent;
        public event Action Engines_fuel_type_listChangedEvent;
        public event Action Fuel_type_listChangedEvent;
        public event Action Cooling_system_listChangedEvent;
        public event Action FlightLog_listChangedEvent;
        public event Action Airplane_listChangedEvent;
        public event Action Repair_work_listChangedEvent;
        public event Action Repair_status_listChangedEvent;
        public event Action Repair_part_listChangedEvent;
        public event Action Engineer_listChangedEvent;
        public event Action Pilot_listChangedEvent;
        public event Action StudentPilot_listChangedEvent;
        public event Action Instructor_listChangedEvent;
        public event Action StudyGroup_listChangedEvent;
        #endregion
        public void ShowError(string message, string title = "Ошибка")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
