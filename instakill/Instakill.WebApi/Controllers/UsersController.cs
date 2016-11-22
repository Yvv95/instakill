using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using instakill.Model;
using instakill.DataLayer;
using instakill.DataLayer.Sql;


namespace Instakill.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        private readonly IDataLayer _dataLayer;
        public UsersController()
        {
            _dataLayer = new DataLayer(ConnectionString);
        }
        //[HttpDelete]
        //smth here

        [HttpPost]      
        public Users CreateUser(Users user)
        {
            return _dataLayer.AddUser(user);
        }

        [HttpPost, ActionName("Delete")]
        public void DelUser(Guid id)
        {
            _dataLayer.DeleteUser(id);
        }
        [HttpGet]
        [Route("api/users/{id}")]
        public Users GetUser(Guid id)
        {
            return _dataLayer.GetUser(id);
        }

    }
}
