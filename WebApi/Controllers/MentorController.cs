using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class MentorController:ControllerBase
{
    
    private MentorService _mentorService; 
    public MentorController(MentorService mentorService)
    {
        _mentorService=mentorService;
    }
    [HttpGet("GetMentors")]
    public List<MentorDto>GetMentors(){
        return _mentorService.GetMentors(null);
    }
 
   [HttpGet("GetMentor")]
    public MentorDto GetMentor(int id){
        return _mentorService.GetMentorById(id);
    }
     [HttpPost("AddMentor")]
    
    public MentorDto AddMentor(MentorDto mentor){
        return _mentorService.AddMentor(mentor);
    }

      [HttpDelete("Delete Mentor")]
    public int DeleteMentor(int id){
        return _mentorService.DeleteMentor(id);
    }

      [HttpPut("Update Mentor")]
    public MentorDto UpdateMent(MentorDto mentor){
        return _mentorService.UpdateMentor( mentor);
    }

}