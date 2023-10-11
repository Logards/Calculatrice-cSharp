using Avalonia.Controls;
using Avalonia.Interactivity;
using CalculatorQuest;


namespace Calculatrice;

public partial class CalculatriceScreen : Window
{
    public CalculatriceScreen()
    {
        InitializeComponent();
    }
    
    void Add(object? sender, RoutedEventArgs args)
    {
        string calcul;
        string result;
        Button b =  (sender as Button)!;
        if (b.Content.ToString() == "=")
        {
            calcul = Operation.Content.ToString();
            Result.Content = Calc.Operator(calcul);
            Operation.Content = "";
        }
        Operation.Content += b.Content.ToString();
    }
}