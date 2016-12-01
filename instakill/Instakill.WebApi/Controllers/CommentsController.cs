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
        [HttpPost]//ok
        [Route("api/comments/{id}")]
        public Comments AddCommentToPost(Guid id, Comments comment)
        {
            return _dataLayer.AddCommentToPost(id,  comment);
        }
       
        [HttpPost]//ok
        [Route("api/comments/")]
        public Comments UpdateComment(Comments com)
        {
            _dataLayer.UpdateComment(com);
            return _dataLayer.GetComment(com.ComId);
        }
        [HttpDelete]//ok
        [Route("api/comments/{id}")]
        public void DeleteComment(Guid id)
        {
            _dataLayer.DeleteComment(id);
        }
        [HttpGet]//ok
        [Route("api/comments/{id}")]
        public Comments GetComment(Guid id)
        {
            return _dataLayer.GetComment(id);
        }
    }
}
