using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class GroupController:ControllerBase
{
    
    private GroupService _groupsService; 
    public GroupController(GroupService groupeService)
    {
        _groupsService=groupeService;
    }
    [HttpGet("GetGroups")]
    public List<GroupDto>GetGroups(){
        return _groupsService.GetGroups(null);
    }
 
   [HttpGet("GetGroup")]
    public GroupDto GetGroup(int id){
        return _groupsService.GetGroupById(id);
    }
     [HttpPost("AddGroup")]
    
    public GroupDto AddGroup(GroupDto group){
        return _groupsService.AddGroup(group);
    }

      [HttpDelete("Delete Group")]
    public int DeleteGroup(int id){
        return _groupsService.DeleteGroup(id);
    }

      [HttpPut("Update Group")]
    public GroupDto UpdateGroup(GroupDto group){
        return _groupsService.UpdateGroup( group);
    }

}