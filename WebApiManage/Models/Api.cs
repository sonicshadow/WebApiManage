using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApiManage.Models
{
    public class Api
    {
        public int ID { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        [Display(Name = "项目")]
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "分组")]
        public string Group { get; set; }

        [Required]
        [Display(Name = "地址")]
        public string Url { get; set; }

        [Required]
        [Display(Name = "类别")]
        public ApiType Type { get; set; }

        [Display(Name = "参数")]
        public string Parameters { get; set; }

        [Display(Name = "说明")]
        [AllowHtml]
        [DataType(DataType.Html)]
        public string Info { get; set; }


    }
}