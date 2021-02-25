using OB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OB.Data.Repositories
{
    public class MachineRepository : BaseRepository<Machine>
    {
        //-----------------------------------------------------
        public DataContext db { get; }
        //-----------------------------------------------------
        public MachineRepository(DataContext context) : base(context)
        {
            db = context;
        }
        //------------------------------------------------------------------------------------------

    }
}