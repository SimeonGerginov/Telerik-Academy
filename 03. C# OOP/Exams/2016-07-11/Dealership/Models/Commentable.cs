using System.Collections.Generic;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Commentable : ICommentable
    {
        private IList<IComment> comments;

        public Commentable()
        {
            this.Comments = new List<IComment>();
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                this.comments = value;
            }
        }
    }
}
