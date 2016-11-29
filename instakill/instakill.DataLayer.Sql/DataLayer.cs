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
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public DataLayer(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

       
        public Users AddUser(Users user)
        {
            logger.Info("Попытка создания пользователя "+ user.Nickname);
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
                    command.Parameters.AddWithValue("@stat", user.Info);
                    command.ExecuteNonQuery();
                    logger.Info("Создание пользователя " + user.Nickname+ " прошло успешно");
                    return user;
                }
            }
        }
        public bool UpdateUser(Guid id, Users userChanged)
        {
            logger.Info("Попытка обновления пользователя c id " + id);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (GetUser(id).UserId != Guid.Empty)
                    {
                        command.CommandText =
                            "update Users set Nickname=@nick, Username=@name, Status=@stat where UserId=@id";
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nick", userChanged.Nickname);
                        command.Parameters.AddWithValue("@name", userChanged.Username);
                        command.Parameters.AddWithValue("@stat", userChanged.Info);
                        command.ExecuteNonQuery();
                        logger.Info("Пользователь " + userChanged.Nickname + " обновлён");
                        return true;
                    }
                    else
                    {
                        logger.Error("Пользователь {0} не был изменён", id);
                        return false;
                    }
                }
            }
        }
        public Posts AddPost(Posts post)
        {
            logger.Info("Попытка добавления поста "+post.UserId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    post.PostId = Guid.NewGuid();
                    if (GetUser(post.UserId).UserId != Guid.Empty)
                    {
                        command.CommandText = "insert into Posts (PostId, UserId, Photo, Date) values (@id, @user, @photo, @date)";
                        command.Parameters.AddWithValue("@id", post.PostId);
                        command.Parameters.AddWithValue("@user", post.UserId);
                        command.Parameters.AddWithValue("@photo", post.Photo);
                        command.Parameters.AddWithValue("@date", post.Date=DateTime.Now);
                        command.ExecuteNonQuery();
                        logger.Info("Добавлен пост " + post.PostId);
                        return post;
                    }
                    logger.Error("Не удалось добавить пост пользователю " + post.UserId.ToString());
                    return new Posts();
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
                    command.CommandText = "select UserId, Nickname, Username, Status from Users where UserId = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            logger.Info("Просмотрен пользователь с id = '{0}'", id);
                            return new Users
                            {
                                UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                                Nickname = reader.GetString(reader.GetOrdinal("Nickname")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Info = reader.GetString(reader.GetOrdinal("Status"))
                            };
                        }
                        logger.Error("Просмотр несуществующего пользователя с id = '{0}'", id);
                        return new Users();
                    }
                }
            }
        }
        public Posts GetPost(Guid postId)
        {
            logger.Info("Поиск " + postId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select PostId, UserId, Photo, Date from Posts where PostId = @id";
                    command.Parameters.AddWithValue("@id", postId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            logger.Info("Просмотрен пост {0} | Дата поста:{1}", postId, reader.GetDateTime(3));
                            return new Posts
                            {
                                PostId = reader.GetGuid(reader.GetOrdinal(@"PostId")),
                                UserId = reader.GetGuid(reader.GetOrdinal(@"UserId")),
                                Photo = reader.GetString(reader.GetOrdinal(@"Photo")),
                                Date = reader.GetDateTime(reader.GetOrdinal(@"Date")),
                            };
                        }           
                          logger.Error("Не найден пост " + postId);  
                          return new Posts();         
                    }
                }
            }
        }
        public bool AddCommentToPost(Guid postId, Comments com)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (GetUser(com.FromId).UserId != Guid.Empty)
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        com.ComId = Guid.NewGuid();
                        command.CommandText =@"insert into Comments (ComId, PostId, FromId, Text, Date) values (@comid, @postid, @fromid, @text, @date)";
                        command.Parameters.AddWithValue("@comid", com.ComId);
                        command.Parameters.AddWithValue("@postid", postId);
                        command.Parameters.AddWithValue("@fromid", com.FromId);
                        command.Parameters.AddWithValue("@text", com.Text);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.ExecuteNonQuery();
                        logger.Info("Пользователь {0} добавил комментарий {1}  к посту {2}", com.FromId, com.Text, postId);
                        return true;
                    }
                }
                logger.Info("Не удалось добавить комментарий {0}  к посту {1}", com.Text, postId);
                return false;
            }
        }

        public bool UpdateComment(Guid comId, string comNew)
        {
            logger.Info("Начато удаление комментария " + comId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (IsComment(comId))
                    {
                        command.CommandText = "update Comments set Text = @text where ComId = @comid";
                        command.Parameters.AddWithValue("@comid", comId);
                        command.Parameters.AddWithValue("@text", comNew);
                        command.ExecuteNonQuery();
                        logger.Info("Комментарий {0} изменён на {1}",comId,comNew);
                        return true;
                    }        
                        logger.Info("Не удалось изменить комментарий " + comId);
                        return false;            
                }
            }
        }

        public bool IsComment(Guid comId)
        {
            logger.Info("Поиск комментария " + comId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select FromId, PostId, ComId from Comments where @ComId = id";
                    command.Parameters.AddWithValue(@"id", comId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            logger.Info("Комментарий найден");
                            return true;
                        }
                        logger.Info("Коментарий не найден");
                        return false;
                    }
                }
            }
        }

        public void DeleteComment(Guid comId)
        {
            logger.Info("Начато удаление комментария " + comId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (IsComment(comId))
                    {
                        command.CommandText = "delete from Comments where ComId = @comid";
                        command.Parameters.AddWithValue("@comid", comId);
                        command.ExecuteNonQuery();
                        logger.Info("Удален комментарий " + comId);
                    }
                    else
                    {
                        logger.Info("Не удалось удалить комментарий " + comId);
                    }
                }
            }
        }
        public bool IsUser(Guid id)
        {
            logger.Info("Поиск пользователя " + id);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select UserId, Nickname from Users where @UserId = id";
                    command.Parameters.AddWithValue(@"id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            logger.Info("Пользователь найден");
                            return true;
                        }
                        logger.Info("Пользователь не найден");
                        return false;
                    }
                }
            }
        }

        public bool ExistsPost(Guid postId)
        {
            logger.Info("Поиск поста " + postId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select UserId, Photo, Date, PostId from Posts where PostId=@postid";
                    command.Parameters.AddWithValue(@"postid", postId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            logger.Info("Пост найден");
                            return true;
                        }
                        logger.Info("Пост не найден");
                        return false;
                    }
                }
            }
        }
        public bool UpdatePost(Guid postId, Posts newPost)
        {
            logger.Info("Попытка изменения поста c id " + postId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (ExistsPost(postId))
                    {            
                        command.CommandText = @"update Posts set Photo=@photo where PostId=@id";              
                        command.Parameters.AddWithValue("@id", postId);
                        command.Parameters.AddWithValue("@photo", newPost.Photo);                     
                        command.ExecuteNonQuery();
                        logger.Info("Изменён пост " + postId);
                        return true;
                    }
                    logger.Info("Не удалось изменить пост " + postId);
                    return false;
                }
            }
        }
        public List<Comments> GetPostComments(Guid postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PostId, FromId, Text, Date, ComId from Comments where PostId = @id";
                    command.Parameters.AddWithValue("@id", postId);
                    List<Comments> coms = new List<Comments>();       
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Comments somecom = new Comments
                            {
                                ComId = reader.GetGuid(reader.GetOrdinal("ComId")),
                                PostId = reader.GetGuid(reader.GetOrdinal("PostId")),
                                FromId = reader.GetGuid(reader.GetOrdinal("FromId")),
                                Text = reader.GetString(reader.GetOrdinal("Text")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date"))
                            };
                            coms.Add(somecom);
                        }
                    }
                    logger.Info("Просмотрены комментарии с поста '" + postId + "'");
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
                    command.CommandText = "select PostId, UserId, Photo, Date from Posts where UserId = @id";
                    command.Parameters.AddWithValue("@id", id);
                    List<Posts> posts = new List<Posts>();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Posts somepost = new Posts
                        {
                            PostId = reader.GetGuid(reader.GetOrdinal("PostId")),
                            UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                            Photo = reader.GetString(reader.GetOrdinal("Photo")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date"))
                        };
                        posts.Add(somepost);
                    }
                    logger.Info("Загружена стена пользователя " + id);
                    return posts;
                }
            }
        }
        public bool AddLike(Likes like) //userid - лайкнувший, postid - какой пост лайкнул
        {
            logger.Info("Добавление лайка к посту "+like.PostId);
            if ((GetPost(like.PostId)!=null)&&(IsLiked(like.PostId, like.UserId)))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"insert into Likes (PostId, UserId) values (@postid, @userid)";
                        command.Parameters.AddWithValue("@postid", like.PostId);
                        command.Parameters.AddWithValue("@userid", like.UserId);
                        command.ExecuteNonQuery();
                        logger.Info("Добавлен лайк к посту " + like.UserId);
                        return true;
                    }
                }
            }
            logger.Info("Не удалось поставить лайк к посту "+like.UserId);
            return false;
        }
        public List<Likes> GetPostLikes(Guid postId)
        {
            if (ExistsPost(postId))
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
                                PostId = reader.GetGuid(reader.GetOrdinal("PostId")),
                                UserId = reader.GetGuid(reader.GetOrdinal("UserId"))
                            };
                            likes.Add(somelike);
                        }
                        logger.Info("Просмотрены лайки с поста " + postId);
                        return likes;
                    }
                }
            }
            logger.Warn("При просмотре лайков не удалось обнаружить комментарий");
            throw new ArgumentException();
        }
        public void DeleteUser(Guid id)
        {
            logger.Info("Попытка удаления пользователя "+ id);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (GetUser(id).UserId!= Guid.Empty)
                    {
                        command.CommandText = "delete from Users where UserId = @userid";
                        command.Parameters.AddWithValue("@userid", id);
                        command.ExecuteNonQuery();
                        logger.Info("Пользователь " + id + " удалён");
                    }
                    else
                    {
                        logger.Warn("Пользователь " + id + " не существует");
                    }
                }
            }
        }
        public void DeletePost(Guid postId)
        {
            logger.Info("Начато удаление поста " + postId);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (ExistsPost(postId))
                    {
                        command.CommandText = "delete from Posts where PostId = @postid";
                        command.Parameters.AddWithValue("@postid", postId);
                        command.ExecuteNonQuery();
                        logger.Info("Удален пост " + postId);
                    }
                    else
                    {
                        logger.Info("Не удалось удалить пост " + postId);
                    }
                }
            }
        }
        public void DeleteLike(Guid postId, Guid userId)
        {
            if (ExistsPost(postId))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        if (IsLiked(postId, userId))
                        {
                            command.CommandText = "delete from Likes where PostId = @postid and UserId = @userid";
                            command.Parameters.AddWithValue("@postid", postId);
                            command.Parameters.AddWithValue("@userid", userId);
                            command.ExecuteNonQuery();
                            logger.Info("Пользователь " + userId + " убрал лайк с поста " + postId);
                        }
                    }
                }
            }
            else
            throw new ArgumentException();
        }
        public bool IsLiked(Guid postId, Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select PostId, UserId from Likes where PostId = @id AND UserId = @userId";
                    command.Parameters.AddWithValue("@id", postId);
                    command.Parameters.AddWithValue("@userId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.HasRows;
                    }
                }
            }
        }
        public Guid GetHashtag(string hashtag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"select ComId, Text from Hashtags where Text = @tag";
                    command.Parameters.AddWithValue("@tag", hashtag);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.HasRows ? reader.GetGuid(reader.GetOrdinal("ComId")) : Guid.Empty;
                    }
                }
            }
        }
        public void DeleteHashtag(Guid comId, string hashtag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                        command.CommandText = "delete from Hashtags where ComId = @comid and Text = @tag";
                        command.Parameters.AddWithValue("@comid", comId);
                        command.Parameters.AddWithValue("@tag", hashtag);
                        command.ExecuteNonQuery();
                        logger.Info("Удалён хэштег {0} с поста {1}", hashtag, comId);    
                }
            }
        }
        public void AddHashtag(Comments com, string hashtag)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"insert into Hashtags (ComId, Text ) values(@comid, @tag)";
                    command.Parameters.AddWithValue("@comid", com.ComId);
                    command.Parameters.AddWithValue("@tag", hashtag);
                    command.ExecuteNonQuery();
                    logger.Info("Добавлен хэштег {0} к посту {1}", hashtag, com.ComId);
                }
            }
        }
        public List<string> GetHashtags(Comments comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select ComId, Text from Hashtags where ComId = @id";
                    command.Parameters.AddWithValue("@id", comment.ComId);
                    List<string> tags = new List<string>();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        tags.Add(reader.GetString(reader.GetOrdinal("Text")));
                    }
                    logger.Info("Загружены теги с комментария {0}", comment.ComId);
                    return tags;
                }
            }
        }


    }
}
