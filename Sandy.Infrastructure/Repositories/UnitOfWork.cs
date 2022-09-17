using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandy.Application;
using System.Threading.Tasks;

namespace Sandy.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRecruiterProfileRepository recruiterProfileRepository, 
                    ICompanyProfileRepository companyProfileRepository)
        {
            RecruiterProfileRepository = recruiterProfileRepository;
            CompanyProfileRepository = companyProfileRepository;
        }
        public IRecruiterProfileRepository RecruiterProfileRepository { get; }

        public ICompanyProfileRepository CompanyProfileRepository { get; }
    }
}
