using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Data;
using System.Threading;

namespace DataBaseSet
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_PassWord;
		private System.Windows.Forms.TextBox textBox_User;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		const int ERROR_FILE_NOT_FOUND =2;
		const int ERROR_ACCESS_DENIED = 5;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			textBox_PassWord.PasswordChar='*';

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
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_PassWord = new System.Windows.Forms.TextBox();
			this.textBox_User = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(80, 112);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 56;
			this.button3.Text = "��ʼ��ϵͳ";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 60;
			this.label3.Text = "����";
			// 
			// textBox_PassWord
			// 
			this.textBox_PassWord.Location = new System.Drawing.Point(184, 64);
			this.textBox_PassWord.Name = "textBox_PassWord";
			this.textBox_PassWord.Size = new System.Drawing.Size(96, 21);
			this.textBox_PassWord.TabIndex = 59;
			this.textBox_PassWord.Text = "";
			// 
			// textBox_User
			// 
			this.textBox_User.Location = new System.Drawing.Point(184, 32);
			this.textBox_User.Name = "textBox_User";
			this.textBox_User.Size = new System.Drawing.Size(96, 21);
			this.textBox_User.TabIndex = 57;
			this.textBox_User.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 58;
			this.label2.Text = "��ʼ��ר���û���";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(240, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 63;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(400, 165);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_PassWord);
			this.Controls.Add(this.textBox_User);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button3);
			this.Name = "Form1";
			this.Text = "�������ݿ�";
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

		private void button3_Click(object sender, System.EventArgs e)
		{
			button3.Enabled=false;
			if(!(textBox_User.Text=="initialuser"&&textBox_PassWord.Text=="initialpassword"))
			{
				MessageBox.Show("�û����������벻��ȷ��", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			string str_Sql,errorstring="";
			string str_DatabaseServer;

			DialogResult result=MessageBox.Show(this,"���Ҫ���г�ʼ����?���ݿ�ᱻ��յ���ʼ״̬��","���ѣ�",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			if (result==DialogResult.OK)
			{				
				Process myProcess = new Process();
				try
				{
					myProcess.StartInfo.FileName ="�������ݿ�.bat"; 
					myProcess.StartInfo.CreateNoWindow = true;
					myProcess.Start();
				}
				catch (Win32Exception ebat)
				{
					if(ebat.NativeErrorCode == ERROR_FILE_NOT_FOUND)
					{
						Console.WriteLine(ebat.Message + ". Check the path.");
					} 
					else if (ebat.NativeErrorCode == ERROR_ACCESS_DENIED)
					{
						Console.WriteLine(ebat.Message +". You do not have permission to run this file.");
					}
				}

				Thread.Sleep(1111);

				str_DatabaseServer=SystemInformation.ComputerName+"\\MSDEDH";
				config connTest=new config();
				if(connTest.TestOpen(str_DatabaseServer,"sa","dhsa.")=="OK")
				{
					MessageBox.Show("���ݿ�������Ϣ��ȷ��", "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("���Ӳ���ȷ��", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);				
				}

				try
				{
					str_Sql="restore database "+ConfigurationSettings.AppSettings["Database"]
						+" from disk='"+System.IO.Directory.GetCurrentDirectory()+"\\DBCityEdu.bak"
						+"' with replace";
					errorstring=connTest.DBCreate(str_Sql);
				}
				catch
				{
					//return false;
					throw new Exception(errorstring+"���ݿ�δ�ؽ���");
				}
				MessageBox.Show(errorstring+"�ɹ��������ݿ⣡", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);					
				config connFirst=new config();
				//�������ݿ�����
				str_Sql="SELECT School_Type_ID As ѧУ������,School_Type_Name As ѧУ�����,School_Type_Year As ѧУ���ѧ�� FROM School_Type";
				errorstring=connFirst.Fill(str_Sql);
				if(errorstring!="OK")
				{
					MessageBox.Show("���ݿ������⣡"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					connFirst.Close();
					return;
				}
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}
