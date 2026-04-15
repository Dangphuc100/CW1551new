using System;

namespace CW1551
{
    /// <summary>
    /// Represents a Teacher in the system, inheriting from Person.
    /// Demonstrates Inheritance, Encapsulation, and Polymorphism.
    /// </summary>
    public class Teacher : Person
    {
        // Encapsulation: Private backing fields for Teachers
        private decimal _salary;
        private string _subject1;
        private string _subject2;

        /// <summary>
        /// Gets the role of this entity.
        /// </summary>
        public override string Role => "Teacher";

        // -------------------------------------------------------------
        // Public Properties with validation (Encapsulation logic)
        // -------------------------------------------------------------

        /// <summary>
        /// Gets or sets the teacher's salary. Must not be negative.
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
        /// Gets or sets the first subject the teacher handles.
        /// </summary>
        public string Subject1
        {
            get { return _subject1; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Subject 1 cannot be empty.");
                _subject1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the second subject the teacher handles.
        /// </summary>
        public string Subject2
        {
            get { return _subject2; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Subject 2 cannot be empty.");
                _subject2 = value;
            }
        }

        /// <summary>
        /// Constructor for Teacher.
        /// </summary>
        public Teacher(string name, string phone, string email, decimal salary, string sub1, string sub2)
            : base(name, phone, email)
        {
            Salary = salary;
            Subject1 = sub1;
            Subject2 = sub2;
        }

        /// <summary>
        /// Polymorphic override to return teacher specific details.
        /// </summary>
        public override string GetDetails()
        {
            return $"[Teacher] {Name} | Subs: {Subject1}, {Subject2} | Salary: {Salary:C}";
        }
    }
}
