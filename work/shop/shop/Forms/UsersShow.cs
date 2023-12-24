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
namespace shop.Forms
{
    public partial class UsersShow : Form
    {
        int countPageNow = 1;
        int countPage = 0;
        int count = 0;
        string search = "";
        string filter = "";
        string orderBy = "";
        int rowsSelected = 0;
        int rowsNow = 0;
        int code=0;
        int code2 = 0;
        public UsersShow()
        {
            InitializeComponent();
        }
        public UsersShow(string pk)
        {
            InitializeComponent();
            code2 = Convert.ToInt32(pk);
        }

        private void UsersShow_Load(object sender, EventArgs e)
        {
            if(code2==0)
                orderBy = " Order by id_users desc";
            else
                orderBy = " Order by ";
            AddTextDataGridView();
            LoadDataGrid();
            ButtonDataGridView();
            dataGridView1.ClearSelection();
            comboBox2.Items.Add("По возростанию");
            comboBox2.Items.Add("По убыванию");
            comboBox1.Items.Add("Администратор");
            comboBox1.Items.Add("Клиент");
            comboBox1.Items.Add("Менеджер");
            countPage = (int)Math.Ceiling(Convert.ToDouble(count) / 15);
            button2.Enabled = false;
            label1.Text = "1/" + countPage;
        }
        private void AddTextDataGridView()
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn.Name = "nameOsn";
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2.Name = "middleOsn";
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3.Name = "phoneOsn";
            dataGridView1.Columns.Add(dataGridViewTextBoxColumn);
            dataGridView1.Columns.Add(dataGridViewTextBoxColumn2);
            dataGridView1.Columns.Add(dataGridViewTextBoxColumn3);
            dataGridView1.Columns["nameOsn"].Visible = false;
            dataGridView1.Columns["middleOsn"].Visible = false;
            dataGridView1.Columns["phoneOsn"].Visible = false;

        }
        private void Search()
        {
            rowsSelected = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.ClearSelection();
                rowsSelected++;
                if (rowsNow != 0)
                {
                    if (rowsNow < rowsSelected)
                    {
                        if (row.Cells["surname"].Value.ToString().Contains(search))
                        {
                            rowsNow = rowsSelected;
                            row.Cells["surname"].Selected = true;
                            return;
                        }
                    }
                }
                else
                {
                    if (row.Cells["surname"].Value.ToString().Contains(search))
                    {
                        rowsNow = rowsSelected;
                        row.Cells["surname"].Selected = true;
                        return;
                    }
                }

            }
            if (countPage == countPageNow)
            {
                countPageNow = 0;
            }
            ++countPageNow;
            LockButtonPage();
            LoadDataGrid();
            rowsNow = 0;
            Search();
        }
        public void LoadDataGrid()
        {
            if (code2 == 0)
                dataGridView1.DataSource = MySqlData.LoadData("select id_users, surname, name,middle_name,login,passwd,date_of_birhday,number_phone,(select roleName from role where id_role=role) as role from users " + filter + orderBy + " limit 15 offset " + ((countPageNow - 1) * 15));
            else
            {
                dataGridView1.DataSource = MySqlData.LoadData("select id_users, surname, name,middle_name,login,passwd,date_of_birhday,number_phone,(select roleName from role where id_role=role) as role from users " + filter + orderBy + " case when id_users=" + code2 + " then 1 else 2 End, id_users desc limit 15 offset " + ((countPageNow - 1) * 15));
                code2 = 0;
                orderBy = " Order by id_users desc ";
            }
            dataGridView1.ClearSelection();
            dataGridView1.Columns["id_users"].Visible = false;
            dataGridView1.Columns["surname"].HeaderText = "Фамилия";
            dataGridView1.Columns["name"].HeaderText = "Имя";
            dataGridView1.Columns["middle_name"].HeaderText = "Отчетство";
            dataGridView1.Columns["login"].Visible = false;
            dataGridView1.Columns["passwd"].Visible = false;
            dataGridView1.Columns["number_phone"].HeaderText = "Телефон";
            dataGridView1.Columns["date_of_birhday"].HeaderText = "Дата рождения";
            dataGridView1.Columns["role"].HeaderText = "Роль";
            count = Convert.ToInt32(MySqlData.StrOne("Select Count(*) from users " +filter));
            label2.Text = "Общее количесвто записей:" + count;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Role.getRole() == 1)
                {
                    row.Cells["nameOsn"].Value = row.Cells["name"].Value.ToString();
                    row.Cells["middleOsn"].Value = row.Cells["middle_name"].Value.ToString();
                    row.Cells["phoneOsn"].Value = row.Cells["number_phone"].Value.ToString();
                }
                row.Cells["name"].Value = row.Cells["name"].Value.ToString()[0] + "****";
                if (row.Cells["middle_name"].Value.ToString() != "")
                {
                    row.Cells["middle_name"].Value = row.Cells["middle_name"].Value.ToString()[0] + "****";
                }
                if (row.Cells["number_phone"].Value.ToString() != "")
                {
                    try
                    {
                        if (row.Cells["number_phone"].Value.ToString().Split(' ')[1] != "")
                        {
                            row.Cells["number_phone"].Value = row.Cells["number_phone"].Value.ToString().Substring(0, 11) + " **-**";
                        }
                    }
                    catch
                    {
                        row.Cells["number_phone"].Value = row.Cells["number_phone"].Value.ToString().Substring(0, 10) + " **-**";
                    }
                }
            }
        }
        private void ButtonDataGridView()
        {
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Удалить";
            dataGridViewButtonColumn.Text = "Удалить";
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dataGridViewButtonColumn);
            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.Name = "Редактировать";
            dataGridViewButtonColumn2.Text = "Редактировать";
            dataGridViewButtonColumn2.Width = 32;
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dataGridViewButtonColumn2);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                code = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_users"].Value.ToString());
            }
            catch (Exception)
            {
                return;
                throw;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Удалить")
            {
                var result = MessageBox.Show("Вы действительно хотите удалить эту запись", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    MySqlData.Delete("Delete from users where id_users=" + code);
                    LoadDataGrid();
                }
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Редактировать")
            {
                var result = MessageBox.Show("Вы действительно хотите редактировать эту запись", "Редактирование", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    users.surname = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                    users.name = dataGridView1.Rows[e.RowIndex].Cells["nameOsn"].Value.ToString();
                    users.middleName = dataGridView1.Rows[e.RowIndex].Cells["middleOsn"].Value.ToString();
                    users.numberPhone = dataGridView1.Rows[e.RowIndex].Cells["phoneOsn"].Value.ToString();
                    users.login = dataGridView1.Rows[e.RowIndex].Cells["login"].Value.ToString();
                    users.pwd = dataGridView1.Rows[e.RowIndex].Cells["passwd"].Value.ToString();
                    users.dateOfBirhday = dataGridView1.Rows[e.RowIndex].Cells["date_of_birhday"].Value.ToString();
                    users.role = dataGridView1.Rows[e.RowIndex].Cells["role"].Value.ToString();
                    users.idUsers = dataGridView1.Rows[e.RowIndex].Cells["id_users"].Value.ToString();
                    this.Hide();
                    Users userss = new Users(true, users.idUsers);
                    userss.Show();
                }
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            glavnay glavnay = new glavnay();
            glavnay.Show();
        }
        public void LockButtonPage()
        {
            countPage = (int)Math.Ceiling(Convert.ToDouble(count) / 15);
            label1.Text = countPageNow + "/" + countPage;
            button2.Enabled = false;
            button3.Enabled = false;
            if (countPageNow != 1)
            {
                button2.Enabled = true;
            }
            if (countPageNow < countPage)
            {
                button3.Enabled = true;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            countPageNow = 1;
            filter = " where role=(select id_role from role where roleName='" + comboBox1.Text + "')";
            LoadDataGrid();
            LockButtonPage();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            countPageNow = 1;
            if (comboBox2.Text == "По убыванию")
                orderBy = " Order by surname desc";
            else
                orderBy = " Order by surname";
            LoadDataGrid();
            LockButtonPage();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 0)
            {
                button4.Visible = true;
                search = textBox1.Text;
                Search();
            }
            else
            {
                search = "";
                button4.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            --countPageNow;
            LockButtonPage();
            LoadDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ++countPageNow;
            LockButtonPage();
            LoadDataGrid();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
