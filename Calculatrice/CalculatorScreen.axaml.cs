using System;
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
    
    void Delete(object? sender, RoutedEventArgs args)
    {
        if (Operation.Content.ToString().Length > 0)
        {
            Operation.Content = (Operation.Content.ToString()).Remove(Operation.Content.ToString().Length - 1);
        }
    }

    void Clear(object? sender, RoutedEventArgs args)
    {
        Operation.Content = null;
        Result.Content = null;
    }
    void ClearE(object? sender, RoutedEventArgs args)
    {
        Operation.Content = null;
    }
    
    void Add(object? sender, RoutedEventArgs args)
    {
        string calcul;
        Button b =  (sender as Button)!;
        if (b.Content.ToString() == "1/x")
        {
            Operation.Content += "1/";
        }
        else
        {
            Operation.Content += b.Content.ToString();
        }
        if (b.Content.ToString() == "=")
        {
            calcul = Operation.Content.ToString();
            Result.Content = Calc.Operator(calcul);
            Operation.Content = "";
        }
    }
}