using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public static class DatabaseOperations
    {

        public static List<T> FullListOfType<T>() where T : class
        {
            using (JamventionEntities entities = new JamventionEntities())
            {
                return entities.Set<T>().ToList();
            }
        }
    }
}
