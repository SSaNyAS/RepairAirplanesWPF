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
        public DBLoader(DbContext context) { this.context = context; this.TryConnectionTimer = new TryConnectionTimer(this.context.Database.Connection);  }
        public DbContext context { get; private set; }
        public double TryConnectionInterval { get; set; } = 5000;
        public int MaxTryConnectionCount { get; set; } = 10;
        private int CurrentTryConnectionCount { get; set; } = 0;
        private TryConnectionTimer TryConnectionTimer;
        public bool IsConnected {
            get
            {
                var isConnected = this.context.Database.Connection.State == System.Data.ConnectionState.Open;
                if (!isConnected)
                {
                    TryConnectionTimer.Start();
                } else
                {
                    TryConnectionTimer.Stop();
                }
                return isConnected;
            }
        }

        public virtual ObservableCollection<T> GetList()
        {
            if (IsConnected)
            {
                var dbSet = context.Set<T>();
                dbSet.Load();
                return dbSet.Local;
            }
            return new ObservableCollection<T>();
        }
        public virtual ObservableCollection<T> GetListWhere(Expression<Func<T,bool>> filter, bool reversed = false)
        {
            if (IsConnected)
            {
                var dbSet = context.Set<T>();

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
                var dbSet = context.Set<T>();
                try
                {
                    dbSet.AddOrUpdate(item);
                    context.SaveChanges();
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
                var dbSet = context.Set<T>();
                try
                {
                    dbSet.Remove(item);
                    context.SaveChanges();
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
                var dbSet = context.Set<T>();
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
                var dbSet = context.Set<T>();
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
                var dbSet = context.Set<T>();
                try
                {
                    dbSet.AddOrUpdate(item);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }
        public event Action ConnectionErrorEvent;
    }
}
