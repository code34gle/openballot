using OB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OB.Data.Repositories
{
    public class ElectionStateRepository : BaseRepository<ElectionState>
    {
        //-----------------------------------------------------
        public DataContext db { get; }
        //-----------------------------------------------------
        public ElectionStateRepository(DataContext context) : base(context)
        {
            db = context;
        }
        //------------------------------------------------------------------------------------------

    }
}