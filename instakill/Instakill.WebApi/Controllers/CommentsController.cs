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
    public class CommentsController : ApiController
    {

        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        private readonly IDataLayer _dataLayer;
        public CommentsController()
        {
            _dataLayer = new DataLayer(ConnectionString);
        }
        [HttpPost]
        public Comments AddCommentToPost(Guid postId, Comments comment)
        {
            return _dataLayer.AddCommentToPost(postId,  comment);
        }
        [HttpGet]
        [Route("api/comments/{id}")]
        public Comments GetComments(Guid postId)
        {
            return _dataLayer.GetPostComments(postId);
        }
    }
}
