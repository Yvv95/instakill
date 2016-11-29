using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace instakill.Model
{
    public interface IDataLayer
    {
        #region Users
        Users AddUser(Users user);
        void DeleteUser(Guid id);
        Users GetUser(Guid id);
        bool UpdateUser(Guid id, Users userChanged);
        bool IsUser(Guid id);
        #endregion

        #region Posts
        Posts AddPost(Posts post);
        Posts GetPost(Guid postId);
        void DeletePost(Guid postId);
        List<Comments> GetPostComments(Guid postId);
        List<Posts> GetLatestPosts(Guid id); //по id пользователя
        bool UpdatePost(Guid postId, Posts newPost);
        bool ExistsPost(Guid postId);
        #endregion

        #region Likes
        bool AddLike(Likes like);//user - лайкнувший
        List<Likes> GetPostLikes(Guid postId);
        void DeleteLike(Guid postId, Guid userId);
        bool IsLiked(Guid postId, Guid userId);
        #endregion

        #region Hashtags
        List<string> GetHashtags(Comments comment);
        Guid GetHashtag(string hashtag);
        void DeleteHashtag(Guid comId, string hashtag);
        void AddHashtag(Comments com, string hashtag);
        #endregion

        /*#region Subscriptions
        bool IsFollower(Users user, Users userFollow);
        List<Users> GetFollowers(Users user);
        void AddSubscription(Users user, Users friendUser);
        bool IsSubscription(Users user, Users friendUser);
        void DeleteSubscription(Users user, Users friendUser);
        List<Users> GetSubscription(Users user);
        #endregion*/

        #region Comments
        bool AddCommentToPost(Guid postId, Comments com);
        void DeleteComment(Guid comId);
        bool UpdateComment(Guid comId, string comNew);
        bool IsComment(Guid comId);

        #endregion
    }
}
