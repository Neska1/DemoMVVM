namespace DemoMVVM
{
    public class AppDataContext
    {
        public CalculatorViewModel CalculatorVM { get; }

        public AppDataContext()
        {
            CalculatorVM = new CalculatorViewModel();
        }
    }
}

