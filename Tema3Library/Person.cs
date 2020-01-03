using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3Library
{
    public class Person
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime BirthDate { get; protected set; }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

    }
}
