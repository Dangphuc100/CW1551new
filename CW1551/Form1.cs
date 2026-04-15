using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CW1551
{
    /// <summary>
    /// Form1 is the main user interface for the Greenwich Education Management System.
    /// It handles capturing user input, displaying data via DataGridView, and provides Main Menu interactions.
    /// This heavily relies on Encapsulation (fetching properties securely) and Polymorphism (handling 'Person' objects).
    /// </summary>
    public partial class Form1 : Form
    {
        // -------------------------------------------------------------------------
        // Field Declarations
        // -------------------------------------------------------------------------
        
        /// <summary>
        /// Centralized data structure storing all persons.
        /// Demonstrates usage of a generic List capable of holding objects of unknown quantities.
        /// </summary>
        private readonly List<Person> personList;

        /// <summary>
        /// Constructor for the main form. Initializes components and data structures.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            personList = new List<Person>();
            SetupApplication();
            SetupMainMenu(); // Initialize the dynamic MenuStrip requested by requirements
        }

        #region Initialization & Menu Setup

        /// <summary>
        /// Dynamically builds and attaches the MenuStrip to substitute simple buttons
        /// and fulfill the 'Main Menu' + 'View By Role' requirements cleanly.
        /// </summary>
        private void SetupMainMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            
            // Build the "File" menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += (s, e) => Application.Exit();
            fileMenu.DropDownItems.Add(exitItem);

            // Build the "View By Role" menu for specialized filtering
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("View By Role");
            
            ToolStripMenuItem viewAll = new ToolStripMenuItem("View All");
            viewAll.Click += (s, e) => { RefreshGrid(personList); MessageBox.Show("Showing all records."); };
            
            ToolStripMenuItem viewAdmins = new ToolStripMenuItem("Admins Only");
            viewAdmins.Click += (s, e) => FilterByRoleMenu("Admin");

            ToolStripMenuItem viewTeachers = new ToolStripMenuItem("Teachers Only");
            viewTeachers.Click += (s, e) => FilterByRoleMenu("Teacher");

            ToolStripMenuItem viewStudents = new ToolStripMenuItem("Students Only");
            viewStudents.Click += (s, e) => FilterByRoleMenu("Student");

            viewMenu.DropDownItems.Add(viewAll);
            viewMenu.DropDownItems.Add(new ToolStripSeparator());
            viewMenu.DropDownItems.Add(viewAdmins);
            viewMenu.DropDownItems.Add(viewTeachers);
            viewMenu.DropDownItems.Add(viewStudents);

            // Add menus to the bar
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(viewMenu);

            // Attach to form
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
            
            // Auto size configuration
            this.Controls.SetChildIndex(menuStrip, 0); // Put at top logically
        }

        /// <summary>
        /// Action handler for filtering the grid explicitly by a selected role from the MenuStrip.
        /// </summary>
        private void FilterByRoleMenu(string roleToFilter)
        {
            var filtered = personList.Where(p => p.Role == roleToFilter).ToList();
            RefreshGrid(filtered);
            MessageBox.Show($"Showing {filtered.Count} {roleToFilter}(s).");
        }

        /// <summary>
        /// Configures initial UI states like ComboBox options and DataGridView columns.
        /// </summary>
        private void SetupApplication()
        {
            // Populate Role combo box
            cbRole.Items.Clear();
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Teacher");
            cbRole.Items.Add("Student");
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            // Populate Employment Type extra combo box
            cbExtra2.Items.Clear();
            cbExtra2.Items.Add("Full-time");
            cbExtra2.Items.Add("Part-time");
            cbExtra2.DropDownStyle = ComboBoxStyle.DropDownList;

            ConfigureGridColumns();
            
            // Grid UI rules
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.DataError += DataGridView1_DataError;
        }

        #endregion

        #region UI Data Binding and Formatting

        /// <summary>
        /// Refreshes the DataGridView content by unbinding and rebinding the data source.
        /// </summary>
        /// <param name="listToDisplay">The list of generic Person objects to render.</param>
        private void RefreshGrid(List<Person> listToDisplay)
        {
            // Clear current layout binding to force a clean redraw
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listToDisplay;
        }

        /// <summary>
        /// Manually maps DataGridView columns to match object properties safely.
        /// </summary>
        private void ConfigureGridColumns()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Core abstract properties
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", DataPropertyName = "Name" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone", DataPropertyName = "Phone" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", HeaderText = "Role", DataPropertyName = "Role" });

            // Specific role properties (populated via CellFormatting event)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Salary", HeaderText = "Salary" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmploymentType", HeaderText = "Emp. Type" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "WorkingHours", HeaderText = "Work Hours" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject1", HeaderText = "Subject 1" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject2", HeaderText = "Subject 2" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject3", HeaderText = "Subject 3" });
        }

        /// <summary>
        /// Event handler used to dynamically map polymorphism data into columns.
        /// Depending on whether the Person is a Student, Teacher, or Admin, it pulls the appropriate values.
        /// </summary>
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is not Person person) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Apply specific object characteristics based on Type checking (Run-time type identification)
            if (columnName == "Salary")
            {
                if (person is Admin admin) e.Value = admin.Salary.ToString("C"); // Currency format
                else if (person is Teacher teacher) e.Value = teacher.Salary.ToString("C");
                else e.Value = string.Empty;
                e.FormattingApplied = true;
            }
            else if (columnName == "EmploymentType")
            {
                e.Value = person is Admin admin ? admin.EmploymentType : string.Empty;
                e.FormattingApplied = true;
            }
            else if (columnName == "WorkingHours")
            {
                e.Value = person is Admin admin ? admin.WorkingHours : string.Empty;
                e.FormattingApplied = true;
            }
            else if (columnName == "Subject1")
            {
                if (person is Teacher teacher) e.Value = teacher.Subject1;
                else if (person is Student student) e.Value = student.Subject1;
                else e.Value = string.Empty;
                e.FormattingApplied = true;
            }
            else if (columnName == "Subject2")
            {
                if (person is Teacher teacher) e.Value = teacher.Subject2;
                else if (person is Student student) e.Value = student.Subject2;
                else e.Value = string.Empty;
                e.FormattingApplied = true;
            }
            else if (columnName == "Subject3")
            {
                e.Value = person is Student student ? student.Subject3 : string.Empty;
                e.FormattingApplied = true;
            }
        }

        /// <summary>
        /// Silences intrinsic data errors thrown by the DataGridView when binding complex logic.
        /// </summary>
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        #endregion

        #region UI Interactions

        /// <summary>
        /// Clears all input textboxes and resets selections to default states.
        /// Useful after add/edit/delete operations.
        /// </summary>
        private void ClearInputs()
        {
            txtName.Text = txtPhone.Text = txtEmail.Text = string.Empty;
            txtExtra1.Text = txtExtra2.Text = txtExtra3.Text = string.Empty;

            cbRole.SelectedIndex = -1;
            cbExtra2.SelectedIndex = -1;

            txtName.Focus(); // Return user focus securely

            // Hide dynamic controls
            lbExtra1.Visible = txtExtra1.Visible = false;
            lbExtra2.Visible = txtExtra2.Visible = false;
            cbExtra2.Visible = false;
            lbExtra3.Visible = txtExtra3.Visible = false;

            if (dataGridView1.DataSource != null)
            {
                dataGridView1.ClearSelection();
            }
        }

        /// <summary>
        /// Dynamically alters the visibility and text of entry fields based on target role.
        /// </summary>
        /// <param name="selectedRole">The role selected in the drop-down.</param>
        private void ConfigureRoleSpecificInputs(string selectedRole)
        {
            // Reset state
            lbExtra1.Visible = txtExtra1.Visible = false;
            lbExtra2.Visible = txtExtra2.Visible = false;
            cbExtra2.Visible = false;
            lbExtra3.Visible = txtExtra3.Visible = false;

            if (selectedRole == "Student")
            {
                lbExtra1.Text = "Subject 1";
                lbExtra2.Text = "Subject 2";
                lbExtra3.Text = "Subject 3";

                lbExtra1.Visible = txtExtra1.Visible = true;
                lbExtra2.Visible = txtExtra2.Visible = true;
                lbExtra3.Visible = txtExtra3.Visible = true;
            }
            else if (selectedRole == "Teacher")
            {
                lbExtra1.Text = "Salary";
                lbExtra2.Text = "Subject 1";
                lbExtra3.Text = "Subject 2";

                lbExtra1.Visible = txtExtra1.Visible = true;
                lbExtra2.Visible = txtExtra2.Visible = true;
                lbExtra3.Visible = txtExtra3.Visible = true;
            }
            else if (selectedRole == "Admin")
            {
                lbExtra1.Text = "Salary";
                lbExtra2.Text = "Emp. Type";
                lbExtra3.Text = "Work Hours";

                lbExtra1.Visible = txtExtra1.Visible = true;
                lbExtra2.Visible = cbExtra2.Visible = true;
                lbExtra3.Visible = txtExtra3.Visible = true;
            }
        }

        /// <summary>
        /// Reads object properties and maps them onto the UI controls when a grid row is clicked.
        /// </summary>
        /// <param name="selectedPerson">The active polymorphic entity.</param>
        private void PopulateInputsFromPerson(Person selectedPerson)
        {
            // Fill abstract base fields
            txtName.Text = selectedPerson.Name;
            txtPhone.Text = selectedPerson.Phone;
            txtEmail.Text = selectedPerson.Email;
            cbRole.Text = selectedPerson.Role;

            // Type check and fill specialized fields
            if (selectedPerson is Admin adminObj)
            {
                txtExtra1.Text = adminObj.Salary.ToString();
                cbExtra2.Text = adminObj.EmploymentType;
                txtExtra3.Text = adminObj.WorkingHours;
            }
            else if (selectedPerson is Teacher teacherObj)
            {
                txtExtra1.Text = teacherObj.Salary.ToString();
                txtExtra2.Text = teacherObj.Subject1;
                txtExtra3.Text = teacherObj.Subject2;
            }
            else if (selectedPerson is Student studentObj)
            {
                txtExtra1.Text = studentObj.Subject1;
                txtExtra2.Text = studentObj.Subject2;
                txtExtra3.Text = studentObj.Subject3;
            }
        }

        #endregion

        #region Domain Logic & Error Handling

        /// <summary>
        /// Attempts to allocate memory for a new derived Person object while capturing encapsulation validation errors.
        /// </summary>
        /// <returns>A concrete Person instance, or null if creation fails to satisfy constraints.</returns>
        private Person SafeCreatePerson()
        {
            try
            {
                // Note: The setters within classes will throw ArgumentException if validation fails.
                if (cbRole.Text == "Admin")
                {
                    if(!decimal.TryParse(txtExtra1.Text, out decimal salary)) throw new ArgumentException("Salary must be a valid number.");
                    return new Admin(txtName.Text, txtPhone.Text, txtEmail.Text, salary, cbExtra2.Text, txtExtra3.Text);
                }
                if (cbRole.Text == "Teacher")
                {
                    if(!decimal.TryParse(txtExtra1.Text, out decimal salary)) throw new ArgumentException("Salary must be a valid number.");
                    return new Teacher(txtName.Text, txtPhone.Text, txtEmail.Text, salary, txtExtra2.Text, txtExtra3.Text);
                }
                if (cbRole.Text == "Student")
                {
                    return new Student(txtName.Text, txtPhone.Text, txtEmail.Text, txtExtra1.Text, txtExtra2.Text, txtExtra3.Text);
                }
                throw new ArgumentException("Role is not selected.");
            }
            catch (ArgumentException ex)
            {
                // This correctly alerts the user to invalid inputs caught by object Encapsulation
                MessageBox.Show(ex.Message, "Encapsulation Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        /// <summary>
        /// Attempts to update properties on an existing object, capturing internal validation faults.
        /// </summary>
        private bool SafeUpdatePerson(Person selectedPerson)
        {
            try
            {
                // Assign generalized properties through property accessors (triggers validation)
                selectedPerson.Name = txtName.Text;
                selectedPerson.Phone = txtPhone.Text;
                selectedPerson.Email = txtEmail.Text;

                // Cast to specific type to assign distinct fields safely
                if (selectedPerson is Admin adminObj)
                {
                    if (!decimal.TryParse(txtExtra1.Text, out decimal sal)) throw new ArgumentException("Salary must be numeric.");
                    adminObj.Salary = sal;
                    adminObj.EmploymentType = cbExtra2.Text;
                    adminObj.WorkingHours = txtExtra3.Text;
                }
                else if (selectedPerson is Teacher teacherObj)
                 {
                    if (!decimal.TryParse(txtExtra1.Text, out decimal sal)) throw new ArgumentException("Salary must be numeric.");
                    teacherObj.Salary = sal;
                    teacherObj.Subject1 = txtExtra2.Text;
                    teacherObj.Subject2 = txtExtra3.Text;
                }
                 else if (selectedPerson is Student studentObj)
                {
                    studentObj.Subject1 = txtExtra1.Text;
                    studentObj.Subject2 = txtExtra2.Text;
                    studentObj.Subject3 = txtExtra3.Text;
                }
                return true; // Successfully updated state
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// Validates phone uniqueness dynamically.
        /// </summary>
        private bool IsUnique(Person currentIgnore = null)
        {
            if (personList.Any(p => p != currentIgnore && p.Phone == txtPhone.Text))
            {
                MessageBox.Show("Phone number must be globally unique.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
             if (personList.Any(p => p != currentIgnore && p.Email == txtEmail.Text))
            {
                MessageBox.Show("Email must be globally unique.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region Event Handlers

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Triggers UI reconstruction based on chosen polymorphic domain type.
            ConfigureRoleSpecificInputs(cbRole.Text);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Map row selection safely without crashing on null frames.
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.CurrentRow != null &&
                dataGridView1.CurrentRow.Index >= 0 &&
                dataGridView1.CurrentRow.DataBoundItem is Person selectedPerson)
            {
                PopulateInputsFromPerson(selectedPerson);
            }
        }

        /// <summary>
        /// Handles object creation request. Connects UI intention with backend generation logic.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsUnique(null)) return; // Check duplication bounds

            Person newPerson = SafeCreatePerson(); // Builds entity dynamically depending on Role
            if (newPerson == null) return; // Halt if instantiation triggered validation breaks.

            personList.Add(newPerson);
            RefreshGrid(personList); // Redraw
            ClearInputs();
            MessageBox.Show("Added successfully.\n" + newPerson.GetDetails(), "Success"); // Demonstrate polymorphism!
        }

        /// <summary>
        /// Clears filters and displays all entities in list.
        /// </summary>
        private void btnView_Click(object sender, EventArgs e)
        {
            RefreshGrid(personList);
            ClearInputs();
        }

        /// <summary>
        /// Simple search query system operating over the global Person generic list.
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<Person> filteredResults = null;

            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                // LINQ lambda mapping for robust query extraction
                filteredResults = personList
                    .Where(p => p.Name.IndexOf(txtName.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            else if (!string.IsNullOrWhiteSpace(cbRole.Text))
            {
                filteredResults = personList.Where(p => p.Role == cbRole.Text).ToList();
            }

            if (filteredResults != null)
            {
                RefreshGrid(filteredResults);
            }
        }

        /// <summary>
        /// Manages mutable state change requests via object replacement or assignment.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Person selectedPerson)
            {
                if (!IsUnique(selectedPerson)) return;

                if (selectedPerson.Role != cbRole.Text)
                {
                    Person replacement = SafeCreatePerson();
                    if (replacement == null) return; 
                    
                    // If moving classes (e.g. Teacher to Admin), we mutate it via replacement
                    // since C# statically enforces single inheritance layout footprints at memory creation time.
                    int storageIndex = personList.IndexOf(selectedPerson);
                    personList.RemoveAt(storageIndex);
                    personList.Insert(storageIndex, replacement);
                }
                else
                {
                    // Mutable properties via safe interface accessor logic
                    if (!SafeUpdatePerson(selectedPerson)) return;
                }

                RefreshGrid(personList);
                MessageBox.Show("Record updated successfully.\n" + selectedPerson.GetDetails(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Prunes target memory instances utilizing standard .Remove operation against pointer addresses.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is Person targetPerson)
            {
                // Confirmation block protecting from accidental purges
                if (MessageBox.Show("Delete " + targetPerson.Name + "?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    personList.Remove(targetPerson);
                    RefreshGrid(personList);
                    ClearInputs();
                }
            }
        }

        #endregion

        #region Designer Event Stubs

        // Legacy stubs kept to prevent Designer XML compilation failures.
        private void label1_Click(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void lbPhone_Click(object sender, EventArgs e) { }

        #endregion
    }
}
