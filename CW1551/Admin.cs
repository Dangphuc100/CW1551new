using System;

namespace CW1551
{
    /// <summary>
    /// Represents an Administrator in the system, inheriting from Person.
    /// Demonstrates Inheritance, Encapsulation, and Polymorphism.
    /// </summary>
    public class Admin : Person
    {
        // Encapsulation: Private backing fields specifically for Admins
        private decimal _salary;
        private string _employmentType;
        private string _workingHours;

        /// <summary>
        /// Gets the role of this entity.
        /// Overrides the abstract property from Person.
        /// </summary>
        public override string Role => "Admin";

        // -------------------------------------------------------------
        // Public Properties with validation (Encapsulation logic)
        // -------------------------------------------------------------

        /// <summary>
        /// Gets or sets the salary. Must not be negative.
        /// </summary>
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative.");
                _salary = value;
            }
        }

        /// <summary>
        /// Gets or sets the employment type (e.g. Full-time, Part-time).
        /// </summary>
        public string EmploymentType
        {
            get { return _employmentType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Employment Type cannot be empty.");
                _employmentType = value;
            }
        }

        /// <summary>
        /// Gets or sets the working hours of the admin.
        /// </summary>
        public string WorkingHours
        {
            get { return _workingHours; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Working Hours cannot be empty.");
                _workingHours = value;
            }
        }

        /// <summary>
        /// Constructor for the Admin class.
        /// Calls the base constructor and validates its own fields using property setters.
        /// </summary>
        public Admin(string name, string phone, string email, decimal salary, string employmentType, string workingHours)
            : base(name, phone, email)
        {
            Salary = salary;
            EmploymentType = employmentType;
            WorkingHours = workingHours;
        }

        /// <summary>
        /// Implements the abstract method from Person (Polymorphism).
        /// Returns a formatted summary string containing Admin specifics.
        /// </summary>
        public override string GetDetails()
        {
            // Building a detailed string representing an Admin
            return $"[Admin] {Name} | Email: {Email} | Salary: {Salary:C} | Emp: {EmploymentType} ({WorkingHours})";
        }
    }
}
