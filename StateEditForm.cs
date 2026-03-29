using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Billow_Lab_3
{
    public partial class StateEditForm : Form
    {
        private StateInfo _state;
        public StateEditForm(StateInfo state)
        {
            InitializeComponent();
            _state = state;
        }

        private void StateEditForm_Load(object sender, EventArgs e)
        {
            lblEditTitle.Text = $"Editing: {_state.Name}";
            txtStateName.Text = _state.Name;
            txtCapital.Text = _state.Capital;
            txtPopulation.Text = _state.Population.ToString();
            txtMedianIncome.Text = _state.MedianIncome.ToString();
            txtJobsPercent.Text = _state.ComputerJobPercentage.ToString();
            txtBird.Text = _state.Bird;
            txtFlower.Text = _state.Flower;
            txtColors.Text = _state.Colors;
            txtFlag.Text = _state.FlagDescription;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!long.TryParse(txtPopulation.Text, out long population))
            {
                MessageBox.Show("Please enter a valid population number.");
                return;
            }
            if (population < 0)
            {
                MessageBox.Show("Population cannot be negative.");
                return;
            }
            if (!decimal.TryParse(txtMedianIncome.Text, out decimal medianIncome))
            {
                MessageBox.Show("Please enter a valid median income.");
                return;
            }
            if (medianIncome < 0)
            {
                MessageBox.Show("Median income cannot be negative.");
                return;
            }
            if (!double.TryParse(txtJobsPercent.Text, out double jobsPercent))
            {
                MessageBox.Show("Please enter a valid computer job percentage.");
                return;
            }
            if (jobsPercent < 0 || jobsPercent > 1)
            {
                MessageBox.Show("Computer job percentage must be between 0 and 1.");
                return;
            }
            //update objects
            _state.Name = txtStateName.Text.Trim();
            _state.Capital = txtCapital.Text.Trim();
            _state.Population = population;
            _state.MedianIncome = medianIncome;
            _state.ComputerJobPercentage = jobsPercent;
            _state.Bird = txtBird.Text.Trim();
            _state.Flower = txtFlower.Text.Trim();
            _state.Colors = txtColors.Text.Trim();
            _state.FlagDescription = txtFlag.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
