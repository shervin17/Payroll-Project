using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollV3
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middle_name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int Logins_id { get; set; }
        public int Payroll_details_id { get; set; }
        public int Leaves_id { get; set; }

       
    }

    public class EmployeeLogins
    {

        public int Logins_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class EmployeePayrollDetails
    { 
        public int Payroll_details_id { get; set; }
        public decimal Salary { get; set; }
        public decimal Daily_rate { get; set; }
        public decimal Hourly_rate { get; set; }
    }
    public class Leaves
    { 
        public int Leaves_id { get; set;}
        public decimal Accrued_sickleave { get; set; }
        public decimal Accrued_vacationleave { get; set; }
        public decimal Remaining_SL {  get; set; }
        public decimal Remaining_VL { get; set; }
        public DateTime DateStarted { get; set; }
    }

    public class PayrollPeriod
    { 
      public int Payroll_period_id { get; set; }
      public DateTime Date_from {  get; set; }
      public DateTime Date_to { get; set;}

        public override string ToString()
        {
            return $" {this.Date_from.ToString("MM-dd-yyyy")} - {this.Date_to.ToString("MM-dd-yyyy")} ";
        }
    }


}