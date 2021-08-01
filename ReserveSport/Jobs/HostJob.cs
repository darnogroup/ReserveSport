using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSport.Jobs
{
    public class HostJob
    {
        public Type JobType { set; get; }
        public string CronExpression { set; get; }

        public HostJob(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }
    }
}
