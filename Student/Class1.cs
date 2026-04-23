using System;
using System.Collections;

namespace lesson15;

public class Student : Person, IComparable, ICloneable
{
    public int GPA { get; set; }
    public int GroupNumber { get; set; }

    public Student(string? name_, string surName_, int age_, string phone_, int gpa_, int groupNumber_)
        : base(name_, surName_, age_, phone_)
    {
        GPA = gpa_;
        GroupNumber = groupNumber_;
    }

    public Student()
        :this(null,null,0,null,0,0)
    {
    }

    new public void Print()
    {
        base.Print();
        Console.WriteLine($"Group point average: {GPA}\nGroup number: {GroupNumber}");
    }
    public override string ToString() 
    {
        return $"{SurName} {Name}, Age: {Age}, Group: {GroupNumber}, GPA: {GPA}";
    }
    // IComparable
    public int CompareTo(object obj)
    {
        if(obj is Student)
            return SurName.CompareTo((obj as Student).SurName);

        throw new ArgumentException();
    }
    // ICloneable
    public object Clone()
    {
        return new Student(Name, SurName, Age, Phone, GPA, GroupNumber);
    }
    
    // IComparer
    public class SortByName : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 == null && obj2 == null) return 0;
            if (obj1 == null) return -1;
            if (obj2 == null) return 1;
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).Name.CompareTo((obj2 as Student).Name);

            throw new ArgumentException("Both objects must be of type Student");
        }
    }
    public class SortBySurName : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 == null && obj2 == null) return 0;
            if (obj1 == null) return -1;
            if (obj2 == null) return 1;
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).SurName.CompareTo((obj2 as Student).SurName);

            throw new ArgumentException("Both objects must be of type Student");
        }
    }
    
    public class SortByGPA : IComparer
    {
        int IComparer.Compare(object? obj1, object? obj2)
        {
            if (obj1 == null && obj2 == null) return 0;
            if (obj1 == null) return -1;
            if (obj2 == null) return 1;
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).GPA.CompareTo((obj2 as Student).GPA);

            throw new ArgumentException("Both objects must be of type Student");
        }
    }
    
}