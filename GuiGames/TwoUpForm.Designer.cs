namespace GuiGames {
    partial class TwoUpForm {
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
            this.components = new System.ComponentModel.Container();
            this.twoUpListBox = new System.Windows.Forms.ListBox();
            this.pbxFirstCoin = new System.Windows.Forms.PictureBox();
            this.pbxSecondCoin = new System.Windows.Forms.PictureBox();
            this.btnThrowCoins = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCoinsTossed = new System.Windows.Forms.Label();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.tmrFlip = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFirstCoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSecondCoin)).BeginInit();
            this.SuspendLayout();
            // 
            // twoUpListBox
            // 
            this.twoUpListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.twoUpListBox.FormattingEnabled = true;
            this.twoUpListBox.Location = new System.Drawing.Point(46, 266);
            this.twoUpListBox.Name = "twoUpListBox";
            this.twoUpListBox.ScrollAlwaysVisible = true;
            this.twoUpListBox.Size = new System.Drawing.Size(429, 238);
            this.twoUpListBox.TabIndex = 4;
            // 
            // pbxFirstCoin
            // 
            this.pbxFirstCoin.Image = global::GuiGames.Properties.Resources.Heads150;
            this.pbxFirstCoin.Location = new System.Drawing.Point(61, 28);
            this.pbxFirstCoin.Name = "pbxFirstCoin";
            this.pbxFirstCoin.Size = new System.Drawing.Size(150, 150);
            this.pbxFirstCoin.TabIndex = 6;
            this.pbxFirstCoin.TabStop = false;
            // 
            // pbxSecondCoin
            // 
            this.pbxSecondCoin.Image = global::GuiGames.Properties.Resources.Heads150;
            this.pbxSecondCoin.Location = new System.Drawing.Point(310, 28);
            this.pbxSecondCoin.Name = "pbxSecondCoin";
            this.pbxSecondCoin.Size = new System.Drawing.Size(150, 150);
            this.pbxSecondCoin.TabIndex = 7;
            this.pbxSecondCoin.TabStop = false;
            // 
            // btnThrowCoins
            // 
            this.btnThrowCoins.Location = new System.Drawing.Point(46, 215);
            this.btnThrowCoins.Name = "btnThrowCoins";
            this.btnThrowCoins.Size = new System.Drawing.Size(117, 28);
            this.btnThrowCoins.TabIndex = 8;
            this.btnThrowCoins.Text = "Throw Coins";
            this.btnThrowCoins.UseVisualStyleBackColor = true;
            this.btnThrowCoins.Click += new System.EventHandler(this.btnThrowCoins_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(367, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel Game";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCoinsTossed
            // 
            this.lblCoinsTossed.AutoSize = true;
            this.lblCoinsTossed.Location = new System.Drawing.Point(240, 103);
            this.lblCoinsTossed.Name = "lblCoinsTossed";
            this.lblCoinsTossed.Size = new System.Drawing.Size(23, 13);
            this.lblCoinsTossed.TabIndex = 10;
            this.lblCoinsTossed.Text = "null";
            this.lblCoinsTossed.Visible = false;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(208, 215);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(117, 28);
            this.btnPlayAgain.TabIndex = 11;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Visible = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // tmrFlip
            // 
            this.tmrFlip.Tick += new System.EventHandler(this.tmrFlip_Tick);
            // 
            // TwoUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 542);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.lblCoinsTossed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnThrowCoins);
            this.Controls.Add(this.pbxSecondCoin);
            this.Controls.Add(this.pbxFirstCoin);
            this.Controls.Add(this.twoUpListBox);
            this.Name = "TwoUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Two Up";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFirstCoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSecondCoin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox twoUpListBox;
        private System.Windows.Forms.PictureBox pbxFirstCoin;
        private System.Windows.Forms.PictureBox pbxSecondCoin;
        private System.Windows.Forms.Button btnThrowCoins;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCoinsTossed;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Timer tmrFlip;
    }
}