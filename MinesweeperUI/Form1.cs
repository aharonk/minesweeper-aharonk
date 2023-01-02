using Minesweeper.Shared;

namespace MinesweeperUI
{
    public partial class Form1 : Form
    {
        private IMSModel model;
        public Form1(IMSModel model)
        {
            this.model = model;
            InitializeComponent();
            InitializeComponent2();
        }

        private void InitializeComponent2()
        {
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = model.Width;
            for (int i = 0; i < model.Width; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F / model.Width));
            }
            this.tableLayoutPanel1.RowCount = model.Height;
            for (int j = 0; j < model.Height; j++)
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));


            Button[,] buttons = new Button[model.Width,model.Height];
            for (int i = 0; i < model.Width; i++)
                for (int j = 0; j < model.Height; j++)
                {
                    buttons[i, j] = new Button();
                    this.tableLayoutPanel1.Controls.Add(buttons[i, j], i, j);

                    buttons[i,j].Dock = System.Windows.Forms.DockStyle.Fill;
                    buttons[i,j].Location = new System.Drawing.Point(3, 3);
                    buttons[i,j].Name = "button1";
                    buttons[i,j].Size = new System.Drawing.Size(319, 534);
                    buttons[i,j].TabIndex = 0;
                    buttons[i,j].Text = "button1";
                    buttons[i,j].UseVisualStyleBackColor = true;
                    buttons[i,j].Click += new System.EventHandler(button_Click);
                    buttons[i, j].Tag = new Point(i, j);
                }

            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);




        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var p = (Point)b.Tag;
            model.OpenCell(p.X, p.Y);
            b.Text = p.ToString();
        }
    }
}