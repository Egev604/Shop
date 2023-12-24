using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shop.Logic;
using shop.data;
using shop.Сonnection;
using System.IO;
using System.Text.RegularExpressions;
namespace shop.Forms
{
    public partial class Product : Form
    {
        int countPageNow = 1;
        int countPage = 0;
        int count = 0;
        string search = "";
        string filter = "";
        string orderBy = "";
        int rowsSelected = 0;
        int rowsNow = 0;
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            comboBox2.Items.Add("По возростанию");
            comboBox2.Items.Add("По убыванию");
            LoadDataGridView();
            ImageDataGridView();
            LoadImageDataGridView();
            foreach (string str in MySqlData.Reader("select categoryName from categoryproduct"))
            {
                comboBox1.Items.Add(str);
            }
            countPage = (int)Math.Ceiling(Convert.ToDouble(count) / 4);
            button2.Enabled = false;
            label1.Text = "1/" + countPage;
            if (Role.getRole() == 1)
            {
                ButtonDataGridView();
            }
        }
        private void ButtonDataGridView()
        {
            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Name = "Удалить";
            dataGridViewButtonColumn.Text = "Удалить";
            dataGridViewButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dataGridViewButtonColumn);
            DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2.Name = "Редактировать";
            dataGridViewButtonColumn2.Text = "Редактировать";
            dataGridViewButtonColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dataGridViewButtonColumn2);
        }
        private void ImageDataGridView()
        {
            DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
            dataGridViewImageColumn.Name = "Картинка";
            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(dataGridViewImageColumn);
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn.Name = "costHide";
            dataGridView1.Columns.Add(dataGridViewTextBoxColumn);
            dataGridView1.Columns["costHide"].Visible = false;
        }
        private void LoadImageDataGridView()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Cells["cost"].Value.ToString()!="" && row.Cells["cost"].Value.ToString() != "0")
                {
                    string cost = row.Cells["cost"].Value.ToString();
                    row.Cells["costHide"].Value = cost;
                    var sb = new StringBuilder();
                    foreach (var character in cost)
                        sb.Append(character + "\u0336");
                    double sale = (Convert.ToDouble(row.Cells["cost"].Value) * (Convert.ToDouble(row.Cells["discount"].Value.ToString()) / 100));
                    double cost2 = Math.Ceiling(Convert.ToDouble(row.Cells["cost"].Value) - sale);
                    row.Cells["cost"].Value = sb.ToString() + "\n" + cost2.ToString();
                }
                try
                {
                     using (Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\images\\" + row.Cells["image"].Value.ToString()))
                     {
                         row.Cells["Картинка"].Value = new Bitmap(image);
                     }
                }
                catch (Exception)
                {
                    using (Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\images\\picture.png"))
                    {
                        row.Cells["Картинка"].Value = new Bitmap(image);
                    }
                }
            }
        }
        public void LoadDataGridView()
        {
            dataGridView1.DataSource = MySqlData.LoadData("select articul, productName, description, (select categoryName from categoryproduct where id_categoryproduct=idCategory) as category, cost, image, (Select manufacturerName from manufacturer where id_manufacturer=idManufacturer) as manuf, discount, (Select unitName from unit where id_unit=unit) as unit, countOnStock  from product " + filter+ orderBy+ " limit 4 offset "+((countPageNow-1) * 4));
            dataGridView1.ClearSelection();
            dataGridView1.Columns["articul"].HeaderText = "Артикул";
            dataGridView1.Columns["productName"].HeaderText = "Наименование";
            dataGridView1.Columns["description"].HeaderText = "Описание";
            dataGridView1.Columns["category"].HeaderText = "Категория";
            dataGridView1.Columns["cost"].HeaderText = "Стоимость";
            dataGridView1.Columns["image"].Visible = false;
            dataGridView1.Columns["manuf"].HeaderText = "Производитель";
            dataGridView1.Columns["discount"].HeaderText = "Скидки";
            dataGridView1.Columns["discount"].Visible = false;
            dataGridView1.Columns["unit"].HeaderText = "Ед. Измерения";
            dataGridView1.Columns["productName"].Width = 200;
            dataGridView1.Columns["description"].Width = 200;
            dataGridView1.Columns["category"].Width = 150;
            dataGridView1.Columns["countOnStock"].HeaderText = "Количество на складе";
            count = Convert.ToInt32(MySqlData.StrOne("Select Count(*) from product " + search + filter + orderBy));
            label2.Text = "Общее количесвто записей:" + count;
        }
        public void LockButtonPage()
        {
            countPage = (int)Math.Ceiling(Convert.ToDouble(count) / 4);
            label1.Text = countPageNow+"/" + countPage;
            button2.Enabled = false;
            button3.Enabled = false;
            if(countPageNow!=1)
            {
                button2.Enabled = true;
            }
            if (countPageNow < countPage)
            {
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            --countPageNow;
            LockButtonPage();
            LoadDataGridView();
            LoadImageDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ++countPageNow;
            LockButtonPage();
            LoadDataGridView();
            LoadImageDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            glavnay glavnay = new glavnay();
            glavnay.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()=="Удалить")
                {
                    var result = MessageBox.Show("Вы уверены  что хотите удалить эту запись", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result==DialogResult.Yes)
                    {
                        MySqlData.Delete("Delete from product where articul="+dataGridView1.Rows[e.RowIndex].Cells["articul"].Value.ToString());
                        MessageBox.Show("Запись удалена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        countPageNow = 1;
                        LoadDataGridView();
                        LoadImageDataGridView();
                    }
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Редактировать")
                {
                    var result = MessageBox.Show("Вы уверены  что хотите редактировать эту запись", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        
                        ProductSave.articul = dataGridView1.Rows[e.RowIndex].Cells["articul"].Value.ToString();
                        ProductSave.productName = dataGridView1.Rows[e.RowIndex].Cells["productName"].Value.ToString();
                        ProductSave.description = dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();
                        ProductSave.category = dataGridView1.Rows[e.RowIndex].Cells["category"].Value.ToString();
                        ProductSave.cost = dataGridView1.Rows[e.RowIndex].Cells["costHide"].Value.ToString();
                        ProductSave.manuf = dataGridView1.Rows[e.RowIndex].Cells["manuf"].Value.ToString();
                        ProductSave.discount = dataGridView1.Rows[e.RowIndex].Cells["discount"].Value.ToString();
                        ProductSave.unit = dataGridView1.Rows[e.RowIndex].Cells["unit"].Value.ToString();
                        ProductSave.countOnStock = dataGridView1.Rows[e.RowIndex].Cells["countOnStock"].Value.ToString();
                        ProductSave.image = dataGridView1.Rows[e.RowIndex].Cells["image"].Value.ToString();
                        this.Hide();
                        ProductBD product = new ProductBD(false);
                        product.Show();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
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
                        if (row.Cells["productName"].Value.ToString().Contains(search))
                        {
                            rowsNow = rowsSelected;
                            row.Cells["productName"].Selected = true;
                            return;
                        }
                    }
                }
                else
                {
                    if (row.Cells["productName"].Value.ToString().Contains(search))
                    {
                        rowsNow = rowsSelected;
                        row.Cells["productName"].Selected = true;
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
            LoadDataGridView();
            LoadImageDataGridView();
            rowsNow = 0;
            Search();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            countPageNow = 1;
            filter = " where idCategory=(select id_categoryProduct from categoryproduct where categoryName='" + comboBox1.Text + "')";
            LoadDataGridView();
            LoadImageDataGridView();
            LockButtonPage();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            countPageNow = 1;
            if(comboBox2.Text== "По убыванию")
                orderBy = " Order by cost desc";
            else
                orderBy = " Order by cost";
            LoadDataGridView();
            LoadImageDataGridView();
            LockButtonPage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Search();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(symbol, @"[a-zA-ZА-Яа-я]|[\b]"))
                e.Handled = true;
        }
    }
}
