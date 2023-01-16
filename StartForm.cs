using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Re2
{
    public partial class StartForm : Form
    {
        ObjectMove kinem;
        ObjectFly polet;
        public StartForm()
        {
            InitializeComponent();
            kinem = new ObjectMove();
            kinem.Visible = false;
            polet = new ObjectFly();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            kinem.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            polet.Visible = true;
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            kinem.Close();
            polet.Close();
        }
    }
}
