using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shop.data;
using System.IO;
using shop.Сonnection;
using System.Threading;
using System.Text.RegularExpressions;
namespace shop.Forms
{
    public partial class ProductBD : Form
    {
        bool checkc;
        string pathImage = "";
        string code = "";
        public ProductBD(bool check)
        {
            checkc = check;
            InitializeComponent();
            
        }

        private void ProductBD_Load(object sender, EventArgs e)
        {
            
            button2.Visible = false;
            button3.Visible = false;
            if (checkc)
            {
                button2.Visible = true;
            }
            else
            {
                code = ProductSave.articul;
                button3.Visible = true;
            }
            comboBox1.Items.AddRange(MySqlData.Reader("select categoryName from categoryproduct"));
            comboBox2.Items.AddRange(MySqlData.Reader("select manufacturerName from manufacturer"));
            comboBox3.Items.AddRange(MySqlData.Reader("select unitName from unit"));
            textBox1.Text = ProductSave.articul;
            textBox2.Text = ProductSave.productName;
            textBox3.Text = ProductSave.description;
            comboBox1.Text = ProductSave.category;
            textBox4.Text = ProductSave.cost;
            comboBox2.Text = ProductSave.manuf;
            textBox5.Text = ProductSave.discount;
            comboBox3.Text = ProductSave.unit;
            textBox6.Text = ProductSave.countOnStock;
            try
            {
                using (Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\images\\" + ProductSave.image))
                {
                    pictureBox1.Image = new Bitmap(image);
                }
            }
            catch (Exception)
            {
                using (Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\images\\picture.png"))
                {
                    pictureBox1.Image = new Bitmap(image);
                }
            }
        }
        public void CheckText()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox6.Text == "" || textBox5.Text == "")
                MessageBox.Show("У вас заполнены еще не все поля", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (checkc)
            {
                this.Hide();
                glavnay glavnay = new glavnay();
                glavnay.Show();
            }
            else
            {
                this.Hide();
                Product product = new Product();
                product.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckText();
            if(MySqlData.Delete(string.Format("Insert into product (articul, productName, description, idCategory, cost, image,idManufacturer,discount,unit,countOnStock) values({0},'{1}', '{2}',(select id_categoryProduct from categoryproduct where categoryName='{3}'), {4}, '{5}',(select id_manufacturer from manufacturer where manufacturerName='{6}'), {7}, (select id_unit from unit where unitName='{8}'), {9})", textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text, textBox1.Text + "." + ProductSave.image.Split('.')[ProductSave.image.Split('.').Length - 1], comboBox2.Text, textBox5.Text,comboBox3.Text,textBox6.Text)));
            {
                openFileDialog1.Dispose();
                pictureBox1.Dispose();
                if (ProductSave.image != "")
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\\images\\" + textBox1.Text + "." + ProductSave.image.Split('.')[1]))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + @"\\images\\" + textBox1.Text + "." + ProductSave.image.Split('.')[1]);
                    }
                    File.Copy(pathImage + @"\\" + ProductSave.image, Directory.GetCurrentDirectory() + @"\\images\\" + textBox1.Text + "." + ProductSave.image.Split('.')[1] + "");
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Clear();
            comboBox2.SelectedIndex = -1;
            textBox5.Clear();
            comboBox3.SelectedIndex = -1;
            textBox6.Clear();
            using (Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\images\\picture.png"))
            {
                pictureBox1.Image = new Bitmap(image);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog1.InitialDirectory = @"d\\";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pathImage= Path.GetDirectoryName(openFileDialog1.FileName);
                ProductSave.image = openFileDialog1.SafeFileName;
                using (Image image = Image.FromFile(pathImage + @"\\" + ProductSave.image))
                {
                    pictureBox1.Image = new Bitmap(image);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckText();
            if (MySqlData.Delete(string.Format("Update product set articul={0}, productName='{1}', description='{2}', idCategory=(select id_categoryProduct from categoryproduct where categoryName='{3}'), cost={4}, image='{5}',idManufacturer=(select id_manufacturer from manufacturer where manufacturerName='{6}'),discount={7},unit=(select id_unit from unit where unitName='{8}'), countOnStock={9} where articul={10}", textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text, textBox1.Text + "." + ProductSave.image.Split('.')[ProductSave.image.Split('.').Length-1], comboBox2.Text, textBox5.Text, comboBox3.Text, textBox6.Text, code)))
            {
                openFileDialog1.Dispose();
                pictureBox1.Dispose();
                if (ProductSave.image != "")
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\\images\\" + textBox1.Text + "." + ProductSave.image.Split('.')[1]))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + @"\\images\\" + textBox1.Text + "." + ProductSave.image.Split('.')[1]);
                    }
                    File.Copy(pathImage + @"\\" + ProductSave.image, Directory.GetCurrentDirectory() + @"\\images\\" + textBox1.Text + "." + ProductSave.image.Split('.')[1] + "");
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Clear();
            comboBox2.SelectedIndex = -1;
            textBox5.Clear();
            comboBox3.SelectedIndex = -1;
            textBox6.Clear();
            using (Image image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\images\\picture.png"))
            {
                pictureBox1.Image = new Bitmap(image);
            }
            this.Hide();
            Product product = new Product();
            product.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(symbol, @"[1-90]|[\b]"))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(symbol, @"[a-zA-ZА-Яа-я]|[\b]"))
                e.Handled = true;
        }
    }
}
