using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DBManager
{
    public class TryConnectionTimer: Timer
    {
        public DbConnection Connection { get; private set; }
        public double TryConnectionInterval
        {
            get
            {
                return this.Interval;
            }
            set
            {
                this.Interval = Interval;
            }
        }
        public int MaxTryConnectionCount { get; set; } = 10;
        private int currentTryConnectionCount = 0;
        private bool IsConnected
        {
            get
            {
                var isConnected = this.Connection.State == System.Data.ConnectionState.Open;
                if (!isConnected)
                {
                    if (currentTryConnectionCount < MaxTryConnectionCount)
                    {
                        if (!this.Enabled)
                        {
                            this.Start();
                        }
                    }
                }
                return isConnected;
            }
        }

        public TryConnectionTimer(DbConnection Connection)
        {
            this.Connection = Connection;
            this.Interval = TryConnectionInterval;
            this.Elapsed += TryConnectionTimer_TryNow;
        }
        private void TryConnectionTimer_TryNow(object sender, ElapsedEventArgs e)
        {
                if (!IsConnected && currentTryConnectionCount < MaxTryConnectionCount)
                {
                    currentTryConnectionCount++;
                    try
                    {
                        this.Connection.Open();
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    this.Stop();
                    if (!IsConnected)
                    {
                        ConnectionTimeoutEvent?.Invoke();
                    }
                    this.currentTryConnectionCount = 0;
                }
        }
        public event Action ConnectionTimeoutEvent;
    }
}
