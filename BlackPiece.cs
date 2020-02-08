using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMoKu
{
    class BlackPiece : Piece  //繼承Piece
    {
        public BlackPiece(int x, int y) : base(x, y)  //建構BlackPiece將x,y指定給Piece
        {
            this.Image = Properties.Resources.black;
        }

        public override PieceType GetPieceType() // 實作繼承 abstract的方法 [多型]
        {
            return PieceType.BLACK;
        }
    }
}
