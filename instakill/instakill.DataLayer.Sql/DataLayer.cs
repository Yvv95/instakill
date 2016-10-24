using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instakill.Model;
using System.Data.SqlClient;

namespace instakill.DataLayer.Sql
{
    public class DataLayer : IDataLayer
    {
        private readonly string _connectionString;
        public DataLayer(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }

        public Users AddUser(Users user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    user.UserId = Guid.NewGuid();
                    command.CommandText = "insert into Users (UserId, Nickname, Username, Status) values (@id, @nick, @name, @stat)";
                    command.Parameters.AddWithValue("@id", user.UserId);
                    command.Parameters.AddWithValue("@nick", user.Nickname);
                    command.Parameters.AddWithValue("@name", user.Username);
                    command.Parameters.AddWithValue("@stat", user.Status);
                    command.ExecuteNonQuery();
                    return user;
                }
            }
        }
        public Posts AddPost(Posts post)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {

                    post.PostId = Guid.NewGuid();
                    if (GetUser(post.UserId) != null)
                    {
                        command.CommandText =
                            "insert into Posts (PostId, UserId, Photo, Date, Hashtag) values (@id, @user, @photo, @date, @hashtag)";
                        command.Parameters.AddWithValue("@id", post.PostId);
                        command.Parameters.AddWithValue("@user", post.UserId);
                        command.Parameters.AddWithValue("@photo", post.Photo);
                        command.Parameters.AddWithValue("@date", post.Date);
                        command.Parameters.AddWithValue("@hashtag", post.Hashtag);
                        command.ExecuteNonQuery();
                        return post;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public Users GetUser(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select UserId, Nickname, Username from Users where UserId = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Users
                        {
                            UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                            Nickname = reader.GetString(1)
                        };
                    }
                }
            }
        }

        public Posts GetPost(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PostId, UserId, Photo, Date, Hashtag from Posts where PostId = @id";
                    command.Parameters.AddWithValue("@id", postId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Posts
                        {
                            PostId = reader.GetGuid(0),
                            UserId = reader.GetGuid(1),
                            Photo = reader.GetString(2) ,
                            Date = reader.GetDateTime(3) ,
                            Hashtag = reader.GetString(4) 

                        };
                    }
                }
            }
        }

        public Comments AddCommentToPost(Guid postId, Comments comment)         
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    comment.ComId = Guid.NewGuid();
                    command.CommandText = "insert into Comments (ComId, PostId, FromId, Text, Date) values (@comid, @postid, @fromid, @text, @date)";
                    command.Parameters.AddWithValue("@comid", comment.ComId);
                    command.Parameters.AddWithValue("@postid", postId);
                    command.Parameters.AddWithValue("@fromid", comment.FromId);
                    command.Parameters.AddWithValue("@text", comment.Text);
                    command.Parameters.AddWithValue("@date", comment.Date); 
                    command.ExecuteNonQuery();
                    return comment;
                }
            }
        }

        public Comments GetPostComments(Guid postId)
        {
            throw new NotImplementedException(); 
            
        }

        
        public Posts GetLatestPosts(Guid id) //по id пользователя
        {
            throw new NotImplementedException(); 
            
        }

        public Likes AddLike(Likes like) //userid - лайкнувший, postid - какой пост лайкнул 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {                     
                    command.CommandText = "insert into Likes (PostId, UserId) values (@postid, @userid)";
                    command.Parameters.AddWithValue("@postid", like.PostId);
                    command.Parameters.AddWithValue("@userid", like.UserId);
                    command.ExecuteNonQuery();
                    return like;
                }
            }
        }

        public Likes GetPostLikes(Guid postId)
        {
            throw new NotImplementedException();
        }


    }
}
