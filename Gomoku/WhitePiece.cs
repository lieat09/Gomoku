using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class WhitePiece : Piece
    {
        public WhitePiece(int x, int y) : base(x, y)
        {
            this.Image = Gomoku.Properties.Resources.white;  //設置圖片為白棋


        }
        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;
        }
    }
}
