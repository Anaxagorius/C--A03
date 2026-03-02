using System.Windows;
using System.Windows.Controls;
using Assignment03.Models;

namespace Assignment03.UserControls;

/// <summary>
/// Interaction logic for SupportStaffInfo.xaml
/// </summary>
public partial class SupportStaffInfo : UserControl
{
    // Custom delegates ───────────────────────────────────────────────────────

    public delegate void SupportStaffSavedHandler(NSSupportStaff staff);
    public delegate void SupportStaffCancelledHandler();

    /// <summary>Raised when the user successfully saves a support staff member.</summary>
    public event SupportStaffSavedHandler? SupportStaffSaved;

    /// <summary>Raised when the user clicks Cancel.</summary>
    public event SupportStaffCancelledHandler? SupportStaffCancelled;

    public SupportStaffInfo()
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

        var staff = new NSSupportStaff
        {
            FirstName    = TxtFirstName.Text.Trim(),
            LastName     = TxtLastName.Text.Trim(),
            EmployeeCode = TxtEmployeeCode.Text.Trim(),
            Department   = TxtDepartment.Text.Trim(),
            Email        = TxtEmail.Text.Trim(),
            SupportArea  = TxtSupportArea.Text.Trim()
        };

        // Show the personalized welcome message from NSSupportStaff.Display().
        MessageBox.Show(staff.Display(), "Support Staff Saved",
                        MessageBoxButton.OK, MessageBoxImage.Information);

        SupportStaffSaved?.Invoke(staff);

        // Clear fields after successful save.
        TxtFirstName.Text    = string.Empty;
        TxtLastName.Text     = string.Empty;
        TxtEmployeeCode.Text = string.Empty;
        TxtDepartment.Text   = string.Empty;
        TxtEmail.Text        = string.Empty;
        TxtSupportArea.Text  = string.Empty;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        TxtValidationError.Visibility = Visibility.Collapsed;
        SupportStaffCancelled?.Invoke();
    }
}
