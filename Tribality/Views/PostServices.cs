using System;
using Tribality.Models;
using Tribality.Repository;
using System.Collections.Generic;

namespace Tribality.Services
{
    public interface IPostServices
    {
        IList<Comment> GetNewComments(string postID);
        IList<Comment> GetNewComments(string postID, int lastCommentID);
        BlogPost GetByPrettyUrl(string url);        
        void Save(BlogPost blogPost);
        IList<BlogPost> Recent(int pageNumber);
    }

    public class PostServices : IPostServices
    {
        private const int PAGE_SIZE = 10;
        IBlogPostRepository blogPostRepository;
        public static int commentID = 1;

        public IList<Comment> GetNewComments(string postNumber)
        {
            int lastCommentID = 0;
            return GetNewComments(postNumber, lastCommentID);
        }

        public IList<Comment> GetNewComments(string postNumber, int lastCommentID)
        {
    		var commentList = new List<Comment>();
            for (int i = 0; i < 3; i++)
            {
                commentList.Add(new Comment {
                    Body = "Here's comment " + commentID++.ToString(),
                    Date = DateTime.Now,
                    ID = commentID,
                    Poster = new User { ID = 1, Email = "ignu.smith@gmail.com", UserName = "ignu" }
                });
            }
            return commentList;
        }

        public IList<BlogPost> Recent(int pageNumber)
        {
            return this.blogPostRepository.GetNewest(pageNumber, PAGE_SIZE);
        }

        public PostServices(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        
        private bool postDoesNotExist(string url)
        {
            return blogPostRepository.GetBy("PrettyUrl", url) != null && blogPostRepository.GetBy("PrettyUrl",url).ID != null;
        }
        

        private string getUniqueUrl(BlogPost blogPost)
        {
            string url = blogPost.Subject.ToUrl();

            if (postDoesNotExist(url))
                url += "-" + blogPost.Owner.UserName;

            while (postDoesNotExist(url))
            {
                url += "-1";
            }
            return url;
        }

        public BlogPost GetByPrettyUrl(string url)
        {
            return blogPostRepository.GetBy("PrettyUrl", url);
        }



        public void Save(BlogPost blogPost)
        {            
            Check.NotNull(blogPost, "Post Can not Be Null");
            Check.NotNull(blogPost.Owner, "Post Owner must be specified");

            if (String.IsNullOrEmpty(blogPost.PrettyUrl))
                blogPost.PrettyUrl = getUniqueUrl(blogPost);

            blogPostRepository.Save(blogPost);
            blogPostRepository.Flush();
        }        
    }

    
}
