using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace I_Billow_Lab_3
{
    public partial class SearchSortFilterForm : Form
    {
        private List<StateInfo> allStates;
        public List<StateInfo> Results { get; private set; }
        private bool _isInitializingFilter = false;
        public SearchSortFilterForm(List<StateInfo> states)
        {
            InitializeComponent();
            allStates = states;
        }
        private void SearchSortFilterForm_Load(object sender, EventArgs e)
        {
            //Populate the category combo box with the appropriate options
            if (cboCategory.Items.Count == 0)
            {
                cboCategory.Items.Add("Name");
                cboCategory.Items.Add("Capital");
                cboCategory.Items.Add("City");
                cboCategory.Items.Add("Bird");
                cboCategory.Items.Add("Flower");
                cboCategory.Items.Add("Colors");
                cboCategory.SelectedIndex = 0;
            }
            //Load the DataGridView with all states
            LoadGrid(allStates);
            dgvStatesCities.AutoGenerateColumns = true;
            dgvStatesCities.AllowUserToOrderColumns = true;
            dgvStatesCities.AllowUserToResizeColumns = true;
            dgvStatesCities.AllowUserToResizeRows = false;
            dgvStatesCities.ReadOnly = true;
            dgvStatesCities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //populate the sort combo box with the appropriate options
            cboSorting.Items.Add("- Alphabetical -");
            cboSorting.Items.Add("State Name A-Z");
            cboSorting.Items.Add("State Name Z-A");
            cboSorting.Items.Add("Capital A-Z");
            cboSorting.Items.Add("Capital Z-A");
            cboSorting.Items.Add("Bird A-Z");
            cboSorting.Items.Add("Bird Z-A");
            cboSorting.Items.Add("Flower A-Z");
            cboSorting.Items.Add("Flower Z-A");
            cboSorting.Items.Add("- Numerical -");
            cboSorting.Items.Add("Population Ascending");
            cboSorting.Items.Add("Population Descending");
            cboSorting.Items.Add("Median Income Ascending");
            cboSorting.Items.Add("Median Income Descending");
            cboSorting.Items.Add("Computer Job Percentage Ascending");
            cboSorting.Items.Add("Computer Job Percentage Descending");

            //populate filter combo box with appropriate options
            _isInitializingFilter = true;
            cboFilterCategory.Items.Clear();
            cboFilterCategory.Items.Add("Population");
            cboFilterCategory.Items.Add("Median Income");
            cboFilterCategory.Items.Add("Computer Job Percentage");
            cboFilterCategory.Items.Add("Bird");
            cboFilterCategory.Items.Add("Flower");
            cboFilterCategory.Items.Add("Colors");
            cboFilterCategory.Items.Add("Capital");
            cboFilterCategory.Items.Add("State Name");
            cboFilterCategory.SelectedIndex = 1;
            //prevent category names from appearing in condition box
            _isInitializingFilter = false;
            cboFilterCondition.Items.Clear();
        }
        private void LoadGrid(List<StateInfo> states)
        {
            dgvStatesCities.DataSource = states.Select(s => new
            {
                s.Name,
                s.Population,
                s.MedianIncome,
                s.ComputerJobPercentage,
                s.Capital,
                LargestCity = string.Join(", ", s.LargestCities),
                s.Bird,
                s.Flower,
            }).ToList();
            //format column values
            dgvStatesCities.Columns["Population"].DefaultCellStyle.Format = "N0";
            dgvStatesCities.Columns["MedianIncome"].DefaultCellStyle.Format = "C0";
            dgvStatesCities.Columns["ComputerJobPercentage"].DefaultCellStyle.Format = "P1";
            //auto-size columns to fit content
            dgvStatesCities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = cboCategory.Text;
            string criteria = txtCriteria.Text.Trim();
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(criteria))
            {
                MessageBox.Show("Please select a category and enter search criteria.");
                return;
            }
            switch (category)
            {
                case "Name":
                    Results = allStates.Where(s => s.Name.IndexOf(criteria, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case "Capital":
                    Results = allStates.Where(s => s.Capital.IndexOf(criteria, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case "City":
                    Results = allStates.Where(s => s.LargestCities.Any(c => c.IndexOf(criteria, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
                    break;
                case "Bird":
                    Results = allStates.Where(s => s.Bird.IndexOf(criteria, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                case "Flower":
                    Results = allStates.Where(s => s.Flower.IndexOf(criteria, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    break;
                default:
                    MessageBox.Show("Please select a valid category.");
                    return;
            }
            LoadGrid(Results);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCriteria.Clear();
            cboCategory.SelectedIndex = 0;
            LoadGrid(allStates);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string sort = cboSorting.Text;

            // Use search results if available, otherwise use all states
            var source = Results ?? allStates;

            // Ignore separator lines
            if (sort.StartsWith("-"))
                return;

            List<StateInfo> sorted;

            switch (sort)
            {
                // Alphabetical – State Name
                case "State Name A-Z":
                    sorted = source.OrderBy(s => s.Name).ToList();
                    break;

                case "State Name Z-A":
                    sorted = source.OrderByDescending(s => s.Name).ToList();
                    break;

                // Alphabetical – Capital
                case "Capital A-Z":
                    sorted = source.OrderBy(s => s.Capital).ToList();
                    break;

                case "Capital Z-A":
                    sorted = source.OrderByDescending(s => s.Capital).ToList();
                    break;

                // Alphabetical – Bird
                case "Bird A-Z":
                    sorted = source.OrderBy(s => s.Bird).ToList();
                    break;

                case "Bird Z-A":
                    sorted = source.OrderByDescending(s => s.Bird).ToList();
                    break;

                // Alphabetical – Flower
                case "Flower A-Z":
                    sorted = source.OrderBy(s => s.Flower).ToList();
                    break;

                case "Flower Z-A":
                    sorted = source.OrderByDescending(s => s.Flower).ToList();
                    break;

                // Numerical – Population
                case "Population Ascending":
                    sorted = source.OrderBy(s => s.Population).ToList();
                    break;

                case "Population Descending":
                    sorted = source.OrderByDescending(s => s.Population).ToList();
                    break;

                // Numerical – Median Income
                case "Median Income Ascending":
                    sorted = source.OrderBy(s => s.MedianIncome).ToList();
                    break;

                case "Median Income Descending":
                    sorted = source.OrderByDescending(s => s.MedianIncome).ToList();
                    break;

                // Numerical – Computer Job Percentage
                case "Computer Job Percentage Ascending":
                    sorted = source.OrderBy(s => s.ComputerJobPercentage).ToList();
                    break;

                case "Computer Job Percentage Descending":
                    sorted = source.OrderByDescending(s => s.ComputerJobPercentage).ToList();
                    break;

                default:
                    MessageBox.Show("Invalid sort option.");
                    return;
            }

            LoadGrid(sorted);

        }

        private void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializingFilter)
                return;

            cboFilterCondition.Items.Clear();

            string cat = cboFilterCategory.Text;

            
            if (cat == "Population" || cat == "Median Income" || cat == "Computer Job Percentage")
            {
                cboFilterCondition.Items.Add(">");
                cboFilterCondition.Items.Add("<");
                cboFilterCondition.Items.Add(">=");
                cboFilterCondition.Items.Add("<=");
                cboFilterCondition.Items.Add("=");
            }
            else
            {
                cboFilterCondition.Items.Add("Contains");
                cboFilterCondition.Items.Add("Starts With");
                cboFilterCondition.Items.Add("Ends With");
                cboFilterCondition.Items.Add("Equals");
            }

            cboFilterCondition.SelectedIndex = 0;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string category = cboFilterCategory.Text;
            string condition = cboFilterCondition.Text;
            string value = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(condition) || string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Please select a category, condition, and enter a value for filtering.");
                return;
            }
            var source = Results ?? allStates;
            List<StateInfo> filtered = null;

            switch (category)
            {
                // numeric filters
                case "Population":
                    if (long.TryParse(value, out long pop))
                        filtered = ApplyNumericFilter(source, s => s.Population, condition, pop);
                    break;

                case "Median Income":
                    if (decimal.TryParse(value, out decimal income))
                        filtered = ApplyNumericFilter(source, s => s.MedianIncome, condition, income);
                    break;

                case "Computer Job Percentage":
                    if (double.TryParse(value, out double jobs))
                        filtered = ApplyNumericFilter(source, s => s.ComputerJobPercentage, condition, jobs);
                    break;

                // text filters
                case "State Name":
                    filtered = ApplyTextFilter(source, s => s.Name, condition, value);
                    break;

                case "Capital":
                    filtered = ApplyTextFilter(source, s => s.Capital, condition, value);
                    break;

                case "Bird":
                    filtered = ApplyTextFilter(source, s => s.Bird, condition, value);
                    break;

                case "Flower":
                    filtered = ApplyTextFilter(source, s => s.Flower, condition, value);
                    break;

                case "Colors":
                    filtered = ApplyTextFilter(source, s => s.Colors, condition, value);
                    break;
            }

            if (filtered == null)
            {
                MessageBox.Show("Invalid filter value. Please enter a valid number for numeric filters.");
                return;
            }
            Results = filtered;
            LoadGrid(filtered);

        }
        private List<StateInfo> ApplyTextFilter(
            List<StateInfo> source,
            Func<StateInfo, string> selector,
            string condition,
            string value)
        {
            switch (condition)
            {
                case "Contains":
                    return source.Where(s =>
                        selector(s).IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                case "Starts With":
                    return source.Where(s =>
                        selector(s).StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList();

                case "Ends With":
                    return source.Where(s =>
                        selector(s).EndsWith(value, StringComparison.OrdinalIgnoreCase)).ToList();

                case "Equals":
                    return source.Where(s =>
                        selector(s).Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();

                default:
                    return source;
            }
        }
        private List<StateInfo> ApplyNumericFilter<T>(
            List<StateInfo> source,
            Func<StateInfo, T> selector,
            string condition,
            T value)
            where T : IComparable
        {
            switch (condition)
            {
                case ">":
                    return source.Where(s => selector(s).CompareTo(value) > 0).ToList();

                case "<":
                    return source.Where(s => selector(s).CompareTo(value) < 0).ToList();

                case ">=":
                    return source.Where(s => selector(s).CompareTo(value) >= 0).ToList();

                case "<=":
                    return source.Where(s => selector(s).CompareTo(value) <= 0).ToList();

                case "=":
                    return source.Where(s => selector(s).CompareTo(value) == 0).ToList();

                default:
                    return source;
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            Results = null;
            txtFilterValue.Clear();
            cboFilterCategory.SelectedIndex = 0;
            cboFilterCondition.Items.Clear();
            LoadGrid(allStates);

        }
    }
}