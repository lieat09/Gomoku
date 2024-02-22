using System.Drawing.Text;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        private bool isBlack = true; //�ΨӧP�_�֪��^�X
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isBlack)
            {

                this.Controls.Add(new BlackPiece(e.X, e.Y)); //������U���m�´�
                isBlack = false;
            }
            else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y)); //��m�մ�
                isBlack = true;
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