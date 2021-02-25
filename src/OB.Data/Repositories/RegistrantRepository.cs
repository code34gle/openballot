using OB.Data.Entities;

namespace OB.Data.Repositories
{
    public class RegistrantRepository : BaseRepository<Registrant>
    {
        //--------------------------------------------------------------------------
        public DataContext db { get; }
        //--------------------------------------------------------------------------
        public RegistrantRepository(DataContext context) : base(context)
        {
            this.db = context;
        }
        //-------------------------------------------------------------------------------------------
    }
}
