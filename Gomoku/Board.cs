using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1); //表示沒有結點
        private static readonly int OFFSET = 75; //棋盤邊緣到內部的距離
        private static readonly int NODE_RADIUS = 10; //節點半徑
        private static readonly int NODE_DISTANCE = 75; //節點之間的距離
        public bool CanBePalced(int x, int y)
        {
            //TODO : 找出最近的節點(Node)
            Point nodeId = FindTheClosestNode(x, y);
            //TODO : 如果沒有回傳FALSE
            if (nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            //TODO : 如果有，判斷有沒有棋子存在
            else
            {
                return true;
            }
        }

        private Point FindTheClosestNode(int x, int y)
        {
            //TODO : (x - offset) % distance = quotient 利用計算得到的商數判斷左邊節點的位置、餘數判斷有無接近節點的半徑Node_R
            int nodeIdX = FindTheClosestNode(x);
            int nodeIdY = FindTheClosestNode(y);

            if (nodeIdX == -1)
            {
                return NO_MATCH_NODE;
            }
            if (nodeIdY == -1) 
            {
                return NO_MATCH_NODE;
            }
            return new Point(nodeIdX, nodeIdY);
            
        }

        private int FindTheClosestNode(int pos) //將問題轉換成一維
        {
            if (pos < OFFSET - NODE_RADIUS)
            {
                return -1;
            }
            else if (pos > OFFSET + NODE_DISTANCE * 8)
            {
                return -1;
            }    
            pos -= OFFSET;
            int quotient = pos / NODE_RADIUS; //商數
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
