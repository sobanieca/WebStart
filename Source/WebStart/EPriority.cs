using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStart
{
    /// <summary>
    /// Priority for bootstrapper config tasks - determines the order in which they will be run
    /// </summary>
    public enum EPriority
    {
        /// <summary>
        /// Very low
        /// </summary>
        VeryLow,
        /// <summary>
        /// Low
        /// </summary>
        Low,
        /// <summary>
        /// Normal
        /// </summary>
        Normal,
        /// <summary>
        /// High
        /// </summary>
        High,
        /// <summary>
        /// Very high
        /// </summary>
        VeryHigh
    }
}
