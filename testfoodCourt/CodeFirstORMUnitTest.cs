using System;
using DBModel.DBContext;
using DBModel.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Data.Entity.Validation;

namespace testfoodCourt
{
    [TestClass]
    public class CodeFirstORMUnitTest
    {
        [TestMethod]
        public void InsertTest()
        {

            using (var ctx = new FoodCourtContext())
            {
                //string cstring = ((IObjectContextAdapter)ctx).ObjectContext.Connection.ConnectionString;
                try
                {
                    Store stud = new Store() { StoreName = "Costa Costa Costa",StoreDescription="desc desc desc" };

                    ctx.Stores.Add(stud);
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                        ); // Add the original exception as the innerException
                }
            }
        }
      

      
    }
}
