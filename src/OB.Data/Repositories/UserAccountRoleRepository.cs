using OB.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OB.Data.Repositories
{
    public class UserAccountRoleRepository : BaseRepository<UserAccountRole>
    {
        //-----------------------------------------------------
        public DataContext db { get; }
        //-----------------------------------------------------
        public UserAccountRoleRepository(DataContext context) : base(context)
        {
            db = context;
        }
        //------------------------------------------------------------------------------------------

    }
}