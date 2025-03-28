using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackApp.DLL.Models;

namespace FullStackApp.BLL.Interface
{
    public interface IStudentService  // ✅ Fixed Spelling
    {
        Task<Student> AddTaskAsync(Student student);  // ✅ Made Async
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Student>> GetLimitedStudentsAsync(int skip, int take);
        Task<Student> GetTaskByIdAsync(int id);
        Task<Student> UpdateTaskAsync(Student student);
        Task<bool> DeleteTaskByIdAsync(int id);  // ✅ Returns bool
    }
}
