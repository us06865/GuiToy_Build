using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace GuiToy
{
    public partial class GuiToyForm : Form
    {
        private GuiToyModel _model;
        private const string Nothing = "Nothing";
        private const string SelectedMessage = "{0} selected";

        public GuiToyForm()
        {
            InitializeComponent();
            _model = new GuiToyModel();
        }

        private void checkboxSetButton_Click(object sender, EventArgs e)
        {
            var items = new List<string>();
            if (checkBox1.Checked)
                items.Add("1");
            if (checkBox2.Checked)
                items.Add("2");
            if (checkBox3.Checked)
                items.Add("3");
            var selected = (items.Count == 0) ? Nothing : "Check " + String.Join(",", items);
            System.Threading.Thread.Sleep(_model.Delay);
            CheckboxLabel.Text = String.Format(SelectedMessage, selected);
        }

        private void radioSetButton_Click(object sender, EventArgs e)
        {
            var items = new List<string>();
            if (radioButton1.Checked)
                items.Add("1");
            if (radioButton2.Checked)
                items.Add("2");
            if (radioButton3.Checked)
                items.Add("3");
            var selected = (items.Count == 0) ? Nothing : "Radio " + String.Join(",", items);
            System.Threading.Thread.Sleep(_model.Delay);
            radioLabel.Text = String.Format(SelectedMessage, selected);
        }

        private void listSetButton_Click(object sender, EventArgs e)
        {
            var items = new List<string>();
            var listItems = listBox1.SelectedIndices;
            if (listItems.Contains(0))
                items.Add("1");
            if (listItems.Contains(1))
                items.Add("2");
            if (listItems.Contains(2))
                items.Add("3");
            var selected = (items.Count == 0) ? Nothing : "List " + String.Join(",", items);
            System.Threading.Thread.Sleep(_model.Delay);
            listLabel.Text = String.Format(SelectedMessage, selected);
        }

        private void comboSetButton_Click(object sender, EventArgs e)
        {
            var items = new List<string>();
            var selectedItem = comboBox1.SelectedIndex;
            if (selectedItem == 0)
                items.Add("1");
            if (selectedItem == 1)
                items.Add("2");
            if (selectedItem == 2)
                items.Add("3");
            var selected = (items.Count == 0) ? Nothing : "Combo " + String.Join(",", items);
            System.Threading.Thread.Sleep(_model.Delay);
            comboLabel.Text = String.Format(SelectedMessage, selected);
        }

        private void openTestWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(_model.Delay);
            MessageBox.Show(this, "This is a test window.", "Test Window");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void delayTextBox_TextChanged(object sender, EventArgs e)
        {
            var newValue = ((TextBox)sender).Text;
            var originalDelay = _model.Delay;
            if (String.IsNullOrWhiteSpace(newValue))
                newValue = "0";
            int parsedDelay;
            var finalDelay = (Int32.TryParse(newValue, out parsedDelay)) ? parsedDelay : originalDelay;
            _model.Delay = finalDelay;
            ((TextBox)sender).Text = _model.Delay.ToString(CultureInfo.InvariantCulture);
        }
    }
}
