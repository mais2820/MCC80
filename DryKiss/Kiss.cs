using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kelompok2;

public class Kiss
{
    /*    public string Nama { get; set; }
        public int Umur { get; set; }*/

    //--------------------------------------------------------------
    //BELUM MENERAPKAN KISS
    public void PrintStudent1()
    {
        string X = "John";
        int Y = 20;
        Console.WriteLine("Student Details:");
        Console.WriteLine("Name: " + X);
        Console.WriteLine("Age : " + Y);

        // Operasi tambahan yang tidak perlu
        if (Y >= 18)
        {
            Console.WriteLine("Student is eligible for voting.");
        }
        else if (Y <= 18)
        {
            Console.WriteLine("Student is not eligible for voting.");
        }

        // Operasi tambahan yang tidak perlu
        if (X.Length > 10)
        {
            Console.WriteLine("Student has a long name.");
        }
        else
        {
            Console.WriteLine("Student has a short name.");
        }

    }


    //SUDAH MENERAPKAN KISS
    public void PrintStudent2()
    {
        string Name = "John";
        int Age = 20;
        Console.WriteLine("Student Detail ");
        Console.WriteLine("Nama : " + Name);
        Console.WriteLine("Umur : " + Age);
    }

}