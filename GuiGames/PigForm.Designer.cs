namespace GuiGames {
    partial class PigForm {
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
            this.pigListBox = new System.Windows.Forms.ListBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.lblWhosTurn = new System.Windows.Forms.Label();
            this.lblPlayerPosition = new System.Windows.Forms.Label();
            this.lblCompPosition = new System.Windows.Forms.Label();
            this.lblPlayerAt = new System.Windows.Forms.Label();
            this.lblCompAt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pigListBox
            // 
            this.pigListBox.FormattingEnabled = true;
            this.pigListBox.Location = new System.Drawing.Point(22, 215);
            this.pigListBox.Name = "pigListBox";
            this.pigListBox.Size = new System.Drawing.Size(340, 251);
            this.pigListBox.TabIndex = 0;
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(22, 162);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(99, 32);
            this.btnRoll.TabIndex = 1;
            this.btnRoll.Text = "Roll Die";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(263, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel Game";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Enabled = false;
            this.btnPlayAgain.Location = new System.Drawing.Point(143, 144);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(99, 50);
            this.btnPlayAgain.TabIndex = 3;
            this.btnPlayAgain.Text = "Play Another Game?";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // lblWhosTurn
            // 
            this.lblWhosTurn.AutoSize = true;
            this.lblWhosTurn.Location = new System.Drawing.Point(29, 132);
            this.lblWhosTurn.Name = "lblWhosTurn";
            this.lblWhosTurn.Size = new System.Drawing.Size(36, 13);
            this.lblWhosTurn.TabIndex = 4;
            this.lblWhosTurn.Text = "Player";
            // 
            // lblPlayerPosition
            // 
            this.lblPlayerPosition.AutoSize = true;
            this.lblPlayerPosition.Location = new System.Drawing.Point(137, 41);
            this.lblPlayerPosition.Name = "lblPlayerPosition";
            this.lblPlayerPosition.Size = new System.Drawing.Size(88, 13);
            this.lblPlayerPosition.TabIndex = 5;
            this.lblPlayerPosition.Text = "Player\'s position: ";
            // 
            // lblCompPosition
            // 
            this.lblCompPosition.AutoSize = true;
            this.lblCompPosition.Location = new System.Drawing.Point(121, 75);
            this.lblCompPosition.Name = "lblCompPosition";
            this.lblCompPosition.Size = new System.Drawing.Size(104, 13);
            this.lblCompPosition.TabIndex = 6;
            this.lblCompPosition.Text = "Computer\'s position: ";
            // 
            // lblPlayerAt
            // 
            this.lblPlayerAt.AutoSize = true;
            this.lblPlayerAt.Location = new System.Drawing.Point(229, 41);
            this.lblPlayerAt.Name = "lblPlayerAt";
            this.lblPlayerAt.Size = new System.Drawing.Size(13, 13);
            this.lblPlayerAt.TabIndex = 7;
            this.lblPlayerAt.Text = "0";
            // 
            // lblCompAt
            // 
            this.lblCompAt.AutoSize = true;
            this.lblCompAt.Location = new System.Drawing.Point(229, 75);
            this.lblCompAt.Name = "lblCompAt";
            this.lblCompAt.Size = new System.Drawing.Size(13, 13);
            this.lblCompAt.TabIndex = 8;
            this.lblCompAt.Text = "0";
            // 
            // PigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 486);
            this.Controls.Add(this.lblCompAt);
            this.Controls.Add(this.lblPlayerAt);
            this.Controls.Add(this.lblCompPosition);
            this.Controls.Add(this.lblPlayerPosition);
            this.Controls.Add(this.lblWhosTurn);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.pigListBox);
            this.Name = "PigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox pigListBox;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Label lblWhosTurn;
        private System.Windows.Forms.Label lblPlayerPosition;
        private System.Windows.Forms.Label lblCompPosition;
        private System.Windows.Forms.Label lblPlayerAt;
        private System.Windows.Forms.Label lblCompAt;
    }
}