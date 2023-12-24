
namespace shop
{
    partial class autorization
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwd = new System.Windows.Forms.TextBox();
            this.entry = new System.Windows.Forms.Button();
            this.entryLink = new System.Windows.Forms.LinkLabel();
            this.exit = new System.Windows.Forms.Button();
            this.Captha = new System.Windows.Forms.GroupBox();
            this.capthaVis = new System.Windows.Forms.Label();
            this.capthaText = new System.Windows.Forms.TextBox();
            this.CapthaTrue = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Captha.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(111, 25);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(174, 29);
            this.login.TabIndex = 1;
            this.login.Text = "admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(111, 66);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(174, 29);
            this.passwd.TabIndex = 3;
            this.passwd.Text = "admin";
            // 
            // entry
            // 
            this.entry.Location = new System.Drawing.Point(75, 173);
            this.entry.Name = "entry";
            this.entry.Size = new System.Drawing.Size(163, 35);
            this.entry.TabIndex = 4;
            this.entry.Text = "Войти";
            this.entry.UseVisualStyleBackColor = true;
            this.entry.Click += new System.EventHandler(this.entry_Click);
            // 
            // entryLink
            // 
            this.entryLink.AutoSize = true;
            this.entryLink.Location = new System.Drawing.Point(41, 221);
            this.entryLink.Name = "entryLink";
            this.entryLink.Size = new System.Drawing.Size(224, 24);
            this.entryLink.TabIndex = 5;
            this.entryLink.TabStop = true;
            this.entryLink.Text = "Войти без авторизации";
            this.entryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.entryLink_LinkClicked);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(75, 258);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(163, 45);
            this.exit.TabIndex = 6;
            this.exit.Text = "Выйти";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Captha
            // 
            this.Captha.Controls.Add(this.capthaVis);
            this.Captha.Controls.Add(this.capthaText);
            this.Captha.Controls.Add(this.CapthaTrue);
            this.Captha.Location = new System.Drawing.Point(33, 2);
            this.Captha.Name = "Captha";
            this.Captha.Size = new System.Drawing.Size(252, 206);
            this.Captha.TabIndex = 7;
            this.Captha.TabStop = false;
            this.Captha.Text = "Капча";
            // 
            // capthaVis
            // 
            this.capthaVis.AutoSize = true;
            this.capthaVis.Location = new System.Drawing.Point(92, 54);
            this.capthaVis.Name = "capthaVis";
            this.capthaVis.Size = new System.Drawing.Size(60, 24);
            this.capthaVis.TabIndex = 2;
            this.capthaVis.Text = "label3";
            // 
            // capthaText
            // 
            this.capthaText.Location = new System.Drawing.Point(62, 113);
            this.capthaText.Name = "capthaText";
            this.capthaText.Size = new System.Drawing.Size(127, 29);
            this.capthaText.TabIndex = 1;
            // 
            // CapthaTrue
            // 
            this.CapthaTrue.Location = new System.Drawing.Point(62, 161);
            this.CapthaTrue.Name = "CapthaTrue";
            this.CapthaTrue.Size = new System.Drawing.Size(127, 35);
            this.CapthaTrue.TabIndex = 0;
            this.CapthaTrue.Text = "Проверить";
            this.CapthaTrue.UseVisualStyleBackColor = true;
            this.CapthaTrue.Click += new System.EventHandler(this.CapthaTrue_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 306);
            this.ControlBox = false;
            this.Controls.Add(this.Captha);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.entryLink);
            this.Controls.Add(this.entry);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "autorization";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.autorization_Load);
            this.Captha.ResumeLayout(false);
            this.Captha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.Button entry;
        private System.Windows.Forms.LinkLabel entryLink;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.GroupBox Captha;
        private System.Windows.Forms.Label capthaVis;
        private System.Windows.Forms.TextBox capthaText;
        private System.Windows.Forms.Button CapthaTrue;
        private System.Windows.Forms.Timer timer1;
    }
}

