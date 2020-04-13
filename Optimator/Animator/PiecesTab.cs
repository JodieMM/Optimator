using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// A tab used to create new pieces.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PiecesTab : UserControl
    {
        private TabPage Owner;

        public PiecesTab(TabPage owner)
        {
            InitializeComponent();
            Owner = owner;
        }

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public new void Resize()
        {
            int bigWidth = (int)(Width * 0.25);
            int bigHeight = (int)(Height * 0.4);
            int bigLength = bigWidth > bigHeight ? bigHeight : bigWidth;

            int lilWidth = (int)(Width * 0.07);
            int lilHeight = (int)(Height * 0.05);

            DrawBase.Size = DrawRight.Size = DrawDown.Size = new Size(bigWidth, bigHeight);
            DrawBase.Location = new Point(lilWidth, lilHeight + ToolStrip.Height);           
            DrawRight.Location = new Point(lilWidth * 2 + bigWidth, lilHeight + ToolStrip.Height);
            DrawDown.Location = new Point(lilWidth, lilHeight * 2 + bigHeight + ToolStrip.Height);

            Panel.Width = (int)(Width * 0.29);

            EraseRightBtn.Size = EraseDownBtn.Size = new Size((int)(bigLength * 0.1), (int)(bigLength * 0.1));
            EraseRightBtn.Location = new Point(DrawRight.Location.X + DrawRight.Size.Width -
                EraseRightBtn.Width, DrawRight.Location.Y);
            EraseDownBtn.Location = new Point(DrawDown.Location.X + DrawDown.Size.Width -
                EraseDownBtn.Width, DrawDown.Location.Y);
        }
    }
}
