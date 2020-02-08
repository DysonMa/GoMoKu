using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMoKu
{
    class Game // 用game這個類別重構(把所有相關的方法封裝)
    {
        private Board board = new Board();
        private PieceType currentPlayer = PieceType.BLACK;
        private PieceType winner = PieceType.NONE;
        public PieceType Winner { get { return winner; } }


        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }


        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                // 檢查是否現在下棋的人獲勝
                CheckWinner();

                // 交換選手
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;

                return piece;
            }

            return null;
        }

        private void CheckWinner()
        {
            int centerX = board.LastPieceNode.X;
            int centerY = board.LastPieceNode.Y;

            // 檢查八個不同方向
            //int countAll = 1;
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                int countAll = 1;
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    // 排除中間的情況
                    if (xDir == 0 && yDir == 0)
                        continue; // 略過迴圈剩下的部分，直接跳到下次迴圈開始


                    // 紀錄現在看到幾顆相同的棋子
                    // 用for迴圈強制執行五次，在下的棋子四周5x5的範圍內去計算各個方向有沒有符合加總5顆
                    for (int count = 1; count < 5; count++)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        // 檢查顏色是否相同
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            continue;


                        countAll++;
                    }

                    // 檢查是否看到加總五顆棋子
                    if (countAll == 5)
                        winner = currentPlayer;
                }

            }
        }

        public void Restart()
        {
            for (int i =1; i < board.pieces.GetLength(0);i++)
            {
                for (int j = 1; j < board.pieces.GetLength(1); j++)
                {
                    board.Clear(i, j, board.GetPieceType(i, j));
                }

            }
        }
    }
}
