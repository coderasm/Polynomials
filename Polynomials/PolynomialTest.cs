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
    public static void ProductTest()
    {
      Console.WriteLine("########## PART 2 ############");
      int[] coefficientOne = { 1, 1, 1 };
      var polyOne = new Polynomial(coefficientOne);
      int[] coefficientTwo = { 1, 1, 0 };
      var polyTwo = new Polynomial(coefficientTwo);
      int[] coefficientThree = { 3, 2, 0, 4};
      var polyThree = new Polynomial(coefficientThree);
      int[] coefficientFour = { 0, 3, 2, 0 };
      var polyFour = new Polynomial(coefficientFour);
      Console.WriteLine("Polynomial 1: " + polyOne.ToString());
      Console.WriteLine("Polynomial 2: " + polyTwo.ToString());
      Console.WriteLine("Product: " + polyOne.Product(polyTwo).ToString());
      Console.WriteLine("Polynomial 3: " + polyThree.ToString());
      Console.WriteLine("Polynomial 4: " + polyFour.ToString());
      Console.WriteLine("Product: " + polyThree.Product(polyFour).ToString());
      Console.WriteLine();
    }

    public static void DivisionTest()
    {
      Console.WriteLine("########## PART 3 ############");
      var coeffientsOne = new int[] { 1, 1, 0, 1 };
      var polyOne = new Polynomial(coeffientsOne);
      var coeffientsTwo = new int[] { 1, 1 };
      var polyTwo = new Polynomial(coeffientsTwo);
      var coeffientsThree = new int[] { 1, 1, 0, 0, 0, 1 };
      var polyThree = new Polynomial(coeffientsThree);
      var coeffientsFour = new int[] { 1, 1, 1 };
      var polyFour = new Polynomial(coeffientsFour);
      var coeffientsFive = new int[] { 1, 1, 1, 0, 0, 1, 0, 1 };
      var polyFive = new Polynomial(coeffientsFive);
      var coeffientsSix = new int[] { 1, 0, 1, 0, 1 };
      var polySix = new Polynomial(coeffientsSix);

      var divisionResultOne = polyOne.Divide(polyTwo);
      var remainderOne = divisionResultOne[1].GreatestPower() >= 0 ? divisionResultOne[1].ToString() : "0";
      Console.WriteLine("(" + polyOne.ToString() + ") / (" + polyTwo.ToString() + ") = " + divisionResultOne[0].ToString() + " Remainder: " + remainderOne);
      Console.WriteLine("(" + polyTwo.ToString() + ") * (" + divisionResultOne[0] + ") + " + divisionResultOne[1] + " = " + polyTwo.Product(divisionResultOne[0]).Sum(divisionResultOne[1]));
      var divisionResultTwo = polyThree.Divide(polyFour);
      var remainderTwo = divisionResultTwo[1].GreatestPower() >= 0 ? divisionResultTwo[1].ToString() : "0";
      Console.WriteLine("(" + polyThree.ToString() + ") / (" + polyFour.ToString() + ") = " + divisionResultTwo[0].ToString() + " Remainder: " + remainderTwo);
      Console.WriteLine("(" + polyFour.ToString() + ") * (" + divisionResultTwo[0] + ") + " + divisionResultTwo[1] + " = " + polyFour.Product(divisionResultTwo[0]).Sum(divisionResultTwo[1]));
      var divisionResultThree = polyFive.Divide(polySix);
      var remainderThree = divisionResultThree[1].GreatestPower() >= 0 ? divisionResultThree[1].ToString() : "0";
      Console.WriteLine("(" + polyFive.ToString() + ") / (" + polySix.ToString() + ") = " + divisionResultThree[0].ToString() + " Remainder: " + remainderThree);
      Console.WriteLine("(" + polySix.ToString() + ") * (" + divisionResultThree[0] + ") + " + divisionResultThree[1] + " = " + polySix.Product(divisionResultThree[0]).Sum(divisionResultThree[1]));
      Console.WriteLine();
    }

    public static void NewtonRaphsonRootTest()
    {
      Console.WriteLine("########## PART 4 ############");
      var coeffientsOne = new int[] { 1, 1, 0, 1 };
      var polyOne = new Polynomial(coeffientsOne);
      double rootOneGuess = -1;
      var coeffientsTwo = new int[] { 2, -3, 1 };
      var polyTwo = new Polynomial(coeffientsTwo);
      double rootTwoGuess = 0;
      double rootThreeGuess = 3;
      var rootOne = polyOne.FindEstimateRoot(rootOneGuess);
      Console.WriteLine(polyOne.ToString() + $", Initial root guess: {rootOneGuess}, Final root: " + (rootOne.Exists ? rootOne.Root.ToString() : "not found"));
      var rootTwo = polyTwo.FindEstimateRoot(rootTwoGuess);
      Console.WriteLine(polyTwo.ToString() + $", Initial root guess: {rootTwoGuess}, Final root: " + (rootTwo.Exists ? rootTwo.Root.ToString() : "not found"));
      var rootThree = polyTwo.FindEstimateRoot(rootThreeGuess);
      Console.WriteLine(polyTwo.ToString() + $", Initial root guess: {rootThreeGuess}, Final root: " + (rootThree.Exists ? rootThree.Root.ToString() : "not found"));
      Console.WriteLine();
    }

    public static void HornersMethodTest()
    {
      Console.WriteLine("########## PART 5 ############");
      var coeffientsOne = new int[] { -1, 2, -6, 2 };
      var valueToApplyOne = 3;
      var polyOne = new Polynomial(coeffientsOne);
      Console.WriteLine(polyOne.ToString() + $" where x = {valueToApplyOne} is " + polyOne.ApplyWithHorner(valueToApplyOne));
      var coeffientsTwo = new int[] { 1, 1, 1 };
      var valueToApplyTwo = 1;
      var polyTwo = new Polynomial(coeffientsTwo);
      Console.WriteLine(polyTwo.ToString() + $" where x = {valueToApplyTwo} is " + polyTwo.ApplyWithHorner(valueToApplyTwo));
      Console.WriteLine();
    }

    public static void DerivativeAndPrintTest()
    {
      Console.WriteLine("########## PART 5 ############");
      Console.WriteLine();
      int[] coefficientsOne = { 4, -5, 1 };
      var polyOne = new Polynomial(coefficientsOne);
      Console.Write("Polynomial: ");
      polyOne.ToString();
      Console.Write("Derivative: ");
      polyOne.Derivative().ToString();


      int[] coefficientsTwo = { 1, 1, 0, 1 };
      var polyTwo = new Polynomial(coefficientsOne);
      Console.Write("Polynomial: ");
      polyTwo.ToString();
      Console.Write("Derivative: ");
      polyTwo.Derivative().ToString();
    }

    public static void AddDiffPrintTest()
    {
      Console.WriteLine("########## PART 6 ############");
      Console.WriteLine();
      int[] coefficientsOne = { 4, -5, 1, 0 };
      int[] coefficientsTwo = { 1, 1, 0, 1 };
      var polyOne = new Polynomial(coefficientsOne);
      var polyTwo = new Polynomial(coefficientsTwo);
      Console.Write("Polynomial 1: ");
      polyOne.ToString();
      Console.Write("Polynomial 2: ");
      polyTwo.ToString();
      Console.Write("Sum: ");
      polyOne.Sum(polyTwo).ToString();
      Console.Write("Difference: ");
      polyOne.Difference(polyTwo).ToString();

      coefficientsOne = new int[] { 4, -5, 1 };
      coefficientsTwo = new int[] { 4, -5, -1 };
      polyOne = new Polynomial(coefficientsOne);
      polyTwo = new Polynomial(coefficientsTwo);
      Console.Write("Polynomial 1: ");
      polyOne.ToString();
      Console.Write("Polynomial 2: ");
      polyTwo.ToString();
      Console.Write("Sum: ");
      polyOne.Sum(polyTwo).ToString();
      Console.Write("Difference: ");
      polyOne.Difference(polyTwo).ToString();
    }
  }
}
