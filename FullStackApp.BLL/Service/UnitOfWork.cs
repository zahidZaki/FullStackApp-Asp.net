using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackApp.BLL.Interface;
using FullStackApp.DLL.Models;
using ProjectForLearing.DLL.Models;

namespace FullStackApp.BLL.Service
{
    public class UnitOfWork  : IUnitOfWork
    {
        public SchoolDbContext schoolDbContext { get; }


        public UnitOfWork(SchoolDbContext context)
        {
            schoolDbContext = context;
            ; // Instance assign kiya
        }


        public async Task<int> CompleteAsync()
        {
            return await schoolDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            schoolDbContext.Dispose();
        }
    }
}
