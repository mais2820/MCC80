using System;

namespace Kelompok2;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("...........Don't Repeat Yourself.............");
        Console.WriteLine("--Sebelum Menerapkan DRY--");
        BeforeDry();

        Console.WriteLine();
        Console.WriteLine("--Setelah Menerapkan DRY--");
        AfterDry();

        Console.WriteLine("...........Keep It Simple, Stupid.............");
        Console.WriteLine("--Sebelum Menerapkan KISS--");
        Kiss kiss = new Kiss();

        kiss.PrintStudent1();
        Console.WriteLine();
        Console.WriteLine("--Setelah Menerapkan KISS--");
        kiss.PrintStudent2();

        Console.WriteLine();
        Console.WriteLine("--Sebelum Menerapkan LOD--");
        Student student = new Student("John Bryant", 20);
        Console.WriteLine("Nama saya " + student.name);
        Console.WriteLine("Umur saya " + student.umur);
        Console.WriteLine();

        Console.WriteLine("--Setelah Menerapkan LOD--");
        LodStudent student2 = new LodStudent("John Bryant LOD", 22);
        Console.WriteLine("Nama saya " + student2.GetName());
        Console.WriteLine("Umur saya " + student2.GetUmur());
    }

    //DRY
    public static void BeforeDry()
    {
        Dry before_dry = new Dry();
        before_dry.CalculatorCircle(4);
        before_dry.CalculatorRegtangle(2, 3);
    }

    public static void AfterDry()
    {
        Dry after_dry = new Dry();
        after_dry.DryCalcCircle(4);
        after_dry.DryCalcRectangle(2, 3);
    }

   

    //KISS
    /*    public static void BeforeKiss()
        {
            Kiss Before_kiss = new Kiss();
            Before_kiss.Nama = "John";
            Before_kiss.Umur = 20;
            Before_kiss.PrintStudent1();
        }

        public static void AfterKiss()
        {
            Kiss After_kiss = new Kiss();
            After_kiss.Nama = "John";
            After_kiss.Umur = 20;
            After_kiss.PrintStudent2();
        }*/

}
