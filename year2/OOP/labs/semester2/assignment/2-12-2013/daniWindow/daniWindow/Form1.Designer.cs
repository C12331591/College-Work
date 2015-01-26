namespace daniWindow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userInput = new System.Windows.Forms.TextBox();
            this.dani2Response = new System.Windows.Forms.TextBox();
            this.dani1Response = new System.Windows.Forms.TextBox();
            this.userToDani1 = new System.Windows.Forms.Button();
            this.userToDani2 = new System.Windows.Forms.Button();
            this.dani1ToDani2 = new System.Windows.Forms.Button();
            this.dani2ToDani1 = new System.Windows.Forms.Button();
            this.dani1Speech = new System.Windows.Forms.CheckBox();
            this.dani2Speech = new System.Windows.Forms.CheckBox();
            this.dani3speech = new System.Windows.Forms.CheckBox();
            this.dani3ToDani1 = new System.Windows.Forms.Button();
            this.dani3Response = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dani1ToDani3 = new System.Windows.Forms.Button();
            this.dani3ToDani2 = new System.Windows.Forms.Button();
            this.dani2ToDani3 = new System.Windows.Forms.Button();
            this.userToDani3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANI 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DANI 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User";
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(12, 25);
            this.userInput.Multiline = true;
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(780, 150);
            this.userInput.TabIndex = 4;
            // 
            // dani2Response
            // 
            this.dani2Response.Location = new System.Drawing.Point(283, 284);
            this.dani2Response.Multiline = true;
            this.dani2Response.Name = "dani2Response";
            this.dani2Response.ReadOnly = true;
            this.dani2Response.Size = new System.Drawing.Size(240, 100);
            this.dani2Response.TabIndex = 5;
            // 
            // dani1Response
            // 
            this.dani1Response.Location = new System.Drawing.Point(12, 284);
            this.dani1Response.Multiline = true;
            this.dani1Response.Name = "dani1Response";
            this.dani1Response.ReadOnly = true;
            this.dani1Response.Size = new System.Drawing.Size(240, 100);
            this.dani1Response.TabIndex = 6;
            // 
            // userToDani1
            // 
            this.userToDani1.Location = new System.Drawing.Point(12, 181);
            this.userToDani1.Name = "userToDani1";
            this.userToDani1.Size = new System.Drawing.Size(122, 38);
            this.userToDani1.TabIndex = 7;
            this.userToDani1.Text = "Say to DANI 1";
            this.userToDani1.UseVisualStyleBackColor = true;
            this.userToDani1.Click += new System.EventHandler(this.userToDani1_Click);
            // 
            // userToDani2
            // 
            this.userToDani2.Location = new System.Drawing.Point(283, 181);
            this.userToDani2.Name = "userToDani2";
            this.userToDani2.Size = new System.Drawing.Size(122, 38);
            this.userToDani2.TabIndex = 8;
            this.userToDani2.Text = "Say to DANI 2";
            this.userToDani2.UseVisualStyleBackColor = true;
            this.userToDani2.Click += new System.EventHandler(this.userToDani2_Click);
            // 
            // dani1ToDani2
            // 
            this.dani1ToDani2.Location = new System.Drawing.Point(12, 390);
            this.dani1ToDani2.Name = "dani1ToDani2";
            this.dani1ToDani2.Size = new System.Drawing.Size(100, 40);
            this.dani1ToDani2.TabIndex = 9;
            this.dani1ToDani2.Text = "Say to DANI 2";
            this.dani1ToDani2.UseVisualStyleBackColor = true;
            this.dani1ToDani2.Click += new System.EventHandler(this.dani1ToDani2_Click);
            // 
            // dani2ToDani1
            // 
            this.dani2ToDani1.Location = new System.Drawing.Point(283, 390);
            this.dani2ToDani1.Name = "dani2ToDani1";
            this.dani2ToDani1.Size = new System.Drawing.Size(100, 40);
            this.dani2ToDani1.TabIndex = 10;
            this.dani2ToDani1.Text = "Say to DANI 1";
            this.dani2ToDani1.UseVisualStyleBackColor = true;
            this.dani2ToDani1.Click += new System.EventHandler(this.dani2ToDani1_Click);
            // 
            // dani1Speech
            // 
            this.dani1Speech.AutoSize = true;
            this.dani1Speech.Location = new System.Drawing.Point(141, 264);
            this.dani1Speech.Name = "dani1Speech";
            this.dani1Speech.Size = new System.Drawing.Size(111, 17);
            this.dani1Speech.TabIndex = 11;
            this.dani1Speech.Text = "Speech Synthesis";
            this.dani1Speech.UseVisualStyleBackColor = true;
            this.dani1Speech.CheckedChanged += new System.EventHandler(this.dani1Speech_CheckedChanged_1);
            // 
            // dani2Speech
            // 
            this.dani2Speech.AutoSize = true;
            this.dani2Speech.Location = new System.Drawing.Point(412, 264);
            this.dani2Speech.Name = "dani2Speech";
            this.dani2Speech.Size = new System.Drawing.Size(111, 17);
            this.dani2Speech.TabIndex = 12;
            this.dani2Speech.Text = "Speech Synthesis";
            this.dani2Speech.UseVisualStyleBackColor = true;
            this.dani2Speech.CheckedChanged += new System.EventHandler(this.dani2Speech_CheckedChanged);
            // 
            // dani3speech
            // 
            this.dani3speech.AutoSize = true;
            this.dani3speech.Location = new System.Drawing.Point(681, 264);
            this.dani3speech.Name = "dani3speech";
            this.dani3speech.Size = new System.Drawing.Size(111, 17);
            this.dani3speech.TabIndex = 16;
            this.dani3speech.Text = "Speech Synthesis";
            this.dani3speech.UseVisualStyleBackColor = true;
            this.dani3speech.CheckedChanged += new System.EventHandler(this.dani3speech_CheckedChanged);
            // 
            // dani3ToDani1
            // 
            this.dani3ToDani1.Location = new System.Drawing.Point(552, 390);
            this.dani3ToDani1.Name = "dani3ToDani1";
            this.dani3ToDani1.Size = new System.Drawing.Size(100, 40);
            this.dani3ToDani1.TabIndex = 15;
            this.dani3ToDani1.Text = "Say to DANI 1";
            this.dani3ToDani1.UseVisualStyleBackColor = true;
            this.dani3ToDani1.Click += new System.EventHandler(this.dani3ToDani1_Click);
            // 
            // dani3Response
            // 
            this.dani3Response.Location = new System.Drawing.Point(552, 284);
            this.dani3Response.Multiline = true;
            this.dani3Response.Name = "dani3Response";
            this.dani3Response.ReadOnly = true;
            this.dani3Response.Size = new System.Drawing.Size(240, 100);
            this.dani3Response.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "DANI 3";
            // 
            // dani1ToDani3
            // 
            this.dani1ToDani3.Location = new System.Drawing.Point(152, 390);
            this.dani1ToDani3.Name = "dani1ToDani3";
            this.dani1ToDani3.Size = new System.Drawing.Size(100, 40);
            this.dani1ToDani3.TabIndex = 17;
            this.dani1ToDani3.Text = "Say to DANI 3";
            this.dani1ToDani3.UseVisualStyleBackColor = true;
            this.dani1ToDani3.Click += new System.EventHandler(this.dani1ToDani3_Click);
            // 
            // dani3ToDani2
            // 
            this.dani3ToDani2.Location = new System.Drawing.Point(692, 390);
            this.dani3ToDani2.Name = "dani3ToDani2";
            this.dani3ToDani2.Size = new System.Drawing.Size(100, 40);
            this.dani3ToDani2.TabIndex = 18;
            this.dani3ToDani2.Text = "Say to DANI 2";
            this.dani3ToDani2.UseVisualStyleBackColor = true;
            this.dani3ToDani2.Click += new System.EventHandler(this.dani3ToDani2_Click);
            // 
            // dani2ToDani3
            // 
            this.dani2ToDani3.Location = new System.Drawing.Point(423, 390);
            this.dani2ToDani3.Name = "dani2ToDani3";
            this.dani2ToDani3.Size = new System.Drawing.Size(100, 40);
            this.dani2ToDani3.TabIndex = 19;
            this.dani2ToDani3.Text = "Say to DANI 3";
            this.dani2ToDani3.UseVisualStyleBackColor = true;
            this.dani2ToDani3.Click += new System.EventHandler(this.dani2ToDani3_Click_1);
            // 
            // userToDani3
            // 
            this.userToDani3.Location = new System.Drawing.Point(552, 181);
            this.userToDani3.Name = "userToDani3";
            this.userToDani3.Size = new System.Drawing.Size(122, 38);
            this.userToDani3.TabIndex = 20;
            this.userToDani3.Text = "Say to DANI 3";
            this.userToDani3.UseVisualStyleBackColor = true;
            this.userToDani3.Click += new System.EventHandler(this.userToDani3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 442);
            this.Controls.Add(this.userToDani3);
            this.Controls.Add(this.dani2ToDani3);
            this.Controls.Add(this.dani3ToDani2);
            this.Controls.Add(this.dani1ToDani3);
            this.Controls.Add(this.dani3speech);
            this.Controls.Add(this.dani3ToDani1);
            this.Controls.Add(this.dani3Response);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dani2Speech);
            this.Controls.Add(this.dani1Speech);
            this.Controls.Add(this.dani2ToDani1);
            this.Controls.Add(this.dani1ToDani2);
            this.Controls.Add(this.userToDani2);
            this.Controls.Add(this.userToDani1);
            this.Controls.Add(this.dani1Response);
            this.Controls.Add(this.dani2Response);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MultiDANI Program by Brian Willis - C12331591";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.TextBox dani2Response;
        private System.Windows.Forms.TextBox dani1Response;
        private System.Windows.Forms.Button userToDani1;
        private System.Windows.Forms.Button userToDani2;
        private System.Windows.Forms.Button dani1ToDani2;
        private System.Windows.Forms.Button dani2ToDani1;
        private System.Windows.Forms.CheckBox dani1Speech;
        private System.Windows.Forms.CheckBox dani2Speech;
        private System.Windows.Forms.CheckBox dani3speech;
        private System.Windows.Forms.Button dani3ToDani1;
        private System.Windows.Forms.TextBox dani3Response;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dani1ToDani3;
        private System.Windows.Forms.Button dani3ToDani2;
        private System.Windows.Forms.Button dani2ToDani3;
        private System.Windows.Forms.Button userToDani3;

    }
}

