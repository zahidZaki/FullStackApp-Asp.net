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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Teacher> AddTaskAsync(Teacher teacher)
        {
            await _unitOfWork.schoolDbContext.Teachers.AddAsync(teacher);
            await _unitOfWork.schoolDbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            var teacher = await _unitOfWork.schoolDbContext.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return false;
            }
            _unitOfWork.schoolDbContext.Teachers.Remove(teacher);
            await _unitOfWork.schoolDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<Teacher>> GetAllTasksAsync()
        {
            try
            {
                var result = await _unitOfWork.schoolDbContext.Teachers.ToListAsync();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<Teacher> GetTaskByIdAsync(int id)
        {
            var result = await _unitOfWork.schoolDbContext.Teachers.FindAsync(id);
            return result;
        }

        public async Task<Teacher> UpdateTaskAsync(Teacher teacher)
        {
            var result = await _unitOfWork.schoolDbContext.Teachers.FindAsync(teacher.Id);
            if (result == null)
            {
                throw new Exception("Teacher not found");
            }
            result.Name = teacher.Name;
            result.Email = teacher.Email;
            result.Subject = teacher.Subject;
            result.HireDate = teacher.HireDate;
            result.PhoneNumber = teacher.PhoneNumber;
            _unitOfWork.schoolDbContext.Entry(result).State = EntityState.Modified;
            await _unitOfWork.schoolDbContext.SaveChangesAsync();
            return result;
        }


    }
}
