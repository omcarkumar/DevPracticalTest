using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PatientDemographics
    {
        public int Id { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public List<TelephoneNumbersType> TelephoneNumbers { get; set; }
    }
}
