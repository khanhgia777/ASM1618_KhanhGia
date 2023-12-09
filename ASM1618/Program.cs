using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1618
{
    internal class Staff
    {
        private string id;
        private string name;
        private int age;
        private double salary;
        private int levels;

        public Staff()
        {

        }

        public Staff(string id, string name, int age, double salary, int hours, int years, int levels)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
            Levels = levels;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int Levels { get; set; }

        public void PrinProfile()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("|   {0,5} | {1,-12} | {2,-15} | {3,-10} | {4,-10} |", Id, Name, Age, Salary, Levels);
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }

    internal class Manager_Staff_Hotel
    {
        List<Staff> _listStaff = new List<Staff>();

        public Manager_Staff_Hotel()
        {
        }

        public Manager_Staff_Hotel(List<Staff> listStaff)
        {
            ListStaff = listStaff;
        }

        List<Staff> ListStaff { get => _listStaff; set => _listStaff = value; }
        public void Inputlistofstaff()
        {
            Console.WriteLine("Input number of staff: ");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Staff staff = new Staff();
                Console.WriteLine("Input ID of Staff: ");
                staff.Id = Console.ReadLine();
                Console.WriteLine("Input Name of Staff: ");
                staff.Name = Console.ReadLine();
                Console.WriteLine("Input Age of Staff: ");
                staff.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input Salary of Staff: ");
                staff.Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input Levels: ");
                staff.Levels = Convert.ToInt32(Console.ReadLine());
                _listStaff.Add(staff);
            }

            Console.WriteLine("Do you want continue? 1.Yes, 2.No");
            string enterfurther = Console.ReadLine();
            if (enterfurther == "1")
            {
                Inputlistofstaff();
            }
        }

        public void Prinlistofstaff()
        {
            if (_listStaff.Count == 0)
            {
                Console.WriteLine("The list if emty now!");
                Inputlistofstaff();
            }
            else
            {
                foreach (var x in _listStaff)
                {
                    x.PrinProfile();
                }
            }
        }


        public void SearchingbyID()
        {
            Console.WriteLine("Input ID staff: ");
            string _idstaff = Console.ReadLine();
            foreach (var x in _listStaff)
            {
                if (x.Id == _idstaff)
                {
                    x.PrinProfile();
                }
            }
        }

        public void Sortingstaffbysalary()
        {
            int i;
            Staff temp;
            Console.WriteLine("List of staffs after sorting: ");
            for (i = 0; i < ListStaff.Count - 1; i++)
            {
                for (int j = ListStaff.Count - 1; j > i; j--)
                {
                    if (ListStaff[i].Salary < ListStaff[j].Salary)
                    {
                        temp = ListStaff[i];
                        ListStaff[i] = ListStaff[j];
                        ListStaff[j] = temp;
                    }
                }
            }
            foreach (var x in ListStaff)
            {
                x.PrinProfile();
            }
        }
        public void EditStaffProfile(string staffId)
        {
            Staff staffToEdit = _listStaff.Find(s => s.Id == staffId);

            if (staffToEdit != null)
            {
                Console.WriteLine("Editing Profile for Staff with ID: " + staffToEdit.Id);

                Console.Write("New Name of : ");
                staffToEdit.Name = Console.ReadLine();

                Console.Write("New Age: ");
                staffToEdit.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("New Salary: ");
                staffToEdit.Salary = Convert.ToDouble(Console.ReadLine());

                Console.Write("New Levels: ");
                staffToEdit.Levels = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Profile updated successfully.");
            }
            else
            {
                Console.WriteLine("Staff with ID " + staffId + " not found.");
            }
        }
    }

    internal class Program
    {
        public static string Menu()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("=====  Menu Manager Staff Service  =====");
            Console.WriteLine("==     1. Input Profile Of Staff      ==");
            Console.WriteLine("==     2. Print List Of Staff         ==");
            Console.WriteLine("==     3. Find Profile By ID          ==");
            Console.WriteLine("==     4. Sorting Staff By Salary     ==");
            Console.WriteLine("==     5. Edit Staff By ID            ==");
            Console.WriteLine("==     6. Exit                        ==");
            Console.WriteLine("==     Input Your Choice              ==");
            Console.WriteLine("========================================");
            string choice = Console.ReadLine();
            return choice;
        }

        public static void Menulap()
        {
            string exit = "0";
            Manager_Staff_Hotel _managerStaff = new Manager_Staff_Hotel();
            while (exit == "0")
            {
                switch (Menu())
                {
                    case "1":
                        _managerStaff.Inputlistofstaff();
                        break;
                    case "2":
                        _managerStaff.Prinlistofstaff();
                        break;
                        break;
                    case "3":
                        _managerStaff.SearchingbyID();
                        break;
                    case "4":
                        _managerStaff.Sortingstaffbysalary();
                        break;
                    case "5":
                        Console.Write("Enter the ID of the staff member you want to edit: ");
                        string staffIdToEdit = Console.ReadLine();
                        _managerStaff.EditStaffProfile(staffIdToEdit);
                        break;
                    case "6":
                        Console.WriteLine("Good Bye, See You!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Menulap();
            Console.ReadKey();
        }
    }
}