using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        private string firstName;
        private string lastName;
        private int salary;

        public string FirstName 
        { 
            get
            {
                return firstName;
            } 
            set
            {
                firstName = value;
            }
        }
        public string LastName 
        { 
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public int Salary 
        { 
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
    }
}