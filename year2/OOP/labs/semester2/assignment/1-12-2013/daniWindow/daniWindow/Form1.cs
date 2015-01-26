using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace daniWindow
{
    public partial class Form1 : Form
    {
        DaniInstance[] Danis = new DaniInstance[3] {new DaniInstance(), new DaniInstance(), new DaniInstance()};
        SpeechSynthesizer talkingDANI = new SpeechSynthesizer();
        
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

            this.dani1Response.Text = Danis[0].core.Parse(this.userInput.Text, answer);

            if (Danis[0].talk)
            {
                talkingDANI.SpeakAsync(this.dani1Response.Text);
            }
        }

        private void userToDani2_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani2Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani2Response.Text = Danis[1].core.Parse(this.userInput.Text, answer);

            if (Danis[1].talk)
            {
                talkingDANI.SpeakAsync(this.dani2Response.Text);
            }
        }

        private void userToDani3_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani2Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani3Response.Text = Danis[2].core.Parse(this.userInput.Text, answer);

            if (Danis[2].talk)
            {
                talkingDANI.SpeakAsync(this.dani3Response.Text);
            }
        }

        private void dani1ToDani2_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani2Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani2Response.Text = Danis[1].core.Parse(this.dani1Response.Text, answer);

            if (Danis[1].talk)
            {
                talkingDANI.SpeakAsync(this.dani2Response.Text);
            }
        }

        private void dani1ToDani3_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani3Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani3Response.Text = Danis[2].core.Parse(this.dani1Response.Text, answer);

            if (Danis[2].talk)
            {
                talkingDANI.SpeakAsync(this.dani3Response.Text);
            }
        }

        private void dani2ToDani1_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani1Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani1Response.Text = Danis[0].core.Parse(this.dani2Response.Text, answer);

            if (Danis[0].talk)
            {
                talkingDANI.SpeakAsync(this.dani1Response.Text);
            }
        }

        private void dani2ToDani3_Click_1(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani3Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani3Response.Text = Danis[2].core.Parse(this.dani2Response.Text, answer);

            if (Danis[2].talk)
            {
                talkingDANI.SpeakAsync(this.dani3Response.Text);
            }
        }

        private void dani3ToDani1_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani1Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani1Response.Text = Danis[0].core.Parse(this.dani3Response.Text, answer);

            if (Danis[0].talk)
            {
                talkingDANI.SpeakAsync(this.dani1Response.Text);
            }
        }

        private void dani3ToDani2_Click(object sender, EventArgs e)
        {
            bool answer = false;

            if (this.dani1Response.Text.IndexOf("?") != -1)
            {
                answer = true;
            }

            this.dani2Response.Text = Danis[1].core.Parse(this.dani3Response.Text, answer);

            if (Danis[1].talk)
            {
                talkingDANI.SpeakAsync(this.dani2Response.Text);
            }
        }

        private void dani1Speech_CheckedChanged_1(object sender, EventArgs e)
        {
            Danis[0].talk = !Danis[0].talk;
        }

        private void dani2Speech_CheckedChanged(object sender, EventArgs e)
        {
            Danis[1].talk = !Danis[1].talk;
        }

        private void dani3speech_CheckedChanged(object sender, EventArgs e)
        {
            Danis[2].talk = !Danis[2].talk;
        }
    }

    public class DaniInstance
    {
        public DaniCore core = new DaniCore();
        public bool talk = false;
    }
}
