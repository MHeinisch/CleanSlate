using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Slate.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        public string TimeOfDay { get; set; }
        public int WeekDay { get; set; }
        public virtual EmployeeInfo employeeInfo { get; set; }
    }
}