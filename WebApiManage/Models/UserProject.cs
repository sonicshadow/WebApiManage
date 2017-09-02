using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiManage.Models
{
    public class UserProject
    {

        public int ID { get; set; }
        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}