using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GIMED_EL
{
    public partial class frmEPSG : Form
    {
        public Int32 selectedSRID { get; set; } 
        public frmEPSG()
        {
            InitializeComponent();
        }

        public void PopulateListBox(Dictionary<int, string> epsg_codes)
        {
            lbEPSGCodes.DataSource = new BindingSource(epsg_codes, null);
            lbEPSGCodes.DisplayMember = "Key";
            lbEPSGCodes.ValueMember = "Value";
        }

        private void btnCancelEpsg_Click(object sender, EventArgs e)
        {
            selectedSRID = -1;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int index = lbEPSGCodes.FindString(this.textBox1.Text);
            if (0 <= index)
            {
                lbEPSGCodes.SelectedIndex = index;
            }
        }

        private void btnSelectEpsg_Click(object sender, EventArgs e)
        {
            if (lbEPSGCodes.SelectedIndex == -1)
            {
                MessageBox.Show("Δεν επιλέξατε προβολικό σύστημα");
                selectedSRID = - 1;
            }
           selectedSRID = Convert.ToInt32(((KeyValuePair<int, string>)lbEPSGCodes.SelectedItem).Key);
           this.Close();
            
        }

        private void lbEPSGCodes_Format(object sender, ListControlConvertEventArgs e)
        {
            KeyValuePair<int, string> item = (KeyValuePair<int, string>)e.ListItem;
            e.Value = string.Format("{0} ({1})", item.Value, item.Key);
        }
    }
}
