namespace WinApp.Forms
{
    partial class MatchForm
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
            this.numAwayScore = new System.Windows.Forms.NumericUpDown();
            this.numHomeScore = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHomeName = new System.Windows.Forms.Label();
            this.lblAwayName = new System.Windows.Forms.Label();
            this.lblScoring = new System.Windows.Forms.Label();
            this.lblMatchNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAwayScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomeScore)).BeginInit();
            this.SuspendLayout();
            // 
            // numAwayScore
            // 
            this.numAwayScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numAwayScore.Location = new System.Drawing.Point(314, 274);
            this.numAwayScore.Name = "numAwayScore";
            this.numAwayScore.Size = new System.Drawing.Size(137, 29);
            this.numAwayScore.TabIndex = 2;
            // 
            // numHomeScore
            // 
            this.numHomeScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numHomeScore.Location = new System.Drawing.Point(47, 274);
            this.numHomeScore.Name = "numHomeScore";
            this.numHomeScore.Size = new System.Drawing.Size(137, 29);
            this.numHomeScore.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(47, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Contestant One";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(314, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contestant Two";
            // 
            // lblHomeName
            // 
            this.lblHomeName.AutoSize = true;
            this.lblHomeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHomeName.Location = new System.Drawing.Point(47, 231);
            this.lblHomeName.Name = "lblHomeName";
            this.lblHomeName.Size = new System.Drawing.Size(114, 21);
            this.lblHomeName.TabIndex = 6;
            this.lblHomeName.Text = "<playername>";
            // 
            // lblAwayName
            // 
            this.lblAwayName.AutoSize = true;
            this.lblAwayName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAwayName.Location = new System.Drawing.Point(314, 231);
            this.lblAwayName.Name = "lblAwayName";
            this.lblAwayName.Size = new System.Drawing.Size(114, 21);
            this.lblAwayName.TabIndex = 7;
            this.lblAwayName.Text = "<playername>";
            // 
            // lblScoring
            // 
            this.lblScoring.AutoSize = true;
            this.lblScoring.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScoring.Location = new System.Drawing.Point(207, 276);
            this.lblScoring.Name = "lblScoring";
            this.lblScoring.Size = new System.Drawing.Size(83, 21);
            this.lblScoring.TabIndex = 8;
            this.lblScoring.Text = "<scoring>";
            // 
            // lblMatchNumber
            // 
            this.lblMatchNumber.AutoSize = true;
            this.lblMatchNumber.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMatchNumber.Location = new System.Drawing.Point(193, 70);
            this.lblMatchNumber.Name = "lblMatchNumber";
            this.lblMatchNumber.Size = new System.Drawing.Size(109, 45);
            this.lblMatchNumber.TabIndex = 9;
            this.lblMatchNumber.Text = "Match";
            this.lblMatchNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 380);
            this.Controls.Add(this.lblMatchNumber);
            this.Controls.Add(this.lblScoring);
            this.Controls.Add(this.lblAwayName);
            this.Controls.Add(this.lblHomeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numHomeScore);
            this.Controls.Add(this.numAwayScore);
            this.Name = "MatchForm";
            this.Text = "MatchForm";
            ((System.ComponentModel.ISupportInitialize)(this.numAwayScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomeScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown numAwayScore;
        private NumericUpDown numHomeScore;
        private Label label1;
        private Label label2;
        private Label lblHomeName;
        private Label lblAwayName;
        private Label lblScoring;
        private Label lblMatchNumber;
    }
}