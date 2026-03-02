using System.Windows;
using Assignment03.UserControls;
using Assignment03.Windows;

namespace Assignment03;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Show Employee Details by default on startup.
        ShowEmployeeInfo();
    }

    // Navigation button handlers ─────────────────────────────────────────────

    private void BtnEmployee_Click(object sender, RoutedEventArgs e) => ShowEmployeeInfo();

    private void BtnSupportStaff_Click(object sender, RoutedEventArgs e) => ShowSupportStaffInfo();

    private void BtnBindingDemo_Click(object sender, RoutedEventArgs e)
    {
        var demo = new SimpleBindingDemoWindow { Owner = this };
        demo.ShowDialog();
    }

    // Helper methods ──────────────────────────────────────────────────────────

    private void ShowEmployeeInfo()
    {
        var control = new EmployeeInfo();
        control.EmployeeSaved      += staff => MessageBox.Show($"Employee {staff.FirstName} {staff.LastName} saved.", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        control.EmployeeCancelled  += () => MessageBox.Show("Employee entry cancelled.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Information);
        ContentArea.Content = control;
    }

    private void ShowSupportStaffInfo()
    {
        var control = new SupportStaffInfo();
        // SupportStaffSaved: the Display() message is shown inside the control itself.
        control.SupportStaffSaved      += _ => { /* additional host-level handling can go here */ };
        control.SupportStaffCancelled  += () => MessageBox.Show("Support staff entry cancelled.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Information);
        ContentArea.Content = control;
    }
}
