using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //PictureBox需要using這個才能被繼承
using System.Drawing;  // 才能使用color這個類別

namespace GoMoKu
{
    abstract class Piece : PictureBox   //abstract避免其他程式設計師直接new Piece這個物件 
    {
        private static readonly int IMAGE_WIDTH = 50; //建立常數
        public Piece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - IMAGE_WIDTH / 2, y - IMAGE_WIDTH / 2); //點擊時放在物件中點
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
        }

        public abstract PieceType GetPieceType();
        // 建立抽象方法以供繼承修改
        // 多型[同一個method，根據每個物件作法不同而引發不同的效果]

    }
}
