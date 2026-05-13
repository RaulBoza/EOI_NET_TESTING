using System;
using System.Collections.Generic;
using System.Text;

enum Priority
{
    Low,
    Medium,
    High,
    Urgent
}

namespace ToDoList
{
    internal class Task
    {
        public int Id;
        public string Tittle;
        public string Description;
        public DateOnly CreationDate;
        public bool Completed;
        public Priority Priority;

        public Task(int id, string tittle, string description, DateOnly creationDate, bool completed, Priority priority)
        {
            Id = id;
            Tittle = tittle;
            Description = description;
            CreationDate = creationDate;
            Completed = completed;
            Priority = priority;
        }
    }
}
