
namespace shop.Forms
{
    partial class Users
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.surname = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.midleName = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.dateOfBit = new System.Windows.Forms.DateTimePicker();
            this.phone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.role = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(116, 10);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(201, 29);
            this.surname.TabIndex = 1;
            this.surname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surname_KeyPress);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(116, 62);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(201, 29);
            this.name.TabIndex = 2;
            this.name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surname_KeyPress);
            // 
            // midleName
            // 
            this.midleName.Location = new System.Drawing.Point(116, 118);
            this.midleName.Name = "midleName";
            this.midleName.Size = new System.Drawing.Size(201, 29);
            this.midleName.TabIndex = 3;
            this.midleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surname_KeyPress);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(477, 8);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(159, 29);
            this.login.TabIndex = 4;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(477, 61);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(159, 29);
            this.pwd.TabIndex = 5;
            // 
            // dateOfBit
            // 
            this.dateOfBit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateOfBit.Location = new System.Drawing.Point(562, 120);
            this.dateOfBit.Name = "dateOfBit";
            this.dateOfBit.Size = new System.Drawing.Size(200, 29);
            this.dateOfBit.TabIndex = 6;
            this.dateOfBit.ValueChanged += new System.EventHandler(this.dateOfBit_ValueChanged);
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(1089, 15);
            this.phone.Mask = "+7 (999)000-00-00";
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(200, 29);
            this.phone.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Отчетсво";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Логин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Пароль";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Дата рождения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(993, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Телефон";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(642, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 29);
            this.button1.TabIndex = 15;
            this.button1.Text = "Сгенерировать логин";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(642, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 29);
            this.button2.TabIndex = 16;
            this.button2.Text = "Сгенерировать пароль";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(34, 179);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(117, 48);
            this.insert.TabIndex = 17;
            this.insert.Text = "Добавить";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(562, 182);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(166, 45);
            this.update.TabIndex = 18;
            this.update.Text = "Редактировать";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // role
            // 
            this.role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.role.FormattingEnabled = true;
            this.role.Location = new System.Drawing.Point(1089, 60);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(200, 32);
            this.role.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1029, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Роль";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1203, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 48);
            this.button3.TabIndex = 22;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 253);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.role);
            this.Controls.Add(this.update);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.dateOfBit);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.login);
            this.Controls.Add(this.midleName);
            this.Controls.Add(this.name);
            this.Controls.Add(this.surname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox midleName;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.DateTimePicker dateOfBit;
        private System.Windows.Forms.MaskedTextBox phone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.ComboBox role;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
    }
}