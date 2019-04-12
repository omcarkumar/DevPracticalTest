using AutoMapper;
using Domain.FluentValidation;
using FluentValidation;
using Repo;
using SharedContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IServiceImplementation
    {
        List<PatientDemographics> GetAll();
        PatientDemographics Get(int id);
        int Save(PatientDemographics newPatientDemographics);
        bool Update(int id, PatientDemographics updatePatientDemographics);
    }

    public class ServiceImplementation : IServiceImplementation
    {
        private IMapper _mapper;
        private IPatientDemographicsRepo _repo;
        private IValidator<PatientDemographicsValidator> _validate;


        public ServiceImplementation(IMapper mapper, IPatientDemographicsRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public PatientDemographics Get(int id)
        {
            var patientDetail = _mapper.Map<PatientDemographicsDto,PatientDemographics>(_repo.Get(id));
            return patientDetail;
        }

        public List<PatientDemographics> GetAll()
        {
            var patientDetail = _mapper.Map<IEnumerable<PatientDemographicsDto>, List<PatientDemographics>>(_repo.GetAll());
            return patientDetail;
        }

        public int Save(PatientDemographics newPatientDemographics)
        {
            var validateResult = _validate.Validate(newPatientDemographics);
            if (!validateResult.IsValid)
                throw new Exception("Validation Errors");

            var save = _mapper.Map<PatientDemographics, PatientDemographicsDto>(newPatientDemographics);
            return _repo.Save(save);
        }

        public bool Update(int id, PatientDemographics updatePatientDemographics)
        {
            var validateResult = _validate.Validate(updatePatientDemographics);
            if (!validateResult.IsValid)
                throw new Exception("Validation Errors");

            var save = _mapper.Map<PatientDemographics, PatientDemographicsDto>(updatePatientDemographics);
            return _repo.Update(id, save);
        }
    }
}
