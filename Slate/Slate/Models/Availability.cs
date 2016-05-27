using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Slate.Models
{
    public class Availability
    {

        [Key]
        public int AvailabilityId { get; set; }
        public int WeekDay { get; set; }
        public virtual EmployeeInfo EmployeeInfoId { get; set; }

    }
}