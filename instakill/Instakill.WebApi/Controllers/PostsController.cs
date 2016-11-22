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
    public class PostsController : ApiController
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        private readonly IDataLayer _dataLayer;
        public PostsController()
        {
            _dataLayer = new DataLayer(ConnectionString);
        }
        [HttpPost]
        public Posts CreatePost(Posts post)
        {
            return _dataLayer.AddPost(post);
        }
        [HttpGet]
        [Route("api/posts/{id}")]
        public Posts GetPost(Guid id)
        {
            return _dataLayer.GetPost(id);
        }
        [HttpGet]
        [Route("api/posts/{id}")]
        public List<Comments> GetPostCom(Guid postId)
        {
            return _dataLayer.GetPostComments(postId);
        }
    }
}
