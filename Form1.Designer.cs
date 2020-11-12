namespace Altın_Toplama_Oyunu
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
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.tbxX = new System.Windows.Forms.TextBox();
            this.tbxY = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxAltinOran = new System.Windows.Forms.TextBox();
            this.lblAltinOrani = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblX.Location = new System.Drawing.Point(17, 37);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(106, 25);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "Tahta En ";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblY.Location = new System.Drawing.Point(12, 81);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(111, 25);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Tahta Boy";
            // 
            // tbxX
            // 
            this.tbxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxX.Location = new System.Drawing.Point(176, 32);
            this.tbxX.Name = "tbxX";
            this.tbxX.Size = new System.Drawing.Size(79, 30);
            this.tbxX.TabIndex = 2;
            this.tbxX.Text = "20";
            // 
            // tbxY
            // 
            this.tbxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxY.Location = new System.Drawing.Point(176, 76);
            this.tbxY.Name = "tbxY";
            this.tbxY.Size = new System.Drawing.Size(79, 30);
            this.tbxY.TabIndex = 3;
            this.tbxY.Text = "20";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(125, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Oyna";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxAltinOran
            // 
            this.tbxAltinOran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAltinOran.Location = new System.Drawing.Point(176, 122);
            this.tbxAltinOran.Name = "tbxAltinOran";
            this.tbxAltinOran.Size = new System.Drawing.Size(79, 30);
            this.tbxAltinOran.TabIndex = 6;
            this.tbxAltinOran.Text = "20";
            // 
            // lblAltinOrani
            // 
            this.lblAltinOrani.AutoSize = true;
            this.lblAltinOrani.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAltinOrani.Location = new System.Drawing.Point(12, 127);
            this.lblAltinOrani.Name = "lblAltinOrani";
            this.lblAltinOrani.Size = new System.Drawing.Size(149, 25);
            this.lblAltinOrani.TabIndex = 5;
            this.lblAltinOrani.Text = "Altın Yüzdeliği";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 464);
            this.Controls.Add(this.tbxAltinOran);
            this.Controls.Add(this.lblAltinOrani);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxY);
            this.Controls.Add(this.tbxX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox tbxX;
        private System.Windows.Forms.TextBox tbxY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxAltinOran;
        private System.Windows.Forms.Label lblAltinOrani;
    }
}

