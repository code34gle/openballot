using OB.Data.Repositories;
using System;

namespace OB.Data
{
    public interface IUow : IDisposable
    {
        //--------------------------------------------------------------------------
        RegistrantRepository Registrants { get; }
        //-----------------------------------------------    
        void Commit();
        //--------------------------------------------------------------------------
    }
}
