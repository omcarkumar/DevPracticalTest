using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PatientDemographicsController : Controller
    {
        private IRestClient _restClient;
        private string URL_PATH = "http://localhost:8090";
            
        public PatientDemographicsController(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IActionResult Index(int id)
        {
            var request = new RestRequest(URL_PATH + "/" + id , Method.GET);
            request.AddUrlSegment("Id", id);
            var response = _restClient.Execute<PatientDemographics>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            
            return View(response);
        }

        public IActionResult Save([FromBody] PatientDemographics viewModel)
        {
            var request = new RestRequest(URL_PATH, Method.POST);
            var response = _restClient.Execute<PatientDemographics>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return View();
        }

        public IActionResult Update(int id,[FromBody] PatientDemographics viewModel)
        {
            var request = new RestRequest(URL_PATH + "/" + id, Method.PUT);
            request.AddUrlSegment("Id", id);
            var response = _restClient.Execute<PatientDemographics>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return View();
        }

        public IActionResult List()
        {
            var request = new RestRequest(URL_PATH, Method.GET);
            var response = _restClient.Execute<List<PatientDemographics>>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return View(response);
        }
    }
}