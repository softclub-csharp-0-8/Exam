using Dapper;
using Npgsql;
public class CourseService
{
    
  private DapperContext _context;

    public CourseService(DapperContext context)
    {
        _context=context;

    }

    //get all Courses

 public List<CourseDto>GetCourses(string? name)
    {
    using(var conn=_context.CreateConnection() ){
        var sql="select id as Id,coursedescription CourseDescription,coursename CourseName ,fee Fee,duration Duration,startdate StartDate,enddate EndDate, studentlimit StudentLimit from courses";
        if (name!=null)
       sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<CourseDto>(sql, new { Name = name });
       return result.ToList();
    }
    }

      // get by id
     public CourseDto GetCourseById(int id)
    {
    using(var conn=_context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,coursedescription CourseDescription,coursename CourseName ,fee Fee,duration Duration,startdate StartDate,enddate EndDate, studentlimit StudentLimit from courses where id=@ID";
       var result = conn.QuerySingle<CourseDto>(sql,new {Id=id});
       return result;
    }
    }

      public CourseDto AddCourse(CourseDto course)
    {
    using(var conn= _context.CreateConnection()){
        var sql=$"insert into courses(id,coursedescription  ,coursename ,fee ,duration ,startdate,enddate,studentlimit)values ( @Id,@CourseDescription, @CourseName,  @Fee,  @Duration, @StartDate,@EndDate,@StudentLimit) returning id";
       var result = conn.Execute(sql,new {course.Id,course.CourseDescription,course.CourseName,course.Fee,course.Duration,course.StartDate,course.EndDate,course.StudentLimit});
       course.Id=result;
       return course;
    }
    }
       public CourseDto UpdateCourse(CourseDto course)
    {
    using(var conn= _context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update courses set id=@Id,coursedescription=@CourseDescription,coursename=@CourseName, fee= @Fee,duration=@Duration ,startdate=@StartDate,enddate= @EndDate,studentlimit=@StudentLimit where id=@Id returning id";
       var result = conn.Execute(sql,new {course.Id,course.CourseDescription,course.CourseName,course.Fee,course.Duration,course.StartDate,course.EndDate,course.StudentLimit});
       course.Id=result;
       return course;
    }
    }
        public  int DeleteCourse(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from courses where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }











}