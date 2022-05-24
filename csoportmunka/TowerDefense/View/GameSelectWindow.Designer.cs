namespace TowerDefense.View
{
    partial class GameSelectWindow
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
            this.SmallLevelBtn = new System.Windows.Forms.RadioButton();
            this.MediumLevelBtn = new System.Windows.Forms.RadioButton();
            this.LargeLevelBtn = new System.Windows.Forms.RadioButton();
            this.StartBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MapSelectionText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SmallLevelBtn
            // 
            this.SmallLevelBtn.AutoSize = true;
            this.SmallLevelBtn.Location = new System.Drawing.Point(35, 81);
            this.SmallLevelBtn.Name = "SmallLevelBtn";
            this.SmallLevelBtn.Size = new System.Drawing.Size(95, 19);
            this.SmallLevelBtn.TabIndex = 0;
            this.SmallLevelBtn.TabStop = true;
            this.SmallLevelBtn.Text = "Small (10x11)";
            this.SmallLevelBtn.UseVisualStyleBackColor = true;
            this.SmallLevelBtn.CheckedChanged += new System.EventHandler(this.SmallLevelBtn_Changed);
            // 
            // MediumLevelBtn
            // 
            this.MediumLevelBtn.AutoSize = true;
            this.MediumLevelBtn.Location = new System.Drawing.Point(35, 106);
            this.MediumLevelBtn.Name = "MediumLevelBtn";
            this.MediumLevelBtn.Size = new System.Drawing.Size(111, 19);
            this.MediumLevelBtn.TabIndex = 1;
            this.MediumLevelBtn.TabStop = true;
            this.MediumLevelBtn.Text = "Medium (12x13)";
            this.MediumLevelBtn.UseVisualStyleBackColor = true;
            this.MediumLevelBtn.CheckedChanged += new System.EventHandler(this.MediumLevelBtn_Changed);
            // 
            // LargeLevelBtn
            // 
            this.LargeLevelBtn.AutoSize = true;
            this.LargeLevelBtn.Location = new System.Drawing.Point(35, 131);
            this.LargeLevelBtn.Name = "LargeLevelBtn";
            this.LargeLevelBtn.Size = new System.Drawing.Size(95, 19);
            this.LargeLevelBtn.TabIndex = 2;
            this.LargeLevelBtn.TabStop = true;
            this.LargeLevelBtn.Text = "Large (14x15)";
            this.LargeLevelBtn.UseVisualStyleBackColor = true;
            this.LargeLevelBtn.CheckedChanged += new System.EventHandler(this.LargeLevelBtn_Changed);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(35, 180);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(151, 180);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MapSelectionText
            // 
            this.MapSelectionText.AutoSize = true;
            this.MapSelectionText.Location = new System.Drawing.Point(29, 38);
            this.MapSelectionText.Name = "MapSelectionText";
            this.MapSelectionText.Size = new System.Drawing.Size(81, 15);
            this.MapSelectionText.TabIndex = 5;
            this.MapSelectionText.Text = "Map selection";
            // 
            // GameSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 233);
            this.Controls.Add(this.MapSelectionText);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.LargeLevelBtn);
            this.Controls.Add(this.MediumLevelBtn);
            this.Controls.Add(this.SmallLevelBtn);
            this.Name = "GameSelectWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton SmallLevelBtn;
        private System.Windows.Forms.RadioButton MediumLevelBtn;
        private System.Windows.Forms.RadioButton LargeLevelBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label MapSelectionText;
    }
}