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
        [HttpPost]//ok
        public Posts CreatePost(Posts post)
        {
            return _dataLayer.AddPost(post);
        }
        [HttpGet]//ok
        [Route("api/posts/{id}")]
        public Posts GetPost(Guid id)
        {
            return _dataLayer.GetPost(id);
        }
        [HttpGet]//ok
        [Route("api/posts/{id}/comments")]
        public List<Comments> GetPostCom(Guid id)
        {
            return _dataLayer.GetPostComments(id);
        }
        [HttpDelete]//ok
        [Route("api/posts/{id}")]
        public void DeletePost(Guid id)
        {
            _dataLayer.DeletePost(id);
        }
        [HttpPost]//ok
        [Route("api/posts/{id}")]
        public Posts UpdatePost(Guid id, Posts newpost)
        {
            _dataLayer.UpdatePost(id, newpost);
            newpost.PostId = id;
            return _dataLayer.GetPost(newpost.PostId);
        }

        [HttpGet] //ok
        [Route("api/posts/user/{id}")]
        public List<Posts> LoadPosts(Guid id)
        {
            return _dataLayer.GetLatestPosts(id);
        }
        [HttpGet] //???
        [Route("api/posts/feed/{id}")]
        public List<Posts> GetFeed(Guid id)
        {
            return _dataLayer.GetFeedPosts(id);
        }


    }
}
