namespace Assignment03.Models;

/// <summary>
/// Represents a Northern Shores Support Staff member, inheriting from NSEmployee.
/// </summary>
public class NSSupportStaff : NSEmployee
{
    public string SupportArea { get; set; } = string.Empty;

    /// <summary>
    /// Returns a welcome message confirming the support staff member has been saved.
    /// </summary>
    public string Display()
    {
        return $"The newly added support staff details saved to the Database. " +
               $"Welcome new support staff member {FirstName} {LastName}.";
    }
}
