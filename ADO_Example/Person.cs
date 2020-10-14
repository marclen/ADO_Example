using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Example
{
    class Person
    {
        public Person()
        {
            FirstName = "";
            LastName = "";
            Phone = "";
            Email = "";
        }

        public Person(int person_ID, string firstName, string lastName, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        public static Person FromCsv(string line)
        {


            string[] split = line.Split(',');
            Person person = new Person();

            if (int.TryParse(split[0], out int test))
            {
                person.person_ID = int.Parse(split[0]);
            }

            person.FirstName = split[1];
            person.LastName = split[2];
            person.Phone = split[3];
            person.Email = split[4];


            return person;
        }

        public int person_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

