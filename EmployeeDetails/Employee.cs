using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails
{
   public class Employee
    {
        private string empId;
        private string name;
        private int age;
        private string dob;
        private string sex;
        private string email;

        public Employee(string empId,string name,int age,string dob,string sex,string email)
        {
            this.empId = empId;
            this.name = name;
            this.age = age;
            this.dob = dob;
            this.sex = sex;
            this.email = email;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string EmpId
        {
            get
            {
                return this.empId;
            }
            set
            {
                this.empId = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        public string DOB
        {
            get
            {
                return this.dob;
            }
            set
            {
                this.dob = value;
            }
        }
        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
    }
}
