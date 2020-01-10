using Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace UI
{
    public partial class UI : Form
    {
        IStorageArea CurrentShipUsing;
        public UI()
        {
            InitializeComponent();
            SetVisibilityTo(Visiblity.Ship);
        }

        public void SetVisibilityTo(Visiblity visibilityName)
        {
            if (visibilityName == Visiblity.Ship)
            {
                SetVisibilityToFalse(Visiblity.All);
                SetVisibilityToTrue(Visiblity.Ship);
            }
            if (visibilityName == Visiblity.Container)
            {
                SetVisibilityToFalse(Visiblity.All);
                SetVisibilityToTrue(Visiblity.Container);
            }
        }
        public void SetVisibilityToFalse(Visiblity visiblityName)
        {
            if (visiblityName == Visiblity.All)
            {
                grpBoxShip.Visible = false;
                grpBoxContainer.Visible = false;
            }
        }
        public void SetVisibilityToTrue(Visiblity visiblityName)
        {
            if (visiblityName == Visiblity.Ship)
            {
                grpBoxShip.Visible = true;
            }
            if (visiblityName == Visiblity.Container)
            {
                grpBoxContainer.Visible = true;
            }
        }

        private void btnCreateShip_Click(object sender, EventArgs e)
        {
            SetVisibilityTo(Visiblity.Container);
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            CurrentShipUsing = new Ship((int)numericUpDownColumns.Value, (int)numericUpDownRows.Value);

            List<IItem> containersToAssign = new List<IItem>();
            foreach (BaseContainer container in lBoxContainer.Items)
            {
                containersToAssign.Add(container);
            }
            CurrentShipUsing.ObjectAssigner.AssignObjects(containersToAssign);
            lblAssigned.Text = "Assigned: Yes";
        }

        private void btnAddRegular_Click(object sender, EventArgs e)
        {
            for (int regularCount = 0; regularCount < (int)numericUpDownRegular.Value; regularCount++)
            {
                lBoxContainer.Items.Add(new NormalContainer((int)numericUpDownWeight.Value));
            }
        }

        private void btnAddCooled_Click(object sender, EventArgs e)
        {
            for (int cooledCount = 0; cooledCount < (int)numericUpDownCooled.Value; cooledCount++)
            {
                lBoxContainer.Items.Add(new CooledContainer((int)numericUpDownWeight.Value));
            }
        }

        private void btnAddValuable_Click(object sender, EventArgs e)
        {
            for (int valuableCount = 0; valuableCount < (int)numericUpDownValuable.Value; valuableCount++)
            {
                lBoxContainer.Items.Add(new ValuableContainer((int)numericUpDownWeight.Value));
            }
        }

        private void btnVisualizerLink_Click(object sender, EventArgs e)
        {
            Process.Start("Chrome.exe", CurrentShipUsing.StorageManager.GetStringVisualizer());
        }

        private void btnClearListContainer_Click(object sender, EventArgs e)
        {
            CurrentShipUsing = new Ship((int)numericUpDownColumns.Value, (int)numericUpDownRows.Value);
            lBoxContainer.Items.Clear();
            lblAssigned.Text = "Assigned: No";
        }
    }
}
