using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackApp.DLL.Models;

namespace FullStackApp.BLL.Interface
{
    public interface ITeacherService
    {
        Task<Teacher> AddTaskAsync(Teacher teacher);
        Task<List<Teacher>> GetAllTasksAsync();
        Task<Teacher> GetTaskByIdAsync(int id);
        Task<Teacher> UpdateTaskAsync(Teacher teacher);
        Task<bool> DeleteTaskByIdAsync(int id);
    }
}
