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
    public partial class StateDetailsForm : Form
    {
        private StateInfo _state;
        public StateDetailsForm(StateInfo state)
        {
            InitializeComponent();
            _state = state;
        }

        private void StateDetailsForm_Load(object sender, EventArgs e)
        {
            lblState.Text = _state.Name.ToString();
            lblCapital.Text = _state.Capital.ToString();
            lblPopulation.Text = _state.Population.ToString("N0");
            lblIncome.Text = _state.MedianIncome.ToString("C");
            lblComputerPercent.Text = _state.ComputerJobPercentage.ToString("P1");
            lblBird.Text = _state.Bird.ToString();
            lblFlower.Text = _state.Flower.ToString();
            lblColors.Text = _state.Colors.ToString();
            lblFlag.Text = _state.FlagDescription.ToString();
            lblCities.Text = string.Join(", ", _state.LargestCities);
        }
    }
}
