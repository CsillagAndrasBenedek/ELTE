
namespace TowerDefense.View
{
    partial class GameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.troopButton = new System.Windows.Forms.Button();
            this.buyTowerButton = new System.Windows.Forms.Button();
            this.cavalryButton = new System.Windows.Forms.Button();
            this.castle2Label = new System.Windows.Forms.Label();
            this.funds2Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.endTurnButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.castle1Label = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.funds1Label = new System.Windows.Forms.Label();
            this.upgradeButton = new System.Windows.Forms.Button();
            this.introLabel = new System.Windows.Forms.Label();
            this.fieldInfoLabel = new System.Windows.Forms.Label();
            this.fieldDataTable = new System.Windows.Forms.DataGridView();
            this.PlayerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HealthCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataTable)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem,
            this.loadGameMenuItem,
            this.saveGameMenuItem,
            this.mapEditorMenuItem,
            this.quitGameMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1280, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newGameMenuItem.Text = "New Game";
            this.newGameMenuItem.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // loadGameMenuItem
            // 
            this.loadGameMenuItem.Name = "loadGameMenuItem";
            this.loadGameMenuItem.Size = new System.Drawing.Size(78, 20);
            this.loadGameMenuItem.Text = "Load game";
            this.loadGameMenuItem.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // saveGameMenuItem
            // 
            this.saveGameMenuItem.Name = "saveGameMenuItem";
            this.saveGameMenuItem.Size = new System.Drawing.Size(76, 20);
            this.saveGameMenuItem.Text = "Save game";
            this.saveGameMenuItem.Click += new System.EventHandler(this.SaveGame_Click);
            // 
            // mapEditorMenuItem
            // 
            this.mapEditorMenuItem.Name = "mapEditorMenuItem";
            this.mapEditorMenuItem.Size = new System.Drawing.Size(77, 20);
            this.mapEditorMenuItem.Text = "Map editor";
            this.mapEditorMenuItem.Click += new System.EventHandler(this.MapEditorMenuItem_Click);
            // 
            // quitGameMenuItem
            // 
            this.quitGameMenuItem.Name = "quitGameMenuItem";
            this.quitGameMenuItem.Size = new System.Drawing.Size(75, 20);
            this.quitGameMenuItem.Text = "Quit game";
            this.quitGameMenuItem.Click += new System.EventHandler(this.QuitGame_Click);
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
            this.splitContainer.Panel1.Controls.Add(this.troopButton);
            this.splitContainer.Panel1.Controls.Add(this.buyTowerButton);
            this.splitContainer.Panel1.Controls.Add(this.cavalryButton);
            this.splitContainer.Panel1.Controls.Add(this.castle2Label);
            this.splitContainer.Panel1.Controls.Add(this.funds2Label);
            this.splitContainer.Panel1.Controls.Add(this.player2Label);
            this.splitContainer.Panel1.Controls.Add(this.endTurnButton);
            this.splitContainer.Panel1.Controls.Add(this.removeButton);
            this.splitContainer.Panel1.Controls.Add(this.castle1Label);
            this.splitContainer.Panel1.Controls.Add(this.player1Label);
            this.splitContainer.Panel1.Controls.Add(this.funds1Label);
            this.splitContainer.Panel1.Controls.Add(this.upgradeButton);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer.Panel2.Controls.Add(this.introLabel);
            this.splitContainer.Panel2.Controls.Add(this.fieldInfoLabel);
            this.splitContainer.Panel2.Controls.Add(this.fieldDataTable);
            this.splitContainer.Panel2.Controls.Add(this.BoardLayout);
            this.splitContainer.Size = new System.Drawing.Size(1280, 674);
            this.splitContainer.SplitterDistance = 125;
            this.splitContainer.TabIndex = 2;
            // 
            // troopButton
            // 
            this.troopButton.AutoSize = true;
            this.troopButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.troopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.troopButton.Enabled = false;
            this.troopButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.troopButton.Location = new System.Drawing.Point(0, 329);
            this.troopButton.Name = "troopButton";
            this.troopButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.troopButton.Size = new System.Drawing.Size(125, 40);
            this.troopButton.TabIndex = 15;
            this.troopButton.Text = "Buy troop";
            this.troopButton.UseVisualStyleBackColor = false;
            this.troopButton.Click += new System.EventHandler(this.TroopButton_Click);
            // 
            // buyTowerButton
            // 
            this.buyTowerButton.AutoSize = true;
            this.buyTowerButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buyTowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buyTowerButton.Enabled = false;
            this.buyTowerButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buyTowerButton.Location = new System.Drawing.Point(0, 430);
            this.buyTowerButton.Name = "buyTowerButton";
            this.buyTowerButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.buyTowerButton.Size = new System.Drawing.Size(125, 40);
            this.buyTowerButton.TabIndex = 14;
            this.buyTowerButton.Text = "Buy tower";
            this.buyTowerButton.UseVisualStyleBackColor = false;
            this.buyTowerButton.Click += new System.EventHandler(this.BuyTowerButton_Click);
            // 
            // cavalryButton
            // 
            this.cavalryButton.AutoSize = true;
            this.cavalryButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.cavalryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cavalryButton.Enabled = false;
            this.cavalryButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cavalryButton.Location = new System.Drawing.Point(0, 370);
            this.cavalryButton.Name = "cavalryButton";
            this.cavalryButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.cavalryButton.Size = new System.Drawing.Size(125, 40);
            this.cavalryButton.TabIndex = 13;
            this.cavalryButton.Text = "Buy cavalry";
            this.cavalryButton.UseVisualStyleBackColor = false;
            this.cavalryButton.Click += new System.EventHandler(this.CavalryButton_Click);
            // 
            // castle2Label
            // 
            this.castle2Label.AutoSize = true;
            this.castle2Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.castle2Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.castle2Label.Location = new System.Drawing.Point(0, 175);
            this.castle2Label.MinimumSize = new System.Drawing.Size(125, 2);
            this.castle2Label.Name = "castle2Label";
            this.castle2Label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.castle2Label.Size = new System.Drawing.Size(125, 27);
            this.castle2Label.TabIndex = 12;
            this.castle2Label.Text = "Castle: 100%";
            this.castle2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // funds2Label
            // 
            this.funds2Label.AutoSize = true;
            this.funds2Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.funds2Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funds2Label.Location = new System.Drawing.Point(0, 148);
            this.funds2Label.MinimumSize = new System.Drawing.Size(125, 2);
            this.funds2Label.Name = "funds2Label";
            this.funds2Label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.funds2Label.Size = new System.Drawing.Size(125, 27);
            this.funds2Label.TabIndex = 11;
            this.funds2Label.Text = "Funds: 100g";
            this.funds2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.player2Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2Label.Location = new System.Drawing.Point(0, 121);
            this.player2Label.MinimumSize = new System.Drawing.Size(125, 2);
            this.player2Label.Name = "player2Label";
            this.player2Label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.player2Label.Size = new System.Drawing.Size(125, 27);
            this.player2Label.TabIndex = 10;
            this.player2Label.Text = "Player2";
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endTurnButton
            // 
            this.endTurnButton.AutoSize = true;
            this.endTurnButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.endTurnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endTurnButton.Enabled = false;
            this.endTurnButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.endTurnButton.Location = new System.Drawing.Point(0, 590);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.endTurnButton.Size = new System.Drawing.Size(125, 40);
            this.endTurnButton.TabIndex = 8;
            this.endTurnButton.Text = "End turn";
            this.endTurnButton.UseVisualStyleBackColor = false;
            this.endTurnButton.Click += new System.EventHandler(this.EndTurnButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.AutoSize = true;
            this.removeButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeButton.Enabled = false;
            this.removeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.removeButton.Location = new System.Drawing.Point(0, 540);
            this.removeButton.Name = "removeButton";
            this.removeButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.removeButton.Size = new System.Drawing.Size(125, 40);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove tower";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // castle1Label
            // 
            this.castle1Label.AutoSize = true;
            this.castle1Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.castle1Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.castle1Label.Location = new System.Drawing.Point(0, 74);
            this.castle1Label.MinimumSize = new System.Drawing.Size(125, 2);
            this.castle1Label.Name = "castle1Label";
            this.castle1Label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.castle1Label.Size = new System.Drawing.Size(125, 27);
            this.castle1Label.TabIndex = 5;
            this.castle1Label.Text = "Castle: 100%";
            this.castle1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.player1Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1Label.Location = new System.Drawing.Point(0, 20);
            this.player1Label.MinimumSize = new System.Drawing.Size(125, 2);
            this.player1Label.Name = "player1Label";
            this.player1Label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.player1Label.Size = new System.Drawing.Size(125, 27);
            this.player1Label.TabIndex = 4;
            this.player1Label.Text = "Player1";
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // funds1Label
            // 
            this.funds1Label.AutoSize = true;
            this.funds1Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.funds1Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funds1Label.Location = new System.Drawing.Point(0, 47);
            this.funds1Label.MinimumSize = new System.Drawing.Size(125, 2);
            this.funds1Label.Name = "funds1Label";
            this.funds1Label.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.funds1Label.Size = new System.Drawing.Size(125, 27);
            this.funds1Label.TabIndex = 3;
            this.funds1Label.Text = "Funds: 100g";
            this.funds1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upgradeButton
            // 
            this.upgradeButton.AutoSize = true;
            this.upgradeButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.upgradeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.upgradeButton.Enabled = false;
            this.upgradeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.upgradeButton.Location = new System.Drawing.Point(0, 471);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.upgradeButton.Size = new System.Drawing.Size(125, 40);
            this.upgradeButton.TabIndex = 0;
            this.upgradeButton.Text = "Upgrade tower";
            this.upgradeButton.UseVisualStyleBackColor = false;
            this.upgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.introLabel.Location = new System.Drawing.Point(283, 121);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(467, 390);
            this.introLabel.TabIndex = 3;
            this.introLabel.Text = resources.GetString("introLabel.Text");
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldInfoLabel
            // 
            this.fieldInfoLabel.AutoSize = true;
            this.fieldInfoLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fieldInfoLabel.Location = new System.Drawing.Point(885, 19);
            this.fieldInfoLabel.Name = "fieldInfoLabel";
            this.fieldInfoLabel.Size = new System.Drawing.Size(93, 28);
            this.fieldInfoLabel.TabIndex = 2;
            this.fieldInfoLabel.Text = "Field info";
            this.fieldInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fieldInfoLabel.UseMnemonic = false;
            // 
            // fieldDataTable
            // 
            this.fieldDataTable.AllowUserToAddRows = false;
            this.fieldDataTable.AllowUserToDeleteRows = false;
            this.fieldDataTable.AllowUserToResizeColumns = false;
            this.fieldDataTable.AllowUserToResizeRows = false;
            this.fieldDataTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldDataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fieldDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldDataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerCol,
            this.TypeCol,
            this.HealthCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fieldDataTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.fieldDataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fieldDataTable.Enabled = false;
            this.fieldDataTable.GridColor = System.Drawing.SystemColors.ControlText;
            this.fieldDataTable.Location = new System.Drawing.Point(741, 51);
            this.fieldDataTable.Name = "fieldDataTable";
            this.fieldDataTable.ReadOnly = true;
            this.fieldDataTable.RowHeadersVisible = false;
            this.fieldDataTable.RowHeadersWidth = 51;
            this.fieldDataTable.RowTemplate.Height = 25;
            this.fieldDataTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fieldDataTable.Size = new System.Drawing.Size(378, 236);
            this.fieldDataTable.TabIndex = 1;
            // 
            // PlayerCol
            // 
            this.PlayerCol.HeaderText = "Player";
            this.PlayerCol.MinimumWidth = 6;
            this.PlayerCol.Name = "PlayerCol";
            this.PlayerCol.ReadOnly = true;
            this.PlayerCol.Width = 125;
            // 
            // TypeCol
            // 
            this.TypeCol.HeaderText = "Type";
            this.TypeCol.MinimumWidth = 6;
            this.TypeCol.Name = "TypeCol";
            this.TypeCol.ReadOnly = true;
            this.TypeCol.Width = 125;
            // 
            // HealthCol
            // 
            this.HealthCol.HeaderText = "Health";
            this.HealthCol.MinimumWidth = 6;
            this.HealthCol.Name = "HealthCol";
            this.HealthCol.ReadOnly = true;
            this.HealthCol.Width = 125;
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
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.statusLabel.Text = "Start a new game!";
            // 
            // GameView
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
            this.Name = "GameView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower Defense";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataTable)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button upgradeButton;
        private System.Windows.Forms.ToolStripMenuItem loadGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitGameMenuItem;
        private System.Windows.Forms.Label castle1Label;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label funds1Label;
        private System.Windows.Forms.TableLayoutPanel BoardLayout;
        private System.Windows.Forms.Button endTurnButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label funds2Label;
        private System.Windows.Forms.Label castle2Label;
        private System.Windows.Forms.Button troopButton;
        private System.Windows.Forms.Button buyTowerButton;
        private System.Windows.Forms.Button cavalryButton;
        private System.Windows.Forms.DataGridView fieldDataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HealthCol;
        private System.Windows.Forms.Label fieldInfoLabel;
        private System.Windows.Forms.Label introLabel;
    }
}

