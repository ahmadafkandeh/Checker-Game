using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public string location;
        bool colorflag = false;
        public Pawn[] WhitePawn = new Pawn[12];
        public Pawn[] RedPawn = new Pawn[12];
        int IsInGame = 0;
        
        Microsoft.VisualBasic.PowerPacks.ShapeContainer ShapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
        Microsoft.VisualBasic.PowerPacks.RectangleShape[] square = new Microsoft.VisualBasic.PowerPacks.RectangleShape[64];
        
        public MainForm()
        {
            InitializeComponent();
        }
        private void Squar_MouseMove(object sender, MouseEventArgs e)
        {
            Microsoft.VisualBasic.PowerPacks.RectangleShape obj = (Microsoft.VisualBasic.PowerPacks.RectangleShape)sender;
            location = obj.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ShapeContainer1.Location = new System.Drawing.Point(12, 28);
            this.ShapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.ShapeContainer1.Name = "shapeContainer1";
            ShapeContainer1.Size = new System.Drawing.Size(603, 571);
            ShapeContainer1.TabIndex = 0;
            ShapeContainer1.TabStop = false;
            this.panel1.Controls.Add(this.ShapeContainer1);
            //--------------------------------------------------------------
            createSquare();
            WindowsFormsApplication1.Program.MainLocation = this.Location;
            NewGame();
        }
        private void createSquare()
        {
            for (int i = 0; i < 64; i++)
            {
                int x = 0; int y = 0;
                square[i] = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
                square[i].Name = "sq" + i.ToString();
                square[i].SendToBack();
                square[i].BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
                square[i].Enabled = false;

                square[i].Size = new Size(70, 70);
                //-----------------------------------------------------
                if (i < 8)
                { x = i; y = 0; colorflag = false; }
                else if (i < 16)
                { x = (i - 8); y = 70; colorflag = true; }
                else if (i < 24)
                { x = (i - 16); y = 140; colorflag = false; }
                else if (i < 32)
                { x = (i - 24); y = 210; colorflag = true; }
                else if (i < 40)
                { x = (i - 32); y = 280; colorflag = false; }
                else if (i < 48)
                { x = (i - 40); y = 350; colorflag = true; }
                else if (i < 56)
                { x = (i - 48); y = 420; colorflag = false; }
                else if (i < 64)
                { x = (i - 56); y = 490; colorflag = true; }
                //-----------------------------------------------------
                if (!colorflag)
                {
                    if (x % 2 == 0)
                        square[i].BackColor = Color.White;
                    else
                        square[i].BackColor = Color.Black;
                }
                else
                {
                    if (x % 2 == 0)
                        square[i].BackColor = Color.Black;
                    else
                        square[i].BackColor = Color.White;
                }
                //-----------------------------------------------------
                x = x * 70;
                //-----------------------------------------------------
                square[i].Location = new Point(x, y);
                ShapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] { square[i] });
                this.ShapeContainer1.Shapes.Add(square[i]);
            }
        }    
        private void NewGame()
        {
            RemoveOldPawns();
            IsInGame = 1;
            //Adding Red Pawn's
            for (int i = 0; i < 12; i++)
            {
                RedPawn[i] = new Pawn();
                RedPawn[i].ID = i;
                RedPawn[i].PawnColor = Color.Red;
                switch (i)
                {
                    case 0:
                        RedPawn[i].PawnShape.Location = square[40].Location;
                        break;
                    case 1:
                        RedPawn[i].PawnShape.Location = square[42].Location;
                        break;
                    case 2:
                        RedPawn[i].PawnShape.Location = square[44].Location;
                        break;
                    case 3:
                        RedPawn[i].PawnShape.Location = square[46].Location;
                        break;
                    case 4:
                        RedPawn[i].PawnShape.Location = square[49].Location;
                        break;
                    case 5:
                        RedPawn[i].PawnShape.Location = square[51].Location;
                        break;
                    case 6:
                        RedPawn[i].PawnShape.Location = square[53].Location;
                        break;
                    case 7:
                        RedPawn[i].PawnShape.Location = square[55].Location;
                        break;
                    case 8:
                        RedPawn[i].PawnShape.Location = square[56].Location;
                        break;
                    case 9:
                        RedPawn[i].PawnShape.Location = square[58].Location;
                        break;
                    case 10:
                        RedPawn[i].PawnShape.Location = square[60].Location;
                        break;
                    case 11:
                        RedPawn[i].PawnShape.Location = square[62].Location;
                        break;
                }
                RedPawn[i].PawnShape.Location = new Point(RedPawn[i].PawnShape.Location.X + 10, RedPawn[i].PawnShape.Location.Y + 10);
                this.ShapeContainer1.Shapes.Add(RedPawn[i].PawnShape);
                RedPawn[i].PawnShape.BringToFront();

            }
            for (int i = 0; i < 12; i++)
            {
                WhitePawn[i] = new Pawn();
                WhitePawn[i].ID = i;
                WhitePawn[i].PawnColor = Color.Peru ;
                switch (i)
                {
                    case 0:
                        WhitePawn[i].PawnShape.Location = square[1].Location;
                        break;
                    case 1:
                        WhitePawn[i].PawnShape.Location = square[3].Location;
                        break;
                    case 2:
                        WhitePawn[i].PawnShape.Location = square[5].Location;
                        break;
                    case 3:
                        WhitePawn[i].PawnShape.Location = square[7].Location;
                        break;
                    case 4:
                        WhitePawn[i].PawnShape.Location = square[8].Location;
                        break;
                    case 5:
                        WhitePawn[i].PawnShape.Location = square[10].Location;
                        break;
                    case 6:
                        WhitePawn[i].PawnShape.Location = square[12].Location;
                        break;
                    case 7:
                        WhitePawn[i].PawnShape.Location = square[14].Location;
                        break;
                    case 8:
                        WhitePawn[i].PawnShape.Location = square[17].Location;
                        break;
                    case 9:
                        WhitePawn[i].PawnShape.Location = square[19].Location;
                        break;
                    case 10:
                        WhitePawn[i].PawnShape.Location = square[21].Location;
                        break;
                    case 11:
                        WhitePawn[i].PawnShape.Location = square[23].Location;
                        break;
                }
                WhitePawn[i].PawnShape.Location = new Point(WhitePawn[i].PawnShape.Location.X + 10, WhitePawn[i].PawnShape.Location.Y + 10);
                this.ShapeContainer1.Shapes.Add(WhitePawn[i].PawnShape);
                WhitePawn[i].PawnShape.BringToFront();
            }
        }
        private void RemoveOldPawns()
        {
            if (IsInGame == 1)
            {
                for (int i = 0; i < 12; i++)
                    try { ShapeContainer1.Shapes.Remove(RedPawn[i].PawnShape); }
                    catch { }
                for (int i = 0; i < 12; i++)
                    try { ShapeContainer1.Shapes.Remove(WhitePawn[i].PawnShape); }
                    catch { }
            }
            IsInGame = 0;
        }
        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Program.MainLocation = this.Location;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
