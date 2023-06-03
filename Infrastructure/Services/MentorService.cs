using Dapper;
using Npgsql;
public class MentorService
{
    
  private DapperContext _context;

    public MentorService(DapperContext context)
    {
        _context=context;

    }

    //get all mentors

 public List<MentorDto>GetMentors(string? name)
    {
    using(var conn=_context.CreateConnection() ){
        var sql="select id as Id,firstname FirstName ,lastname LastName,email Email,phone Phone,address Address, city City from mentors";
        if (name!=null)
       sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<MentorDto>(sql, new { Name = name });
       return result.ToList();
    }
    }

      // get by id
     public MentorDto GetMentorById(int id)
    {
    using(var conn=_context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,firstname FirstName ,lastname LastName,email Email,phone Phone,address Address, city City from mentors where id=@ID";
       var result = conn.QuerySingle<MentorDto>(sql,new {Id=id});
       return result;
    }
    }

      public MentorDto AddMentor(MentorDto mentor)
    {
    using(var conn= _context.CreateConnection()){
        var sql=$"insert into mentors(id,firstname  ,lastname ,email ,phone ,address,city)values ( @Id,@FirstName, @LastName,  @Email,  @Phone, @Address,@City) returning id";
       var result = conn.Execute(sql,new {mentor.Id,mentor.FirstName,mentor.LastName,mentor.Email,mentor.Phone,mentor.Address,mentor.City});
       mentor.Id=result;
       return mentor;
    }
    }
       public MentorDto UpdateMentor(MentorDto mentor)
    {
    using(var conn= _context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update teachers set id=@Id,first_name=@FirstName,last_name=@LastName, email= @Email,gender=@Gender ,ip_address=@IpAddress where id=5 returning id";
       var result = conn.Execute(sql,new {mentor.Id,mentor.FirstName,mentor.LastName,mentor.Email,mentor.Phone,mentor.Address,mentor.City});
       mentor.Id=result;
       return mentor;
    }
    }
        public  int DeleteMentor(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from mentors where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }











}