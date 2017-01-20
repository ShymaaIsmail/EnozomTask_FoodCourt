using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Unit_Work
{
    public interface IUnitOfWork
    {
       
            DbContext GetContext();

            void Save();
            void Dispose();

        

    }
}
