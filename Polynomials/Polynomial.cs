using System;

namespace Polynomials
{
  class Polynomial
  {
    int[] coefficients;
    int deg = 0;

    public Polynomial(int[] coefficients)
    {
      this.coefficients = coefficients;
      deg = coefficients.Length - 1;
    }

    public Polynomial derivative()
    {
      int[] derivative = new int[coefficients.Length - 1];
      for (int i = 0; i < coefficients.Length; i++)
      {
        if (i == 0)
          continue;
        else
          derivative[i - 1] = i * coefficients[i];
      }
      return new Polynomial(derivative);
    }

    public string print()
    {
      var polynomial = "";
      for (int i = coefficients.Length - 1; i >= 0; i--)
      {
        //only process non zero coefficients
        if (coefficients[i] != 0)
        {
          var sign = " ";
          //Do not show plus sign on leading coefficient
          if (coefficients[i] > 0 && i != coefficients.Length - 1)
            sign = " + ";
          //No space if leading coefficient is negative
          else if (coefficients[i] < 0 && i == coefficients.Length - 1)
            sign = "";
          switch (i)
          {
            case 0:
              polynomial += sign + coefficients[i];
              break;
            case 1:
              polynomial += sign + coefficients[i] + "x";
              break;
            default:
              polynomial += sign + coefficients[i] + "x^" + i;
              break;
          }
        }
      }
      Console.WriteLine(polynomial);
      return polynomial;
    }
  }
}
