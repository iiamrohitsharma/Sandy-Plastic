using Microsoft.AspNetCore.Mvc.Rendering;
using Sandy.Core.Entities;
using System.Collections.Generic;

namespace Sandy.Main.Models
{
    public class RecruiterProfilesViewModel : RecruiterProfile
    {
        public int SelectedCompanyID { get; set; }
        public IList<SelectListItem> Companies { get; set; }
    }
}
