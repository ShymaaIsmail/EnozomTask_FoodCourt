using DBModel.DBContext;
using Repository.Unit_Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Repository.Unit_Work
{
    public class UnitofWork : IDisposable, IUnitOfWork
    {
        private FoodCourtContext context = new FoodCourtContext();
        private bool bDisposed = false;

       public DbContext GetContext(){
           return context;
        }
        public void Save()
        {
            this.context.SaveChanges();
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.bDisposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.bDisposed = true;
        }

    }

}