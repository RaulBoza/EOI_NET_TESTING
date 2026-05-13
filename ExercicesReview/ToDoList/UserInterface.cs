using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class UserInterface
    {
        public void ShowMenu()
        {
            Console.WriteLine("""
                -- To-Do List Menu --

                1. Add New Task
                2. List All Tasks
                3. List Completed Tasks
                4. Delete Task
                5. List Tasks by Status
                6. List Tasks by Priority

                0. Exit
                """);
            Console.WriteLine("Please, select an option:");
        }
    }
}
