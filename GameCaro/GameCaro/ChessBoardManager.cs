using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessboard;

        public Panel Chessboard
        {
            get { return chessboard; }
            set { chessboard = value; }
        }
        private List<Players> player;

        public List<Players> Player
        {
            get { return player; }
            set { player = value; }
        }
        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        private TextBox playerName;

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        private PictureBox playerMark;

        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked 
        {
            add
            {
                playerMarked+=value;   
            }
            remove
            {
                playerMarked-=value;   
            }
        }
        private event EventHandler endedGame;
        public event EventHandler EndedGame 
        {
            add
            {
               endedGame+=value;   
            }
            remove
            {
                endedGame-=value;   
            }
        }
        private Stack<PlayInfo> playTimeLine;

        internal Stack<PlayInfo> PlayTimeLine
        {
            get { return playTimeLine; }
            set { playTimeLine = value; }
        }
       
        #endregion
        #region Initialize
        


        public ChessBoardManager(Panel chessboard,TextBox playerName,PictureBox mark)
        {
            this.chessboard = chessboard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            this.player = new List<Players>() 
            {   new Players("player1", Image.FromFile(Application.StartupPath + "\\Resources\\b.png")),
                new Players("player2", Image.FromFile(Application.StartupPath + "\\Resources\\a.png"))
            };
          
        }
        #endregion
        #region Methods
        public void DrawChessBoard()
        {
            chessboard.Enabled = true;
            chessboard.Controls.Clear();

            PlayTimeLine = new Stack<PlayInfo>();

            currentPlayer = 0;

            ChangePlayer();
            Matrix = new List<List<Button>>();
            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag =i.ToString()
                    };
                    btn.Click += btn_Click;
                    chessboard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            Mark(btn);

            playTimeLine.Push(new PlayInfo(GetChessPoint(btn),CurrentPlayer));//

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if(isEndGame(btn))
            {
                EndGame();
            }

            if (playerMarked != null)
                playerMarked(this, new EventArgs());
        }
        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }
       
        public bool Undo()
        {
            if (playTimeLine.Count <= 0)
                return false;
            PlayInfo oldPoint = playTimeLine.Pop();
            Button btn = matrix[oldPoint.Point.Y][oldPoint.Point.X];
            btn.BackgroundImage = null;

            if (playTimeLine.Count <= 0)
                CurrentPlayer = 0;
            else
            {
                oldPoint = PlayTimeLine.Peek();
                CurrentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;
            }
            ChangePlayer();
            return true;
        }
        private bool isEndGameHorizontal(Button btn)// ket thuc o hang ngang
        {
            Point point = GetChessPoint(btn);
            int countLeft=0, countRight = 0;
            for (int i = point.X; i >= 0;i-- )
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            for (int i = point.X+1; i <Cons.CHESS_BOARD_WIDTH ; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }
                return countLeft + countRight == 5;
        }
        private bool isEndGameVertical(Button btn)//ket thuc o hang doc
        {
            Point point = GetChessPoint(btn);
            int countTop = 0, countBottom = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndGamePrimary(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0, countBottom = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (Matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            for (int i = 1; i < Cons.CHESS_BOARD_WIDTH-point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X + i >= Cons.CHESS_BOARD_HEIGHT)
                    break;
                if (Matrix[point.Y+i][point.X+i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndGameSub(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0, countBottom = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > Cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X - i <0)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndGame(Button btn)
        {
            return isEndGameHorizontal(btn)||isEndGameVertical(btn)||isEndGamePrimary(btn)||isEndGameSub(btn);
        }
        private Point GetChessPoint(Button btn)
        {
          
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal,vertical);
            return point;
        }
        private void Mark(Button btn)
        {
            btn.BackgroundImage = player[currentPlayer].Mark;
        }
        private void ChangePlayer()
        {
            PlayerName.Text = player[currentPlayer].Name;
            PlayerMark.Image = player[currentPlayer].Mark;
        }

       
    }
        #endregion
        
}