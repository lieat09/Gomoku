namespace Gomoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Controls.Add(new BlackPiece(10, 20));
            this.Controls.Add(new WhitePiece(80, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}