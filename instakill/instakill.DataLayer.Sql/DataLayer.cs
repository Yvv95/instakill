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
                    user.IdUser = Guid.NewGuid();
                    command.CommandText = "insert into Users (IdUser, Nickname, Username, Status) values (@id, @nick, @name, @stat)";
                    command.Parameters.AddWithValue("@id", user.IdUser);
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
            throw new NotImplementedException();
        }
        public Users GetUser(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select IdUser, Nickname, Username from Users where IdUser = @id";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new Users
                        {
                            IdUser = reader.GetGuid(0),
                            Nickname = reader.GetString(1)
                        };
                    }
                }
            }
        }

        public Posts GetPost(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Comments AddCommentToPost(Comments text, Comments idFrom, Posts idPosts)          
        {
            throw new NotImplementedException();
        }

        public Comments GetPostComments(Guid postId)
        {
            throw new NotImplementedException(); 
            
        }
        /*pubic Posts GetLatestPosts(Guid id) //по id пользователя
        {
            throw new NotImplementedException(); 
            
        }*/

        public Likes AddLike(Likes like) //user - лайкнувший
        {
            throw new NotImplementedException();
        }

        public Likes GetPostLikes(Guid postId)
        {
            throw new NotImplementedException();
        }


    }
}
