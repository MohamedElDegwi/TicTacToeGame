using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGame.Properties;

namespace TicTacToeGame
{
    public partial class MainGame : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        {
            Player1,
            Player2
        }
        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        public MainGame()
        {
            InitializeComponent();
        }

        public void EndGame()
        {
            lblTurnVal.Text = "GAME OVER";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:

                    lblWinnerVal.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinnerVal.Text = "Player2";
                    break;

                default:

                    lblWinnerVal.Text = "Draw";
                    break;
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        }

        private void CheckWinner()
        {
            if (CheckValues(btn1, btn2, btn3))
                return;

            if (CheckValues(btn4, btn5, btn6))
                return;

            if (CheckValues(btn7, btn8, btn9))
                return;

            if (CheckValues(btn1, btn4, btn7))
                return;

            if (CheckValues(btn2, btn5, btn8))
                return;

            if (CheckValues(btn3, btn6, btn9))
                return;

            if (CheckValues(btn1, btn5, btn9))
                return;

            if (CheckValues(btn3, btn5, btn7))
                return;

        }

        private void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurnVal.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurnVal.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("This place is already taken!\nPlease try again.", "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;

            Pen pen = new Pen(White, 5);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 440, 185, 849, 185);
            e.Graphics.DrawLine(pen, 440, 325, 849, 325);
            e.Graphics.DrawLine(pen, 571, 61, 571, 449);
            e.Graphics.DrawLine(pen, 718, 61, 718, 449);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ChangeImage(btn5);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ChangeImage(btn8);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ChangeImage(btn7);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ChangeImage(btn6);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ChangeImage(btn9);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ChangeImage(btn4);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ChangeImage(btn3);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ChangeImage(btn2);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ChangeImage(btn1);
        }

        private void ResetBtn(Button btn)
        {
            btn.Image = Resources.QuestionMark;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        private void RestartGame()
        {

            ResetBtn(btn1);
            ResetBtn(btn2);
            ResetBtn(btn3);
            ResetBtn(btn4);
            ResetBtn(btn5);
            ResetBtn(btn6);
            ResetBtn(btn7);
            ResetBtn(btn8);
            ResetBtn(btn9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
