namespace lesson15;

public class AcademyGroup : ICloneable
{
    public Student[] arr;
    public int count = 0;

    public AcademyGroup()
    {
        arr = new Student[30];
    }

    public void Add(Student obj)
    {
        if (count == arr.Length) Array.Resize(ref arr, arr.Length + 10);
        arr[count] = obj;
        count++;
    }

    public void Remove(string? Surname_)
    {
        for (int i = 0; i < count; i++)
        {
            if (arr[i].SurName == Surname_)
            {
                int length = count - i - 1;

                if (length > 0)
                {
                    Array.Copy(arr, i + 1, arr, i, length);
                }
                count--;
                arr[count] = null;
                Console.WriteLine($"Student {Surname_} removed.");
                return;
            }
        }
    }

    public void Edit(string? surname_)
    {
        Student st = Search(surname_);
        if (st != null)
        {
            Console.WriteLine("Enter name:");
            st.Name = Console.ReadLine();
            Console.WriteLine("Enter surname:");
            st.SurName = Console.ReadLine();
            Console.WriteLine("Enter age:");
            st.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone:");
            st.Phone = Console.ReadLine();
            Console.WriteLine("Enter group point average:");
            st.GPA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter group number:");
            st.GroupNumber = Convert.ToInt32(Console.ReadLine());
        }
        else Console.WriteLine("Student not found.");
    }

    public void Print()
    {
        Console.WriteLine($"\n\tAcademy Group List ({count} students)");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {arr[i].Name} {arr[i].SurName}, Average: {arr[i].GPA}, Group number: {arr[i].GroupNumber}");
        }
    }
    
    public void Save(string filename)
    {
        using StreamWriter sw = new StreamWriter(filename);
        for (int i = 0; i < count; i++)
        {
            var s = arr[i];
            sw.WriteLine($"{s.Name};{s.SurName};{s.Age};{s.Phone};{s.GPA};{s.GroupNumber}");
        }
        Console.WriteLine("Data saved to " + filename);
    }

    public void Load(string? filename)
    {
        if (!File.Exists(filename)) return;

        using StreamReader sr = new StreamReader(filename);
        string? line;
        count = 0;

        while ((line = sr.ReadLine()) != null)
        {
            string[] data = line.Split(';');
            Student s = new Student() {
                Name = data[0],
                SurName = data[1],
                Age = int.Parse(data[2]),
                Phone = data[3],
                GPA = int.Parse(data[4]),
                GroupNumber = int.Parse(data[5])
            };
            Add(s);
        }
        Console.WriteLine("Data loaded successfully.");
    }

    public Student Search(string? surname_)
    {
        for (int i = 0; i < count; i++)
        {
            if (arr[i].SurName == surname_) return arr[i];
        }
        return null;
    }
    public Student this[int index]
    {
        get 
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            return arr[index];
        }
        set 
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            arr[index] = value;
        }
    }

    public void Sort(string value)
    {
        if (value == null) return;
        switch (value.ToLower())
        {
            case "name":
                Array.Sort(arr,0, count, new Student.SortByName());
                Print();
                break;
            case "surname":
                Array.Sort(arr,0, count, new Student.SortBySurName());
                Print();
                break;
            case "gpa":
                Array.Sort(arr,0, count, new Student.SortByGPA());
                Print();
                break;
            default: 
                Console.WriteLine("Incorrect value");
                break;
        }
    }
    // ICloneable
    public object Clone()
    {
        AcademyGroup result = new AcademyGroup();
        for (int i = 0; i < count; i++)
        {
            result.Add((Student)this.arr[i].Clone());
        }
        return result;
    }
}