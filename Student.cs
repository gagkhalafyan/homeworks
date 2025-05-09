using System;

    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public List<int> EnrolledCourseIds { get; set; } = new();

        public Student(int id, string fullname, int depid, List<int> list)
        {
            Id = id;
            FullName = fullname;
            DepartmentId = depid;
            EnrolledCourseIds = list;
        }
    }
