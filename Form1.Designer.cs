
namespace WinForms_AsyncOps_Example
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblSteps = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 13);
            this.lblStatus.Name = "label1";
            this.lblStatus.Size = new System.Drawing.Size(52, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Waiting...";
            // 
            // button1
            // 
            this.btnGo.Location = new System.Drawing.Point(13, 30);
            this.btnGo.Name = "button1";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Dewit";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 60);
            this.txtInput.Name = "textBox1";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = "100";
            // 
            // label2
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(13, 87);
            this.lblSteps.Name = "label2";
            this.lblSteps.Size = new System.Drawing.Size(62, 13);
            this.lblSteps.TabIndex = 3;
            this.lblSteps.Text = "Total steps:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "steps";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 188);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(369, 227);
            this.MinimumSize = new System.Drawing.Size(369, 227);
            this.Name = "Form1";
            this.Text = "How many steps?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.Label label3;
    }
}

