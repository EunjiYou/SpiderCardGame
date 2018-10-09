namespace SpiderCardGame.Gui
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgCard1 = new System.Windows.Forms.PictureBox();
            this.btnHint = new System.Windows.Forms.Button();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblRemainCardSet = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            this.pictureBox51 = new System.Windows.Forms.PictureBox();
            this.pictureBox61 = new System.Windows.Forms.PictureBox();
            this.pictureBox71 = new System.Windows.Forms.PictureBox();
            this.pictureBox81 = new System.Windows.Forms.PictureBox();
            this.pictureBox91 = new System.Windows.Forms.PictureBox();
            this.pbxNewCard = new System.Windows.Forms.PictureBox();
            this.lblState = new System.Windows.Forms.Label();
            this.difficultyPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVeryHard = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewCard)).BeginInit();
            this.difficultyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgCard1
            // 
            this.imgCard1.BackColor = System.Drawing.Color.White;
            this.imgCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCard1.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard2;
            this.imgCard1.InitialImage = null;
            this.imgCard1.Location = new System.Drawing.Point(61, 119);
            this.imgCard1.Name = "imgCard1";
            this.imgCard1.Padding = new System.Windows.Forms.Padding(7);
            this.imgCard1.Size = new System.Drawing.Size(90, 130);
            this.imgCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCard1.TabIndex = 0;
            this.imgCard1.TabStop = false;
            this.imgCard1.Visible = false;
            // 
            // btnHint
            // 
            this.btnHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHint.Location = new System.Drawing.Point(1053, 27);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(100, 40);
            this.btnHint.TabIndex = 3;
            this.btnHint.Text = "힌트";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDifficulty.Location = new System.Drawing.Point(977, 657);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(157, 25);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "난이도 : 매우 어려움";
            this.lblDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScore.Location = new System.Drawing.Point(28, 35);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(150, 32);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "점수 : 1000";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemainCardSet
            // 
            this.lblRemainCardSet.AutoSize = true;
            this.lblRemainCardSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemainCardSet.Location = new System.Drawing.Point(30, 650);
            this.lblRemainCardSet.Name = "lblRemainCardSet";
            this.lblRemainCardSet.Size = new System.Drawing.Size(111, 20);
            this.lblRemainCardSet.TabIndex = 6;
            this.lblRemainCardSet.Text = "남은 카드 세트 : ";
            this.lblRemainCardSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.InitialImage = null;
            this.pictureBox11.Location = new System.Drawing.Point(176, 119);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(90, 130);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 33;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Visible = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox21.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox21.Image")));
            this.pictureBox21.InitialImage = null;
            this.pictureBox21.Location = new System.Drawing.Point(291, 119);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(90, 130);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 43;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Visible = false;
            // 
            // pictureBox31
            // 
            this.pictureBox31.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox31.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox31.Image")));
            this.pictureBox31.InitialImage = null;
            this.pictureBox31.Location = new System.Drawing.Point(406, 119);
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.Size = new System.Drawing.Size(90, 130);
            this.pictureBox31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox31.TabIndex = 53;
            this.pictureBox31.TabStop = false;
            this.pictureBox31.Visible = false;
            // 
            // pictureBox41
            // 
            this.pictureBox41.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox41.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox41.Image")));
            this.pictureBox41.InitialImage = null;
            this.pictureBox41.Location = new System.Drawing.Point(521, 119);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(90, 130);
            this.pictureBox41.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox41.TabIndex = 63;
            this.pictureBox41.TabStop = false;
            this.pictureBox41.Visible = false;
            // 
            // pictureBox51
            // 
            this.pictureBox51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox51.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox51.Image")));
            this.pictureBox51.InitialImage = null;
            this.pictureBox51.Location = new System.Drawing.Point(636, 119);
            this.pictureBox51.Name = "pictureBox51";
            this.pictureBox51.Size = new System.Drawing.Size(90, 130);
            this.pictureBox51.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox51.TabIndex = 73;
            this.pictureBox51.TabStop = false;
            this.pictureBox51.Visible = false;
            // 
            // pictureBox61
            // 
            this.pictureBox61.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox61.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox61.Image")));
            this.pictureBox61.InitialImage = null;
            this.pictureBox61.Location = new System.Drawing.Point(751, 119);
            this.pictureBox61.Name = "pictureBox61";
            this.pictureBox61.Size = new System.Drawing.Size(90, 130);
            this.pictureBox61.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox61.TabIndex = 83;
            this.pictureBox61.TabStop = false;
            this.pictureBox61.Visible = false;
            // 
            // pictureBox71
            // 
            this.pictureBox71.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox71.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox71.Image")));
            this.pictureBox71.InitialImage = null;
            this.pictureBox71.Location = new System.Drawing.Point(866, 119);
            this.pictureBox71.Name = "pictureBox71";
            this.pictureBox71.Size = new System.Drawing.Size(90, 130);
            this.pictureBox71.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox71.TabIndex = 93;
            this.pictureBox71.TabStop = false;
            this.pictureBox71.Visible = false;
            // 
            // pictureBox81
            // 
            this.pictureBox81.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox81.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox81.Image")));
            this.pictureBox81.InitialImage = null;
            this.pictureBox81.Location = new System.Drawing.Point(981, 119);
            this.pictureBox81.Name = "pictureBox81";
            this.pictureBox81.Size = new System.Drawing.Size(90, 130);
            this.pictureBox81.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox81.TabIndex = 103;
            this.pictureBox81.TabStop = false;
            this.pictureBox81.Visible = false;
            // 
            // pictureBox91
            // 
            this.pictureBox91.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox91.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox91.Image")));
            this.pictureBox91.InitialImage = null;
            this.pictureBox91.Location = new System.Drawing.Point(1096, 119);
            this.pictureBox91.Name = "pictureBox91";
            this.pictureBox91.Size = new System.Drawing.Size(90, 130);
            this.pictureBox91.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox91.TabIndex = 113;
            this.pictureBox91.TabStop = false;
            this.pictureBox91.Visible = false;
            // 
            // pbxNewCard
            // 
            this.pbxNewCard.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbxNewCard.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pbxNewCard.InitialImage = null;
            this.pbxNewCard.Location = new System.Drawing.Point(1170, 574);
            this.pbxNewCard.Name = "pbxNewCard";
            this.pbxNewCard.Size = new System.Drawing.Size(90, 130);
            this.pbxNewCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxNewCard.TabIndex = 123;
            this.pbxNewCard.TabStop = false;
            this.pbxNewCard.Click += new System.EventHandler(this.pbxNewCard_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblState.Location = new System.Drawing.Point(281, 650);
            this.lblState.Name = "lblState";
            this.lblState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblState.Size = new System.Drawing.Size(20, 29);
            this.lblState.TabIndex = 130;
            this.lblState.Text = " ";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // difficultyPanel
            // 
            this.difficultyPanel.Controls.Add(this.label1);
            this.difficultyPanel.Controls.Add(this.btnVeryHard);
            this.difficultyPanel.Controls.Add(this.btnHard);
            this.difficultyPanel.Controls.Add(this.btnNormal);
            this.difficultyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.difficultyPanel.Location = new System.Drawing.Point(0, 0);
            this.difficultyPanel.Name = "difficultyPanel";
            this.difficultyPanel.Size = new System.Drawing.Size(1282, 723);
            this.difficultyPanel.TabIndex = 137;
            this.difficultyPanel.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(370, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 29);
            this.label1.TabIndex = 127;
            this.label1.Text = "난이도를 선택하세요.";
            this.label1.UseWaitCursor = true;
            // 
            // btnVeryHard
            // 
            this.btnVeryHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVeryHard.Location = new System.Drawing.Point(735, 320);
            this.btnVeryHard.Name = "btnVeryHard";
            this.btnVeryHard.Size = new System.Drawing.Size(158, 69);
            this.btnVeryHard.TabIndex = 126;
            this.btnVeryHard.Text = "VeryHard";
            this.btnVeryHard.UseVisualStyleBackColor = true;
            this.btnVeryHard.UseWaitCursor = true;
            this.btnVeryHard.Click += new System.EventHandler(this.btnVeryHard_Click);
            // 
            // btnHard
            // 
            this.btnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHard.Location = new System.Drawing.Point(551, 320);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(158, 69);
            this.btnHard.TabIndex = 125;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.UseWaitCursor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNormal.Location = new System.Drawing.Point(349, 320);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(158, 69);
            this.btnNormal.TabIndex = 124;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.UseWaitCursor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.Location = new System.Drawing.Point(345, 300);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(645, 138);
            this.lblResult.TabIndex = 138;
            this.lblResult.Text = "You Win!!";
            this.lblResult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 723);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.difficultyPanel);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.pbxNewCard);
            this.Controls.Add(this.pictureBox91);
            this.Controls.Add(this.pictureBox81);
            this.Controls.Add(this.pictureBox71);
            this.Controls.Add(this.pictureBox61);
            this.Controls.Add(this.pictureBox51);
            this.Controls.Add(this.pictureBox41);
            this.Controls.Add(this.pictureBox31);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.lblRemainCardSet);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.imgCard1);
            this.Name = "Form1";
            this.Text = "스파이더 카드 게임";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.imgCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNewCard)).EndInit();
            this.difficultyPanel.ResumeLayout(false);
            this.difficultyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCard1;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblRemainCardSet;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox31;
        private System.Windows.Forms.PictureBox pictureBox41;
        private System.Windows.Forms.PictureBox pictureBox51;
        private System.Windows.Forms.PictureBox pictureBox61;
        private System.Windows.Forms.PictureBox pictureBox71;
        private System.Windows.Forms.PictureBox pictureBox81;
        private System.Windows.Forms.PictureBox pictureBox91;
        private System.Windows.Forms.PictureBox pbxNewCard;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Panel difficultyPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVeryHard;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Label lblResult;
    }
}

