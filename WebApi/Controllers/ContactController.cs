using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebApi.Services;
using WebApi.Models;




namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private HttpRequest _request = HttpContext.Current.Request;
        private ContactRepository repository;

        public ContactController()
        {
            repository = new ContactRepository();
        }
        public IList<Contact> Get()
        {
            return repository.GetAllContacts();
        }

        public bool Put(Contact contact)
        {
            return repository.UpdateContact(contact);
        }

        public HttpResponseMessage Post(Contact contact)
        {
            HttpResponseMessage response;

            Contact saved = repository.SaveContact(contact);
            if (saved.Id > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.Created, saved);
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, saved);
                response.Content = new StringContent("Unable to create user");
            }       
            return response;
        }
    }
}