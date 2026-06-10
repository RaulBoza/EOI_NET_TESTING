//Crea un gestor de tareas (To-Do) que almacene en JSON: 
//título, descripción, fecha de creación, completada (sí / no), prioridad (enum). 
//Permite: añadir, listar, completar, eliminar, filtrar por estado/prioridad.

namespace ToDoList
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //string RelativeRroute = @"..\..\..\ProgramFolder\example.txt";
            List<Task> tasks = new List<Task>();
            Task exampleTask = new Task(0, "Example Task", "This is an example task.", DateOnly.FromDateTime(DateTime.Now), false, Priority.Medium);
            tasks.Add(exampleTask);

            //Console.WriteLine(File.ReadAllText(RelativeRroute));

            UserInterface ui = new UserInterface();
            ui.ShowMenu();
            Console.ReadLine();
        }
    }
}