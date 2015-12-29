using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickassSeries.Ultilities
{
    internal class Initialize
    {
        public static void Init()
        {
            Trackers.RecallTracker.Initialize();
            Trackers.WardTracker.Initialize();
        }
    }
}
