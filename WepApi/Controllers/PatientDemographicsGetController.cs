using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedContract;

namespace WepApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientDemographicsGetController : ControllerBase
    {
        private readonly IServiceImplementation _serviceImplementation;

        public PatientDemographicsGetController(IServiceImplementation serviceImplementation)
        {
            _serviceImplementation = serviceImplementation;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDemographics>> Get()
        {
            return _serviceImplementation.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PatientDemographics> Get(int id)
        {
            return _serviceImplementation.Get(id);
        }

    }
}