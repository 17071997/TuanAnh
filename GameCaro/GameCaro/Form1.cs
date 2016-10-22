using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager chessboard;
        #endregion
        public Form1()
        {
           InitializeComponent();
           chessboard = new ChessBoardManager(panel1,textBox1,pictureBox2);
           chessboard.EndedGame+=chessboard_EndedGame;
           chessboard.PlayerMarked+=chessboard_PlayerMarked;

           NewGame();
        }
        #region Methods
        void EndGame()
        {
            panel1.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("FINISHED");
        }
        void NewGame()
        {
            chessboard.DrawChessBoard();
            undoToolStripMenuItem.Enabled = true;
        }
        void Undo()
        {
            chessboard.Undo();
        }
        void Quit()
        {
            Application.Exit();
        }
        private void chessboard_PlayerMarked(object sender, EventArgs e)
        {
            
        }

        private void chessboard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }
     
       
        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

 

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;

        }
        #endregion

    }
       
}
