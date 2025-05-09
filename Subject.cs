using System;

    class Subject
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Subject(string name, int departmentId)
        {
            Name = name;
            DepartmentId = departmentId;
        }
    }
