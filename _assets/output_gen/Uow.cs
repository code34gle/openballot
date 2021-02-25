using OB.Data.Data.Entities;
using OB.Data.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace OB.Data.Data
{
    public class Uow : IUow
    {
        //--------------------------------------------------------------------------
        public DataContext db { get; }
        //--------------------------------------------------------------------------

        public CandidateRepository Candidates { get; set;}
        public ElectionStateRepository ElectionStates { get; set;}
        public MachineRepository Machines { get; set;}
        public OfficeRepository Offices { get; set;}
        public QuestionRepository Questions { get; set;}
        public RegistrantRepository Registrants { get; set;}
        public RoleRepository Roles { get; set;}
        public UserAccountRepository UserAccounts { get; set;}
        public UserAccountRoleRepository UserAccountRoles { get; set;}
        public VoteRepository Votes { get; set;}

        //--------------------------------------------------------------------------

        //--------------------------------------------------------------------------
        public Uow(DataContext context)
        {
            db = context;
            //------------------------------------------------

            Candidates = new CandidateRepository(db)
            ElectionStates = new ElectionStateRepository(db)
            Machines = new MachineRepository(db)
            Offices = new OfficeRepository(db)
            Questions = new QuestionRepository(db)
            Registrants = new RegistrantRepository(db)
            Roles = new RoleRepository(db)
            UserAccounts = new UserAccountRepository(db)
            UserAccountRoles = new UserAccountRoleRepository(db)
            Votes = new VoteRepository(db)

            //------------------------------------------------
        }
        //--------------------------------------------------------------------------
        public void Commit()
        {
           db.SaveChanges();
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
        #region Disposable
        //--------------------------------------------------------------------------
        private bool disposed = false;
        //--------------------------------------------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        //--------------------------------------------------------------------------
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //--------------------------------------------------------------------------
        #endregion
        //--------------------------------------------------------------------------
    }
}