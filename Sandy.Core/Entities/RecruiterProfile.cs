using System.ComponentModel.DataAnnotations;

namespace Sandy.Core.Entities
{
    public class RecruiterProfile : BaseEntity
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        public CompanyProfile CompanyProfile { get; set; }
        [Display(Name = "Company Name")]
        public int CompanyID { get; set; }
    }
}
