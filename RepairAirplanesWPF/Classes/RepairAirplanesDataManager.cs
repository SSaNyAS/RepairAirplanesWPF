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
        private DBLoader<Airplane> AirplaneDataLoader;
        private DBLoader<Engine> EngineDataLoader;
        private DBLoader<Engines_fuel_type> EngineFuelTypeDataLoader;
        private DBLoader<Fuel_type> FuelTypeDataLoader;
        private DBLoader<Person> PersonDataLoader;
        private DBLoader<Repair_status> RepairStatusDataLoader;
        private DBLoader<Repair_work> RepairWorkDataLoader;
        private DBLoader<Repair_part> RepairPartDataLoader;
        private DBLoader<Required_repair_part> RequiredRepairPartDataLoader;
        private DBLoader<Required_repair_work> RequiredRepairWorkDataLoader;
        private DBLoader<Permission> PermissionDataLoader;
        private DBLoader<Permission_group> PermissionGroupDataLoader;
        private DBLoader<Authorization> AuthorizationDataLoader;

        public RepairAirplanesDataManager(Repair_airplanesConnection connection)
        {
            this.Connection = connection;
            AirplaneDataLoader = new DBLoader<Airplane>(connection);
            EngineDataLoader = new DBLoader<Engine>(connection);
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
        }
        public ObservableCollection<Airplane> GetAirplane_List()
        {
            return AirplaneDataLoader.GetList();
        }
        public ObservableCollection<Engine> GetEngine_List()
        {
            return EngineDataLoader.GetList();
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
    }
}
