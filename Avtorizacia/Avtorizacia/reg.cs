using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtorizacia
{
    public partial class reg : Form
    {
        LoginForm f2 = new LoginForm();
        public reg()
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
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {

            if (RegL1Text.Text=="" || RegP1Text.Text=="")
            {
                MessageBox.Show("Null login or password");
                return;
            }
            if (cheakUser())
                return;
            Bd db = new Bd();
            MySqlCommand command = new MySqlCommand("INSERT INTO  users  (  login ,  pass ) VALUES (@login, @pass);", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = RegL1Text.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = RegP1Text.Text;

            db.openConnection();


            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("All ok!");
            }
            else
            {
                MessageBox.Show("Not ok!");
            }


            db.ClozeConnection();
        }
        public Boolean cheakUser()
        {
            Bd bd = new Bd();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @uL", bd.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = RegL1Text.Text; 

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Login clozer");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            f2.Show();
        }
    }
}
