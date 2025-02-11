using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace DemoMVVM
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _input;
        private string _result;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged(nameof(Input));
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }

        public CalculatorViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            ClearCommand = new RelayCommand(Clear);
        }

        private bool CanCalculate(object parameter) => true;

        private void Calculate(object parameter)
        {
            try
            {
                Result = new DataTable().Compute(Input, null).ToString();
            }
            catch
            {
                Result = "Erreur";
            }
        }

        private void Clear(object parameter)
        {
            Input = "";
            Result = "";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
