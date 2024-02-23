using System.Drawing.Text;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //左鍵按下後，先判斷是哪方下棋，在判斷piece是否為空值，最後放置黑棋
            Piece piece = game.PlaceAPiece(e.X, e.Y);
           
            if (piece != null )
                this.Controls.Add(piece);
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
                
            }
            else
            {
                this.Cursor= Cursors.Default;
            }
            
        }
    }
}