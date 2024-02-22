using System.Drawing.Text;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        private PieceType nextPieceType = PieceType.BLACK; //�ΨӧP�_�֪��^�X
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //������U��A���P�_�O����U�ѡA�b�P�_piece�O�_���ŭȡA�̫��m�´�
            Piece piece = board.PlaceAPiece(e.X, e.Y, nextPieceType);
            if (piece != null)
            {
                this.Controls.Add(piece);
                if (nextPieceType == PieceType.BLACK )
                {
                    nextPieceType = PieceType.WHITE;
                }
                else if (nextPieceType == PieceType.WHITE)
                {
                    nextPieceType = PieceType.BLACK;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePalced(e.X, e.Y))
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