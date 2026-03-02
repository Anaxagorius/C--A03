using System.Windows;
using Assignment03.ViewModels;

namespace Assignment03.Windows;

/// <summary>
/// Interaction logic for SimpleBindingDemoWindow.xaml (Question 2).
///
/// DataContext: Setting DataContext to a MyData instance tells every {Binding}
/// in this window to resolve property names against that object.
/// No manual event wiring is needed — WPF's binding engine handles it.
/// </summary>
public partial class SimpleBindingDemoWindow : Window
{
    public SimpleBindingDemoWindow()
    {
        InitializeComponent();

        // Set DataContext so that {Binding MyName} in XAML resolves to
        // MyData.MyName.  This is the standard WPF data-binding pattern.
        DataContext = new MyData { MyName = "Type your name above…" };
    }
}
