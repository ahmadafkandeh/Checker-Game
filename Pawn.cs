using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Pawn:Form
    {

        private int _id;

        private string _location;
        private bool _IsKing = false;
        private Point OldLocation;
        public Microsoft.VisualBasic.PowerPacks.OvalShape PawnShape=new Microsoft.VisualBasic.PowerPacks.OvalShape();
        //Microsoft.VisualBasic.PowerPacks.OvalShape sh=new Microsoft.VisualBasic.PowerPacks.OvalShape();
        //Property
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public System.Drawing.Color PawnColor
        {
            set { PawnShape.BackColor = value; }
        }
        //constructor
        public Pawn()
        {  


            PawnShape.Size = new System.Drawing.Size(50, 50);
            PawnShape.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            PawnShape.MouseDown += new System.Windows.Forms.MouseEventHandler(PawnShape_MouseDown);
            PawnShape.MouseMove += new System.Windows.Forms.MouseEventHandler(PawnShape_MouseMove);
            PawnShape.MouseUp += new MouseEventHandler(PawnShape_MouseUp);    
            //sh.Size=PawnShape.Size;
            //sh.BackStyle = PawnShape.BackStyle;
        }
        //Event Handlers
        void PawnShape_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && WindowsFormsApplication1.Program.SelectedPawn==ID.ToString() + PawnShape.BackColor)
            {
                PawnShape.Location = new Point(System.Windows.Forms.Control.MousePosition.X-WindowsFormsApplication1.Program.MainLocation.X-50, System.Windows.Forms.Control.MousePosition.Y-WindowsFormsApplication1.Program.MainLocation.Y-90);
            }
        }
        void PawnShape_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
           // sh.BackColor=PawnShape.BackColor;
           // sh.BringToFront();
           // DoDragDrop(sh, DragDropEffects.None);
            
            WindowsFormsApplication1.Program.SelectedPawn = ID.ToString() + PawnShape.BackColor;
            OldLocation = PawnShape.Location;
            PawnShape.BringToFront();
        }   
        void PawnShape_MouseUp(object sender, MouseEventArgs e)
        {
            WindowsFormsApplication1.Program.SelectedPawn = "";
            MovePawn();
        }
        //Moving Metods
        public void MovePawn()
        {
            SetLocation();
            string[] str = _location.Split(' ');
            int x = int.Parse(str[0]);
            int y = int.Parse(str[1]);
            if ((x / 70) % 2 == 0 | x==0)
            { 
                if ((y / 70) % 2 != 0)
                    PawnShape.Location = new Point(x + 10, y + 10);
                else
                    PawnShape.Location = OldLocation;
            }
            else if ((x/70) % 2 != 0 | x==70)
            {
                if ((y / 70) % 2 == 0)
                    PawnShape.Location = new Point(x + 10, y + 10);
                else
                    PawnShape.Location = OldLocation;
            }
            else
                PawnShape.Location = OldLocation;

                if (_IsKing)
                {

                }
                else
                {
                    if (PawnShape.BackColor == Color.Red)
                        if ((x == 70 || x == 210 || x == 350 || x == 490) && y == 0)
                        {
                            PawnColor = Color.Purple;
                            _IsKing = true;
                        }
                    if (PawnShape.BackColor == Color.Peru)
                        if ((x == 0 || x == 140 || x == 280 || x == 420) && y == 490)
                        {
                            PawnColor = Color.Yellow;
                            _IsKing = true;
                        }
                }
        }
        private void SetLocation()
        {
            if (PawnShape.Location.X > 0 && PawnShape.Location.X < 70)
                _location = "0";
            else if (PawnShape.Location.X > 70 && PawnShape.Location.X < 140)
                _location = "70";
            else if (PawnShape.Location.X > 140 && PawnShape.Location.X < 210)
                _location = "140";
            else if (PawnShape.Location.X > 210 && PawnShape.Location.X < 280)
                _location = "210";
            else if (PawnShape.Location.X > 280 && PawnShape.Location.X < 350)
                _location = "280";
            else if (PawnShape.Location.X > 350 && PawnShape.Location.X < 420)
                _location = "350";
            else if (PawnShape.Location.X > 420 && PawnShape.Location.X < 490)
                _location = "420";
            else if (PawnShape.Location.X > 490 && PawnShape.Location.X < 560)
                _location = "490";
            else
                _location = OldLocation.X.ToString();

            _location += " ";
            if (PawnShape.Location.Y > 0 && PawnShape.Location.Y < 70)
                _location += "0";
            else if (PawnShape.Location.Y > 70 && PawnShape.Location.Y < 140)
                _location += "70";
            else if (PawnShape.Location.Y > 140 && PawnShape.Location.Y < 210)
                _location += "140";
            else if (PawnShape.Location.Y > 210 && PawnShape.Location.Y < 280)
                _location += "210";
            else if (PawnShape.Location.Y > 280 && PawnShape.Location.Y < 350)
                _location += "280";
            else if (PawnShape.Location.Y > 350 && PawnShape.Location.Y < 420)
                _location += "350";
            else if (PawnShape.Location.Y > 420 && PawnShape.Location.Y < 490)
                _location += "420";
            else if (PawnShape.Location.Y > 490 && PawnShape.Location.Y < 560)
                _location += "490";
            else
                _location += OldLocation.Y.ToString();
        }
    }
}
