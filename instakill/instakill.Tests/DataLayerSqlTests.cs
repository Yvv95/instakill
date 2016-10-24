using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using instakill.Model;


namespace instakill.Tests
{
    [TestClass]
    public class DataLayerSqlTests
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        [TestMethod]
        public void ShouldAddUser()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = "test",
                Status = "status"
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            //asserts
            var resultUser = dataLayer.GetUser(user.UserId);
            Assert.AreEqual(user.Nickname, resultUser.Nickname);
        }

        [TestMethod]
        public void ShouldAddPost()
        {
            //frirstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = "test",
                Status = "status"
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);         
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                
                UserId = user.UserId,
                Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                Hashtag = "simplehash",
                Photo = "simple_url"
            };
            dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            post = dataLayer.AddPost(post);
            var resultPost = dataLayer.GetPost(post.PostId);
            Assert.AreEqual(post.PostId, resultPost.PostId);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var user = new Users
            {
                UserId = Guid.NewGuid(),
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = "test",
                Status = "status"
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //asserts
            var resultUser = dataLayer.GetUser(user.UserId);
            Assert.AreEqual(user.Nickname, resultUser.Nickname);
        }
        /*
        [TestMethod]
        public void ShouldAddLike()
        {
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = "test",
                Status = "status"
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {

                UserId = user.UserId,
                Date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                Hashtag = "simplehash",
                Photo = "simple_url"
            };
            var like = new Likes
            {
                PostId = post.PostId,
                UserId = user.UserId

            };

            dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            like = dataLayer.AddLike(like);
            var resultLike = dataLayer.AddLike(like);
            Assert.AreEqual(like, resultLike);
        }
        */



    }
}



//todo
//2)в программе работаем с типами
//3)переименовать перемнные UserId, ..
//4)работать с типами
//5) коммментить почаще
//6) название проекта с большой буквы
