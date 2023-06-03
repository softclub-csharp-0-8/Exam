// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var StudentService= new StudentService();

//ShowStudent(null);
//GetByIdStudent(8);
//DeleteStudent();
//AddStudent();
//UpdateStudet();

void ShowStudent(string name){
var studentt=StudentService.GetStudents(name);
Console.WriteLine("Id / FirstName / LastNma / Email / Gender / IpAddress");
foreach (var stud in studentt)
{
    Console.WriteLine($"{stud.Id}, {stud.FirstName}, {stud.LastName}, {stud.Email}, {stud.Phone}, {stud.Address}, {stud.City}");
}
}

void GetByIdStudent (int id){
    var rr=StudentService.GetStudentById(id);
    System.Console.WriteLine($"{rr.Id}");
    System.Console.WriteLine($"{rr.FirstName}");

}
void AddStudent (){

    Console.WriteLine($"Enter student Firstname");
    var studentf=new StudentDto();
studentf.FirstName=Console.ReadLine();
    Console.WriteLine($"Enter student LastName");
    studentf.LastName=Console.ReadLine();
    Console.WriteLine($"Enter student Email");

studentf.Email=Console.ReadLine();
    Console.WriteLine($"Enter student Phone");

studentf.Phone=Console.ReadLine();
    Console.WriteLine($"Enter student Address");
studentf.Address=Console.ReadLine();
    Console.WriteLine($"Enter student City");
studentf.City=Console.ReadLine();

    var result=StudentService.AddStudent(studentf);
    System.Console.WriteLine(result.FirstName);
    System.Console.WriteLine(result.LastName);
}
void UpdateStudet (){
    Console.WriteLine("Enter student ID");
    int id = Convert.ToInt32(Console.ReadLine());

    var rr=StudentService.GetStudentById(id);

Console.WriteLine("Studet's datas");
    Console.WriteLine($"{rr.Id}");
        Console.WriteLine($"{rr.Id}");

    Console.WriteLine($"{rr.FirstName}");
    rr.FirstName=Console.ReadLine();
    Console.WriteLine($"{rr.LastName}");
        rr.LastName=Console.ReadLine();

    Console.WriteLine($"{rr.Email}");
        rr.Email=Console.ReadLine();

    Console.WriteLine($"{rr.Phone}");
        rr.Phone=Console.ReadLine();

         Console.WriteLine($"{rr.City}");
        rr.City=Console.ReadLine();

    Console.WriteLine($"{rr.Address}");
        rr.Address=Console.ReadLine();


    var result=StudentService.UpdateStudent(rr);
}
void DeleteStudent(){
    Console.WriteLine("Enter student ID");
      int id = Convert.ToInt32(Console.ReadLine());

    var rr=StudentService.DeleteStud(id);
}
