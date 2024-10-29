public class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string GroupNo { get; set; }
    public string Type { get; set; } 
    public Student(string name, string surname, string groupNo, string type)
    {
        Name = name;
        Surname = surname;
        GroupNo = groupNo;
        Type = type;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Ad: {Name}, Soyad: {Surname}, Qrup No: {GroupNo}, Tip: {Type}");
    }
}
