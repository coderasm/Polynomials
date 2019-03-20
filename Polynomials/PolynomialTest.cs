using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomials
{
  /*
   Prints a polynomial and its derivative
     */
  class PolynomialTest
  {
    public static void DerivativeAndPrintTest()
    {
      Console.WriteLine("########## PART 5 ############");
      Console.WriteLine();
      int[] coefficientsOne = { 4, -5, 1 };
      var polyOne = new Polynomial(coefficientsOne);
      Console.Write("Polynomial: ");
      polyOne.print();
      Console.Write("Derivative: ");
      polyOne.derivative().print();


      int[] coefficientsTwo = { 1, 1, 0, 1 };
      var polyTwo = new Polynomial(coefficientsOne);
      Console.Write("Polynomial: ");
      polyTwo.print();
      Console.Write("Derivative: ");
      polyTwo.derivative().print();
    }

    public static void AddAndPrintTest()
    {
      Console.WriteLine("########## PART 6 ############");
      Console.WriteLine();
      int[] coefficientsOne = { 4, -5, 1, 0 };
      int[] coefficientsTwo = { 1, 1, 0, 1 };
      var polyOne = new Polynomial(coefficientsOne);
      var polyTwo = new Polynomial(coefficientsTwo);
      Console.Write("Polynomial 1: ");
      polyOne.print();
      Console.Write("Polynomial 2: ");
      polyTwo.print();
      Console.Write("Sum: ");
      polyOne.Sum(polyTwo).print();
      Console.Write("Difference: ");
      polyOne.Difference(polyTwo).print();

      coefficientsOne = new int[] { 4, -5, 1 };
      coefficientsTwo = new int[] { 4, -5, -1 };
      polyOne = new Polynomial(coefficientsOne);
      polyTwo = new Polynomial(coefficientsTwo);
      Console.Write("Polynomial 1: ");
      polyOne.print();
      Console.Write("Polynomial 2: ");
      polyTwo.print();
      Console.Write("Sum: ");
      polyOne.Sum(polyTwo).print();
      Console.Write("Difference: ");
      polyOne.Difference(polyTwo).print();
    }
  }
}
