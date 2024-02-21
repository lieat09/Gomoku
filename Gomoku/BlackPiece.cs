using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class BlackPiece : Piece
    {
        public BlackPiece(int x, int y) : base(x, y) 
        {
            this.Image = Gomoku.Properties.Resources.black;  //設置圖片為黑棋

        }
    }
}
