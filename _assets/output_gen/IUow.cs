using OB.Data.DataAccess.Repositories;
using System;

namespace OB.Data.DataAccess
{
    public interface IUow : IDisposable
    {
        //--------------------------------------------------------------------------

        CandidateRepository Candidates { get; }
        ElectionStateRepository ElectionStates { get; }
        MachineRepository Machines { get; }
        OfficeRepository Offices { get; }
        QuestionRepository Questions { get; }
        RegistrantRepository Registrants { get; }
        RoleRepository Roles { get; }
        UserAccountRepository UserAccounts { get; }
        UserAccountRoleRepository UserAccountRoles { get; }
        VoteRepository Votes { get; }

        //-----------------------------------------------
        void Commit();
        //-----------------------------------------------

    }
}