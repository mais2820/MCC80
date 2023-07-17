using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok2;

public class Dry
{
    //================BEFORE USING DRY====================
    public void CalculatorRegtangle(double length, double width)
    {
        double area = length * width;
        double perimeter = 2 * (length + width);

        Console.WriteLine("Bentuk    : Persegi Panjang");
        Console.WriteLine("Luas      : " + area);
        Console.WriteLine("Keliling  : " + perimeter);
    }

    public void CalculatorCircle(double radius)
    {
        double area = Math.PI * Math.Pow(radius, 2);
        double circumference = 2 * Math.PI * radius;

        Console.WriteLine("Bentuk   : Lingkaran");
        Console.WriteLine("Luas     : " + area);
        Console.WriteLine("Keliling : " + circumference);
        Console.WriteLine();
    }

    //================AFTER USING DRY====================
    public void DryCalcCircle(double radius)
    {
        double luas = Math.PI * Math.Pow(radius, 2);
        double keliling = 2 * Math.PI * radius;

        PrintShapeProperties("Lingkaran ", luas, keliling);
    }
    public void DryCalcRectangle(double length, double width)
    {
        double luas = length * width;
        double keliling = 2 * (length + width);

        PrintShapeProperties("Persegi Panjang ", luas, keliling);
    }

    public void PrintShapeProperties(string shapename, double luas, double keliling)
    {
        Console.WriteLine("Bentuk   : " + shapename);
        Console.WriteLine("Luas     : " + luas);
        Console.WriteLine("Keliling : " + keliling);
        Console.WriteLine();
    }

}