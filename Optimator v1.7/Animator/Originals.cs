using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{
    public class Originals
    {
        // Initialise Variables
        Piece piece;
        double x;
        double y;
        double r;
        double t;
        double s;
        double sm;



        public Originals(Piece piece)
        {
            this.piece = piece;
            x = piece.GetCoords()[0];
            y = piece.GetCoords()[1];
            r = piece.GetAngles()[0];
            t = piece.GetAngles()[1];
            s = piece.GetAngles()[2];
            sm = piece.GetSizeMod();
            // Colours/Outlines?
            // Attached sets etc?
        }

        // Getters

        public Piece GetPiece()
        {
            return piece;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public double GetR()
        {
            return r;
        }

        public double GetT()
        {
            return t;
        }

        public double GetS()
        {
            return s;
        }

        public double GetSM()
        {
            return sm;
        }

        public string GetSaveData()
        {
            string data = x + ";" + y + ";" + r + ";" + t + ";" + s + ";" + sm;
            return data;
        }

        // Setters

        public void SetX(double x)
        {
            this.x = x;
        }

        public void SetY(double y)
        {
            this.y = y;
        }

        public void SetR(double r)
        {
            this.r = r;
        }

        public void SetT(double t)
        {
            this.t = t;
        }

        public void SetS(double s)
        {
            this.s = s;
        }

        public void SetSM(double sm)
        {
            this.sm = sm;
        }

        // General Functions
        public Boolean IsMatch(Piece compare)
        {
            if (piece == compare)
            {
                return true;
            }
            return false;
        }
    }
}
