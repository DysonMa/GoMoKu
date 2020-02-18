namespace GoMoKu
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Restart = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.label_turn = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(700, 21);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(84, 35);
            this.Restart.TabIndex = 0;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(700, 62);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(84, 35);
            this.Quit.TabIndex = 1;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // label_turn
            // 
            this.label_turn.AutoSize = true;
            this.label_turn.BackColor = System.Drawing.Color.Transparent;
            this.label_turn.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_turn.Location = new System.Drawing.Point(707, 112);
            this.label_turn.Name = "label_turn";
            this.label_turn.Size = new System.Drawing.Size(72, 16);
            this.label_turn.TabIndex = 2;
            this.label_turn.Text = "黑棋先下";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeTxt
            // 
            this.timeTxt.AutoSize = true;
            this.timeTxt.BackColor = System.Drawing.Color.Transparent;
            this.timeTxt.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.timeTxt.Location = new System.Drawing.Point(12, 21);
            this.timeTxt.Name = "timeTxt";
            this.timeTxt.Size = new System.Drawing.Size(72, 16);
            this.timeTxt.TabIndex = 3;
            this.timeTxt.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GoMoKu.Properties.Resources.board;
            this.ClientSize = new System.Drawing.Size(804, 712);
            this.Controls.Add(this.timeTxt);
            this.Controls.Add(this.label_turn);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Restart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(820, 750);
            this.MinimumSize = new System.Drawing.Size(820, 726);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Label label_turn;
        private System.Windows.Forms.Label timeTxt;
        private System.Windows.Forms.Timer timer1;
    }
}

