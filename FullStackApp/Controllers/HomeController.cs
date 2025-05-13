using FullStackApp.BLL.Interface;
using FullStackApp.DLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            this._studentService = studentService;
        }


        [HttpGet]
        [Route("AllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();

            
           

            if (students == null || !students.Any())
            {
                return NotFound("No students found.");
            }
            return new JsonResult(new { status = "Succes ", msg = "Success", data = students });


        }
        [HttpGet]
        [Route("LimitedStudents")]
        public async Task<IActionResult> GetLimitedStudents(int skip, int take)
        {
            var students = await _studentService.GetLimitedStudentsAsync(skip, take);

            if (students == null || !students.Any())
            {
                return NotFound("No students found.");
            }

            return Ok(students);
        }



        [HttpGet]
        [Route("ByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var student = await _studentService.GetTaskByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }


        [HttpPost]
        [Route("Student/{id}")] // Pass ID as a Route Parameter
        public async Task<IActionResult> PostStudent([FromBody] Student value, int id)
        {
            if (value == null)
            {
                return BadRequest("Invalid student data.");
            }

            var student = await _studentService.AddTaskAsync(value); // 🔹 Await Async Call
            return CreatedAtAction(nameof(GetByID), new { id = student.Id }, student);
        }


        // ✅ Update Student (Async)
        [HttpPut]
        [Route("ById/{id}")] // ✅ Fixed Route
        public async Task<IActionResult> PutById(int id, [FromBody] Student value)
        {
            if (value == null)
            {
                return BadRequest("Invalid Data: Student data is required.");
            }

            if (id != value.Id)
            {
                return BadRequest("Invalid Data: ID does not match.");
            }

            try
            {
                var updatedStudent = await _studentService.UpdateTaskAsync(value); // 🔹 Await Async Call
                if (updatedStudent == null)
                {
                    return NotFound("Student not found.");
                }

                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // ✅ Delete Student (Async)
        [HttpDelete]
        [Route("ByID/{id}")] // ✅ Fixed Route
        public async Task<IActionResult> DeleteByID(int id)
        {
            var student = await _studentService.GetTaskByIdAsync(id); // 🔹 Await Async Call
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            var isDeleted = await _studentService.DeleteTaskByIdAsync(id); // 🔹 Await Async Call
            if (!isDeleted)
            {
                return StatusCode(500, "Failed to delete student. Please try again.");
            }

            return Ok($"Student with ID {id} deleted successfully.");
        }

    }
}
