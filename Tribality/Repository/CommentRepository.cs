using Tribality.Models;

namespace Tribality.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {      
        public CommentRepository(ISessionBuilder sessionManager) : base(sessionManager) { }

        public override void Save(Comment entity)
        {
            Require.A(entity.Post);
            Require.A(entity.Poster);
            base.Save(entity);
        }
    }
}
