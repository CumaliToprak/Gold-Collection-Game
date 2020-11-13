namespace Altın_Toplama_Oyunu
{
    partial class MainFrm
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
            this.tbxOyuncuAltın = new System.Windows.Forms.TextBox();
            this.lblAltınMitarı = new System.Windows.Forms.Label();
            this.tbxGizliAltin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAdımSayısı = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblX.Location = new System.Drawing.Point(145, 46);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(250, 33);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "Tahta En (max = 74) ";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblY.Location = new System.Drawing.Point(146, 93);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(251, 33);
            this.lblY.TabIndex = 1;
            this.lblY.Text = "Tahta Boy (max = 40)";
            // 
            // tbxX
            // 
            this.tbxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxX.Location = new System.Drawing.Point(421, 46);
            this.tbxX.Name = "tbxX";
            this.tbxX.Size = new System.Drawing.Size(79, 30);
            this.tbxX.TabIndex = 2;
            this.tbxX.Text = "20";
            // 
            // tbxY
            // 
            this.tbxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxY.Location = new System.Drawing.Point(421, 93);
            this.tbxY.Name = "tbxY";
            this.tbxY.Size = new System.Drawing.Size(79, 30);
            this.tbxY.TabIndex = 3;
            this.tbxY.Text = "20";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(165, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(320, 54);
            this.button1.TabIndex = 4;
            this.button1.Text = "Oyna";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxAltinOran
            // 
            this.tbxAltinOran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAltinOran.Location = new System.Drawing.Point(421, 139);
            this.tbxAltinOran.Name = "tbxAltinOran";
            this.tbxAltinOran.Size = new System.Drawing.Size(79, 30);
            this.tbxAltinOran.TabIndex = 6;
            this.tbxAltinOran.Text = "20";
            // 
            // lblAltinOrani
            // 
            this.lblAltinOrani.AutoSize = true;
            this.lblAltinOrani.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAltinOrani.Location = new System.Drawing.Point(146, 139);
            this.lblAltinOrani.Name = "lblAltinOrani";
            this.lblAltinOrani.Size = new System.Drawing.Size(180, 33);
            this.lblAltinOrani.TabIndex = 5;
            this.lblAltinOrani.Text = "Altın Yüzdeliği";
            // 
            // tbxOyuncuAltın
            // 
            this.tbxOyuncuAltın.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxOyuncuAltın.Location = new System.Drawing.Point(421, 229);
            this.tbxOyuncuAltın.Name = "tbxOyuncuAltın";
            this.tbxOyuncuAltın.Size = new System.Drawing.Size(79, 30);
            this.tbxOyuncuAltın.TabIndex = 8;
            this.tbxOyuncuAltın.Text = "200";
            // 
            // lblAltınMitarı
            // 
            this.lblAltınMitarı.AutoSize = true;
            this.lblAltınMitarı.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAltınMitarı.Location = new System.Drawing.Point(146, 229);
            this.lblAltınMitarı.Name = "lblAltınMitarı";
            this.lblAltınMitarı.Size = new System.Drawing.Size(254, 33);
            this.lblAltınMitarı.TabIndex = 7;
            this.lblAltınMitarı.Text = "Oyuncu Altın Miktarı";
            // 
            // tbxGizliAltin
            // 
            this.tbxGizliAltin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxGizliAltin.Location = new System.Drawing.Point(421, 181);
            this.tbxGizliAltin.Name = "tbxGizliAltin";
            this.tbxGizliAltin.Size = new System.Drawing.Size(79, 30);
            this.tbxGizliAltin.TabIndex = 10;
            this.tbxGizliAltin.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(146, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gizli Altın Oranı";
            // 
            // tbxAdımSayısı
            // 
            this.tbxAdımSayısı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAdımSayısı.Location = new System.Drawing.Point(421, 276);
            this.tbxAdımSayısı.Name = "tbxAdımSayısı";
            this.tbxAdımSayısı.Size = new System.Drawing.Size(79, 30);
            this.tbxAdımSayısı.TabIndex = 12;
            this.tbxAdımSayısı.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "Adım Sayısı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(560, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "NOT: Değerler değiştirilmezse varsayılan değerler kullanılacaktır!";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(700, 444);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxAdımSayısı);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxGizliAltin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxOyuncuAltın);
            this.Controls.Add(this.lblAltınMitarı);
            this.Controls.Add(this.tbxAltinOran);
            this.Controls.Add(this.lblAltinOrani);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxY);
            this.Controls.Add(this.tbxX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
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
        private System.Windows.Forms.TextBox tbxOyuncuAltın;
        private System.Windows.Forms.Label lblAltınMitarı;
        private System.Windows.Forms.TextBox tbxGizliAltin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAdımSayısı;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

