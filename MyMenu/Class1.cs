using lesson15;

public class Run
{
    AcademyGroup arr_ = new AcademyGroup();
    
    private void Menu()
    {
        arr_.Print();
        Console.WriteLine("Enter command");
        Console.WriteLine("1-Add, 2-Edit, 3-Remove, 4-Search, 5-Sort, 6-Save, 7-Load, 8-Iterator 0-Exit");
    }

    public void Start()
    {
        bool stop = true;
        while (stop)
        {
            Menu();
            string? str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    AddNewStudent();
                    break;
                case "2":
                    Console.WriteLine("Enter surname for edit");
                    string? str_edit = Console.ReadLine();
                    arr_.Edit(str_edit);
                    break;
                case "3":
                    Console.WriteLine("Enter surname for remove");
                    string? str_remove = Console.ReadLine();
                    arr_.Remove(str_remove);
                    break;
                case "4":
                    Console.WriteLine("Enter surname for search");
                    string? str_search = Console.ReadLine();
                    Student std = arr_.Search(str_search);
                    Console.WriteLine();
                    if (std != null) std.Print();
                    else Console.WriteLine("Student not found");
                    break;
                case "5":
                    Console.WriteLine("Enter 'name', 'surname' or 'gpa' for sort");
                    string? str_sort = Console.ReadLine();
                    arr_.Sort(str_sort ?? "");
                    break;
                case "6":
                    Console.WriteLine("Enter filename.txt to save");
                    string? str_save = Console.ReadLine();
                    arr_.Save(str_save ?? "");
                    break;
                case "7":
                    Console.WriteLine("Enter filename.txt to load");
                    string? str_load = Console.ReadLine();
                    arr_.Load(str_load);
                    break;
                case "8":
                    Console.WriteLine("Lesson 16 Iterator");
                    foreach (var var in arr_)
                    {
                        Console.WriteLine(var);
                    }
                    break;
                case "0":
                    stop = false;
                    break;
                default:
                    Console.WriteLine("Unknown command!");
                    break;
            }
        }
    }

    private void AddNewStudent()
    {
        Student st = new Student();
        Console.WriteLine("Enter name:");
        string? s = Console.ReadLine();
        st.Name = s;
        Console.WriteLine("Enter surname:");
        s = Console.ReadLine();
        st.SurName = s;
        Console.WriteLine("Enter age:");
        s = Console.ReadLine();
        st.Age = CheckInt(s);
        Console.WriteLine("Enter phone:");
        s = Console.ReadLine();
        st.Phone = s;
        Console.WriteLine("Enter grade point average:");
        s = Console.ReadLine();
        st.GPA = CheckInt(s);
        Console.WriteLine("Enter group number:");
        s = Console.ReadLine();
        st.GroupNumber = CheckInt(s);
        arr_.Add(st);
    }

    private int CheckInt(string? str)
    {
        int result;
        while (!int.TryParse(str, out result))
        {
            Console.WriteLine("Invalid input! Please enter a valid number:");
            str = Console.ReadLine();
        }
        return result;
    }
}