using Sandy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandy.Application
{
    public interface IRecruiterProfileRepository : IGenericRepository<RecruiterProfile> { };
    public interface ICompanyProfileRepository : IGenericRepository<CompanyProfile> { };
}
