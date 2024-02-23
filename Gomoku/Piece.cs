using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku
{
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_WIDTH = 50; //棋子寬度
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;   //設置背景顏色為透明
            this.Location = new Point(x - IMAGE_WIDTH / 2, y - IMAGE_WIDTH / 2);   //取得棋子的位置，除2使他位於中間
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);  //設置棋子的大小
            
        }
        
        public abstract PieceType GetPieceType();
    }
}
