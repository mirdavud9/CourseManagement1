using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static List<Group> groups = new List<Group>();

        static void Main(string[] args)
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine("Tetbiqe xos gelmisiz,zehmet olmazsa istediyiniz emeliyyati secin:");
                Console.WriteLine("1. Yeni qrup yarat");
                Console.WriteLine("2. Qruplarin siyahisini goster");
                Console.WriteLine("3. Qrup uzerinde duzelis etmek");
                Console.WriteLine("4. Qrupdaki telebelerin siyahisini goster");
                Console.WriteLine("5. Butun telebelerin siyahisini goster");
                Console.WriteLine("6. Telebe yarat");
                Console.WriteLine("0. Cixis");
                Console.Write("\nSeciminizi daxil edin: ");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        CreateGroup();
                        break;
                    case "2":
                        ShowGroups();
                        break;
                    case "3":
                        EditGroup();
                        break;
                    case "4":
                        ShowGroupStudents();
                        break;
                    case "5":
                        ShowAllStudents();
                        break;
                    case "6":
                        CreateStudent();
                        break;
                    case "0":
                        Console.WriteLine("Tetbiqden cixilirr...");
                        break;
                    default:
                        Console.WriteLine("Yanlis secim, yeniden cehd edin");
                        break;
                }

                if (answer != "0")
                {
                    Console.WriteLine("\nDavam etmek ucun her hansi duymeye basin:");
                }

            } while (answer != "0");
        }

        static void CreateGroup()
        {
            Console.Write("Qrup nomresini daxil edin: ");
            string no = Console.ReadLine();

            if (groups.Exists(g => g.No == no))
            {
                Console.WriteLine("Bu adda qrup artiq movcuddur");
                return;
            }

            Console.Write("Kateqoriyani daxil edin (Programming, Design, System Administration): ");
            string category = Console.ReadLine();

            Console.Write("Online qrupmu? (beli/xeyr): ");
            bool isOnline = Console.ReadLine().ToLower() == "beli";

            groups.Add(new Group(no, category, isOnline));
            Console.WriteLine("Yeni qrup yaradildi:");
        }

        static void ShowGroups()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("Sistemde hec bir qrup yoxdur");
                return;
            }

            foreach (var group in groups)
            {
                group.GetGroupInfo();
            }
        }

        static void EditGroup()
        {
            Console.Write("Deyisdirilecek qrup nomresini daxil edin: ");
            string no = Console.ReadLine();
            Group group = groups.Find(g => g.No == no);

            if (group == null)
            {
                Console.WriteLine("Bu nomreli qrup tapilmadi");
                return;
            }

            Console.Write("Yeni qrup nomresini daxil edin: ");
            string newNo = Console.ReadLine();

            if (groups.Exists(g => g.No == newNo))
            {
                Console.WriteLine("Bu adda qrup artiq movcuddur");
                return;
            }

            group.No = newNo;
            Console.WriteLine("Qrup nomresi deyisdirildi");
        }

        static void ShowGroupStudents()
        {
            Console.Write("Telereleri gormek istediyiniz qrup nomresini daxil edin: ");
            string no = Console.ReadLine();
            Group group = groups.Find(g => g.No == no);

            if (group == null)
            {
                Console.WriteLine("Bu nomreli qrup tapilmadi");
                return;
            }

            if (group.Students.Count == 0)
            {
                Console.WriteLine("Bu qrupda telebe yoxdur");
            }
            else
            {
                foreach (var student in group.Students)
                {
                    student.GetInfo();
                }
            }
        }

        static void ShowAllStudents()
        {
            bool hasStudents = false;

            foreach (var group in groups)
            {
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Ad: {student.Name}, Qrup: {student.GroupNo}, Online: {(group.IsOnline ? "Beli" : "Xeyr")}");
                    hasStudents = true;
                }
            }

            if (!hasStudents)
            {
                Console.WriteLine("Sistemde telebe yoxdur");
            }
        }

        static void CreateStudent()
        {
            Console.Write("Telebenin adini daxil edin: ");
            string name = Console.ReadLine();

            Console.Write("Telebenin soyadini daxil edin: ");
            string surname = Console.ReadLine();

            Console.Write("Telebenin qrup nomresini daxil edin: ");
            string groupNo = Console.ReadLine();

            Group group = groups.Find(g => g.No == groupNo);
            if( group == null) 
                Console.Write("Telebe tipi (zemanetli/zemanetsiz): ");
                string type = Console.ReadLine();

                Student student = new Student(name, surname, groupNo, type);
                if (group.AddStudent(student))
                {
                    Console.WriteLine("Telebe qrupda yaradildi");
                }
            else
            {
                Console.WriteLine("Bu nomreli qrup tapilmadi");
                return;
            }
        }
    }
}
