using OB.Data.Repositories;
using System;

namespace OB.Data
{
    public class Uow : IUow
    {
        //--------------------------------------------------------------------------
        public DataContext db { get; }
        //--------------------------------------------------------------------------  Authority
        public RegistrantRepository Registrants { get; set; }


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
