using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1_Modul3
{
   public class Person
    {
        public int? Id;
        public string FirstName;
        public string LastName;
        public int? BirthYear;
        public int? DeathYear;
        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            string returnString = string.Empty;
            if (FirstName != null) returnString += $"{FirstName} ";
            if (LastName != null) returnString += $"{LastName} ";
            if (Id != null) returnString += $"(Id={Id}) ";
            if (BirthYear != null) returnString += $"Født: {BirthYear} ";
            if (DeathYear != null) returnString += $"Død: {DeathYear} ";
            if (Father != null) returnString += $"Far: {Father.FirstName} (Id={Father.Id}) ";
            if (Mother != null) returnString += $"Mor: {Mother.FirstName} (Id={Mother.Id}) ";
            string returnStringTrimed = returnString.Trim();
            return returnStringTrimed;
        }
    }
}
