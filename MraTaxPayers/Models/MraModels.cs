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
        public string BusinessCertificateNumber { get; set; }
        [Required]
        public string TradingName { get; set; }
        [Required]
        public string BusinessRegistrationDate { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhysicalLocation { get; set; }
        [Required]
        public string Username { get; set; }
        public bool Deleted { get; set; }
    }


    public class MraLogin 
    {
        [Required]
        public string Email { get; set; }
        [Required]
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
        public string FirstName { get; set; }
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
