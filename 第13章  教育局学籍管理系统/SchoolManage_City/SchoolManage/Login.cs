using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// Login ��ժҪ˵����
	/// </summary>
	public class Login : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_PassWord;
		private System.Windows.Forms.TextBox textBox_User;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		private static string str_User_login;

		public Login()
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
				if(components != null)
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_PassWord = new System.Windows.Forms.TextBox();
			this.textBox_User = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(154, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 62;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(50, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 61;
			this.button1.Text = "��¼";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(50, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 60;
			this.label3.Text = "����";
			// 
			// textBox_PassWord
			// 
			this.textBox_PassWord.Location = new System.Drawing.Point(146, 64);
			this.textBox_PassWord.Name = "textBox_PassWord";
			this.textBox_PassWord.Size = new System.Drawing.Size(96, 21);
			this.textBox_PassWord.TabIndex = 59;
			this.textBox_PassWord.Text = "";
			this.textBox_PassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_PassWord_KeyDown);
			// 
			// textBox_User
			// 
			this.textBox_User.Location = new System.Drawing.Point(146, 32);
			this.textBox_User.Name = "textBox_User";
			this.textBox_User.Size = new System.Drawing.Size(96, 21);
			this.textBox_User.TabIndex = 57;
			this.textBox_User.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(50, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 58;
			this.label2.Text = "�û���";
			// 
			// Login
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 165);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_PassWord);
			this.Controls.Add(this.textBox_User);
			this.Controls.Add(this.label2);
			this.Name = "Login";
			this.Text = "��¼";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			config connFirst=new config();
			//�������ݿ�����
			string str_Sql="SELECT School_Type_ID As ѧУ������,School_Type_Name As ѧУ�����,School_Type_Year As ѧУ���ѧ�� FROM School_Type";
			string errorstring=connFirst.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				connFirst.Close();
				return;
			}

			//�����ַ�������
			if(connFirst.Sniffer_In(textBox_User.Text)||connFirst.Sniffer_In(textBox_PassWord.Text))
			{
				MessageBox.Show("�û��������벻���ÿո����'\"?%=�������ַ���"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				connFirst.Close();
				return;
			}

			//�ж��û��Ϸ�
			str_Sql="Select * FROM Users WHERE UserName= '"+textBox_User.Text+"' AND PassWord='"+textBox_PassWord.Text+"'";
			if(connFirst.GetRowCount(str_Sql)!=1)
			{
				MessageBox.Show("������û��������룡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				connFirst.Close();
				
				button1.Enabled=true;
				return;
			}
			else
			{
				str_User_login=textBox_User.Text;
				this.Close();
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{			
			this.Dispose();
		}

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new Login());
			if(str_User_login!=null)
			{
				//str_User_login="admin";
				Form1 MainForm1=new Form1(str_User_login);
				Application.Run(MainForm1);
			}
		}

		private void textBox_PassWord_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.ToString()=="Enter")
			{
				button1.Focus();
				button1_Click(null,null);��
			}
		}
	}
}
