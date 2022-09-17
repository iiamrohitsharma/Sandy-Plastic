using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sandy.Application;
using Sandy.Core.Entities;
using Sandy.Main.Models;
using Sandy.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Main.Controllers
{
    public class RecruiterController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public RecruiterController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var recruiterProfileRepository = await unitOfWork.RecruiterProfileRepository.GetAllAsync();
            var companyProfileRepository = await unitOfWork.CompanyProfileRepository.GetAllAsync();

            // database seeding
            if (companyProfileRepository.Count() == 0)
            {
                DatabaseInitializer databaseInitializer = new DatabaseInitializer(unitOfWork);
                databaseInitializer.CompanyProfile();
                databaseInitializer.RecruiterProfile();
            }

            var recruiterProfile = recruiterProfileRepository
                                    .Join(companyProfileRepository, ai => ai.CompanyID,
              al => al.ID, (ai, al) => new RecruiterProfile
              {
                  ID = ai.ID,
                  FirstName = ai.FirstName,
                  LastName = ai.LastName,
                  CompanyID = al.ID,
                  EmailID = ai.EmailID,
                  MobileNumber = ai.MobileNumber,
                  CompanyProfile = new CompanyProfile()
                  {
                      ID = al.ID,
                      Name = al.Name,
                      Description = al.Description,
                      IsActive = al.IsActive
                  }
              });

            return View(recruiterProfile);
        }

        public IActionResult AddRecruiterDetail()
        {
            var recruiterProfile = new RecruiterProfilesViewModel()
            {
                Companies = GetCompanyProfileDropdownValues()
            };

            return View(recruiterProfile);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecruiterDetail(RecruiterProfilesViewModel recruiterProfile)
        {
            recruiterProfile.CompanyID = recruiterProfile.SelectedCompanyID;
            _ = await unitOfWork.RecruiterProfileRepository.AddAsync(recruiterProfile);


            recruiterProfile.Companies = GetCompanyProfileDropdownValues();
            return View(recruiterProfile);
        }

        private IList<SelectListItem> GetCompanyProfileDropdownValues()
        {
           return unitOfWork.CompanyProfileRepository
                .GetAllAsync().Result
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.ID.ToString() })
                .ToList();
        }

        public IActionResult SendRecruiterEmail() 
        {
            return View(new SendRecruiterEmailViewModel());
        }
    }
}
