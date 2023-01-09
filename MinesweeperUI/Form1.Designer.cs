namespace MinesweeperUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHard = new System.Windows.Forms.ToolStripMenuItem();
            this.flagChar = new System.Windows.Forms.ToolStripTextBox();
            this.bombsRemaining = new System.Windows.Forms.ToolStripTextBox();
            this.timeChar = new System.Windows.Forms.ToolStripTextBox();
            this.timeElapsed = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 229F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(151, 227);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 133);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.flagChar,
            this.bombsRemaining,
            this.timeChar,
            this.timeElapsed});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(914, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEasy,
            this.menuItemMedium,
            this.menuItemHard});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // menuItemEasy
            // 
            this.menuItemEasy.Name = "menuItemEasy";
            this.menuItemEasy.Size = new System.Drawing.Size(224, 26);
            this.menuItemEasy.Text = "Easy";
            this.menuItemEasy.Click += new System.EventHandler(this.DifficultyClick);
            // 
            // menuItemMedium
            // 
            this.menuItemMedium.Name = "menuItemMedium";
            this.menuItemMedium.Size = new System.Drawing.Size(224, 26);
            this.menuItemMedium.Text = "Medium";
            this.menuItemMedium.Click += new System.EventHandler(this.DifficultyClick);
            // 
            // menuItemHard
            // 
            this.menuItemHard.Name = "menuItemHard";
            this.menuItemHard.Size = new System.Drawing.Size(224, 26);
            this.menuItemHard.Text = "Hard";
            this.menuItemHard.Click += new System.EventHandler(this.DifficultyClick);
            // 
            // flagChar
            // 
            this.flagChar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flagChar.Enabled = false;
            this.flagChar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.flagChar.Margin = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.flagChar.Name = "flagChar";
            this.flagChar.ReadOnly = true;
            this.flagChar.Size = new System.Drawing.Size(23, 27);
            this.flagChar.Text = "🚩";
            // 
            // bombsRemaining
            // 
            this.bombsRemaining.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bombsRemaining.Enabled = false;
            this.bombsRemaining.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.bombsRemaining.Name = "bombsRemaining";
            this.bombsRemaining.ReadOnly = true;
            this.bombsRemaining.Size = new System.Drawing.Size(114, 27);
            this.bombsRemaining.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timeChar
            // 
            this.timeChar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeChar.Enabled = false;
            this.timeChar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeChar.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.timeChar.Name = "timeChar";
            this.timeChar.ReadOnly = true;
            this.timeChar.Size = new System.Drawing.Size(22, 27);
            this.timeChar.Text = "⏱";
            // 
            // timeElapsed
            // 
            this.timeElapsed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeElapsed.Enabled = false;
            this.timeElapsed.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.ReadOnly = true;
            this.timeElapsed.Size = new System.Drawing.Size(114, 27);
            this.timeElapsed.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewGameShortcut);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem menuItemEasy;
        private ToolStripMenuItem menuItemMedium;
        private ToolStripMenuItem menuItemHard;
        private ToolStripMenuItem menuItemCustom;
        private ToolStripTextBox bombsRemaining;
        private ToolStripTextBox timeElapsed;
        private ToolStripTextBox flagChar;
        private ToolStripTextBox timeChar;
        private ToolStripMenuItem menuItemSave;
        private ToolStripMenuItem menuItemSaveAs;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem menuItemOpen;
        private ToolStripSeparator toolStripSeparator1;
    }
}