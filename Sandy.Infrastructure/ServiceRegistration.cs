using Microsoft.Extensions.DependencyInjection;
using Sandy.Application;
using Sandy.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandy.Infrastructure
{
    public static class ServiceRegistration 
    {
        public static void AddInfrastructureService(this IServiceCollection services) 
        {
            services.AddTransient<IRecruiterProfileRepository, RecruiterProfileRepository>();
            services.AddTransient<ICompanyProfileRepository, CompanyProfileRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
