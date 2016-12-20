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
    public class HashtagsController : ApiController
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        //private const string ConnectionString = @"Server=tcp:instakill.database.windows.net,1433;Initial Catalog=Instagramm;Persist Security Info=False;User ID=Valera;Password=Instakill1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly IDataLayer _dataLayer;
        public HashtagsController()
        {
            _dataLayer = new DataLayer(ConnectionString);
        }
        [HttpPost]//добавляет в БД, но не к комментариям
        [Route("api/tags/{hashtag}")]
        public void AddTag(Comments com, string hashtag)
        {
            _dataLayer.AddHashtag(com, hashtag);           
        }
        [HttpGet]//прилетает только первый хештег
        [Route("api/tags/")]
        public List<string> GetAllHashtags(Comments comment)
        {
            //Guid postid = _dataLayer.GetPost(id);
            return _dataLayer.GetHashtags(comment);
        }
        //smth add
    }
}
