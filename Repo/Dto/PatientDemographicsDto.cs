using System;
using System.Collections.Generic;

namespace Repo
{
    public class PatientDemographicsDto
    {
        public int Id { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public List<TelephoneNumbersType> TelephoneNumbers { get; set; }
    }
}

 