using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBManager;
namespace RepairAirplanesWPF.Classes
{
    public class RepairAirplanesDataManager
    {
        private Repair_airplanesConnection Connection;
        #region DataLoaders
        private DBLoader<Airplane> AirplaneDataLoader;
        private DBLoader<Engine> EngineDataLoader;
        private DBLoader<Engines_fuel_type> EngineFuelTypeDataLoader;
        private DBLoader<Fuel_type> FuelTypeDataLoader;
        private DBLoader<Person> PersonDataLoader;
        private DBLoader<Engineer> EngineerDataLoader;
        private DBLoader<Pilot> PilotDataLoader;
        private DBLoader<Student_pilot> StudentPilotDataLoader;
        private DBLoader<Instructor> InstructorDataLoader;
        private DBLoader<Repair_status> RepairStatusDataLoader;
        private DBLoader<Repair_work> RepairWorkDataLoader;
        private DBLoader<Repair_part> RepairPartDataLoader;
        private DBLoader<Required_repair_part> RequiredRepairPartDataLoader;
        private DBLoader<Required_repair_work> RequiredRepairWorkDataLoader;
        private DBLoader<Permission> PermissionDataLoader;
        private DBLoader<Permission_group> PermissionGroupDataLoader;
        private DBLoader<Authorization> AuthorizationDataLoader;
        private DBLoader<Cooling_system> CoolingSystemDataLoader;
        private DBLoader<Repair_list> RepairListDataLoader;
        private DBLoader<Flight_log> FlightLogListDataLoader;
        private DBLoader<Study_group> StudyGroupListDataLoader;
        #endregion


        public RepairAirplanesDataManager(Repair_airplanesConnection connection)
        {
            this.Connection = connection;
            AirplaneDataLoader = new DBLoader<Airplane>(connection);
            EngineDataLoader = new DBLoader<Engine>(connection);
            RepairListDataLoader = new DBLoader<Repair_list>(connection);
            FlightLogListDataLoader = new DBLoader<Flight_log>(connection);
            EngineFuelTypeDataLoader = new DBLoader<Engines_fuel_type>(connection);
            FuelTypeDataLoader = new DBLoader<Fuel_type>(connection);
            PersonDataLoader = new DBLoader<Person>(connection);
            RepairStatusDataLoader = new DBLoader<Repair_status>(connection);
            RepairWorkDataLoader = new DBLoader<Repair_work>(connection);
            RepairPartDataLoader = new DBLoader<Repair_part>(connection);
            RequiredRepairPartDataLoader = new DBLoader<Required_repair_part>(connection);
            RequiredRepairWorkDataLoader = new DBLoader<Required_repair_work>(connection);
            PermissionDataLoader = new DBLoader<Permission>(connection);
            PermissionGroupDataLoader = new DBLoader<Permission_group>(connection);
            AuthorizationDataLoader = new DBLoader<Authorization>(connection);
            CoolingSystemDataLoader = new DBLoader<Cooling_system>(connection);
            EngineerDataLoader = new DBLoader<Engineer>(connection);
            PilotDataLoader = new DBLoader<Pilot>(connection);
            StudentPilotDataLoader = new DBLoader<Student_pilot>(connection);
            InstructorDataLoader = new DBLoader<Instructor>(connection);
            StudyGroupListDataLoader = new DBLoader<Study_group>(connection);
            TryOpenConnection();
        }

