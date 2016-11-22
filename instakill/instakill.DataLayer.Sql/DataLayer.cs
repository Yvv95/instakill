using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using instakill.Model;
using System.Data.SqlClient;
using NLog;

namespace instakill.DataLayer.Sql
{
    public class DataLayer : IDataLayer
    {
        private readonly string _connectionString;
        //private static Logger logger = LogManager.GetCurrentClassLogger();
        
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
                    //logger.Info("Добавлен пользователь с номером "+user.UserId.ToString());
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
                        command.CommandText ="insert into Posts (PostId, UserId, Photo, Date, Hashtag) values (@id, @user, @photo, @date, @hashtag)";
                        command.Parameters.AddWithValue("@id", post.PostId);
                        command.Parameters.AddWithValue("@user", post.UserId);
                        command.Parameters.AddWithValue("@photo", post.Photo);
                        command.Parameters.AddWithValue("@date", post.Date);
                        command.Parameters.AddWithValue("@hashtag", post.Hashtag);
                        command.ExecuteNonQuery();
                        //logger.Trace("Добавлен пост у пользователя " + post.UserId.ToString());
                        return post;
                    }
                    else
                    {
                        //logger.Error("Не удалось добавить пост пользователю " + post.UserId.ToString());
                        return null;
                    }
                }
            }
        }
        public Users GetUser(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                connection.Open();
                //logger.Info("Попытка просмотреть пользователя");
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select UserId, Nickname, Username from Users where UserId = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {                    
                        reader.Read();
                        logger.Info("Просмотрен пользователь с id = "+"'"+ id.ToString()+"'");
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
                Logger logger = LogManager.GetCurrentClassLogger();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PostId, UserId, Photo, Date, Hashtag from Posts where PostId = @id";
                    command.Parameters.AddWithValue("@id", postId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        logger.Info("Просмотрен пост №'" + postId.ToString()+"'"+ " Дата:"+ reader.GetDateTime(3));
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

        public List<Comments> GetPostComments(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select UserId, Photo, Date, Hashtag, PostId from Posts where PostId = @id";
                    command.Parameters.AddWithValue("@id", postId);
                    List<Comments> coms = new List<Comments>();
                    string temp;
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Comments somecom = new Comments
                        {
                            ComId = reader.GetGuid(0),
                            PostId = reader.GetGuid(1),
                            FromId = reader.GetGuid(2),
                            Text = reader.GetString(3),
                            Date = reader.GetDateTime(4)
                        };
                        coms.Add(somecom);
                    }
                    logger.Info("Загружены комментарии с поста № '"+ postId + "'");
                    return coms;
                }
            }
        }

        public List<Posts> GetLatestPosts(Guid id) //по id пользователя
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PostId, UserId, Photo, Date, Hashtag from Posts where UserId = @id";
                    command.Parameters.AddWithValue("@id", id);
                    List <Posts> posts = new List<Posts>();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Posts somepost = new Posts
                        {
                            PostId = reader.GetGuid(0),
                            UserId = reader.GetGuid(1),
                            Photo = reader.GetString(2),
                            Date = reader.GetDateTime(3),
                            Hashtag = reader.GetString(4)
                        };
                        posts.Add(somepost);
                    }
                    return posts;
                }
            }
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
                    //logger.Trace("Пользователь " + like.UserId.ToString()+" поставил лайк к посту " + like.PostId.ToString());
                    return like;
                }
            }
        }

        public List<Likes> GetPostLikes(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PostId, UserId from Likes where PostId = @id";
                    command.Parameters.AddWithValue("@id", postId);
                    List<Likes> likes = new List<Likes>();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Likes somelike = new Likes
                        {
                            PostId = reader.GetGuid(0),
                            UserId = reader.GetGuid(1)              
                        };
                        likes.Add(somelike);
                    }
                    return likes;
                }
            }
        }

        public void DeleteUser(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Users where UserId = @userid";             
                    command.Parameters.AddWithValue("@userid", id);
                    command.ExecuteNonQuery();
                    //logger.Trace("Пользователь "+id.ToString()+" удалён");
                }
            }           
        }

        public void DeletePost(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Posts where PostId = @postid";
                    command.Parameters.AddWithValue("@postid", postId);
                    command.ExecuteNonQuery();
                }
            }

        }

        public void DeleteLike(Guid postId, Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Likes where PostId = @postid and UserId = @userid";
                    command.Parameters.AddWithValue("@postid", postId);
                    command.Parameters.AddWithValue("@userid", userId);
                    command.ExecuteNonQuery();
                }
            }
        }




    }
}
