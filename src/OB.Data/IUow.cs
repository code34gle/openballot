using OB.Data.Repositories;
using System;

namespace OB.Data
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