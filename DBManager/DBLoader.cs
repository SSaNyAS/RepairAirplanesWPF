using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Timers;

namespace DBManager
{
    public class DBLoader<T> where T : class
    {
        public DBLoader(DbContext context) { this.Context = context; }
        public DbContext Context { get; private set; }
       // private TryConnectionTimer TryConnectionTimer;
        public bool IsConnected {
            get
            {
                var isConnected = this.Context.Database.Connection.State == System.Data.ConnectionState.Open;
                if (!isConnected)
                {
                    //TryConnectionTimer.Start();
                    TryOpenConnection();
                } else
                {
                    //TryConnectionTimer.Stop();
                }
                return isConnected;
            }
        }
        private void TryOpenConnection()
        {
            try
            {
                this.Context.Database.Connection.Open();
            }
            catch (Exception)
            {

            }
        }
        public virtual ObservableCollection<T> GetList()
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();
                dbSet.Load();
                return dbSet.Local;
            }
            return new ObservableCollection<T>();
        }
        public virtual ObservableCollection<T> GetListWhere(Expression<Func<T,bool>> filter, bool reversed = false)
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();

                if (reversed)
                    dbSet.Where(filter).Reverse().Load();
                else 
                    dbSet.Where(filter).Load();

                return dbSet.Local;
            }
            return new ObservableCollection<T>();
        }
        public virtual void AddItem(T item, Action<Exception> OnErrorAction = null)
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();
                try
                {
                    dbSet.AddOrUpdate(item);
                    Context.SaveChanges();
                }
                catch (Exception error)
                {
                    OnErrorAction?.Invoke(error);
                }
            }
        }
        public virtual void RemoveItem(T item, Action<Exception> OnErrorAction = null)
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();
                try
                {
                    dbSet.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception error)
                {
                    OnErrorAction?.Invoke(error);
                }
            }
        }
        public virtual T FindItem(params object[] keyValues)
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();
                try
                {
                    return dbSet.Find(keyValues);
                }
                catch (Exception)
                {

                }
            }
            return null;
        }
        public virtual T FindItem(Expression<Func<T,bool>> filter, Action<Exception> OnErrorAction = null)
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();
                try
                {
                    var result = dbSet.FirstOrDefault(filter);
                    if (result == default(T))
                        return null;
                    return result;
                }
                catch (Exception error)
                {
                    OnErrorAction?.Invoke(error);
                }
            }
            return null;
        }
        public virtual void UpdateItem(T item)
        {
            if (IsConnected)
            {
                var dbSet = Context.Set<T>();
                try
                {
                    dbSet.AddOrUpdate(item);
                    Context.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }
        public event Action ConnectionErrorEvent;
    }
}
