using System;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DepartmentId { get; set; }

    public Course(int id, string title, int departmentId)
    {
        Id = id; Title = title; DepartmentId = departmentId;
    }
}
