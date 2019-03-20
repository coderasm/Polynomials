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
      int[] coefficientsOne = { -2, 0, 5, -10 };
      var polyOne = new Polynomial(coefficientsOne);
      Console.Write("Polynomial: ");
      polyOne.print();
      Console.Write("Derivative: ");
      polyOne.derivative().print();


      int[] coefficientsTwo = { 5, -2, 16 };
      var polyTwo = new Polynomial(coefficientsOne);
      Console.Write("Polynomial: ");
      polyTwo.print();
      Console.Write("Derivative: ");
      polyTwo.derivative().print();
    }
  }
}
