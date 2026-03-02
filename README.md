# PROG 2500 – Assignment 03

A WPF application targeting **.NET 9** demonstrating OOP inheritance, custom events/delegates, data binding, and `INotifyPropertyChanged`.

## Requirements

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (Windows)
* Visual Studio 2022+ **or** the `dotnet` CLI

## How to Run

```bash
# From the repository root
dotnet run --project Assignment03/Assignment03.csproj
```

Or open `Assignment03.slnx` in Visual Studio 2022 and press **F5**.

---

## Feature Map

| Assignment Task | Implementation |
|---|---|
| **Q1-1** `NSSupportStaff` inheriting `NSEmployee` | `Assignment03/Models/NSEmployee.cs`, `NSSupportStaff.cs` |
| **Q1-1** `Display()` method with personalized message | `NSSupportStaff.Display()` returns the exact required message |
| **Q1-2** `EmployeeInfo` UserControl | `Assignment03/UserControls/EmployeeInfo.xaml` + `.cs` |
| **Q1-2** `SupportStaffInfo` UserControl with unique styles | `Assignment03/UserControls/SupportStaffInfo.xaml` + `.cs` (uses `SupportLabel/TextBox/ButtonStyle` defined in `App.xaml`) |
| **Q1-3** Custom delegates & events (Save / Cancel) | `SupportStaffSavedHandler`, `SupportStaffCancelledHandler` in `SupportStaffInfo.xaml.cs` |
| **Q1-3** Save triggers `Display()` via `MessageBox` | `BtnSave_Click` in `SupportStaffInfo.xaml.cs` |
| **Q1-4** MainWindow – "Support Staff Details" button | Third `<Button>` in `MainWindow.xaml` left pane |
| **Q1-4** Right pane hosts selected UserControl | `ContentControl x:Name="ContentArea"` in `MainWindow.xaml` |
| **Q1-5** Validation errors; clear only on success | `TxtValidationError` shown on error; fields cleared only after valid save |
| **Q2** Simple binding with `DataContext` & `{Binding}` | `Assignment03/Windows/SimpleBindingDemoWindow.xaml` + `.cs` |
| **Q2** `INotifyPropertyChanged` | `Assignment03/ViewModels/MyData.cs` |
| **Q2** Comments explaining binding concepts | Inline XML/C# comments in `SimpleBindingDemoWindow.xaml`, `MyData.cs`, `SimpleBindingDemoWindow.xaml.cs` |

---

## Application Layout

```
┌──────────────────────┬──────────────────────────────────┐
│  Navigation          │                                  │
│  ──────────────────  │   (Selected UserControl appears  │
│  Employee Details    │    here)                         │
│  Support Staff Det.  │                                  │
│  Q2 – Data Binding   │                                  │
└──────────────────────┴──────────────────────────────────┘
```
