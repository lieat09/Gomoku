using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class Game
    {
        private Board board = new Board();
        private PieceType currentPlayer = PieceType.BLACK; //用來判斷誰的回合

        public bool CanBePlaced (int x, int y)
        {
            return board.CanBePalced (x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece =  board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                if (currentPlayer == PieceType.BLACK)
                {
                    currentPlayer = PieceType.WHITE;
                }
                else if (currentPlayer == PieceType.WHITE)
                {
                    currentPlayer = PieceType.BLACK;
                }
                return piece;

            }
            return null;
            
        }

        public void CheckWinner()
        {


        }
    }
}
