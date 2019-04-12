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
    public class PatientDemographicsSaveController : ControllerBase
    {
        private readonly IServiceImplementation _serviceImplementation;

        public PatientDemographicsSaveController(IServiceImplementation serviceImplementation)
        {
            _serviceImplementation = serviceImplementation;
        }

        [HttpPost]
        public int Post([FromBody] PatientDemographics value)
        {
            return _serviceImplementation.Save(value);
        }

        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] PatientDemographics value)
        {
            return _serviceImplementation.Update(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}