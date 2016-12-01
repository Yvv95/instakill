using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using instakill.Model;
using instakill.DataLayer;
using instakill.DataLayer.Sql;

namespace Instakill.WebApi.Controllers
{
    public class LikesController : ApiController
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        //private const string ConnectionString = @"Server=tcp:instakill.database.windows.net,1433;Initial Catalog=Instagramm;Persist Security Info=False;User ID=Valera;Password=Instakill1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly IDataLayer _dataLayer;
        public LikesController()
        {
            _dataLayer = new DataLayer(ConnectionString);
        }

        [HttpPost]//ok            
        public Likes CreateLike(Likes like)
        {
            return _dataLayer.AddLike(like);
        }

        [HttpGet]//ok
        [Route("api/likes/{id}/users")]
        public List<Users> GetLikes(Guid id)
        {
            return _dataLayer.GetPostLikes(id);
        }
        [HttpDelete]//ok
        public void DeleteUsersLike(Likes like)
        {           
            _dataLayer.DeleteLike(like.PostId, like.UserId);           
        }
    }
}
