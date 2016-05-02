using Electron.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Electron.ViewModels
{
    public class UserViewModel
    {
        public int id { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string mail { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets of First Name")]
        [Required(ErrorMessage = "First name required!")]
        public string firstname { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets of Last Name")]
        [Required(ErrorMessage = "Last name required!")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Username name required!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [RegularExpression("((?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^$.|?*+(){}]).{6,20})", ErrorMessage = "Password must contain lowercase, uppercase characters, at least one number and one special character! Minimum length is 6")]
        public string pass { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Enter only numbers of Mobile number")]
        [Required(ErrorMessage = "Mobile required!")]
        public string mobile { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets of Country")]
        public string country { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets of City")]
        public string city { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets of Street")]
        public string street { get; set; }

        [RegularExpression("([a-zA-Z0-9]+)", ErrorMessage = "Enter only alphabets and numbers of Street number")]
        public string number { get; set; }


        [RegularExpression("([a-zA-Z0-9]{10,15})", ErrorMessage = "Enter only alphabets and numbers of Street number")]
        public string IBAN { get; set; }


        public virtual ICollection<UserRoleModel> UserRoles { get; set; }
    }
}