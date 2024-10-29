using System.Collections.Generic;

public class Group
{
    public string No { get; set; } 
    public string Category { get; set; } 
    public bool IsOnline { get; set; }
    public int Limit { get; private set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public Group(string no, string category, bool isOnline)
    {
        No = no;
        Category = category;
        IsOnline = isOnline;
        Limit = isOnline ? 15 : 10;
    }

    public void GetGroupInfo()
    {
        Console.WriteLine($"Qrup No: {No}, Kateqoriya: {Category}, Online: {(IsOnline ? "Beli" : "Xeyr")}, Telebe sayi: {Students.Count}/{Limit}");
    }

    public bool AddStudent(Student student)
    {
        if (Students.Count < Limit)
        {
            Students.Add(student);
            return true;
        }
        Console.WriteLine("Bu qrupda telebe limiti dolub");
        return false;
    }
}
