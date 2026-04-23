//Crea un programa que gestione las notas de alumnos en un archivo de texto. 
//Cada línea: nombre; nota1; nota2; nota3.
//Permite: añadir alumno, ver todos, calcular medias, encontrar mejor/peor alumno.

using System.Security.Cryptography;

Subject subject1 = new Subject("Data types");
Subject subject2 = new Subject("Operators");
Subject subject3 = new Subject("Loops");
Subject subject4 = new Subject("Conditionals");

StudentGrade student1 = new StudentGrade("Manuel", "Martinez", new Dictionary<Subject, double>
{
    { subject1, 8.5 },
    { subject2, 9.0 },
    { subject3, 7.8 },
    { subject4, 7.8 }
});

StudentGrade student2 = new StudentGrade("Miguel", "Guerrero", new Dictionary<Subject, double>
{
    { subject1, 6.5 },
    { subject2, 7.0 },
    { subject3, 5.0 },
    { subject4, 4.5 }
});

StudentGrade student3 = new StudentGrade("Covadonga", "García", new Dictionary<Subject, double>
{
    { subject1, 8.5 },
    { subject2, 7.0 },
    { subject3, 6.5 },
    { subject4, 7.5 }
});

List<StudentGrade> students = new List<StudentGrade>
{
    student1,
    student2,
    student3
};

MainMenu();

void MainMenu()
{
    Console.WriteLine("""

        -----------------------------------------
        Welcome to Student Grade Manager.
        -----------------------------------------

        Please, choose an option:
        1) Show every grades.
        2) Show student grades.
        3) Calculate student average.
        4) List students by average grade.

        """);

    int option = int.TryParse(Console.ReadLine(),out int number) ? number : 0;
        
    switch (option)
    {
        case 1:
            ShowAllStudentsGrades();
            break;
        case 2:
            ShowStudentGrades();
            break;
        case 3:
            break;
        case 4:
            break;
        default:
            Console.WriteLine("\nChoose a valid option, please.");
            MainMenu();
            break;
    };
}


void ShowAllStudentsGrades()
{
    foreach(StudentGrade student in students)
    {
        Console.WriteLine($"""

            ============================================
            Student Name: {student.Name} {student.Surname}
            -------------------------------------------
            """);
        foreach(Subject subject in student.Grades.Keys)
        {
            Console.WriteLine($"{subject.Name}:");
            Console.WriteLine($"    --------------------> | { student.Grades[subject]} | ");
        }
        Console.WriteLine("-------------------------------------------");
    }

    Console.WriteLine("\nEnter anything to show main menu again");
    Console.ReadLine();
    MainMenu();

}

void ShowStudentGrades()
{
    int studentNumber = 1;

    Console.WriteLine("""

        Which student do you want to see the grades of?:
        (Select a number, please)

        """);
    
    foreach (StudentGrade student in students)
    {
        Console.WriteLine($"{studentNumber++}) {student.Name} {student.Surname}");
    }

    int option = int.TryParse(Console.ReadLine(), out int number) ? number : 0;
    
    if(option > 0 && option <= students.Count)
    {
        option -= 1;
        Console.WriteLine($"""

            ============================================
            Student Name: {students[option].Name} {students[option].Surname}
            -------------------------------------------
            """);

        for (int i = 0; i <= students.Count; i++)
        {
            Console.WriteLine($"{students[option].Grades.ElementAt(i).Key.Name}:");
            Console.WriteLine($"    --------------------> | {students[option].Grades.ElementAt(i).Value} | ");
        }
    }
    else
    {
        Console.WriteLine("\nChoose a valid option, please.");
        ShowStudentGrades();
    }

     Console.WriteLine("\nEnter anything to show main menu again");
     Console.ReadLine();
     MainMenu();
}

public class StudentGrade
{
    public StudentGrade(string name, string surname, Dictionary<Subject, double> grades)
    {
        Name = name;
        Surname = surname;
        Grades = grades;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Dictionary<Subject,double> Grades { get; set; }
}
public class Subject
{
    public Subject(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}