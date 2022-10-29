using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtorizacia
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
             
        }

        private void closeBB_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeBB_MouseEnter(object sender, EventArgs e)
        {
            closeBB.ForeColor = Color.Red;
        }

        private void closeBB_MouseLeave(object sender, EventArgs e)
        {
            closeBB.ForeColor = Color.Black;
        }
        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X,e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginUser = LogText.Text;
            string passinUser =RegText.Text;

            Bd bd = new Bd();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @uL AND pass = @uP", bd.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passinUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count >0)
                MessageBox.Show("Yes");
            else 
                MessageBox.Show("No" );
        }
        reg f2 = new reg();
        private void Regist_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2.Show(); 
        }
    }
}
