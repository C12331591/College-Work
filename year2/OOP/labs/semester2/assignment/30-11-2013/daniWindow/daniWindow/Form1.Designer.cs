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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANI 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 187);
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
            this.userInput.Size = new System.Drawing.Size(558, 80);
            this.userInput.TabIndex = 4;
            // 
            // dani2Response
            // 
            this.dani2Response.Location = new System.Drawing.Point(309, 203);
            this.dani2Response.Multiline = true;
            this.dani2Response.Name = "dani2Response";
            this.dani2Response.ReadOnly = true;
            this.dani2Response.Size = new System.Drawing.Size(261, 139);
            this.dani2Response.TabIndex = 5;
            // 
            // dani1Response
            // 
            this.dani1Response.Location = new System.Drawing.Point(12, 203);
            this.dani1Response.Multiline = true;
            this.dani1Response.Name = "dani1Response";
            this.dani1Response.ReadOnly = true;
            this.dani1Response.Size = new System.Drawing.Size(245, 139);
            this.dani1Response.TabIndex = 6;
            // 
            // userToDani1
            // 
            this.userToDani1.Location = new System.Drawing.Point(15, 111);
            this.userToDani1.Name = "userToDani1";
            this.userToDani1.Size = new System.Drawing.Size(122, 38);
            this.userToDani1.TabIndex = 7;
            this.userToDani1.Text = "Say to DANI 1";
            this.userToDani1.UseVisualStyleBackColor = true;
            this.userToDani1.Click += new System.EventHandler(this.userToDani1_Click);
            // 
            // userToDani2
            // 
            this.userToDani2.Location = new System.Drawing.Point(309, 111);
            this.userToDani2.Name = "userToDani2";
            this.userToDani2.Size = new System.Drawing.Size(122, 38);
            this.userToDani2.TabIndex = 8;
            this.userToDani2.Text = "Say to DANI 2";
            this.userToDani2.UseVisualStyleBackColor = true;
            this.userToDani2.Click += new System.EventHandler(this.userToDani2_Click);
            // 
            // dani1ToDani2
            // 
            this.dani1ToDani2.Location = new System.Drawing.Point(12, 348);
            this.dani1ToDani2.Name = "dani1ToDani2";
            this.dani1ToDani2.Size = new System.Drawing.Size(122, 38);
            this.dani1ToDani2.TabIndex = 9;
            this.dani1ToDani2.Text = "Say to DANI 2";
            this.dani1ToDani2.UseVisualStyleBackColor = true;
            this.dani1ToDani2.Click += new System.EventHandler(this.dani1ToDani2_Click);
            // 
            // dani2ToDani1
            // 
            this.dani2ToDani1.Location = new System.Drawing.Point(309, 348);
            this.dani2ToDani1.Name = "dani2ToDani1";
            this.dani2ToDani1.Size = new System.Drawing.Size(122, 38);
            this.dani2ToDani1.TabIndex = 10;
            this.dani2ToDani1.Text = "Say to DANI 1";
            this.dani2ToDani1.UseVisualStyleBackColor = true;
            this.dani2ToDani1.Click += new System.EventHandler(this.dani2ToDani1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
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
            this.Text = "Form1";
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

    }
}

