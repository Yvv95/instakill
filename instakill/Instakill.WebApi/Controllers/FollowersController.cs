using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using instakill.DataLayer.Sql;
using instakill.Model;

namespace Instakill.WebApi.Controllers
{
    public class FollowersController : ApiController
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        //private const string ConnectionString = @"Server=tcp:instakill.database.windows.net,1433;Initial Catalog=Instagramm;Persist Security Info=False;User ID=Valera;Password=Instakill1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly IDataLayer _dataLayer;
        public FollowersController()
        {
            _dataLayer = new DataLayer(ConnectionString);
        }
        [HttpGet]//ok
        [Route("api/subs/{id}")]
        public List<Users> GetSubscriptions(Guid id)
        {
            var user = _dataLayer.GetUser(id);
            return _dataLayer.GetFollowing(user);
        }
        [HttpGet]//ok
        [Route("api/followers/{id}")]
        public List<Users> GetFollowUsers(Guid id)
        {
            var user = _dataLayer.GetUser(id);
            return _dataLayer.GetFollowers(user);
        }

        [HttpPost]//ok
        [Route("api/followers/{id}")]
        public void AddFollow(Guid id, Users follower)
        {
           _dataLayer.AddSubscription(id, follower);
        }

        [HttpDelete]//ok
        [Route("api/followers/{id}")]
        public void DeleteSubscription(Guid id, Users subscription)
        {
            var user = _dataLayer.GetUser(id);
            subscription = _dataLayer.GetUser(subscription.UserId);
            _dataLayer.DeleteFollower(user, subscription);
        }


    }
}
