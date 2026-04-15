using System;

namespace CW1551
{
    /// <summary>
    /// Abstract base class representing a general Person in the educational system.
    /// This demonstrates encapsulation and provides a polymorphic base for derived classes.
    /// </summary>
    public abstract class Person
    {
        // -------------------------------------------------------------
        // Encapsulation: Private backing fields
        // -------------------------------------------------------------
        private string _name;
        private string _phone;
        private string _email;

        // -------------------------------------------------------------
        // Public Properties with validation (Encapsulation logic)
        // -------------------------------------------------------------

        /// <summary>
        /// Gets or sets the name of the person.
        /// Throws an exception if the value is empty.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the phone number of the person.
        /// Throws an exception if the value is empty.
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone cannot be empty.");
                _phone = value;
            }
        }

        /// <summary>
        /// Gets or sets the email address of the person.
        /// Throws an exception if the value is empty.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be empty.");
                _email = value;
            }
        }

        /// <summary>
        /// Abstract property that must be overridden by derived classes to indicate their role.
        /// </summary>
        public abstract string Role { get; }

        /// <summary>
        /// Constructor to initialize the Person object.
        /// Uses the property setters to ensure validation logic runs upon creation.
        /// </summary>
        public Person(string name, string phone, string email)
        {
            // Assigning to properties (Name, Phone, Email) instead of backing fields 
            // to re-use the validation logic built into the setters.
            Name = name;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Abstract method demonstrating polymorphism.
        /// Each sub-class must provide its own specific implementation.
        /// </summary>
        /// <returns>A formatted string detailing the person.</returns>
        public abstract string GetDetails();
    }
}
