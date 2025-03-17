namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        private double currentNumber = 0;
        private double previousNumber = 0;
        private string operatorSymbol = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }
        private double Calculate(string input)
        {
            try
            {
                
                return Convert.ToDouble(input);
            }
            catch (FormatException)
            {
                
                return 0;
            }
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (DisplayLabel.Text == "0")
                DisplayLabel.Text = button.Text;
            else
                DisplayLabel.Text += button.Text;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            previousNumber = double.Parse(DisplayLabel.Text);
            operatorSymbol = button.Text;
            DisplayLabel.Text = "0";
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(DisplayLabel.Text, out currentNumber))
            {
                DisplayLabel.Text = "Error";
                return;
            }

            double result;
            try
            {
                result = operatorSymbol switch
                {
                    "+" => previousNumber + currentNumber,
                    "−" => previousNumber - currentNumber,
                    "×" => previousNumber * currentNumber,
                    "÷" when currentNumber == 0 => throw new DivideByZeroException(),
                    "÷" => previousNumber / currentNumber,
                    _ => 0,
                };
                DisplayLabel.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                DisplayLabel.Text = "0'a bölme hatası!!";
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentNumber = 0;
            previousNumber = 0;
            operatorSymbol = string.Empty;
            DisplayLabel.Text = "0";
        }

        

        private void OnToggleSignClicked(object sender, EventArgs e)
        {
            if (double.TryParse(DisplayLabel.Text, out double number))
                DisplayLabel.Text = (-number).ToString();
        }

        private void OnPercentClicked(object sender, EventArgs e)
        {
            if (double.TryParse(DisplayLabel.Text, out double number))
                DisplayLabel.Text = (number / 100).ToString();
        }
    }

}
