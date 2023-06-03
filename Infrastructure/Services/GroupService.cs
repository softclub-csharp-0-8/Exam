using Dapper;
using Npgsql;
public class GroupService
{
    
  private DapperContext _context;

    public GroupService(DapperContext context)
    {
        _context=context;

    }

    //get all groups

 public List<GroupDto>GetGroups(string? name)
    {
    using(var conn=_context.CreateConnection() ){
        var sql="select id as Id,groupname GroupName ,groupdescription GroupDescription,courseid CoursId from groups";
        if (name!=null)
       sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<GroupDto>(sql, new { Name = name });
       return result.ToList();
    }
    }

      // get by id
     public GroupDto GetGroupById(int id)
    {
    using(var conn=_context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,groupname GroupName ,groupdescription GroupDescription,courseid CoursId from students where id=@ID";
       var result = conn.QuerySingle<GroupDto>(sql,new {Id=id});
       return result;
    }
    }

      public GroupDto AddGroup(GroupDto group)
    {
    using(var conn= _context.CreateConnection()){
        var sql=$"insert into groups(id,groupname  ,groupdescription ,courseid )values ( @Id,@GroupName, @GroupDescription,  @CoursId) returning id";
       var result = conn.Execute(sql,new {group.Id,group.GroupName,group.GroupDescription,group.CoursId});
       group.Id=result;
       return group;
    }
    }
       public GroupDto UpdateGroup(GroupDto group)
    {
    using(var conn= _context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update groups set id=@Id,groupname=@GroupName,groupdescription=@GroupDescription, courseid= @CoursId where id=5 returning id";
       var result = conn.Execute(sql,new {group.Id,group.GroupName,group.GroupDescription,group.CoursId});
       group.Id=result;
       return group;
    }
    }
        public  int DeleteGroup(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from groups where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }











}