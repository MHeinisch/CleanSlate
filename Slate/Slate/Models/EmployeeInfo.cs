using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Slate.Models
{
    public class EmployeeInfo
    {

        [Key]
        public int EmployeeInfoId { get; set; }
        public string Name { get; set; }

    }
}