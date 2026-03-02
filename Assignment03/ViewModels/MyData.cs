using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment03.ViewModels;

/// <summary>
/// A simple data class that implements INotifyPropertyChanged so that the UI
/// is automatically updated whenever a property value changes.
///
/// INotifyPropertyChanged: The interface that enables "data binding" in WPF.
/// When a bound property changes, PropertyChanged is raised and WPF updates
/// all controls that are bound to that property — without any manual UI code.
/// </summary>
public class MyData : INotifyPropertyChanged
{
    // Backing field for the bound property.
    private string _myName = string.Empty;

    /// <summary>
    /// The property exposed to the UI via {Binding MyName}.
    /// The setter calls OnPropertyChanged so WPF refreshes the bound TextBlock.
    /// </summary>
    public string MyName
    {
        get => _myName;
        set
        {
            if (_myName == value) return;
            _myName = value;
            // Notify WPF that MyName changed — triggers UI refresh.
            OnPropertyChanged();
        }
    }

    // INotifyPropertyChanged implementation ──────────────────────────────────

    /// <summary>
    /// Raised whenever a property value changes.
    /// WPF subscribes to this event automatically when you use {Binding}.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <param name="propertyName">
    /// Filled in by the compiler via [CallerMemberName] — no need to type it.
    /// </param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
