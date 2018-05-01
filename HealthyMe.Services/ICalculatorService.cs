using FakeNews.Data.Models;

namespace FakeNews.Services
{
    public interface ICalculatorService
    {
        double Calculate(Gender gender, double weight, double height, int age);
    }
}