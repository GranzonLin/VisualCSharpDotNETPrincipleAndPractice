using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiveclient
{
    public partial class FiveSetconnect : Form
    {
        
        public FiveSetconnect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Fivehouse.portNum = System.Convert.ToInt32(textBox2.Text, 10);
           Fivehouse.serverip = textBox1.Text;
           try
           {
               Fivehouse.myclient = new System.Net.Sockets.TcpClient(Fivehouse.serverip, Fivehouse.portNum);
           }
           catch
           {
               MessageBox.Show("�������ܾ���������","��Ϣ");
               return;
           }
           Fivehouse.networkClient = Fivehouse.myclient.GetStream();//��ȡ������ 
           byte[] read = new byte[2];
           int bytes = Fivehouse.networkClient.Read(read, 0, read.Length);//��ȡ���ֽ���
           if (bytes >0)
           {
               
               Fivehouse.isConnecting = true;
               Fivehouse.startthreads();
               Fivehouse.in_id = Convert.ToInt16( System.Text.Encoding.Unicode.GetString(read));
               MessageBox.Show("�������ӳɹ�", System.Text.Encoding.Unicode.GetString(read));
               this.Close();
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}