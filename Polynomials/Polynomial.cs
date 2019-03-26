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

    public Polynomial Derivative()
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
      var longer = coefficients.Length > polynomial.coefficients.Length ? this : polynomial;
      var shorter = longer == this ? polynomial : this;
      var clonedLonger = longer.Clone();
      for (int i = 0; i < shorter.coefficients.Length; i++)
      {
        clonedLonger.coefficients[i] = clonedLonger.coefficients[i] + shorter.coefficients[i];
      }
      return clonedLonger;
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

    public Polynomial Product(Polynomial polynomial)
    {
      var newLength = coefficients.Length + polynomial.coefficients.Length;
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

    public Polynomial[] Divide(Polynomial polynomial)
    {
      var newLength = coefficients.Length;
      var quotient = new Polynomial(new int[newLength]);
      var dividend = this;
      var divisorGreatestPower = polynomial.GreatestPower();
      var dividendGreatestPower = dividend.GreatestPower();
      //only divide if divisable
      while (dividendGreatestPower >= divisorGreatestPower)
      {
        var powerNeeded = dividendGreatestPower - divisorGreatestPower;
        var coefficientNeeded = dividend.coefficients[dividendGreatestPower] / polynomial.coefficients[divisorGreatestPower];
        //correct sign
        coefficientNeeded = dividend.coefficients[dividendGreatestPower] > 0 ? Math.Abs(coefficientNeeded) : -1 * Math.Abs(coefficientNeeded);
        //build new polynomial
        var quotientCoefficient = new int[newLength];
        quotientCoefficient[powerNeeded] = coefficientNeeded;
        var partialQuotient = new Polynomial(quotientCoefficient);
        //add onto the quotient
        quotient = quotient.Sum(partialQuotient);
        //multiply new quotient into divisor and subtract from current
        //dividend for new dividend
        dividend = dividend.Difference(polynomial.Product(partialQuotient));
        //calculate top power of new dividend.
        dividendGreatestPower = dividend.GreatestPower();
      }
      return new Polynomial[] { quotient, dividend };
    }

    public NewTonRaphsonRoot FindEstimateRoot(double initialDomainValue)
    {
      var MIN_DOMAIN_DIFF = Math.Pow(10, -7);
      var MAX_FROM_ZERO = .0625;
      var MAX_ATTEMPTS = 50;
      var firstRangeValue = ApplyValue(initialDomainValue);
      if (Math.Abs(firstRangeValue) <= MAX_FROM_ZERO)
        return new NewTonRaphsonRoot(initialDomainValue);
      double domainDifference = 1;
      var counter = 0;
      var derivative = Derivative();
      var currentDomainValue = initialDomainValue;
      while (domainDifference > MIN_DOMAIN_DIFF && counter <= MAX_ATTEMPTS)
      {
        var newDomainValue = currentDomainValue - (ApplyValue(currentDomainValue) / derivative.ApplyValue(currentDomainValue));
        var rangeValue = ApplyValue(newDomainValue);
        if (Math.Abs(rangeValue) <= MAX_FROM_ZERO)
          return new NewTonRaphsonRoot(newDomainValue);
        domainDifference = Math.Abs(currentDomainValue - newDomainValue);
        currentDomainValue = newDomainValue;
        counter++;
      }
      return new NewTonRaphsonRoot();
    }

    private double ApplyValue(double value)
    {
      double total = 0;
      for (int i = 0; i < coefficients.Length; i++)
      {
        total += coefficients[i] * Math.Pow(value, i);
      }
      return total;
    }

    public int GreatestPower()
    {
      for (int i = coefficients.Length - 1; i >= 0; i--)
      {
        if (coefficients[i] != 0)
        {
          return i;
        }
      }
      return -1;
    }

    private Polynomial Clone()
    {
      var length = coefficients.Length;
      var zero = new int[length];
      for (int i = 0; i < length; i++)
      {
        zero[i] = coefficients[i];
      }
      return new Polynomial(zero);
    }

    public bool Equals(Polynomial polynomial)
    {
      if (coefficients.Length != polynomial.coefficients.Length)
        return false;
      for (int i = 0; i < coefficients.Length; i++)
      {
        if (coefficients[i] != polynomial.coefficients[i])
          return false;
      }
      return true;
    }

    public override string ToString()
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
          if (coefficients[i] == -1 && i != 0)
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
      polynomial = polynomial.TrimStart(toTrim);
      return polynomial;
    }

    public class NewTonRaphsonRoot
    {
      public bool Exists { get; set; }
      public double Root { get; set; }

      public NewTonRaphsonRoot()
      {
        Exists = false;
      }
      public NewTonRaphsonRoot(double Root)
      {
        Exists = true;
        this.Root = Root;
      }
    }
  }
}
