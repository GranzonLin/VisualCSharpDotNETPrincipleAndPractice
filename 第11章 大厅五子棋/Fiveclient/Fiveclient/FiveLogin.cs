using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiveclient
{
    public partial class FiveLogin : Form
    {
        static public string regmsg;//ע������
        public FiveLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("�û�����Ϊ��");
                username.Text = "";               
                return;
            }
            if (userpwd1.Text == "" || userpwd2.Text == "")
            {
                MessageBox.Show("���벻��Ϊ��");
                userpwd1.Text = "";
                userpwd1.Text = "";
                return;
            }
            if (userpwd1.Text != userpwd2.Text)
            {
                MessageBox.Show("ǰ�����벻��");
                return;
            }
            if (useremail.Text == "")
            {
                MessageBox.Show("Email����Ϊ��");
                useremail.Text = "";
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("��ѡ��ͷ��");
                comboBox1.Text = "";
                return;
            }
            regmsg="";
            regmsg = "@@@@" + username.Text + "," + userpwd1.Text + "," + useremail.Text + "," + comboBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FiveLogin_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = @"..\..\newface\" + (comboBox1.SelectedIndex + 1) + ".bmp";
            pictureBox1.Image = Image.FromFile(filename);
        }
    }
}