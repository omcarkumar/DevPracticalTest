using AutoFixture;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Repo.Test
{
    [TestFixture]
    public class PatientDemographicsRepoTest
    {
        private IPatientDemographicsRepo _repo;
        private Fixture _fixture;

        [SetUp]
        public void PatientDemographicsRepoTestSetUp()
        {
            _repo = new PatientDemographicsRepo();
            _fixture = new Fixture();
        }

        [TestFixture]
        public class GetMethod : PatientDemographicsRepoTest
        {
            [Test]
            public void Should_return_list_of_patientDetails()
            {
                int id = _fixture.Create<int>();
                var dto = _fixture.Create<PatientDemographicsDto>();

                var exception = new NotImplementedException();

                //act
                Action create = () => _repo.Save(dto);

                //assert
                create.Should().Throw<NotImplementedException>().Which.Should().Be(exception);
            }
        }

        [TestFixture]
        public class GetListMethod : PatientDemographicsRepoTest
        {
            [Test]
            public void Should_return_list_of_patientDetails()
            {

            }
        }

        [TestFixture]
        public class SaveMethod : PatientDemographicsRepoTest
        {
            [Test]
            public void Should_return_unique_id_of_new_patientDetails()
            {

            }
        }

        [TestFixture]
        public class UpdateMethod : PatientDemographicsRepoTest
        {
            [Test]
            public void Should_return_bool_If_update_patientDetails_success()
            {

            }
        }
    }
}
