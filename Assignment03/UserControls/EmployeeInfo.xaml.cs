using System.Windows;
using System.Windows.Controls;
using Assignment03.Models;

namespace Assignment03.UserControls;

/// <summary>
/// Interaction logic for EmployeeInfo.xaml
/// </summary>
public partial class EmployeeInfo : UserControl
{
    // Custom delegates and events ────────────────────────────────────────────

    public delegate void EmployeeSavedHandler(NSEmployee employee);
    public delegate void EmployeeCancelledHandler();

    /// <summary>Raised when the user successfully saves an employee.</summary>
    public event EmployeeSavedHandler? EmployeeSaved;

    /// <summary>Raised when the user clicks Cancel.</summary>
    public event EmployeeCancelledHandler? EmployeeCancelled;

    public EmployeeInfo()
    {
        InitializeComponent();
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        // Validate required fields — do NOT clear on error.
        if (string.IsNullOrWhiteSpace(TxtFirstName.Text) ||
            string.IsNullOrWhiteSpace(TxtLastName.Text) ||
            string.IsNullOrWhiteSpace(TxtEmployeeCode.Text))
        {
            TxtValidationError.Text = "First Name, Last Name and Employee Code are required.";
            TxtValidationError.Visibility = Visibility.Visible;
            return;
        }

        TxtValidationError.Visibility = Visibility.Collapsed;

        var employee = new NSEmployee
        {
            FirstName    = TxtFirstName.Text.Trim(),
            LastName     = TxtLastName.Text.Trim(),
            EmployeeCode = TxtEmployeeCode.Text.Trim(),
            Department   = TxtDepartment.Text.Trim(),
            Email        = TxtEmail.Text.Trim()
        };

        EmployeeSaved?.Invoke(employee);

        // Clear fields after successful save.
        TxtFirstName.Text    = string.Empty;
        TxtLastName.Text     = string.Empty;
        TxtEmployeeCode.Text = string.Empty;
        TxtDepartment.Text   = string.Empty;
        TxtEmail.Text        = string.Empty;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        TxtValidationError.Visibility = Visibility.Collapsed;
        EmployeeCancelled?.Invoke();
    }
}
