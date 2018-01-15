using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace SchoolManage
{
	/// <summary>
	/// LoginFirst ��ժҪ˵����
	/// </summary>
	public class LoginFirst : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_PassWord;
		private System.Windows.Forms.TextBox textBox_User;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_DbUser;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_DBServer;
		private System.Windows.Forms.GroupBox groupBox1;
		private static string str_User_login;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_Database;
		private System.Windows.Forms.CheckBox checkBox_First;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_DbPassWord;
		protected config conn=new config();

		public LoginFirst()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			textBox_PassWord.PasswordChar='*';

			//��ʾ���ݿ���Ϣ,�����û��������ݿ�
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="Database")
					{
						textBox_Database.Text=xn1.Attributes["value"].Value;
						//break;
					}
					if(xn1.Attributes["key"].Value=="DatabaseServer")
					{
						textBox_DBServer.Text=xn1.Attributes["value"].Value;
						//break;
					}					
					if(xn1.Attributes["key"].Value=="DatabaseUser")
					{
						textBox_DbUser.Text=xn1.Attributes["value"].Value;
						break;
					}	
					/*if(xn1.Attributes["key"].Value=="DatabasePassword")
					 {
						 textBox_DbPassWord.Text=xn1.Attributes["value"].Value;
						 break;
					 }*/		
				}
			}
			catch
			{
				//return false;
				throw new Exception("Config�����ļ���ȡʧ�ܣ�");
			}
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
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_User = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_DbUser = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_DBServer = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_Database = new System.Windows.Forms.TextBox();
			this.checkBox_First = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_DbPassWord = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(168, 96);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 56;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(64, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 55;
			this.button1.Text = "��¼";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(64, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 54;
			this.label3.Text = "����";
			// 
			// textBox_PassWord
			// 
			this.textBox_PassWord.Location = new System.Drawing.Point(160, 64);
			this.textBox_PassWord.Name = "textBox_PassWord";
			this.textBox_PassWord.Size = new System.Drawing.Size(96, 21);
			this.textBox_PassWord.TabIndex = 53;
			this.textBox_PassWord.Text = "";
			this.textBox_PassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_PassWord_KeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 52;
			this.label2.Text = "�û���";
			// 
			// textBox_User
			// 
			this.textBox_User.Location = new System.Drawing.Point(160, 32);
			this.textBox_User.Name = "textBox_User";
			this.textBox_User.Size = new System.Drawing.Size(96, 21);
			this.textBox_User.TabIndex = 51;
			this.textBox_User.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 60;
			this.label4.Text = "�û���";
			// 
			// textBox_DbUser
			// 
			this.textBox_DbUser.Enabled = false;
			this.textBox_DbUser.Location = new System.Drawing.Point(112, 56);
			this.textBox_DbUser.Name = "textBox_DbUser";
			this.textBox_DbUser.Size = new System.Drawing.Size(96, 21);
			this.textBox_DbUser.TabIndex = 59;
			this.textBox_DbUser.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 23);
			this.label5.TabIndex = 58;
			this.label5.Text = "��������";
			// 
			// textBox_DBServer
			// 
			this.textBox_DBServer.Enabled = false;
			this.textBox_DBServer.Location = new System.Drawing.Point(112, 24);
			this.textBox_DBServer.Name = "textBox_DBServer";
			this.textBox_DBServer.Size = new System.Drawing.Size(96, 21);
			this.textBox_DBServer.TabIndex = 57;
			this.textBox_DBServer.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox_DbUser);
			this.groupBox1.Controls.Add(this.textBox_DBServer);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox_Database);
			this.groupBox1.Location = new System.Drawing.Point(48, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 120);
			this.groupBox1.TabIndex = 63;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "��ȷ�����ݿ����������";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 60;
			this.label1.Text = "���ݿ���";
			// 
			// textBox_Database
			// 
			this.textBox_Database.Enabled = false;
			this.textBox_Database.Location = new System.Drawing.Point(112, 88);
			this.textBox_Database.Name = "textBox_Database";
			this.textBox_Database.Size = new System.Drawing.Size(96, 21);
			this.textBox_Database.TabIndex = 59;
			this.textBox_Database.Text = "";
			// 
			// checkBox_First
			// 
			this.checkBox_First.Location = new System.Drawing.Point(72, 280);
			this.checkBox_First.Name = "checkBox_First";
			this.checkBox_First.Size = new System.Drawing.Size(136, 24);
			this.checkBox_First.TabIndex = 64;
			this.checkBox_First.Text = "��һ�ε�¼";
			this.checkBox_First.Visible = false;
			this.checkBox_First.CheckedChanged += new System.EventHandler(this.checkBox_First_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(64, 256);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 23);
			this.label6.TabIndex = 62;
			this.label6.Text = "����";
			this.label6.Visible = false;
			// 
			// textBox_DbPassWord
			// 
			this.textBox_DbPassWord.Enabled = false;
			this.textBox_DbPassWord.Location = new System.Drawing.Point(160, 256);
			this.textBox_DbPassWord.Name = "textBox_DbPassWord";
			this.textBox_DbPassWord.Size = new System.Drawing.Size(96, 21);
			this.textBox_DbPassWord.TabIndex = 61;
			this.textBox_DbPassWord.Text = "";
			this.textBox_DbPassWord.Visible = false;
			// 
			// LoginFirst
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 317);
			this.Controls.Add(this.checkBox_First);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_PassWord);
			this.Controls.Add(this.textBox_User);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_DbPassWord);
			this.Controls.Add(this.label6);
			this.Name = "LoginFirst";
			this.Text = "��¼";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(checkBox_First.Checked==true)
			{
				try
				{
					string path="SchoolManage.exe.config";
					XmlDocument xd=new XmlDocument();
					xd.Load(path);
					//�жϽڵ��Ƿ���ڣ�����������޸ĵ�ǰ�ڵ�
					foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
					{
						if(xn1.Attributes["key"].Value=="Database")
						{
							xn1.Attributes["value"].Value=textBox_Database.Text;
							//break;
						}
						if(xn1.Attributes["key"].Value=="DatabaseServer")
						{
							xn1.Attributes["value"].Value=textBox_DBServer.Text;
							//break;
						}						
						if(xn1.Attributes["key"].Value=="DatabaseUser")
						{
							xn1.Attributes["value"].Value=textBox_DbUser.Text;
							break;
						}						
						/*if(xn1.Attributes["key"].Value=="DatabasePassword")
						{
							xn1.Attributes["value"].Value=textBox_DbPassWord.Text;
							break;
						}*/
					}
					//����web.config
					xd.Save(path);
					//return true;
					MessageBox.Show("�ɹ��޸ģ�", "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				catch
				{
					//return false;
					throw new Exception("Config�����ļ���ȡʧ�ܣ�");
				}

			}

			//�������ݿ�����
			string str_Sql,errorstring;
			str_Sql="SELECT School_Type_ID As ѧУ������,School_Type_Name As ѧУ�����,School_Type_Year As ѧУ���ѧ�� FROM School_Type";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				conn.Close();
				return;
			}

			//�����ַ�������
			if(conn.Sniffer_In(textBox_User.Text)||conn.Sniffer_In(textBox_PassWord.Text))
			{
				MessageBox.Show("�û��������벻���ÿո����'\"?%=�������ַ���"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				conn.Close();
				return;
			}
			
			//�ж��û��Ϸ�
			str_Sql="Select * FROM Users WHERE UserName= '"+textBox_User.Text+"' AND PassWord='"+textBox_PassWord.Text+"'";
			if(conn.GetRowCount(str_Sql)!=1)
			{
				MessageBox.Show("������û��������룡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				conn.Close();
				
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
		/*[STAThread]
		static void Main()
		{
			Application.Run(new LoginFirst());
			if(str_User_login!=null)
			{
				str_User_login="Admin";
				Form1 MainForm1=new Form1(str_User_login);
				Application.Run(MainForm1);
			}
		}*/

		private void checkBox_First_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkBox_First.Checked==true)
			{
				textBox_Database.Enabled=true;
				textBox_DBServer.Enabled=true;
				textBox_DbPassWord.Enabled=true;
				textBox_DbUser.Enabled=true;
			}
			else
			{
				textBox_Database.Enabled=false;
				textBox_DBServer.Enabled=false;
				textBox_DbPassWord.Enabled=false;
				textBox_DbUser.Enabled=false;
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
