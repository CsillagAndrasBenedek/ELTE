
using System;

namespace TowerDefense.View
{
    partial class MapEditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorWindow));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.startGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.castle1Button = new System.Windows.Forms.Button();
            this.castle2Button = new System.Windows.Forms.Button();
            this.hut1Button = new System.Windows.Forms.Button();
            this.castle2Label = new System.Windows.Forms.Label();
            this.funds2Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.deleteFieldButton = new System.Windows.Forms.Button();
            this.obstacleButton = new System.Windows.Forms.Button();
            this.castle1Label = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.funds1Label = new System.Windows.Forms.Label();
            this.hut2Button = new System.Windows.Forms.Button();
            this.rulesLabel = new System.Windows.Forms.Label();
            this.rulesTextBox = new System.Windows.Forms.RichTextBox();
            this.BoardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameMenuItem,
            this.newMapMenuItem,
            this.loadMapMenuItem,
            this.saveMapMenuItem,
            this.mapEditorMenuItem,
            this.quitEditorMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1280, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // startGameMenuItem
            // 
            this.startGameMenuItem.Name = "startGameMenuItem";
            this.startGameMenuItem.Size = new System.Drawing.Size(76, 20);
            this.startGameMenuItem.Text = "Start game";
            this.startGameMenuItem.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // newMapMenuItem
            // 
            this.newMapMenuItem.Name = "newMapMenuItem";
            this.newMapMenuItem.Size = new System.Drawing.Size(70, 20);
            this.newMapMenuItem.Text = "New map";
            this.newMapMenuItem.Click += new System.EventHandler(this.NewMap_Click);
            // 
            // loadMapMenuItem
            // 
            this.loadMapMenuItem.Name = "loadMapMenuItem";
            this.loadMapMenuItem.Size = new System.Drawing.Size(72, 20);
            this.loadMapMenuItem.Text = "Load map";
            this.loadMapMenuItem.Click += new System.EventHandler(this.LoadMap_Click);
            // 
            // saveMapMenuItem
            // 
            this.saveMapMenuItem.Enabled = false;
            this.saveMapMenuItem.Name = "saveMapMenuItem";
            this.saveMapMenuItem.Size = new System.Drawing.Size(70, 20);
            this.saveMapMenuItem.Text = "Save map";
            this.saveMapMenuItem.Click += new System.EventHandler(this.SaveMap_Click);
            // 
            // mapEditorMenuItem
            // 
            this.mapEditorMenuItem.Name = "mapEditorMenuItem";
            this.mapEditorMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // quitEditorMenuItem
            // 
            this.quitEditorMenuItem.Name = "quitEditorMenuItem";
            this.quitEditorMenuItem.Size = new System.Drawing.Size(76, 20);
            this.quitEditorMenuItem.Text = "Quit editor";
            this.quitEditorMenuItem.Click += new System.EventHandler(this.QuitEditor_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer.Panel1.Controls.Add(this.castle1Button);
            this.splitContainer.Panel1.Controls.Add(this.castle2Button);
            this.splitContainer.Panel1.Controls.Add(this.hut1Button);
            this.splitContainer.Panel1.Controls.Add(this.castle2Label);
            this.splitContainer.Panel1.Controls.Add(this.funds2Label);
            this.splitContainer.Panel1.Controls.Add(this.player2Label);
            this.splitContainer.Panel1.Controls.Add(this.deleteFieldButton);
            this.splitContainer.Panel1.Controls.Add(this.obstacleButton);
            this.splitContainer.Panel1.Controls.Add(this.castle1Label);
            this.splitContainer.Panel1.Controls.Add(this.player1Label);
            this.splitContainer.Panel1.Controls.Add(this.funds1Label);
            this.splitContainer.Panel1.Controls.Add(this.hut2Button);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer.Panel2.Controls.Add(this.rulesLabel);
            this.splitContainer.Panel2.Controls.Add(this.rulesTextBox);
            this.splitContainer.Panel2.Controls.Add(this.BoardLayout);
            this.splitContainer.Size = new System.Drawing.Size(1280, 674);
            this.splitContainer.SplitterDistance = 125;
            this.splitContainer.TabIndex = 2;
            // 
            // castle1Button
            // 
            this.castle1Button.AutoSize = true;
            this.castle1Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.castle1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.castle1Button.Enabled = false;
            this.castle1Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.castle1Button.Location = new System.Drawing.Point(0, 329);
            this.castle1Button.Name = "castle1Button";
            this.castle1Button.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.castle1Button.Size = new System.Drawing.Size(125, 35);
            this.castle1Button.TabIndex = 15;
            this.castle1Button.Text = "Castle (P1)";
            this.castle1Button.UseVisualStyleBackColor = false;
            this.castle1Button.Click += new System.EventHandler(this.Castle1Button_Click);
            // 
            // castle2Button
            // 
            this.castle2Button.AutoSize = true;
            this.castle2Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.castle2Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.castle2Button.Enabled = false;
            this.castle2Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.castle2Button.Location = new System.Drawing.Point(0, 370);
            this.castle2Button.Name = "castle2Button";
            this.castle2Button.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.castle2Button.Size = new System.Drawing.Size(125, 35);
            this.castle2Button.TabIndex = 14;
            this.castle2Button.Text = "Castle (P2)";
            this.castle2Button.UseVisualStyleBackColor = false;
            this.castle2Button.Click += new System.EventHandler(this.Castle2Button_Click);
            // 
            // hut1Button
            // 
            this.hut1Button.AutoSize = true;
            this.hut1Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.hut1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hut1Button.Enabled = false;
            this.hut1Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hut1Button.Location = new System.Drawing.Point(0, 430);
            this.hut1Button.Name = "hut1Button";
            this.hut1Button.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.hut1Button.Size = new System.Drawing.Size(125, 35);
            this.hut1Button.TabIndex = 13;
            this.hut1Button.Text = "Huts (P1)";
            this.hut1Button.UseVisualStyleBackColor = false;
            this.hut1Button.Click += new System.EventHandler(this.Hut1Button_Click);
            // 
            // castle2Label
            // 
            this.castle2Label.Location = new System.Drawing.Point(0, 0);
            this.castle2Label.Name = "castle2Label";
            this.castle2Label.Size = new System.Drawing.Size(100, 23);
            this.castle2Label.TabIndex = 16;
            // 
            // funds2Label
            // 
            this.funds2Label.Location = new System.Drawing.Point(0, 0);
            this.funds2Label.Name = "funds2Label";
            this.funds2Label.Size = new System.Drawing.Size(100, 23);
            this.funds2Label.TabIndex = 17;
            // 
            // player2Label
            // 
            this.player2Label.Location = new System.Drawing.Point(0, 0);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(100, 23);
            this.player2Label.TabIndex = 18;
            // 
            // deleteFieldButton
            // 
            this.deleteFieldButton.AutoSize = true;
            this.deleteFieldButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.deleteFieldButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteFieldButton.Enabled = false;
            this.deleteFieldButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteFieldButton.Location = new System.Drawing.Point(0, 590);
            this.deleteFieldButton.Name = "deleteFieldButton";
            this.deleteFieldButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.deleteFieldButton.Size = new System.Drawing.Size(125, 35);
            this.deleteFieldButton.TabIndex = 8;
            this.deleteFieldButton.Text = "Delete field";
            this.deleteFieldButton.UseVisualStyleBackColor = false;
            this.deleteFieldButton.Click += new System.EventHandler(this.DeleteFieldButton_Click);
            // 
            // obstacleButton
            // 
            this.obstacleButton.AutoSize = true;
            this.obstacleButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.obstacleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.obstacleButton.Enabled = false;
            this.obstacleButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.obstacleButton.Location = new System.Drawing.Point(0, 540);
            this.obstacleButton.Name = "obstacleButton";
            this.obstacleButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.obstacleButton.Size = new System.Drawing.Size(125, 35);
            this.obstacleButton.TabIndex = 7;
            this.obstacleButton.Text = "Mountain";
            this.obstacleButton.UseVisualStyleBackColor = false;
            this.obstacleButton.Click += new System.EventHandler(this.ObstacleButton_Click);
            // 
            // castle1Label
            // 
            this.castle1Label.Location = new System.Drawing.Point(0, 0);
            this.castle1Label.Name = "castle1Label";
            this.castle1Label.Size = new System.Drawing.Size(100, 23);
            this.castle1Label.TabIndex = 19;
            // 
            // player1Label
            // 
            this.player1Label.Location = new System.Drawing.Point(0, 0);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(100, 23);
            this.player1Label.TabIndex = 20;
            // 
            // funds1Label
            // 
            this.funds1Label.Location = new System.Drawing.Point(0, 0);
            this.funds1Label.Name = "funds1Label";
            this.funds1Label.Size = new System.Drawing.Size(100, 23);
            this.funds1Label.TabIndex = 21;
            // 
            // hut2Button
            // 
            this.hut2Button.AutoSize = true;
            this.hut2Button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.hut2Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hut2Button.Enabled = false;
            this.hut2Button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hut2Button.Location = new System.Drawing.Point(0, 471);
            this.hut2Button.Name = "hut2Button";
            this.hut2Button.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.hut2Button.Size = new System.Drawing.Size(125, 35);
            this.hut2Button.TabIndex = 0;
            this.hut2Button.Text = "Huts (P2)";
            this.hut2Button.UseVisualStyleBackColor = false;
            this.hut2Button.Click += new System.EventHandler(this.Hut2Button_Click);
            // 
            // rulesLabel
            // 
            this.rulesLabel.AutoSize = true;
            this.rulesLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.rulesLabel.Location = new System.Drawing.Point(912, 42);
            this.rulesLabel.Name = "rulesLabel";
            this.rulesLabel.Size = new System.Drawing.Size(86, 21);
            this.rulesLabel.TabIndex = 3;
            this.rulesLabel.Text = "Guidelines";
            // 
            // rulesTextBox
            // 
            this.rulesTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rulesTextBox.Location = new System.Drawing.Point(779, 86);
            this.rulesTextBox.Name = "rulesTextBox";
            this.rulesTextBox.ReadOnly = true;
            this.rulesTextBox.Size = new System.Drawing.Size(338, 124);
            this.rulesTextBox.TabIndex = 2;
            this.rulesTextBox.Text = resources.GetString("rulesTextBox.Text");
            // 
            // BoardLayout
            // 
            this.BoardLayout.ColumnCount = 10;
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.Location = new System.Drawing.Point(19, 19);
            this.BoardLayout.Name = "BoardLayout";
            this.BoardLayout.RowCount = 11;
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoardLayout.Size = new System.Drawing.Size(200, 220);
            this.BoardLayout.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 676);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1280, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.statusLabel.Size = new System.Drawing.Size(1290, 17);
            this.statusLabel.Text = "Create your own map!";
            // 
            // MapEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1280, 698);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MapEditorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_Closing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newMapMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button hut2Button;
        private System.Windows.Forms.ToolStripMenuItem loadMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitEditorMenuItem;
        private System.Windows.Forms.Label castle1Label;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label funds1Label;
        private System.Windows.Forms.TableLayoutPanel BoardLayout;
        private System.Windows.Forms.Button deleteFieldButton;
        private System.Windows.Forms.Button obstacleButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label funds2Label;
        private System.Windows.Forms.Label castle2Label;
        private System.Windows.Forms.Button castle1Button;
        private System.Windows.Forms.Button castle2Button;
        private System.Windows.Forms.Button hut1Button;
        private System.Windows.Forms.ToolStripMenuItem startGameMenuItem;
        private System.Windows.Forms.RichTextBox rulesTextBox;
        private System.Windows.Forms.Label rulesLabel;
    }
}

