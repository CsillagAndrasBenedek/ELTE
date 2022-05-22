
namespace SquaresGame.View
{
    partial class SquaresWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeByThreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fiveByFiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nineByNineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.playerBluePointsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.playerToMoveLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.playerRedPointsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(865, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.threeByThreeToolStripMenuItem,
            this.fiveByFiveToolStripMenuItem,
            this.nineByNineToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.newGameToolStripMenuItem.Text = "New game";
            // 
            // threeByThreeToolStripMenuItem
            // 
            this.threeByThreeToolStripMenuItem.Name = "threeByThreeToolStripMenuItem";
            this.threeByThreeToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.threeByThreeToolStripMenuItem.Text = "3x3";
            // 
            // fiveByFiveToolStripMenuItem
            // 
            this.fiveByFiveToolStripMenuItem.Name = "fiveByFiveToolStripMenuItem";
            this.fiveByFiveToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.fiveByFiveToolStripMenuItem.Text = "5x5";
            // 
            // nineByNineToolStripMenuItem
            // 
            this.nineByNineToolStripMenuItem.Name = "nineByNineToolStripMenuItem";
            this.nineByNineToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.nineByNineToolStripMenuItem.Text = "9x9";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.onSaveGameMenuItemClicked);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.onLoadGameMenuItemClicked);
            // 
            // buttonTableLayoutPanel
            // 
            this.buttonTableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTableLayoutPanel.ColumnCount = 2;
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.Location = new System.Drawing.Point(44, 57);
            this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            this.buttonTableLayoutPanel.RowCount = 2;
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.Size = new System.Drawing.Size(750, 750);
            this.buttonTableLayoutPanel.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerBluePointsLabel,
            this.playerToMoveLabel,
            this.playerRedPointsLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 810);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(865, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // playerBluePointsLabel
            // 
            this.playerBluePointsLabel.Name = "playerBluePointsLabel";
            this.playerBluePointsLabel.Size = new System.Drawing.Size(118, 20);
            this.playerBluePointsLabel.Text = "playerBluePoints";
            // 
            // playerToMoveLabel
            // 
            this.playerToMoveLabel.Name = "playerToMoveLabel";
            this.playerToMoveLabel.Size = new System.Drawing.Size(103, 20);
            this.playerToMoveLabel.Text = "playerToMove";
            // 
            // playerRedPointsLabel
            // 
            this.playerRedPointsLabel.Name = "playerRedPointsLabel";
            this.playerRedPointsLabel.Size = new System.Drawing.Size(115, 20);
            this.playerRedPointsLabel.Text = "playerRedPoints";
            // 
            // SquaresWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 836);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonTableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "SquaresWindow";
            this.Text = "Squares game";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeByThreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fiveByFiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nineByNineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel playerBluePointsLabel;
        private System.Windows.Forms.ToolStripStatusLabel playerRedPointsLabel;
        private System.Windows.Forms.ToolStripStatusLabel playerToMoveLabel;
    }
}