        #region SaveMethods
        public void SaveChanges(Action<Exception> errorAction = null)
        {
            try
            {
                Connection.SaveChanges();
            }
            catch (Exception error)
            {
                errorAction?.Invoke(error);
            }
        }
        #endregion
        #region GetDataList
        public ObservableCollection<Airplane> GetAirplane_List()
        {
            return AirplaneDataLoader.GetList();
        }
        public ObservableCollection<Repair_list> GetRepair_List()
        {
            return RepairListDataLoader.GetList();
        }
        public ObservableCollection<Engine> GetEngine_List()
        {
            return EngineDataLoader.GetList();
        }
        public ObservableCollection<Flight_log> GetFlightLog_List()
        {
            return FlightLogListDataLoader.GetList();
        }
        public ObservableCollection<Engines_fuel_type> GetEngineFuelType_List()
        {
            return EngineFuelTypeDataLoader.GetList();
        }
        public ObservableCollection<Fuel_type> GetFuelType_List()
        {
            return FuelTypeDataLoader.GetList();
        }
        public ObservableCollection<Person> GetPerson_List()
        {
            return PersonDataLoader.GetList();
        }
        public ObservableCollection<Repair_status> GetRepairStatus_List()
        {
            return RepairStatusDataLoader.GetList();
        }
        public ObservableCollection<Repair_work> GetRepairWork_List()
        {
            return RepairWorkDataLoader.GetList();
        }
        public ObservableCollection<Repair_part> GetRepairPart_List()
        {
            return RepairPartDataLoader.GetList();
        }
        public ObservableCollection<Required_repair_part> GetRequiredRepairPart_List()
        {
            return RequiredRepairPartDataLoader.GetList();
        }
        public ObservableCollection<Required_repair_work> GetRequiredRepairWork_List()
        {
            return RequiredRepairWorkDataLoader.GetList();
        }
        public ObservableCollection<Permission> GetPermission_List()
        {
            return PermissionDataLoader.GetList();
        }
        public ObservableCollection<Permission_group> GetPermissionGroup_List()
        {
            return PermissionGroupDataLoader.GetList();
        }
        public ObservableCollection<Authorization> GetAuthorization_List()
        {
            return AuthorizationDataLoader.GetList();
        }
        public ObservableCollection<Cooling_system> GetCoolingSystem_List()
        {
            return CoolingSystemDataLoader.GetList();
        }
        public ObservableCollection<Engineer> GetEngineer_List()
        {
            return EngineerDataLoader.GetList();
        }
        public ObservableCollection<Pilot> GetPilot_List()
        {
            return PilotDataLoader.GetList();
        }
        public ObservableCollection<Student_pilot> GetStudentPilot_List()
        {
            return StudentPilotDataLoader.GetList();
        }
        public ObservableCollection<Instructor> GetInstructor_List()
        {
            return InstructorDataLoader.GetList();
        }
        public ObservableCollection<Study_group> GetStudyGroup_List()
        {
            return StudyGroupListDataLoader.GetList();
        }
        #endregion

        #region AddItems
        public void AddAirplane(Airplane airplane)
        {
            AirplaneDataLoader.AddItem(airplane);
        }
        public void AddEngine(Engine engine)
        {
            EngineDataLoader.AddItem(engine);
        }
        public void AddPerson(Person person)
        {
            PersonDataLoader.AddItem(person);
        }
        public void AddEngineer(Engineer engineer)
        {
            EngineerDataLoader.AddItem(engineer);
        }
        public void AddRepairWork(Repair_work repair_Work)
        {
            RepairWorkDataLoader.AddItem(repair_Work);
        }
        public void AddRepairPart(Repair_part repair_Part)
        {
            RepairPartDataLoader.AddItem(repair_Part);
        }
        public void AddCoolingSystem(Cooling_system cooling_System)
        {
            CoolingSystemDataLoader.AddItem(cooling_System);
        }
        public void AddPermissionGroup(Permission_group permission_Group)
        {
            PermissionGroupDataLoader.AddItem(permission_Group);
        }
        public void AddAuthorization(Authorization authorization)
        {
            AuthorizationDataLoader.AddItem(authorization);
        }
        public void AddRequiredRepairPart(Required_repair_part required_Repair_Part)
        {
            RequiredRepairPartDataLoader.AddItem(required_Repair_Part);
        }
        public void AddRequiredRepairWork(Required_repair_work required_Repair_Work)
        {
            RequiredRepairWorkDataLoader.AddItem(required_Repair_Work);
        }
        public void AddRepairStatus(Repair_status repair_Status)
        {
            RepairStatusDataLoader.AddItem(repair_Status);
        }
        public void AddEngineFuelType(Engines_fuel_type engines_Fuel_Type)
        {
            EngineFuelTypeDataLoader.AddItem(engines_Fuel_Type);
        }
        public void AddRepairList(Repair_list repair_List)
        {
            RepairListDataLoader.AddItem(repair_List);
        }
        public void AddStudentPilot(Student_pilot student_Pilot)
        {
            StudentPilotDataLoader.AddItem(student_Pilot);
        }
        public void AddPilot(Pilot pilot)
        {
            PilotDataLoader.AddItem(pilot);
        }
        public void AddInstructor(Instructor instructor)
        {
            InstructorDataLoader.AddItem(instructor);
        }
        public void AddStudyGroup(Study_group group)
        {
            StudyGroupListDataLoader.AddItem(group);
        }
        #endregion

        #region OtherFunctions
        public void TryOpenConnection()
        {
            if (this.Connection.Database.Connection.State != System.Data.ConnectionState.Open && this.Connection.Database.Connection.State != System.Data.ConnectionState.Connecting)
            {
                try
                {
                    this.Connection.Database.Connection.Open();
                }
                catch (Exception)
                {

                }
            }
        }
        #endregion
    }
}
