using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETWebAPI.Models
{
    public class Employee
    {
        public long ID { get; set; }
        
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public String LastName { get; set; }

        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public String FirstName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        public String Photo { get; set; }
        
        public String Notes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
