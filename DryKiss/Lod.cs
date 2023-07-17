using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public string name;
    public int umur;
    public Student(string name, int umur)
    {
        this.name = name;
        this.umur = umur;
    }
}

public class LodStudent
{
    public string name;
    public int umur;
    public LodStudent(string name, int umur)
    {
        this.name = name;
        this.umur = umur;
    }

    public string GetName()
    {
        return name;
    }

    public int GetUmur()
    {
        return umur;
    }
}
