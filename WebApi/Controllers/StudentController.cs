using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController:ControllerBase
{
    
    private StudentService _studentService; 
    public StudentController(StudentService studentService)
    {
        _studentService=studentService;
    }
    [HttpGet("GetStudents")]
    public List<StudentDto>GetStudents(){
        return _studentService.GetStudents(null);
    }
 
   [HttpGet("GetStudent")]
    public StudentDto GetStudent(int id){
        return _studentService.GetStudentById(id);
    }
     [HttpPost("AddStudent")]
    
    public StudentDto AddStudent(StudentDto student){
        return _studentService.AddStudent(student);
    }

      [HttpDelete("Delete Student")]
    public int DeleteStud(int id){
        return _studentService.DeleteStud(id);
    }

      [HttpPut("Update Student")]
    public StudentDto UpdateStud(StudentDto student){
        return _studentService.UpdateStudent( student);
    }

}