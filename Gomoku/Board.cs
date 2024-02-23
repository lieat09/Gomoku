using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class Board
    {
        private static readonly int NODE_COUNT = 9; //棋盤格數

        private static readonly Point NO_MATCH_NODE = new Point(-1, -1); //表示沒有結點


        private static readonly int OFFSET = 75; //棋盤邊緣到內部的距離
        private static readonly int NODE_RADIUS = 10; //節點半徑
        private static readonly int NODE_DISTANCE = 75; //節點之間的距離

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT]; 

        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
            {
                return PieceType.NONE;
            }
            else
            {
                return pieces[nodeIdX, nodeIdY].GetPieceType();

            }
        }

        public bool CanBePalced(int x, int y)  //判斷能不能放棋子
        {
            // 找出最近的節點(Node)
            Point nodeId = findTheClosestNode(x, y);
            // 如果沒有回傳FALSE
            if (nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            // 如果有，判斷有沒有棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return false;
            }
            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type) //用來鎖定座標放棋子
        {
            //找出最近的節點(Node)
            Point nodeId = findTheClosestNode(x, y);
            //如果沒有回傳FALSE
            if (nodeId == NO_MATCH_NODE)
            {
                return null;
            }

            //如果有，判斷有沒有棋子存在
            if (pieces[nodeId.X,nodeId.Y] != null)
            {
                return null;
            }

            //根據type產生對應的棋子
            Point formPosition = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
            {

                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPosition.X, formPosition.Y);
               
            }
            else if (type == PieceType.WHITE)
            {

                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPosition.X, formPosition.Y);
    
            }

            return pieces[nodeId.X, nodeId.Y];

        }

        private Point convertToFormPosition(Point nodeId) //將座標轉換為螢幕上的座標
        {
            Point formPosition = new Point();
            formPosition.X = OFFSET + nodeId.X * NODE_DISTANCE;
            formPosition.Y = OFFSET + nodeId.Y * NODE_DISTANCE;
            return formPosition;
        }

        private Point findTheClosestNode(int x, int y)
        {
            //(x - offset) % distance = quotient 利用計算得到的商數判斷左邊節點的位置、餘數判斷有無接近節點的半徑Node_R
            int nodeIdX = findTheClosestNode(x);
            if (nodeIdX == -1 || nodeIdX >= NODE_COUNT)
            {
                return NO_MATCH_NODE;
            }

            int nodeIdY = findTheClosestNode(y);
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT) 
            {
                return NO_MATCH_NODE;
            }
        
            return new Point(nodeIdX, nodeIdY);
            
        }

        private int findTheClosestNode(int pos) //將問題轉換成一維
        {
            if (pos < OFFSET - NODE_RADIUS)
            {
                return -1;
            }
        
            pos -= OFFSET;
            int quotient = pos / NODE_DISTANCE; //商數
            int remainder = pos % NODE_DISTANCE;  //餘數

            if (remainder <= NODE_RADIUS) //判斷位置是不是位於左邊節點半徑內
            {
                return quotient; //靠近左邊節點
            }
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)  //判斷位置是不是位於左邊節點到右邊節點半徑間的距離外
            {
                return quotient + 1; //靠近右邊節點
            }
            else
            {
                return -1; //表示沒有符合的節點
            }
        }
    }
}
