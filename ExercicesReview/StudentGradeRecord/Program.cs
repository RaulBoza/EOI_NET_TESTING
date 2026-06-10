//Crea un programa que gestione las notas de alumnos en un archivo de texto. 
//Cada línea: nombre; nota1; nota2; nota3.
//Permite: añadir alumno, ver todos, calcular medias, encontrar mejor/peor alumno.

using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

const string ROOT_RUTE = "C:\\Users\\rakim\\Documents\\GitHub\\EOI_NET_TESTING\\ExercicesReview\\StudentGradeRecord\\StudentsData\\";
Directory.SetCurrentDirectory(ROOT_RUTE);

Subject subject1 = new Subject("Data types");
Subject subject2 = new Subject("Operators");
Subject subject3 = new Subject("Loops");
Subject subject4 = new Subject("Conditionals");

StudentGrade student1 = new StudentGrade("Manuel", "Martinez", new Dictionary<Subject, float>
{
    { subject1, 8.5f },
    { subject2, 9.0f },
    { subject3, 7.8f },
    { subject4, 7.8f }
});

StudentGrade student2 = new StudentGrade("Miguel", "Guerrero", new Dictionary<Subject, float>
{
    { subject1, 6.5f },
    { subject2, 7.0f },
    { subject3, 5.0f },
    { subject4, 4.5f }
});

StudentGrade student3 = new StudentGrade("Covadonga", "García", new Dictionary<Subject, float>
{
    { subject1, 8.5f },
    { subject2, 7.0f },
    { subject3, 6.5f },
    { subject4, 7.5f }
});

List<StudentGrade> students = new List<StudentGrade>
{
    student1,
    student2,
    student3
};

