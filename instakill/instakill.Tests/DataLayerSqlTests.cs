using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using instakill.Model;


namespace instakill.Tests
{
    [TestClass]
    public class DataLayerSqlTests
    {
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        [TestMethod]//ok
        public void AddUserTest()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            //asserts
            var resultUser = dataLayer.GetUser(user.UserId);
            Assert.AreEqual(user.Nickname, resultUser.Nickname);
        }

        [TestMethod]//ok
        public void UpdateUserTest()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var newuser = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            dataLayer.UpdateUser(user.UserId, newuser);
            //asserts
            var resultUser = dataLayer.GetUser(user.UserId);
            Assert.AreEqual(user.UserId, resultUser.UserId);
        }

        [TestMethod]//ok
        public void AddPostTest()
        {
            //firstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);         
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {              
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            var resultPost = dataLayer.GetPost(post.PostId);
            Assert.AreEqual(post.PostId, resultPost.PostId);
        }

        [TestMethod]//ok
        public void DeletePostTest()
        {
            //firstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            var resultPost = dataLayer.GetPost(post.PostId);
            dataLayer.DeletePost(post.PostId);
            var delpost = dataLayer.GetPost(post.PostId);
            Assert.AreNotEqual(delpost.PostId, resultPost.PostId);
        }

        [TestMethod]//ok
        public void UpdatePostTest()
        {
            //firstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            var newPost = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            dataLayer.UpdatePost(post.PostId, newPost);
            var resultPost = dataLayer.GetPost(post.PostId);         
            Assert.AreEqual(resultPost.Photo, newPost.Photo);
        }

        [TestMethod]//ok
        public void GetUserTest()
        {
            var user = new Users
            {
                UserId = Guid.NewGuid(),
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //asserts
            var resultUser = dataLayer.GetUser(user.UserId);
            Assert.AreEqual(user.Nickname, resultUser.Nickname);
        }

        [TestMethod]//ok
        public void DeleteUserTest()
        {
            //arrange
            var user = new Users
            {
                //UserId = Guid.NewGuid(),
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            //act
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            dataLayer.DeleteUser(user.UserId);
            var resultUser = dataLayer.GetUser(user.UserId);            
            //asserts
            Assert.AreNotEqual(user.UserId, resultUser.UserId);
        }

        [TestMethod]//ok
        public void GetPostTest()
        {
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            var user = new Users
            {
                UserId = Guid.NewGuid(),
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            
            //act       
            user = dataLayer.AddUser(user);
            post = dataLayer.AddPost(post);
            //asserts
            var resultPost = dataLayer.GetPost(post.PostId);
            Assert.AreEqual(post.Photo, resultPost.Photo);
        }

        [TestMethod]//ok
        public void AddLikeTest()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            var like = new Likes
            {
                PostId = post.PostId,
                UserId = user.UserId
            };
            dataLayer.AddLike(like);
            var check = dataLayer.IsLiked(post.PostId, user.UserId);
            Assert.AreEqual(check, true);
        }

        [TestMethod]//ok
        public void DeleteLikeTest()
        {
            //arrange         
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            var like = new Likes
            {
                PostId = post.PostId,
                UserId = user.UserId
            };
            
            dataLayer.AddLike(like);
            dataLayer.DeleteLike(like.PostId, like.UserId);
            var check = dataLayer.IsLiked(post.PostId, user.UserId);
            Assert.AreEqual(check, false);
        }

        [TestMethod]//ok
        public void GetLikeTest()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            var like = new Likes
            {
                PostId = post.PostId,
                UserId = user.UserId
            };
            dataLayer.AddLike(like);
            Assert.AreEqual(dataLayer.IsLiked(post.PostId, user.UserId), true);
        }

        [TestMethod]//ok
        public void AddFollowerTest()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var follower = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            follower = dataLayer.AddUser(follower);
            dataLayer.AddSubscription(user.UserId, follower);
            //asserts
            Assert.AreEqual(dataLayer.IsFollower(user, follower), true);
        }

        [TestMethod]//ok
        public void DeleteFollowerTest()
        {
            //arrange
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var follower = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            follower = dataLayer.AddUser(follower);
            dataLayer.AddSubscription(user.UserId, follower);
            dataLayer.DeleteFollower(user, follower);
            //asserts
            Assert.AreEqual(dataLayer.IsFollower(user, follower), false);
        }

        //to add: getfolowerstest
        //to add: hashtags tests
        
        [TestMethod]//ok
        public void AddComTest()
        {
            //firstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            //add com to post
            var com = new Comments()
            {
                Date = DateTime.Now,
                FromId = user.UserId,
                PostId = post.PostId,
                Text = Guid.NewGuid().ToString().Substring(10)
            };
            dataLayer.AddCommentToPost(post.PostId, com);
            var resultCom = dataLayer.GetComment(com.ComId);
            Assert.AreEqual(com.Text, resultCom.Text);
        }

        [TestMethod]//ok
        public void DeleteComTest()
        {
            //firstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            //add com to post
            var com = new Comments()
            {
                Date = DateTime.Now,
                FromId = user.UserId,
                PostId = post.PostId,
                Text = Guid.NewGuid().ToString().Substring(10)
            };
            dataLayer.AddCommentToPost(post.PostId, com);
            dataLayer.DeleteComment(com.ComId);
            Assert.AreEqual(dataLayer.IsComment(com.ComId), false);
        }

        [TestMethod]//ok
        public void UpdateComTest()
        {
            //firstly, add user to add him post
            var user = new Users
            {
                Nickname = Guid.NewGuid().ToString().Substring(10),
                Username = Guid.NewGuid().ToString().Substring(10),
                Info = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
            user = dataLayer.AddUser(user);
            //add post to user
            var post = new Posts
            {
                UserId = user.UserId,
                Date = DateTime.Now,
                Photo = Guid.NewGuid().ToString().Substring(10)
            };
            post = dataLayer.AddPost(post);
            //add com to post
            var com = new Comments()
            {
                Date = DateTime.Now,
                FromId = user.UserId,
                PostId = post.PostId,
                Text = Guid.NewGuid().ToString().Substring(10)
            };
            var newCom = new Comments()
            {
                Date = DateTime.Now,
                FromId = user.UserId,
                PostId = post.PostId,
                Text = Guid.NewGuid().ToString().Substring(10)
            };
            newCom.ComId = com.ComId;
            dataLayer.AddCommentToPost(post.PostId, com);
            var resultCom = dataLayer.GetComment(com.ComId);
            var check = dataLayer.UpdateComment(newCom);          
            Assert.AreEqual(com.Text, resultCom.Text);
        }

        


    }
}




