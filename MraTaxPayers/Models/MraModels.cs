using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MraTaxPayers.Models
{

    public class MraTPinRecord 
    {
        public string TPIN { get; set; }
    } 
    public class MraTaxPayer
    {
        public int id { get; set; }
        [Required]
        public string TPIN { get; set; }
        [Required]
       [Display(Name ="Business Certificate Number")]
        public string BusinessCertificateNumber { get; set; }

        [Required]
        [Display(Name = "Trading Name")]
        public string TradingName { get; set; }

        [Required]
        [Display(Name = "Business Registration Date")]
        public string BusinessRegistrationDate { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Physical Location")]
        public string PhysicalLocation { get; set; }
        [Required]
        public string Username { get; set; }
        public bool Deleted { get; set; }
    }


    public class MraLogin 
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class MraToken
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class MraUserDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string email { get; set; }
    }

    public class MraLoginRoot
    {
        public int ResultCode { get; set; }
        public string Remark { get; set; }
        public MraToken Token { get; set; }
        public bool Authenticated { get; set; }
        public MraUserDetails UserDetails { get; set; }
    }


    public class MraLogout
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class MraLogoutResult
    {
        public int ResultCode { get; set; }
        public string Remark { get; set; }
        public object data { get; set; }
    }

    public class MraRootResult
    {
        public int ResultCode { get; set; }
        public string Remark { get; set; }
        public string data { get; set; }
    }


}
