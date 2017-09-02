using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApiManage.Models
{
    public class Project
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        public virtual ICollection<Api> Apis { get; set; }


    }
}