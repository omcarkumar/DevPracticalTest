using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Repo;
using SharedContract;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Domain.Tests
{
    [TestFixture]
    public class ServiceImplementationTest
    {
        private IServiceImplementation _serviceImplementation;
        private Mock<IPatientDemographicsRepo> _repo;
        private Mock<IMapper> _mapper;
        private Fixture _fixture;

        [SetUp]
        public void ServiceImplementationTestSetUp()
        {
            _fixture = new Fixture();
            _repo = new Mock<IPatientDemographicsRepo>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _serviceImplementation = new ServiceImplementation(_mapper.Object, _repo.Object);
        }

        [TestFixture]
        public class GetMethod : ServiceImplementationTest
        {
            [Test]
            public void Should_return_list_of_patientDetails()
            {
                //arrange
                var mappingOutput = _fixture.Create<PatientDemographics>();
                var expected = _fixture.Create<PatientDemographicsDto>();
                var id = _fixture.Create<int>();

                _repo.Setup(m => m.Get(id)).Returns(expected);
                _mapper.Setup(x => x.Map<PatientDemographicsDto, PatientDemographics>(expected)).Returns(mappingOutput);

                //act
                var actual = _serviceImplementation.GetAll();

                //assert
                actual.Should().BeEquivalentTo(mappingOutput);
            }
        }

        [TestFixture]
        public class GetListMethod : ServiceImplementationTest
        {
            [Test]
            public void Should_return_list_of_patientDetails()
            {
                //arrange
                var mappingOutput = _fixture.Create<List<PatientDemographics>>();
                var expected = _fixture.Create<List<PatientDemographicsDto>>();

                _repo.Setup(m => m.GetAll()).Returns(expected);
                _mapper.Setup(x => x.Map<IEnumerable<PatientDemographicsDto>, IEnumerable<PatientDemographics>>(expected)).Returns(mappingOutput);

                //act
                var actual = _serviceImplementation.GetAll();

                //assert
                actual.Should().BeEquivalentTo(mappingOutput);
            }
        }

        [TestFixture]
        public class SaveMethod : ServiceImplementationTest
        {
            [Test]
            public void Should_return_unique_id_of_new_patientDetails()
            {
                int id = _fixture.Create<int>();
                var model = _fixture.Create<PatientDemographics>();
                var dto = _fixture.Create<PatientDemographicsDto>();

                _mapper.Setup(x => x.Map<PatientDemographics, PatientDemographicsDto>(model)).Returns(dto);

                _repo.Setup(m => m.Save(dto)).Returns(id);

                //act
                _serviceImplementation.Save(model);

                //assert
                _repo.Verify(c => c.Save(dto), Times.Once);

            }
        }

        [TestFixture]
        public class UpdateMethod : ServiceImplementationTest
        {
            [Test]
            public void Should_return_bool_If_update_patientDetails_success()
            {

            }
        }
    }
}
