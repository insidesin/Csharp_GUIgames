namespace GuiGames {
    partial class ChooseSuitForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gboxChooseASuit = new System.Windows.Forms.GroupBox();
            this.rbSpades = new System.Windows.Forms.RadioButton();
            this.rbHearts = new System.Windows.Forms.RadioButton();
            this.rbClubs = new System.Windows.Forms.RadioButton();
            this.rbDiamonds = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gboxChooseASuit.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxChooseASuit
            // 
            this.gboxChooseASuit.Controls.Add(this.rbSpades);
            this.gboxChooseASuit.Controls.Add(this.rbHearts);
            this.gboxChooseASuit.Controls.Add(this.rbClubs);
            this.gboxChooseASuit.Controls.Add(this.rbDiamonds);
            this.gboxChooseASuit.Location = new System.Drawing.Point(26, 12);
            this.gboxChooseASuit.Name = "gboxChooseASuit";
            this.gboxChooseASuit.Size = new System.Drawing.Size(133, 144);
            this.gboxChooseASuit.TabIndex = 0;
            this.gboxChooseASuit.TabStop = false;
            this.gboxChooseASuit.Text = "Choose a Suit";
            this.gboxChooseASuit.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbSpades
            // 
            this.rbSpades.AutoSize = true;
            this.rbSpades.Location = new System.Drawing.Point(27, 98);
            this.rbSpades.Name = "rbSpades";
            this.rbSpades.Size = new System.Drawing.Size(61, 17);
            this.rbSpades.TabIndex = 3;
            this.rbSpades.TabStop = true;
            this.rbSpades.Text = "Spades";
            this.rbSpades.UseVisualStyleBackColor = true;
            // 
            // rbHearts
            // 
            this.rbHearts.AutoSize = true;
            this.rbHearts.Location = new System.Drawing.Point(27, 72);
            this.rbHearts.Name = "rbHearts";
            this.rbHearts.Size = new System.Drawing.Size(56, 17);
            this.rbHearts.TabIndex = 2;
            this.rbHearts.TabStop = true;
            this.rbHearts.Text = "Hearts";
            this.rbHearts.UseVisualStyleBackColor = true;
            // 
            // rbClubs
            // 
            this.rbClubs.AutoSize = true;
            this.rbClubs.Location = new System.Drawing.Point(27, 46);
            this.rbClubs.Name = "rbClubs";
            this.rbClubs.Size = new System.Drawing.Size(51, 17);
            this.rbClubs.TabIndex = 1;
            this.rbClubs.TabStop = true;
            this.rbClubs.Text = "Clubs";
            this.rbClubs.UseVisualStyleBackColor = true;
            // 
            // rbDiamonds
            // 
            this.rbDiamonds.AutoSize = true;
            this.rbDiamonds.Location = new System.Drawing.Point(27, 20);
            this.rbDiamonds.Name = "rbDiamonds";
            this.rbDiamonds.Size = new System.Drawing.Size(72, 17);
            this.rbDiamonds.TabIndex = 0;
            this.rbDiamonds.TabStop = true;
            this.rbDiamonds.Text = "Diamonds";
            this.rbDiamonds.UseVisualStyleBackColor = true;
            this.rbDiamonds.CheckedChanged += new System.EventHandler(this.rbDiamonds_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(53, 173);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ChooseSuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 226);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gboxChooseASuit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseSuitForm";
            this.Text = "Choose Suit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gboxChooseASuit.ResumeLayout(false);
            this.gboxChooseASuit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxChooseASuit;
        private System.Windows.Forms.RadioButton rbSpades;
        private System.Windows.Forms.RadioButton rbHearts;
        private System.Windows.Forms.RadioButton rbClubs;
        private System.Windows.Forms.RadioButton rbDiamonds;
        private System.Windows.Forms.Button btnOK;
    }
}