using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instakill.Model
{
    public interface IDataLayer
    {
        Users AddUser(Users user);
        Posts AddPost(Posts post);
        Users GetUser(Guid id);
        Posts GetPost(Guid postId);
        Comments AddCommentToPost(Guid postId, Comments comment);
        List<Comments> GetPostComments(Guid postId);
        List<Posts> GetLatestPosts(Guid id); //по id пользователя
        Likes AddLike(Likes like);//user - лайкнувший
        List<Likes> GetPostLikes(Guid postId);
        void DeleteUser(Guid id);
        void DeletePost(Guid postId);
        void DeleteLike(Guid postId, Guid userId);
    }
}
