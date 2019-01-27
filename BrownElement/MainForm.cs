using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrownElement
{
    public partial class BrownElementForm : Form
    {
        public BrownElementForm()
        {
            InitializeComponent();
        }

        private void TextBoxMoveCount_TextChanged(object sender, EventArgs e)
        {
            MainService.SimulateBrownMovemnts(textBoxMoveCount, ref MovementChart);
        }

        private void TextBoxMoveCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MainService.SaveResultToXLXFile();
        }
    }
}
