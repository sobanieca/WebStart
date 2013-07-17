using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebStart
{
    /// <summary>
    /// Abstract class for WebStart bootstrapper config task
    /// </summary>
    public abstract class Config
    {
        /// <summary>
        /// Priority of particular config
        /// </summary>
        public virtual EPriority Priority { get { return EPriority.Normal; } }

        /// <summary>
        /// Performs config task in order to set up application (code being run once per application domain)
        /// </summary>
        public abstract void Setup();

        /// <summary>
        /// Allows to attach event handlers for an HttpApplication (code being run once per HttpApplication instance)
        /// </summary>
        /// <param name="context"></param>
        public virtual void AttachEventHandlers(HttpApplication context) { return; }

        /// <summary>
        /// Performs config task when applicaiton is being shutdown
        /// </summary>
        public virtual void Shutdown() { return; }
    }
}
