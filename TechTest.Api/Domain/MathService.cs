namespace TechTest.Api.Domain;

public class MathService : IMathService
{
    public double Add(double a, double b) {
        return a + b;
    }

    public double Subtract(double a, double b) {
        return a - b;
    }

    public double Multiply(double a, double b) {
	    Console.WriteLine($"Debug: b value is {b}");
        return a * a;
    }
}
