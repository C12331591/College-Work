using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace daniWindow
{
    public partial class Form1 : Form
    {
        DaniCore dani1 = new DaniCore();
        DaniCore dani2 = new DaniCore();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void userToDani1_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani1Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani1Response.Text = dani1.Parse(this.userInput.Text, answer);
        }

        private void userToDani2_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani2Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani2Response.Text = dani2.Parse(this.userInput.Text, answer);
        }

        private void dani1ToDani2_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani2Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani2Response.Text = dani2.Parse(this.dani1Response.Text, answer);
        }

        private void dani2ToDani1_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani1Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani1Response.Text = dani1.Parse(this.dani2Response.Text, answer);
        }
    }
}
