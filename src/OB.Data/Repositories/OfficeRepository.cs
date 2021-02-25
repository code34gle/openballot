using OB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OB.Data.Repositories
{
    public class OfficeRepository : BaseRepository<Office>
    {
        //-----------------------------------------------------
        public DataContext db { get; }
        //-----------------------------------------------------
        public OfficeRepository(DataContext context) : base(context)
        {
            db = context;
        }
        //------------------------------------------------------------------------------------------

    }
}