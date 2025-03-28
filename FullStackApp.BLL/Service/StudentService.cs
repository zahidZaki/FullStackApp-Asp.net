using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackApp.BLL.Interface;
using FullStackApp.DLL.ExtensionMethods;
using FullStackApp.DLL.Models;
using FullStackApp.Utils.DTOs;
using Microsoft.EntityFrameworkCore;
using ProjectForLearing.DLL.Models;

namespace FullStackApp.BLL.Service
{
    public class StudentService : IStudentService
    {
        SchoolDbContext _schoolDbContext;

        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Student> AddTaskAsync(Student student)
        {
            await _unitOfWork.schoolDbContext.Students.AddAsync(student);
            await _unitOfWork.schoolDbContext.SaveChangesAsync();
            return student;
        }

        //// ✅ Get All Students (Async)
        public async Task<List<Student>> GetAllStudentsAsync(StudentDTO studentDTO)
        {
            try
            {
                var result = await _unitOfWork.schoolDbContext
                    .LoadStoredProc("[spGetAllStudent]")
                    .ExecuteStoredProc<Student>();

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception instead of rethrowing it blindly
                Console.WriteLine($"Error in GetAllStudentsAsync: {ex.Message}");
                throw;
            }
        }


        public async Task<Student> GetTaskByIdAsync(int id)
        {
            var result = await _unitOfWork.schoolDbContext.Students.FindAsync(id);
            return result;
        }

        public async Task<Student> UpdateTaskAsync(Student student)
        {
            var existingStudent = await _unitOfWork.schoolDbContext.Students.FindAsync(student.Id);
            if (existingStudent == null)
            {
                throw new Exception("Student not found.");
            }

            existingStudent.Name = student.Name;
            existingStudent.Class = student.Class;
            existingStudent.Email = student.Email;

            _unitOfWork.schoolDbContext.Entry(existingStudent).State = EntityState.Modified;
            await _unitOfWork.schoolDbContext.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            var student = await _unitOfWork.schoolDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return false; // Student not found
            }

            _unitOfWork.schoolDbContext.Students.Remove(student);
            await _unitOfWork.schoolDbContext.SaveChangesAsync();
            return true; // Successfully deleted
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            try
            {
                var result = await _unitOfWork.schoolDbContext
                    .LoadStoredProc("[sp_GetAllStudent]")
                    .ExecuteStoredProc<Student>();

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception instead of rethrowing it blindly
                Console.WriteLine($"Error in GetAllStudentsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Student>> GetLimitedStudentsAsync(int skip, int take)
        {
            try
            {
                var result = await _unitOfWork.schoolDbContext
                    .LoadStoredProc("[sp_SelectRows]")
                    .WithSqlParam("@offsetRows", skip)
                    .WithSqlParam("@fetchRows", take)
                    .ExecuteStoredProc<Student>();

                return result.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception instead of rethrowing it blindly
                Console.WriteLine($"Error in GetAllStudentsAsync: {ex.Message}");
                throw;
            }
        }
    }
}
