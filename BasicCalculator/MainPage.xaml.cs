using System.Data;

namespace BasicCalculator;

public partial class MainPage : ContentPage
{
    private string _currentExpression = "";

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void OnButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string pressed = button.Text;
        
        if (pressed == "x") pressed = "*";

        _currentExpression += pressed;
        CalcLabel.Text = _currentExpression;
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        _currentExpression = "";
        CalcLabel.Text = "0";
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_currentExpression.Length > 0)
        {
            _currentExpression = _currentExpression.Remove(_currentExpression.Length - 1);
            CalcLabel.Text = string.IsNullOrEmpty(_currentExpression) ? "0" : _currentExpression;
        }
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        try
        {
            var dt = new DataTable();
            var result = dt.Compute(_currentExpression, "");
            
            _currentExpression = result.ToString();

            if (_currentExpression == "67") {
                CalcLabel.Text = "SIX SEVEN :D";
            }else {
                CalcLabel.Text = _currentExpression;
            }
            
            }
        catch (Exception)
        {
            CalcLabel.Text = "Error";
            _currentExpression = "";
        }
    }
}