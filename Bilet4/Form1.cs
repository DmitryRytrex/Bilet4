using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            using (ConnectDB db = new ConnectDB())
            {
                DataTable dt = db.ExecuteSql($"Select * from users where login = '{login}' and password = '{password}'");
                if (dt.Rows.Count > 0)
                {
                    user.login = login;
                    FormMain main = new FormMain();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }
    }
}
