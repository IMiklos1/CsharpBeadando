using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBeadando
{
    internal class Employee
    {
        private string name;
        private DateTime dateOfBirth = DateTime.Now;
        private string phoneNumber;
        private int salary;

        public Employee(string name, string dateOfBirth, string phoneNumber, int payment)
        {
            DateTime dOB = new();
            this.name = name;
            if (DateTime.TryParse(dateOfBirth, out dOB))
            {
                this.dateOfBirth = dOB;
            }
            this.phoneNumber = phoneNumber;
            this.salary = payment;
        }

        public string Name { get => name; set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Payment { get => salary; set => salary = value; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Employee other = (Employee)obj;
            return Name == other.Name &&
                   DateOfBirth == other.DateOfBirth &&
                   PhoneNumber == other.PhoneNumber &&
                   salary == other.salary;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ DateOfBirth.GetHashCode() ^
                   PhoneNumber.GetHashCode() ^ salary.GetHashCode();
        }

    }
}
