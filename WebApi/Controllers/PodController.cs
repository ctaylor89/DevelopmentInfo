using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevelopmentInfo.Entities;

namespace WebApi.Controllers
{
    public class PodController : ApiController
    {
        List<Pod> Pods = null;

        public PodController()
        {
            Pods = new List<Pod>()
            {
                new Pod()
                {
                    Id = 200,
                    Name = "PodSmithx",
                    StartDate = DateTime.Now.AddDays(30).AddHours(2),
                    Weight = 135
                },
                new Pod()
                {
                    Id = 300,
                    Name = "Podscicle",
                    StartDate = DateTime.Now.AddDays(30).AddHours(2),
                    Weight = 135
                }
            };
        }
        
        // GET api/values
        // http://localhost:53047/api/Pod
        public HttpResponseMessage GetPods()
        {
            HttpResponseMessage response = null;

            if(Pods == null || Pods.Count < 1)
            {
                response = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("No Pods have been found!")
                };
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Pods);
            }

            return response;
        }

        // http://localhost:53047/api/Pod/?id=200  
        // http://localhost:53047/api/Pod/200      
        public HttpResponseMessage GetPod(int id)
        {
            HttpResponseMessage response = null;

            if (Pods == null || Pods.Count < 1)
            {
                response = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("No Pods have been found!")
                };
            }
            else
            {
                var returnPod = Pods.Where(p => p.Id == id).FirstOrDefault();
                response = Request.CreateResponse<Pod>(HttpStatusCode.OK, returnPod);
            }
            
            return response;
        }

        // POST api/values
        public HttpResponseMessage Post(Pod pod)
        {
            HttpResponseMessage response = null;
            // Data would be saved here:
            int numberOfSavedItems = 1;
            response = Request.CreateResponse(HttpStatusCode.OK, numberOfSavedItems);
            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
