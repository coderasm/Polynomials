using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomials
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] coefficients = { -2, 0, 5, -10 };
      var poly = new Polynomial(coefficients);
      poly.print();
      poly.derivative().print();
      Console.ReadKey();
    }
  }
}
