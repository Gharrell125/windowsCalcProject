namespace windowsCalcProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Solver solver = new Solver();

        private void PosOrNeg_Click(object sender, EventArgs e)
        {
            Input.Text += "-";
            solver.Accumulate("-");
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            Input.Text += "0";
            solver.Accumulate("0");
        }

        private void One_Click(object sender, EventArgs e)
        {
            Input.Text += "1";
            solver.Accumulate("1");
        }

        private void Two_Click(object sender, EventArgs e)
        {
            Input.Text += "2";
            solver.Accumulate("2");
        }

        private void Three_Click(object sender, EventArgs e)
        {
            Input.Text += "3";
            solver.Accumulate("3");
        }

        private void Four_Click(object sender, EventArgs e)
        {
            Input.Text += "4";
            solver.Accumulate("4");
        }

        private void Five_Click(object sender, EventArgs e)
        {
            Input.Text += "5";
            solver.Accumulate("5");
        }

        private void Six_Click(object sender, EventArgs e)
        {
            Input.Text += "6";
            solver.Accumulate("6");
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            Input.Text += "7";
            solver.Accumulate("7");
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            Input.Text += "8";
            solver.Accumulate("8");
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            Input.Text += "9";
            solver.Accumulate("9");
        }

        private void Decimal_Click(object sender, EventArgs e)
        {
            Input.Text += ".";
            solver.Accumulate(".");
        }

        private void Mod_Click(object sender, EventArgs e)
        {
            Input.Text += "%";
            solver.Accumulate("%");
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            Input.Text += "/";
            solver.Accumulate("/");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Input.Text += "+";
            solver.Accumulate("+");
        }

        private void Subtract_Click(object sender, EventArgs e)
        {
            Input.Text += "-";
            solver.Accumulate("-");
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            Input.Text += "*";
            solver.Accumulate("*");


        }

        private void AC_Click(object sender, EventArgs e)
        {
            Input.Text = string.Empty;
            Output.Text = string.Empty;

            solver.Clear();
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            Output.Text = solver.Solve().ToString();
        }
    }
}