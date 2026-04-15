using System;

namespace CW1551
{
    /// <summary>
    /// Represents a Student in the system, inheriting from Person.
    /// Demonstrates Inheritance, Encapsulation, and Polymorphism.
    /// </summary>
    public class Student : Person
    {
        // Encapsulation: Private backing fields for Student grades or subjects
        private string _subject1;
        private string _subject2;
        private string _subject3;

        /// <summary>
        /// Gets the role of this entity.
        /// </summary>
        public override string Role => "Student";

        // -------------------------------------------------------------
        // Public Properties with validation (Encapsulation logic)
        // -------------------------------------------------------------

        /// <summary>
        /// Enrolled Subject 1
        /// </summary>
        public string Subject1
        {
            get { return _subject1; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Subject 1 cannot be empty.");
                _subject1 = value; 
            }
        }

        /// <summary>
        /// Enrolled Subject 2
        /// </summary>
        public string Subject2
        {
            get { return _subject2; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Subject 2 cannot be empty.");
                _subject2 = value; 
            }
        }

        /// <summary>
        /// Enrolled Subject 3
        /// </summary>
        public string Subject3
        {
            get { return _subject3; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Subject 3 cannot be empty.");
                _subject3 = value; 
            }
        }

        /// <summary>
        /// Constructor for Student.
        /// </summary>
        public Student(string name, string phone, string email, string sub1, string sub2, string sub3)
            : base(name, phone, email)
        {
            Subject1 = sub1;
            Subject2 = sub2;
            Subject3 = sub3;
        }

        /// <summary>
        /// Polymorphic override to return student specific details.
        /// </summary>
        public override string GetDetails()
        {
            return $"[Student] {Name} | Enrolled In: {Subject1}, {Subject2}, {Subject3}";
        }
    }
}
