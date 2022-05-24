namespace TowerDefense.View
{
    partial class MapSelectWindow
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MapSelectionText = new System.Windows.Forms.Label();
            this.rowUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnUpDown = new System.Windows.Forms.NumericUpDown();
            this.rowLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(29, 167);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(165, 167);
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
            this.MapSelectionText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MapSelectionText.Location = new System.Drawing.Point(29, 32);
            this.MapSelectionText.Name = "MapSelectionText";
            this.MapSelectionText.Size = new System.Drawing.Size(107, 21);
            this.MapSelectionText.TabIndex = 5;
            this.MapSelectionText.Text = "Map creation";
            // 
            // rowUpDown
            // 
            this.rowUpDown.Location = new System.Drawing.Point(185, 74);
            this.rowUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rowUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.rowUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rowUpDown.Name = "rowUpDown";
            this.rowUpDown.Size = new System.Drawing.Size(55, 23);
            this.rowUpDown.TabIndex = 6;
            this.rowUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // columnUpDown
            // 
            this.columnUpDown.Location = new System.Drawing.Point(185, 112);
            this.columnUpDown.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.columnUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.columnUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.columnUpDown.Name = "columnUpDown";
            this.columnUpDown.Size = new System.Drawing.Size(55, 23);
            this.columnUpDown.TabIndex = 7;
            this.columnUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(29, 76);
            this.rowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(96, 15);
            this.rowLabel.TabIndex = 8;
            this.rowLabel.Text = "Number of rows:";
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(29, 114);
            this.columnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(117, 15);
            this.columnLabel.TabIndex = 9;
            this.columnLabel.Text = "Number of columns:";
            // 
            // MapSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 218);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.columnUpDown);
            this.Controls.Add(this.rowUpDown);
            this.Controls.Add(this.MapSelectionText);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.StartBtn);
            this.Name = "MapSelectWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New game";
            ((System.ComponentModel.ISupportInitialize)(this.rowUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label MapSelectionText;
        private System.Windows.Forms.NumericUpDown rowUpDown;
        private System.Windows.Forms.NumericUpDown columnUpDown;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Label columnLabel;
    }
}