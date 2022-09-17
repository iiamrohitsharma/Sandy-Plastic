using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandy.Application
{
    public interface IUnitOfWork
    {
        IRecruiterProfileRepository RecruiterProfileRepository { get; }

        ICompanyProfileRepository CompanyProfileRepository { get; }
    }
}
