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
using shop.Logic;
using shop.data;
using System.Text.RegularExpressions;
namespace shop.Forms
{
    public partial class Users : Form
    {
        bool checkc;
        int code = 0;
        public Users(bool check, string codee)
        {
            code = Convert.ToInt32(codee);
            checkc = check;
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            if(checkc)
            {
                insert.Visible = false;
            }
            else
            {
                update.Visible = false;
            }
            foreach(string str in MySqlData.Reader("select roleName from role"))
            {
                role.Items.Add(str);
            }
            dateOfBit.CustomFormat = "' '";
            if(checkc)
            {
                surname.Text = users.surname;
                name.Text = users.name;
                if(users.middleName!="" && users.middleName!=null)
                    midleName.Text = users.middleName;
                login.Text = users.login;
                pwd.Text = users.pwd;
                if(users.dateOfBirhday != "" && users.dateOfBirhday != null)
                    dateOfBit.Text = users.dateOfBirhday;
                if (users.numberPhone != "" && users.numberPhone != null)
                    phone.Text = users.numberPhone;
                role.Text = users.role;
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            login.Text = GenerateText.Generate(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pwd.Text = GenerateText.Generate(false);
        }

        private void insert_Click(object sender, EventArgs e)
        {

            if(surname.Text=="" || name.Text=="" || login.Text==""||pwd.Text=="" || role.Text=="")
            {
                MessageBox.Show("Поля не заполнены", "Информация");
                return;
            }
            string phonee = "";
            if(phone.Text.Replace(" ", "").Length!=15)
                phonee = "";
            else
                phonee = phone.Text;
            string date = "";
            if(dateOfBit.Text==" ")
            {
                date = "";
            }
            else
            {
                date = dateOfBit.Value.ToString("yyyy-MM-dd");
            }
            MySqlData.Delete(string.Format(@"Insert into users (surname, users.name, middle_name, login, passwd, date_of_birhday, number_phone, role) 
                                                                                values('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}', (select id_role from role where roleName='{7}'))", surname.Text, name.Text,midleName.Text, login.Text, pwd.Text, date, phonee, role.Text));
            ClearText();
        }
        private void ClearText()
        {
            surname.Clear();
            name.Clear();
            midleName.Clear();
            login.Clear();
            pwd.Clear();
            phone.Clear();
            role.SelectedIndex = -1;
            dateOfBit.Format = DateTimePickerFormat.Custom;
            dateOfBit.CustomFormat = "' '";
        }


        private void update_Click(object sender, EventArgs e)
        {
            if (surname.Text == "" || name.Text == "" || login.Text == "" || pwd.Text == "" || role.Text == "")
            {
                MessageBox.Show("Поля не заполнены", "Информация");
                return;
            }
            string phonee = "";
            if (phone.Text.Replace(" ", "").Length != 16)
                phonee = "";
            else
                phonee = phone.Text;
            string date = "";
            if (dateOfBit.Text == " ")
            {
                date = "";
            }
            else
            {
                date = dateOfBit.Value.ToString("yyyy-MM-dd");
            }
            MySqlData.Delete(string.Format(@"update users Set surname='{0}',name='{1}',middle_name='{2}',login='{3}', passwd='{4}', date_of_birhday='{5}', number_phone='{6}', role=(select id_role from role where roleName='{7}') where id_users={8}", surname.Text, name.Text, midleName.Text, login.Text, pwd.Text, date, phonee, role.Text, code));
            ClearText();
            this.Hide();
            UsersShow usersShow = new UsersShow(code.ToString());
            usersShow.Show();
        }

        private void dateOfBit_ValueChanged(object sender, EventArgs e)
        {
            dateOfBit.CustomFormat = "yyyy-MM-dd";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            glavnay glavnay = new glavnay();
            glavnay.Show();
        }

        private void surname_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(symbol, @"[а-яА-ЯA-Za-z]|[\b]"))
                e.Handled = true;
        }
    }
}
