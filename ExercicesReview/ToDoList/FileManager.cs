using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class FileManager
    {
        public bool CheckFileExist(string path)
        {
            return File.Exists(path);
        }
    }
}
