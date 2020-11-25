using JamventionDAL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Guest> RepoGuests { get; }
        IRepository<Nationality> RepoNationality { get; }
        IRepository<GuestRole> RepoGuestRoles { get; }
        IRepository<Residence> RepoResidence { get; }

        int Save();
    }
}
