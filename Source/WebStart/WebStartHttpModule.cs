using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace WebStart
{
    /// <summary>
    /// Http module that handles bootstrap config tasks
    /// </summary>
    public class WebStartHttpModule : IHttpModule
    {
        private object _locker = new object();
        private static int _startExecutionCount = 0;
        private static int _shutdownExecutionCount = 0;
        private static List<Config> _configTasks;

        /// <summary>
        /// Setting up configuration tasks
        /// </summary>
        public static List<Config> ConfigTasks
        {
            set
            {
                _configTasks = value;
                _configTasks.Sort(ConfigComparison);
            }
        }

        /// <summary>
        /// Runs all bootstrap config tasks
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            //Performing main config tasks
            lock (_locker)
            {
                if (_startExecutionCount++ == 0)
                {
                    foreach (Config configTask in _configTasks)
                    {
                        Debug.WriteLine("Executing bootstrap config task. Method: Setup(). Priority: {0}. Name: {1}", configTask.Priority, configTask.GetType().Name);
                        configTask.Setup();
                    }
                }
            }
            foreach (Config configTask in _configTasks)
            {
                Debug.WriteLine("Executing bootstrap config task. Method: AttachEventHandlers(). Priority: {0}. Name: {1}", configTask.Priority, configTask.GetType().Name);
                configTask.AttachEventHandlers(context);
            }
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            lock (_locker)
            {
                if (_shutdownExecutionCount++ == 0)
                {
                    foreach (Config configTask in _configTasks)
                    {
                        Debug.WriteLine("Executing bootstrap config task. Method: Shutdown(). Priority: {0}. Name: {1}", configTask.Priority, configTask.GetType().Name);
                        configTask.Shutdown();
                    }
                }
            }
        }

        private static int ConfigComparison(Config a, Config b)
        {
            if (a.Priority > b.Priority)
                return -1;
            if (a.Priority < b.Priority)
                return 1;
            return 0;
        }

    }
}