WriteFile();
WriteJSON();
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
        3) Add a new student.
        4) Edit a student.
        5) Calculate student average.
        6) List students by average grade.

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
            AddStudent();
            break;
        case 4:
            EditStudent();
            break;
        case 5:
            CalculateStudentAverage();
            break;
        case 6:
            ListStudentsByAverageGrade();
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
        ============================================
        Which student do you want to see the grades of?:
        (Select a number, please)
        -------------------------------------------
        """);
    
    foreach (StudentGrade student in students)
    {
        Console.WriteLine($"{studentNumber++}) {student.Name} {student.Surname}");
    }

    int option = int.TryParse(Console.ReadLine(), out int number) ? number : 0;

    if (option > 0 && option <= students.Count)
    {
        option -= 1;
        Console.WriteLine($"""

            ============================================
            Student Name: {students[option].Name} {students[option].Surname}
            -------------------------------------------
            """);

        for (int i = 0; i < students[option].Grades.Count; i++)
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

void AddStudent()
{
    Console.WriteLine("""
        ============================================
        Adding a new student. You will be asked for the name and surname firts.
        Then you will be asked for the grade of each subject.
        -------------------------------------------
        """);
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Surame: ");
    string surname = Console.ReadLine();

    StudentGrade newStudent = new StudentGrade(name, surname, new Dictionary<Subject, float>
    {
        { subject1, 0 },
        { subject2, 0 },
        { subject3, 0 },
        { subject4, 0 }
    });

    foreach(Subject subject in newStudent.Grades.Keys)
    {
        Console.Write($"What grade does {name} {surname} have in '{subject.Name}': ");
        float auxgrade;
        float grade = float.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out auxgrade) ? auxgrade:-1;
        while(!(grade >= 0.00 && grade <= 10.00))
        {
            Console.WriteLine("Set a valid grade between 0 and 10.");
            Console.Write($"What grade does {name} {surname} have in '{subject.Name}': ");
            grade = float.TryParse(Console.ReadLine(), out auxgrade) ? auxgrade : -1;
        }
        newStudent.Grades[subject] = grade;
    }
    students.Add(newStudent);
    WriteFile();
    Console.WriteLine($"{name} {surname} succesfully added.");
    MainMenu();
}

void EditStudent()
{
    int studentNumber = 1;

    Console.WriteLine("""
        ============================================
        Which student do you want to edit the grades of?:
        (Select a number, please)
        -------------------------------------------
        """);

    foreach (StudentGrade student in students)
    {
        Console.WriteLine($"{studentNumber++}) {student.Name} {student.Surname}");
    }

    int option = int.TryParse(Console.ReadLine(), out int number) ? number : 0;

    if (option > 0 && option <= students.Count)
    {
        option -= 1;
        Console.WriteLine($"Change grades for {students[option].Name} {students[option].Surname}:");

        for (int i = 0; i < students[option].Grades.Count; i++)
        {
            Console.Write($"What grade does {students[option].Name} {students[option].Surname} have in '{students[option].Grades.ElementAt(i).Value}': ");
            float auxgrade;
            float grade = float.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out auxgrade) ? auxgrade : -1;
            while (!(grade >= 0.00 && grade <= 10.00))
            {
                Console.WriteLine("Set a valid grade between 0 and 10.");
                Console.Write($"What grade does {students[option].Name} {students[option].Surname} have in '{students[option].Grades.ElementAt(i).Value}': ");
                grade = float.TryParse(Console.ReadLine(), out auxgrade) ? auxgrade : -1;
            }
            students[option].Grades[students[option].Grades.ElementAt(i).Key] = grade;
        }
    }
    else
    {
        Console.WriteLine("\nChoose a valid option, please.");
        ShowStudentGrades();
    }
    WriteFile();
    Console.WriteLine("\nEnter anything to show main menu again");
    Console.ReadLine();
    MainMenu();

}   

void CalculateStudentAverage()
{
    float average = -1;
    int studentNumber = 1;

    Console.WriteLine("""
        ============================================
        Which student do you want to check its average grade?:
        (Select a number, please)
        -------------------------------------------
        """);

    foreach (StudentGrade student in students)
    {
        Console.WriteLine($"{studentNumber++}) {student.Name} {student.Surname}");
    }

    int option = int.TryParse(Console.ReadLine(), out int number) ? number : 0;

    if (option > 0 && option <= students.Count)
    {
        option -= 1;

        for (int i = 0; i < students[option].Grades.Count; i++)
        {
            average = students[option].Grades.Values.Average();
        }
    }
    else
    {
        Console.WriteLine("\nChoose a valid option, please.");
        ShowStudentGrades();
    }
    Console.WriteLine($"The average grade for {students[option].Name} {students[option].Surname} is: {average:F2}");
    Console.WriteLine("\nEnter anything to show main menu again");
    Console.ReadLine();
    MainMenu();
}

void ListStudentsByAverageGrade()
{
    Dictionary<String, float> studentAverages = new Dictionary<String, float>();

    foreach(StudentGrade student in students)
    {
        studentAverages.Add($"{student.Name} {student.Surname}", student.Grades.Values.Average());
    }

    var sortedStudents = studentAverages.OrderByDescending(x => x.Value);

    foreach(var student in sortedStudents)
    {
        Console.WriteLine($"{student.Key}: {student.Value:F2}");
    }

}

void WriteFile()
{
    Console.WriteLine("Writing to file...");
    string[] studentsFile = new string[students.Count];
    for (int i = 0; i < students.Count; i++)
    {
        studentsFile[i] = $"""
        ============================================
        Student Name: {students[i].Name} {students[i].Surname}
        -------------------------------------------
        {subject1.Name}: 
            --------------------> | {students[i].Grades[subject1]} |
        {subject2.Name}: 
            --------------------> | {students[i].Grades[subject2]} |
        {subject3.Name}: 
            --------------------> | {students[i].Grades[subject3]} |
        {subject4.Name}: 
            --------------------> | {students[i].Grades[subject4]} |
        """;
    }
    File.WriteAllLines("students.txt", studentsFile);
}

void WriteJSON()
{
    string? json = null;
    json = JsonSerializer.Serialize(students, new JsonSerializerOptions{ WriteIndented = true });
    File.WriteAllText("students.json", json);
}
public class StudentGrade
{
    public StudentGrade(string name, string surname, Dictionary<Subject, float> grades)
    {
        Name = name;
        Surname = surname;
        Grades = grades;
    }

    [JsonPropertyName("Student Name")]
    public string Name { get; set; }

    [JsonPropertyName("Student Surname")]
    public string Surname { get; set; }

    [JsonPropertyName("Student Grades")]
    public Dictionary<Subject,float> Grades { get; set; }
}

[JsonConverter(typeof(SubjectJsonConverter))]
public class Subject : TypeConverter
{
    public static Subject Parse(string name)
    {
        return new Subject(name);
    }
    public Subject(string name)
    {
        Name = name;
    }

    [JsonPropertyName("Subject Name")]
    public string Name { get; set; }
}

class SubjectJsonConverter : JsonConverter<Subject>
{
    public override Subject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => Subject.Parse(reader.GetString());

    public override void Write(Utf8JsonWriter writer, Subject value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());

    public override Subject ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => Subject.Parse(reader.GetString());

    public override void WriteAsPropertyName(Utf8JsonWriter writer, Subject value, JsonSerializerOptions options)
        => writer.WritePropertyName(value.ToString());
}
