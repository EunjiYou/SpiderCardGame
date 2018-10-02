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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHint = new System.Windows.Forms.Button();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblRemainCardSet = new System.Windows.Forms.Label();
            this.txtSendLine = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtRecvLine = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox92 = new System.Windows.Forms.PictureBox();
            this.pictureBox91 = new System.Windows.Forms.PictureBox();
            this.pictureBox81 = new System.Windows.Forms.PictureBox();
            this.pictureBox71 = new System.Windows.Forms.PictureBox();
            this.pictureBox61 = new System.Windows.Forms.PictureBox();
            this.pictureBox51 = new System.Windows.Forms.PictureBox();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.imgCard1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(939, 27);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "실행";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHint
            // 
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
            this.lblDifficulty.Location = new System.Drawing.Point(25, 35);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(147, 15);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "난이도 : 매우 어려움";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(209, 35);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(84, 15);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "점수 : 1000";
            // 
            // lblRemainCardSet
            // 
            this.lblRemainCardSet.AutoSize = true;
            this.lblRemainCardSet.Location = new System.Drawing.Point(30, 650);
            this.lblRemainCardSet.Name = "lblRemainCardSet";
            this.lblRemainCardSet.Size = new System.Drawing.Size(122, 15);
            this.lblRemainCardSet.TabIndex = 6;
            this.lblRemainCardSet.Text = "남은 카드 세트 : ";
            // 
            // txtSendLine
            // 
            this.txtSendLine.Location = new System.Drawing.Point(338, 30);
            this.txtSendLine.Name = "txtSendLine";
            this.txtSendLine.Size = new System.Drawing.Size(100, 25);
            this.txtSendLine.TabIndex = 8;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(531, 30);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 25);
            this.txtAmount.TabIndex = 9;
            // 
            // txtRecvLine
            // 
            this.txtRecvLine.Location = new System.Drawing.Point(701, 30);
            this.txtRecvLine.Name = "txtRecvLine";
            this.txtRecvLine.Size = new System.Drawing.Size(100, 25);
            this.txtRecvLine.TabIndex = 10;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(444, 35);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(72, 15);
            this.label.TabIndex = 11;
            this.label.Text = "번 줄에서";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(648, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "만큼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(815, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "번 줄로 이동";
            // 
            // pictureBox92
            // 
            this.pictureBox92.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox92.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox92.InitialImage = null;
            this.pictureBox92.Location = new System.Drawing.Point(1123, 565);
            this.pictureBox92.Name = "pictureBox92";
            this.pictureBox92.Size = new System.Drawing.Size(90, 130);
            this.pictureBox92.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox92.TabIndex = 123;
            this.pictureBox92.TabStop = false;
            // 
            // pictureBox91
            // 
            this.pictureBox91.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox91.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox91.InitialImage = null;
            this.pictureBox91.Location = new System.Drawing.Point(1095, 90);
            this.pictureBox91.Name = "pictureBox91";
            this.pictureBox91.Size = new System.Drawing.Size(90, 130);
            this.pictureBox91.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox91.TabIndex = 113;
            this.pictureBox91.TabStop = false;
            // 
            // pictureBox81
            // 
            this.pictureBox81.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox81.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox81.InitialImage = null;
            this.pictureBox81.Location = new System.Drawing.Point(980, 90);
            this.pictureBox81.Name = "pictureBox81";
            this.pictureBox81.Size = new System.Drawing.Size(90, 130);
            this.pictureBox81.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox81.TabIndex = 103;
            this.pictureBox81.TabStop = false;
            // 
            // pictureBox71
            // 
            this.pictureBox71.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox71.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox71.InitialImage = null;
            this.pictureBox71.Location = new System.Drawing.Point(865, 90);
            this.pictureBox71.Name = "pictureBox71";
            this.pictureBox71.Size = new System.Drawing.Size(90, 130);
            this.pictureBox71.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox71.TabIndex = 93;
            this.pictureBox71.TabStop = false;
            // 
            // pictureBox61
            // 
            this.pictureBox61.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox61.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox61.InitialImage = null;
            this.pictureBox61.Location = new System.Drawing.Point(750, 90);
            this.pictureBox61.Name = "pictureBox61";
            this.pictureBox61.Size = new System.Drawing.Size(90, 130);
            this.pictureBox61.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox61.TabIndex = 83;
            this.pictureBox61.TabStop = false;
            // 
            // pictureBox51
            // 
            this.pictureBox51.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox51.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox51.InitialImage = null;
            this.pictureBox51.Location = new System.Drawing.Point(635, 90);
            this.pictureBox51.Name = "pictureBox51";
            this.pictureBox51.Size = new System.Drawing.Size(90, 130);
            this.pictureBox51.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox51.TabIndex = 73;
            this.pictureBox51.TabStop = false;
            // 
            // pictureBox41
            // 
            this.pictureBox41.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox41.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox41.InitialImage = null;
            this.pictureBox41.Location = new System.Drawing.Point(520, 90);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(90, 130);
            this.pictureBox41.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox41.TabIndex = 63;
            this.pictureBox41.TabStop = false;
            // 
            // pictureBox31
            // 
            this.pictureBox31.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox31.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox31.InitialImage = null;
            this.pictureBox31.Location = new System.Drawing.Point(405, 90);
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.Size = new System.Drawing.Size(90, 130);
            this.pictureBox31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox31.TabIndex = 53;
            this.pictureBox31.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox21.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox21.InitialImage = null;
            this.pictureBox21.Location = new System.Drawing.Point(290, 90);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(90, 130);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 43;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox11.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.pictureBox11.InitialImage = null;
            this.pictureBox11.Location = new System.Drawing.Point(175, 90);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(90, 130);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 33;
            this.pictureBox11.TabStop = false;
            // 
            // imgCard1
            // 
            this.imgCard1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.imgCard1.Image = global::SpiderCardGame.Gui.Properties.Resources.backcard;
            this.imgCard1.InitialImage = null;
            this.imgCard1.Location = new System.Drawing.Point(60, 90);
            this.imgCard1.Name = "imgCard1";
            this.imgCard1.Size = new System.Drawing.Size(90, 130);
            this.imgCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCard1.TabIndex = 0;
            this.imgCard1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 719);
            this.Controls.Add(this.pictureBox92);
            this.Controls.Add(this.pictureBox91);
            this.Controls.Add(this.pictureBox81);
            this.Controls.Add(this.pictureBox71);
            this.Controls.Add(this.pictureBox61);
            this.Controls.Add(this.pictureBox51);
            this.Controls.Add(this.pictureBox41);
            this.Controls.Add(this.pictureBox31);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.txtRecvLine);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtSendLine);
            this.Controls.Add(this.lblRemainCardSet);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.imgCard1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCard1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCard1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblRemainCardSet;
        private System.Windows.Forms.TextBox txtSendLine;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtRecvLine;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox31;
        private System.Windows.Forms.PictureBox pictureBox41;
        private System.Windows.Forms.PictureBox pictureBox51;
        private System.Windows.Forms.PictureBox pictureBox61;
        private System.Windows.Forms.PictureBox pictureBox71;
        private System.Windows.Forms.PictureBox pictureBox81;
        private System.Windows.Forms.PictureBox pictureBox91;
        private System.Windows.Forms.PictureBox pictureBox92;
    }
}

