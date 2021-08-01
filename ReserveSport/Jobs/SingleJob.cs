using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace ReserveSport.Jobs
{
    public class SingleJob : IJobFactory
    {
        private readonly IServiceProvider _service;

        public SingleJob(IServiceProvider service)
        {
            _service = service;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _service.GetRequiredService(bundle.JobDetail.JobType) as IJob;  
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
