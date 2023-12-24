using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shop.Сonnection;
using shop.Forms;
using shop.Logic;
using System.Threading;
namespace shop
{
    public partial class autorization : Form
    {
        string capthaa = "";
        int count = 10;
        public autorization()
        {
            InitializeComponent();
        }
        private void entry_Click(object sender, EventArgs e)
        {
            auto auto = new auto();
            auto.login = login.Text;
            auto.pwd = passwd.Text;
            string result = MySqlData.StrOne(string.Format("select role from users where login='{0}' and passwd='{1}'", auto.login, auto.pwd));
            if (result!="")
            {
                MessageBoxShow("Успешный вход");
                Role.setRole(Convert.ToInt32(result));
                Jump();
                return;
            }
            else
                MessageBoxShow("Неверный логин или пароль");
            MessageBoxShow("Для следующего входа необходимо ввести капчу");
            Lock(false);
            Captha.Visible = true;
            capthaVis.Text = GenerateText.Generate(false);
            var sb = new StringBuilder();
            foreach (var character in capthaVis.Text)
                sb.Append(character + "\u0336");
            capthaa = capthaVis.Text;
            capthaVis.Text = sb.ToString();
            capthaText.Text = "";
            login.Clear();
            passwd.Clear();
        }
        
        private void Lock(bool lockk)
        {
            login.Enabled = lockk;
            passwd.Enabled = lockk;
            entry.Enabled = lockk;
        }
        private void MessageBoxShow(string query)
        {
            MessageBox.Show(""+query, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Jump()
        {
            this.Hide();
            glavnay glavnay = new glavnay();
            glavnay.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void entryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Role.setRole(-1);
            Jump();
        }

        private void autorization_Load(object sender, EventArgs e)
        {
            Captha.Visible = false;
        }

        private void CapthaTrue_Click(object sender, EventArgs e)
        {
            if(capthaText.Text==capthaa)
            {
                MessageBoxShow("Успешный ввод капчи");
                Captha.Visible = false;
                Lock(true);
            }
            else
            {
                MessageBoxShow("Неверный ввод. Попробуйте еще разок");
                Captha.Enabled = false;
                entryLink.Enabled = false;
                count = 10;
                timer1.Start();
                timer1.Interval = 1000;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CapthaTrue.Text = count.ToString();
            if (count==0)
            {
                timer1.Stop();
                CapthaTrue.Text = "Проверить";
                capthaVis.Text = GenerateText.Generate(false);
                var sb = new StringBuilder();
                foreach (var character in capthaVis.Text)
                    sb.Append(character + "\u0336");
                capthaVis.Text = sb.ToString();
                capthaa = capthaVis.Text;
                capthaText.Text = "";
                Captha.Enabled = true;
                entryLink.Enabled = true;
                return;
            }
            count--;
        }
    }
}
