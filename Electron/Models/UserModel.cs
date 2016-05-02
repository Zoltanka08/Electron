using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electron.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string mail { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string mobile { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string number { get; set; }

        public virtual IEnumerable<OrderModel> Orders { get; set; }
        public virtual IEnumerable<UserRoleModel> UserRoles { get; set; }

    }
}