using JamventionDAL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private IRepository<Guest> _repoGuests;
        private IRepository<Nationality> _repoNationality;
        private IRepository<GuestRole> _repoGuestRoles;
        private IRepository<Residence> _repoResidences;
        public UnitOfWork(JamventionEntities jamventionEntities)
        {
            this.JamventionEntities = jamventionEntities;

        }
        private JamventionEntities JamventionEntities { get; }
        public IRepository<Guest> RepoGuests { 
                 get
                 {
                 if (_repoGuests == null)
                  {
                    _repoGuests = new Repository<Guest>(this.JamventionEntities);
                  }
                  return _repoGuests;
                 }
        }

        public IRepository<Nationality> RepoNationality
        {
            get
            {
                if (_repoNationality == null)
                {
                    _repoNationality = new Repository<Nationality>(this.JamventionEntities);
                }
                return _repoNationality;
            }
        }

        public IRepository<GuestRole> RepoGuestRoles
        {
            get
            {
                if (_repoGuestRoles == null)
                {
                    _repoGuestRoles = new Repository<GuestRole>(this.JamventionEntities);
                }
                return _repoGuestRoles;
            }
        }

        public IRepository<Residence> RepoResidence
        {
            get
            {
                if (_repoResidences == null)
                {
                    _repoResidences = new Repository<Residence>(this.JamventionEntities);
                }
                return _repoResidences;
            }
        }

        public void Dispose()
        {
            JamventionEntities.Dispose();
        }

        public int Save()
        {
            return JamventionEntities.SaveChanges();
        }
    }
}
