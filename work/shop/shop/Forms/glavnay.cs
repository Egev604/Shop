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
namespace shop.Forms
{
    public partial class glavnay : Form
    {
        public glavnay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users users = new Users(false, "-1");
            users.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void glavnay_Load(object sender, EventArgs e)
        {
            Users.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            if (Role.getRole() == 1)
            {
                Users.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
            }
            if(Role.getRole()==2 || Role.getRole()==3)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Product product = new Product();
            product.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ProductSave.articul = "";
            ProductSave.productName = "";
            ProductSave.description = "";
            ProductSave.category = "";
            ProductSave.cost = "";
            ProductSave.manuf = "";
            ProductSave.discount = "";
            ProductSave.unit = "";
            ProductSave.countOnStock = "";
            ProductSave.image = "";
            this.Hide();
            ProductBD product = new ProductBD(true);
            product.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            autorization autorization = new autorization();
            autorization.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersShow usersShow = new UsersShow();
            usersShow.Show();
        }
    }
}
