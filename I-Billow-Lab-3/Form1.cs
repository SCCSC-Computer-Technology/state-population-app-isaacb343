using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StateLibrary;

namespace I_Billow_Lab_3
{
    public partial class Form1 : Form
    {
        private StateRepository repo;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Application.StartupPath + "\\states.db";
                repo = new StateRepository($"Data Source={dbPath};");
                var states = repo.GetAllStates();
                //populate dropdown with states
                cboStates.Items.Clear();
                foreach (var state in states)
                {
                    cboStates.Items.Add(state.Name);
                }
                if (cboStates.Items.Count > 0)
                    cboStates.SelectedIndex = 0;

                MessageBox.Show("Database connected. States loaded: " + states.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void btnOpenSearchForm_Click(object sender, EventArgs e)
        {
            var states = repo.GetAllStates();
            var form = new SearchSortFilterForm(states);
            form.ShowDialog();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (cboStates.SelectedItem == null)
            {
                MessageBox.Show("Please select a state from the dropdown.");
                return;
            }
            string selectedStateName = cboStates.SelectedItem.ToString();

            //get list of states from the repository and find the selected state
            var states = repo.GetAllStates();
            var selectedState = states.FirstOrDefault(s => s.Name == selectedStateName);

            if (selectedState == null)
            {
                MessageBox.Show("Selected state not found in the database.");
                return;
            }
            //open details form
            var detailsForm = new StateDetailsForm(selectedState);
            detailsForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditState_Click(object sender, EventArgs e)
        {
            if (cboStates.SelectedItem == null)
            {
                MessageBox.Show("Please select a state from the dropdown.");
                return;
            }
            string selectedStateName = cboStates.SelectedItem.ToString();
            //get list of states from repository and find the selected state
            var states = repo.GetAllStates();
            var selectedState = states.FirstOrDefault(s => s.Name == selectedStateName);
            if (selectedState == null)
            {
                MessageBox.Show("Selected state not found in the database.");
                return;
            }
            //open edit form
            var editForm = new StateEditForm(selectedState);
            //if user clicks save, update the state in the database and refresh the dropdown
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    repo.UpdateState(selectedState);
                    //refresh dropdown
                    cboStates.Items.Clear();
                    foreach (var state in states)
                    {
                        cboStates.Items.Add(state.Name);
                    }
                    cboStates.SelectedItem = selectedState.Name;
                    MessageBox.Show("State updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating state: " + ex.Message);
                }
            }
        }
    }
}
