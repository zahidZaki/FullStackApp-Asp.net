using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectForLearing.DLL.Models;

namespace FullStackApp.BLL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public SchoolDbContext schoolDbContext { get; }

        Task<int> CompleteAsync();


    }
}
