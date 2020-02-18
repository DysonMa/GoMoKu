using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoMoKu
{
    public partial class Form1 : Form
    {
        private Game game = new Game();

        DateTime StartTime;
        TimeSpan TimeCount;

        public Form1()
        {
            InitializeComponent();

            timer1.Start();
            StartTime = DateTime.Now;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeCount = DateTime.Now - StartTime;
            timeTxt.Text = string.Format("{0:00}:{1:00}:{2:00}", TimeCount.Hours, TimeCount.Minutes, TimeCount.Seconds);
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)  //Event
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);

            if (piece != null)
            {
                this.Controls.Add(piece);


                //檢查是否有人獲勝
                if (game.Winner == PieceType.BLACK)
                {
                    timer1.Stop();
                    MessageBox.Show("黑色獲勝", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                    var result = MessageBox.Show("重來一場?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Application.Restart();
                    else
                        return;
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    timer1.Stop();
                    MessageBox.Show("白色獲勝", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                    var result = MessageBox.Show("重來一場?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Application.Restart();
                    else
                        return;
                }
            }

            // 顯示下一著手是誰下
            if (game.CurrentPlayer == PieceType.BLACK)
                label_turn.Text = "換黑棋下";
            else if (game.CurrentPlayer == PieceType.WHITE)
                label_turn.Text = "換白棋下";



        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (game.CanBePlaced(e.X, e.Y))
            //{
            //    this.Cursor = Cursors.Hand;
            //}
            //else
            //{
            //    this.Cursor = Cursors.Default;
            //}

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            game.Restart();
            //foreach (Control c in this.Controls)
            //{
            //    if (c != null)
            //    {
            //        this.Controls.Remove(c);
            //    }
            //}

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //return -1;
        }


    }
}
