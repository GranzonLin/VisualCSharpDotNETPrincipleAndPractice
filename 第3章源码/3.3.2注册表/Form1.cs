using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32 ;  //����ʹ�õ������ƿռ�
namespace ע���
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(24, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(128, 184);
			this.listBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(176, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "��ȡע���";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(176, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "�����Ӽ�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(176, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "��������";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(176, 176);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "��������ֵ";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(104, 216);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 24);
			this.button5.TabIndex = 5;
			this.button5.Text = "button5";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 246);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "�������޸�ע����Ϣ";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
          //���б���ʽ��ʾ"HARDWARE"����һ����Ӽ��ͼ�ֵ
		private void button1_Click(object sender, System.EventArgs e)//��ȡע���
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
            //��"HARDWARE"�Ӽ�
            RegistryKey software = hklm.OpenSubKey("HARDWARE");////��"SYSTEM"�Ӽ�
			foreach ( string site in software.GetSubKeyNames ( ) )
				//��ʼ�������Ӽ�������ɵ��ַ�������
			{
				listBox1.Items.Add ( site ) ;
				//���б��м����Ӽ�����
				RegistryKey sitekey = software.OpenSubKey ( site ) ;
				//�򿪴��Ӽ�
				foreach ( string sValName in sitekey.GetValueNames ( ) )
					//��ʼ������ָ���Ӽ�ӵ�еļ�ֵ������ɵ��ַ�������
				{
					listBox1.Items.Add ( " " + sValName + ": " + sitekey.GetValue ( sValName ) ) ;
					//���б��м�������ƺͶ�Ӧ�ļ�ֵ
				}
			}
		}
          //�����Ӽ��ͼ�ֵ
		private void button2_Click(object sender, System.EventArgs e)//�����Ӽ�
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
			RegistryKey software = hklm.OpenSubKey ( "HARDWARE", true ) ;
			RegistryKey ddd = software.CreateSubKey ( "ddd" ) ;
			ddd.SetValue ( "www" , "1234" );
		}
         //����һ������������һ����ֵ
		private void button3_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
			RegistryKey software = hklm.OpenSubKey ( "HARDWARE", true ) ;
			RegistryKey main1 = software.CreateSubKey ( "main" ) ;
			RegistryKey ddd = main1.CreateSubKey ( "sub" ) ;
			ddd.SetValue ( "value" , "1234" ) ;
		}
          //������һ�����ڵļ�ֵ
		private void button4_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
			RegistryKey software = hklm.OpenSubKey ( "HARDWARE", true ) ;
			RegistryKey dddw = software.OpenSubKey ( "main" , true ) ;
			dddw.SetValue ( "sub" , "abcd" ) ;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
		//OpenSubKey��Run�Ӽ�			
		RegistryKey KeyCon=Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run",true);
	    string myKey= "myProgram2";
	    //����ע����е�������
	    if((string)KeyCon.GetValue(myKey,"noname") == "noname")//ָ���ļ�������
        {
	         string Path = "c:\\windows\\calc.exe";
	         KeyCon.SetValue(myKey,Path); //calc.exe����ע�����
			 MessageBox.Show("calc.exe�ɹ���Ϊ����������"); 
         }
		}

	}
}
