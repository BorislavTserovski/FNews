using FakeNews.Data.Models;
using System;

namespace FakeNews.Services.Implementations
{
    public class CalculatorService : ICalculatorService
    {
        public double Calculate(Gender gender, double weight, double height, int age)
        {
            var BMI = Math.Round(weight / ((height / 100) * (height / 100)), 2);

            return BMI;
        }
    }
}