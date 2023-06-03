using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController:ControllerBase
{
    
    private CourseService _courseService; 
    public CourseController(CourseService courseService)
    {
        _courseService=courseService;
    }
    [HttpGet("GetCourses")]
    public List<CourseDto>GetCourse(){
        return _courseService.GetCourses(null);
    }
 
   [HttpGet("GetCourse")]
    public CourseDto GetCourse(int id){
        return _courseService.GetCourseById(id);
    }
     [HttpPost("AddCourse")]
    
    public CourseDto AddCourse(CourseDto course){
        return _courseService.AddCourse(course);
    }

      [HttpDelete("Delete Cours")]
    public int DeleteCourse(int id){
        return _courseService.DeleteCourse(id);
    }

      [HttpPut("Update Cours")]
    public CourseDto UpdateCourse(CourseDto course){
        return _courseService.UpdateCourse( course);
    }

}