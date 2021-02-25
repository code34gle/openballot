using OB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OB.Data.Repositories
{
    public class VoteRepository : BaseRepository<Vote>
    {
        //-----------------------------------------------------
        public DataContext db { get; }
        //-----------------------------------------------------
        public VoteRepository(DataContext context) : base(context)
        {
            db = context;
        }
        //------------------------------------------------------------------------------------------

    }
}