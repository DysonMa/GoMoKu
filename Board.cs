﻿using System;
using System.Collections.Generic;
using System.Drawing;  //才能用Point
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMoKu
{
    class Board
    {
        public static readonly int NODE_COUNT = 9; // 避免點擊超過9*9的格子外面時遇到的問題

        private static readonly int OFFSET = 75;     //常數
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1); //因為棋盤上座標都為正，負的代表不存在

        public Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];  //多維陣列

        private Point lastPieceNode = NO_MATCH_NODE;    // private: 變數首字小寫
        public Point LastPieceNode { get { return lastPieceNode; } } //public: 變數首字大寫
        // 只get不set

        public PieceType GetPieceType(int nodeIdX, int nodeIdY)  // 點選棋盤上某個座標(點)，回傳我該點的棋子顏色
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }



        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點(Node)
            Point nodeId = findTheClosetNode(x, y);

            // 如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;

            // 如果有的話，檢查棋子是否已經存在
            if (pieces[nodeId.X, nodeId.Y] != null)
                return false;

            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 找出最近的節點(Node)
            Point nodeId = findTheClosetNode(x, y);

            // 如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
                return null;

            // 如果有的話，檢查棋子是否已經存在
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;

            // 根據Type，產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            else if (type == PieceType.WHITE)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);

            // 紀錄最後下棋子的位置
            lastPieceNode = nodeId;


            return pieces[nodeId.X, nodeId.Y];

        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }





        private Point findTheClosetNode(int x, int y)
        {
            int nodeIdX = findTheClosetNode(x);
            if (nodeIdX == -1 || nodeIdX >= NODE_COUNT)
                return NO_MATCH_NODE;

            int nodeIdY = findTheClosetNode(y);
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT)
                return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY);
        }

        private int findTheClosetNode(int pos)
        {
            if (pos <= OFFSET - NODE_RADIUS)
                return -1;

            pos -= OFFSET;
            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1; //無任何點符合
        }

        public Piece Clear(int x, int y, PieceType type)
        {
            // 找出最近的節點(Node)
            Point nodeId = new Point(x, y);
            //Point nodeId = findTheClosetNode(x, y);

            // 根據Type，產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type != PieceType.NONE)
            {
                pieces[nodeId.X, nodeId.Y].Image = null;
                //pieces[nodeId.X, nodeId.Y] = picturebx;
                
                //pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            }


            //pieces = new Piece[NODE_COUNT, NODE_COUNT];



            // 找出最近的節點(Node)
            //Point nodeId = findTheClosetNode(x, y);

            // 如果沒有的話，回傳false
            //if (nodeId == NO_MATCH_NODE)
            //    return null;

            //// 如果有的話，檢查棋子是否已經存在
            //if (pieces[nodeId.X, nodeId.Y] != null)
            //    return null;

            //// 根據Type，產生對應的棋子
            ////Point formPos = convertToFormPosition(nodeId);
            //if (type == PieceType.BLACK)
            //    pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            //else if (type == PieceType.WHITE)
            //    pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);

            // 紀錄最後下棋子的位置
            //lastPieceNode = nodeId;


            return pieces[nodeId.X, nodeId.Y];

        }
    }
}
