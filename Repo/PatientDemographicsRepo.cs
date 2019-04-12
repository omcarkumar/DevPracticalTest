using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace Repo
{
    public interface IPatientDemographicsRepo
    {
        List<PatientDemographicsDto> GetAll();
        PatientDemographicsDto Get(int id);
        int Save(PatientDemographicsDto newPatientDemographics);
        bool Update(int id, PatientDemographicsDto updatePatientDemographics);
    }

    public class PatientDemographicsRepo : IPatientDemographicsRepo
    {

        private IDbConnection _db = new SqlConnection("DBModel");

        public PatientDemographicsRepo()
        {

        }

        public PatientDemographicsDto Get(int id)
        {
            return  _db.Query<PatientDemographicsDto>("select * from PatientDemographicsTable where Id=@PId ", new { PId = id })
                .FirstOrDefault();
        }

       
        public List<PatientDemographicsDto> GetAll()
        {
            return _db.Query<PatientDemographicsDto>("select * from PatientDemographicsTable ").AsList();
        }

        public int Save(PatientDemographicsDto newPatientDemographics)
        {
            return _db.Execute("PatientDemographicsTable", newPatientDemographics);
        }

        public bool Update(int id, PatientDemographicsDto updatePatientDemographics)
        {
            _db.Execute("PatientDemographicsTable", updatePatientDemographics);
            return true;
        }
    }
}
