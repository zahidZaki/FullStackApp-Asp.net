using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackApp.BLL.Interface;
using FullStackApp.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackApp.BLL.Service
{
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Department>> GetAllTasksAsync()
        {
            try
            {
                var result = await _unitOfWork.schoolDbContext.Departments.ToListAsync();
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
