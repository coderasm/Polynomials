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

    public Polynomial Sum(Polynomial polynomial)
    {
      var length = coefficients.Length;
      int[] summedCoefficients = new int[length];
      for (int i = 0; i < coefficients.Length; i++)
      {
        summedCoefficients[i] = coefficients[i] + polynomial.coefficients[i];
      }
      return new Polynomial(summedCoefficients);
    }

    public Polynomial Difference(Polynomial polynomial)
    {
      var length = coefficients.Length;
      int[] subtracted = new int[length];
      for (int i = 0; i < coefficients.Length; i++)
      {
        subtracted[i] = coefficients[i] - polynomial.coefficients[i];
      }
      return new Polynomial(subtracted);
    }

    public Polynomial product(Polynomial polynomial)
    {
      var newLength = (coefficients.Length - 1) * 2 + 1;
      var multiplied = new int[newLength];
      for (int i = 0; i < coefficients.Length; i++)
      {
        var coefficientOne = coefficients[i];
        for (int j = 0; j < polynomial.coefficients.Length; j++)
        {
          var coefficientTwo = polynomial.coefficients[j];
          multiplied[i + j] = multiplied[i + j] + coefficientOne * coefficientTwo;
        }
      }
      return new Polynomial(multiplied);
    }

    public Polynomial divide(Polynomial polynomial)
    {
      var newLength = coefficients.Length;
      var divided = new int[newLength];
      return new Polynomial(divided);
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
          var coefficient = coefficients[i].ToString();
          if (coefficients[i] == -1)
            coefficient = "-";
          if (coefficients[i] == 1 && i != 0)
            coefficient = "";
          switch (i)
          {
            case 0:
              polynomial += sign + coefficient;
              break;
            case 1:
              polynomial += sign + coefficient + "x";
              break;
            default:
              polynomial += sign + coefficient + "x^" + i;
              break;
          }
        }
      }
      //trim off any leading spaces and plus signs
      var toTrim = new char[] { ' ', '+' };
      Console.WriteLine(polynomial.TrimStart(toTrim));
      return polynomial;
    }
  }
}
