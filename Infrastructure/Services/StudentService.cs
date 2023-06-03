using Dapper;
using Npgsql;
public class StudentService
{
    
  private DapperContext _context;

    public StudentService(DapperContext context)
    {
        _context=context;

    }

    //get all students

 public List<StudentDto>GetStudents(string? name)
    {
    using(var conn=_context.CreateConnection() ){
        var sql="select id as Id,firstname FirstName ,lastname LastName,email Email,phone Phone,address Address, city City from students";
        if (name!=null)
       sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<StudentDto>(sql, new { Name = name });
       return result.ToList();
    }
    }

      // get by id
     public StudentDto GetStudentById(int id)
    {
    using(var conn=_context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,firstname FirstName ,lastname LastName,email Email,phone Phone,address Address, city City from students where id=@ID";
       var result = conn.QuerySingle<StudentDto>(sql,new {Id=id});
       return result;
    }
    }

      public StudentDto AddStudent(StudentDto student)
    {
    using(var conn= _context.CreateConnection()){
        var sql=$"insert into students(id,firstname  ,lastname ,email ,phone ,address,city)values ( @Id,@FirstName, @LastName,  @Email,  @Phone, @Address,@City) returning id";
       var result = conn.Execute(sql,new {student.Id,student.FirstName,student.LastName,student.Email,student.Phone,student.Address,student.City});
       student.Id=result;
       return student;
    }
    }
       public StudentDto UpdateStudent(StudentDto student)
    {
    using(var conn= _context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update students set id=@Id,firstname=@FirstName,lastname=@LastName, email= @Email,phone=@Phone ,address=@Address city=@City where id=@Id returning id";
       var result = conn.Execute(sql,new {student.Id,student.FirstName,student.LastName,student.Email,student.Phone,student.Address,student.City});
       student.Id=result;
       return student;
    }
    }
        public  int DeleteStud(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from students where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }











}