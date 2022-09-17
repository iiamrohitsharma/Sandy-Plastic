using Microsoft.AspNetCore.Mvc;
using Sandy.Application;
using Sandy.Core.Entities;
using Sandy.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Sandy.Main.Areas.Admin.Controllers
{
    public class CompanyProfileManagementController : BaseAdminController
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyProfileManagementController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var companyProfile = await unitOfWork.CompanyProfileRepository.GetAllAsync();

            return View(companyProfile);
        }
        public IActionResult AddCompanyProfile() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyProfile(CompanyProfile companyProfile)
        {
            _ = await unitOfWork.CompanyProfileRepository.AddAsync(companyProfile);

            return View();
        }
    }
}
