namespace GuiGames {
    partial class TwentyOneForm {
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
            this.twentyOneListBox = new System.Windows.Forms.ListBox();
            this.btnDealCards = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnCanelGame = new System.Windows.Forms.Button();
            this.lblDealerGamesWon = new System.Windows.Forms.Label();
            this.lblUserGamesWon = new System.Windows.Forms.Label();
            this.lblDealer = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblDealerHandvalue = new System.Windows.Forms.Label();
            this.lblPlayerHandValue = new System.Windows.Forms.Label();
            this.dealerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumberOfAces = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblDealersHandvalue = new System.Windows.Forms.Label();
            this.lblPlayersHandValue = new System.Windows.Forms.Label();
            this.lblDealerGamesWonValue = new System.Windows.Forms.Label();
            this.lblPlayerGamesWonValue = new System.Windows.Forms.Label();
            this.PlayerHasBusted = new System.Windows.Forms.Label();
            this.DealerHasBusted = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // twentyOneListBox
            // 
            this.twentyOneListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.twentyOneListBox.FormattingEnabled = true;
            this.twentyOneListBox.Location = new System.Drawing.Point(60, 355);
            this.twentyOneListBox.Name = "twentyOneListBox";
            this.twentyOneListBox.ScrollAlwaysVisible = true;
            this.twentyOneListBox.Size = new System.Drawing.Size(469, 329);
            this.twentyOneListBox.TabIndex = 2;
            this.twentyOneListBox.SelectedIndexChanged += new System.EventHandler(this.twentyOneListBox_SelectedIndexChanged);
            // 
            // btnDealCards
            // 
            this.btnDealCards.Location = new System.Drawing.Point(60, 299);
            this.btnDealCards.Name = "btnDealCards";
            this.btnDealCards.Size = new System.Drawing.Size(98, 23);
            this.btnDealCards.TabIndex = 3;
            this.btnDealCards.Text = "Deal Cards";
            this.btnDealCards.UseVisualStyleBackColor = true;
            this.btnDealCards.Click += new System.EventHandler(this.btnDealCards_Click);
            // 
            // btnHit
            // 
            this.btnHit.Enabled = false;
            this.btnHit.Location = new System.Drawing.Point(181, 299);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(98, 23);
            this.btnHit.TabIndex = 4;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.Enabled = false;
            this.btnStand.Location = new System.Drawing.Point(307, 299);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(98, 23);
            this.btnStand.TabIndex = 5;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnCanelGame
            // 
            this.btnCanelGame.Location = new System.Drawing.Point(431, 299);
            this.btnCanelGame.Name = "btnCanelGame";
            this.btnCanelGame.Size = new System.Drawing.Size(98, 23);
            this.btnCanelGame.TabIndex = 6;
            this.btnCanelGame.Text = "Cancel Game";
            this.btnCanelGame.UseVisualStyleBackColor = true;
            this.btnCanelGame.Click += new System.EventHandler(this.btnCanelGame_Click);
            // 
            // lblDealerGamesWon
            // 
            this.lblDealerGamesWon.AutoSize = true;
            this.lblDealerGamesWon.Location = new System.Drawing.Point(468, 28);
            this.lblDealerGamesWon.Name = "lblDealerGamesWon";
            this.lblDealerGamesWon.Size = new System.Drawing.Size(72, 13);
            this.lblDealerGamesWon.TabIndex = 7;
            this.lblDealerGamesWon.Text = "Games Won: ";
            // 
            // lblUserGamesWon
            // 
            this.lblUserGamesWon.AutoSize = true;
            this.lblUserGamesWon.Location = new System.Drawing.Point(468, 155);
            this.lblUserGamesWon.Name = "lblUserGamesWon";
            this.lblUserGamesWon.Size = new System.Drawing.Size(72, 13);
            this.lblUserGamesWon.TabIndex = 8;
            this.lblUserGamesWon.Text = "Games Won: ";
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Location = new System.Drawing.Point(224, 28);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(38, 13);
            this.lblDealer.TabIndex = 9;
            this.lblDealer.Text = "Dealer";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(224, 155);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(36, 13);
            this.lblPlayer.TabIndex = 10;
            this.lblPlayer.Text = "Player";
            // 
            // lblDealerHandvalue
            // 
            this.lblDealerHandvalue.AutoSize = true;
            this.lblDealerHandvalue.Location = new System.Drawing.Point(269, 28);
            this.lblDealerHandvalue.Name = "lblDealerHandvalue";
            this.lblDealerHandvalue.Size = new System.Drawing.Size(49, 13);
            this.lblDealerHandvalue.TabIndex = 11;
            this.lblDealerHandvalue.Text = "              ";
            // 
            // lblPlayerHandValue
            // 
            this.lblPlayerHandValue.AutoSize = true;
            this.lblPlayerHandValue.Location = new System.Drawing.Point(267, 155);
            this.lblPlayerHandValue.Name = "lblPlayerHandValue";
            this.lblPlayerHandValue.Size = new System.Drawing.Size(43, 13);
            this.lblPlayerHandValue.TabIndex = 12;
            this.lblPlayerHandValue.Text = "            ";
            // 
            // dealerTableLayoutPanel
            // 
            this.dealerTableLayoutPanel.ColumnCount = 8;
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.dealerTableLayoutPanel.Location = new System.Drawing.Point(12, 46);
            this.dealerTableLayoutPanel.Name = "dealerTableLayoutPanel";
            this.dealerTableLayoutPanel.RowCount = 1;
            this.dealerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dealerTableLayoutPanel.Size = new System.Drawing.Size(576, 95);
            this.dealerTableLayoutPanel.TabIndex = 13;
            // 
            // playerTableLayoutPanel
            // 
            this.playerTableLayoutPanel.ColumnCount = 8;
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.playerTableLayoutPanel.Location = new System.Drawing.Point(12, 173);
            this.playerTableLayoutPanel.Name = "playerTableLayoutPanel";
            this.playerTableLayoutPanel.RowCount = 1;
            this.playerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerTableLayoutPanel.Size = new System.Drawing.Size(576, 95);
            this.playerTableLayoutPanel.TabIndex = 14;
            // 
            // lblNumberOfAces
            // 
            this.lblNumberOfAces.AutoSize = true;
            this.lblNumberOfAces.Location = new System.Drawing.Point(227, 275);
            this.lblNumberOfAces.Name = "lblNumberOfAces";
            this.lblNumberOfAces.Size = new System.Drawing.Size(152, 13);
            this.lblNumberOfAces.TabIndex = 15;
            this.lblNumberOfAces.Text = "Number Of Aces With Value 1:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(385, 275);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(13, 13);
            this.lblValue.TabIndex = 16;
            this.lblValue.Text = "0";
            // 
            // lblDealersHandvalue
            // 
            this.lblDealersHandvalue.AutoSize = true;
            this.lblDealersHandvalue.Location = new System.Drawing.Point(269, 29);
            this.lblDealersHandvalue.Name = "lblDealersHandvalue";
            this.lblDealersHandvalue.Size = new System.Drawing.Size(13, 13);
            this.lblDealersHandvalue.TabIndex = 17;
            this.lblDealersHandvalue.Text = "0";
            // 
            // lblPlayersHandValue
            // 
            this.lblPlayersHandValue.AutoSize = true;
            this.lblPlayersHandValue.Location = new System.Drawing.Point(266, 156);
            this.lblPlayersHandValue.Name = "lblPlayersHandValue";
            this.lblPlayersHandValue.Size = new System.Drawing.Size(13, 13);
            this.lblPlayersHandValue.TabIndex = 18;
            this.lblPlayersHandValue.Text = "0";
            // 
            // lblDealerGamesWonValue
            // 
            this.lblDealerGamesWonValue.AutoSize = true;
            this.lblDealerGamesWonValue.Location = new System.Drawing.Point(538, 28);
            this.lblDealerGamesWonValue.Name = "lblDealerGamesWonValue";
            this.lblDealerGamesWonValue.Size = new System.Drawing.Size(13, 13);
            this.lblDealerGamesWonValue.TabIndex = 19;
            this.lblDealerGamesWonValue.Text = "0";
            // 
            // lblPlayerGamesWonValue
            // 
            this.lblPlayerGamesWonValue.AutoSize = true;
            this.lblPlayerGamesWonValue.Location = new System.Drawing.Point(538, 155);
            this.lblPlayerGamesWonValue.Name = "lblPlayerGamesWonValue";
            this.lblPlayerGamesWonValue.Size = new System.Drawing.Size(13, 13);
            this.lblPlayerGamesWonValue.TabIndex = 20;
            this.lblPlayerGamesWonValue.Text = "0";
            // 
            // PlayerHasBusted
            // 
            this.PlayerHasBusted.AutoSize = true;
            this.PlayerHasBusted.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerHasBusted.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.PlayerHasBusted.Location = new System.Drawing.Point(139, 147);
            this.PlayerHasBusted.Name = "PlayerHasBusted";
            this.PlayerHasBusted.Size = new System.Drawing.Size(79, 25);
            this.PlayerHasBusted.TabIndex = 21;
            this.PlayerHasBusted.Text = "Busted";
            this.PlayerHasBusted.Visible = false;
            this.PlayerHasBusted.Click += new System.EventHandler(this.PlayerHasBusted_Click);
            // 
            // DealerHasBusted
            // 
            this.DealerHasBusted.AutoSize = true;
            this.DealerHasBusted.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DealerHasBusted.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.DealerHasBusted.Location = new System.Drawing.Point(139, 20);
            this.DealerHasBusted.Name = "DealerHasBusted";
            this.DealerHasBusted.Size = new System.Drawing.Size(79, 25);
            this.DealerHasBusted.TabIndex = 22;
            this.DealerHasBusted.Text = "Busted";
            this.DealerHasBusted.Visible = false;
            // 
            // TwentyOneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 719);
            this.Controls.Add(this.DealerHasBusted);
            this.Controls.Add(this.PlayerHasBusted);
            this.Controls.Add(this.lblPlayerGamesWonValue);
            this.Controls.Add(this.lblDealerGamesWonValue);
            this.Controls.Add(this.lblPlayersHandValue);
            this.Controls.Add(this.lblDealersHandvalue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblNumberOfAces);
            this.Controls.Add(this.playerTableLayoutPanel);
            this.Controls.Add(this.dealerTableLayoutPanel);
            this.Controls.Add(this.lblPlayerHandValue);
            this.Controls.Add(this.lblDealerHandvalue);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.lblUserGamesWon);
            this.Controls.Add(this.lblDealerGamesWon);
            this.Controls.Add(this.btnCanelGame);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.btnDealCards);
            this.Controls.Add(this.twentyOneListBox);
            this.Name = "TwentyOneForm";
            this.Text = "Twenty-One";
            this.Load += new System.EventHandler(this.TwentyOneForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox twentyOneListBox;
        private System.Windows.Forms.Button btnDealCards;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnCanelGame;
        private System.Windows.Forms.Label lblDealerGamesWon;
        private System.Windows.Forms.Label lblUserGamesWon;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblDealerHandvalue;
        private System.Windows.Forms.Label lblPlayerHandValue;
        private System.Windows.Forms.TableLayoutPanel dealerTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel playerTableLayoutPanel;
        private System.Windows.Forms.Label lblNumberOfAces;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblDealersHandvalue;
        private System.Windows.Forms.Label lblPlayersHandValue;
        private System.Windows.Forms.Label lblDealerGamesWonValue;
        private System.Windows.Forms.Label lblPlayerGamesWonValue;
        private System.Windows.Forms.Label PlayerHasBusted;
        private System.Windows.Forms.Label DealerHasBusted;
    }
}