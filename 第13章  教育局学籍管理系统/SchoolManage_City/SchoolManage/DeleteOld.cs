using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace SchoolManage
{
	/// <summary>
	/// DeleteOld ��ժҪ˵����
	/// </summary>
	public class DeleteOld : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox_School_ID;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button3;

		protected config conn=new config();

		public DeleteOld()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			string str_Sql="SELECT School_ID AS ѧУ����,School_Name AS ѧУ����,School_Type_Name AS ѧУ���,Schoolmaster AS У��,School_Tel AS �绰,School_Zip AS ��������,School_Address AS ѧУ��ַ,School_Type_Year AS ѧУѧ������ FROM View_School";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
			button1.Enabled=false;
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
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_School_ID = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(456, 356);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(56, 24);
			this.button2.TabIndex = 51;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AllowDrop = true;
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                     ѧУ��Ϣ";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(20, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(752, 300);
			this.DataGrid1.TabIndex = 49;
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(168, 352);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 32);
			this.button1.TabIndex = 50;
			this.button1.Text = "ɾ��ѡ�е�ѧУ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_School_ID
			// 
			this.textBox_School_ID.Enabled = false;
			this.textBox_School_ID.Location = new System.Drawing.Point(40, 344);
			this.textBox_School_ID.Name = "textBox_School_ID";
			this.textBox_School_ID.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_ID.TabIndex = 52;
			this.textBox_School_ID.Text = "";
			this.textBox_School_ID.Visible = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(320, 352);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 32);
			this.button3.TabIndex = 50;
			this.button3.Text = "ɾ������ѧУ";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// DeleteOld
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 397);
			this.Controls.Add(this.textBox_School_ID);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button3);
			this.Name = "DeleteOld";
			this.Text = "ɾ������Ϣ";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{			
			this.Dispose();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string errorstring="",str_Sql="";
			//DELETE from School WHERE School_ID='"+textBox_School_ID.Text+"'";
			
			DialogResult result=MessageBox.Show(this,"���Ҫ����ɾ����?","���ѣ�",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			if (result==DialogResult.OK)
			{
				str_Sql="DELETE from Student WHERE School_ID='"+textBox_School_ID.Text+"'";
				errorstring=conn.ExeSql(str_Sql);

				str_Sql="DELETE from Class WHERE School_ID='"+textBox_School_ID.Text+"'";
				errorstring=conn.ExeSql(str_Sql);

				str_Sql="DELETE from Teacher WHERE School_ID='"+textBox_School_ID.Text+"'";
				errorstring=conn.ExeSql(str_Sql);

				str_Sql="DELETE from School WHERE School_ID='"+textBox_School_ID.Text+"'";
				errorstring=conn.ExeSql(str_Sql);
				if(errorstring!="OK")
				{
					MessageBox.Show("δ�ɹ�ɾ�������鱾�����ݿ⣡"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					button1.Enabled=false;
					return;
				}
				MessageBox.Show("�ɹ�ɾ����", "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				return;
			}
			str_Sql="SELECT School_ID AS ѧУ����,School_Name AS ѧУ����,School_Type_Name AS ѧУ���,Schoolmaster AS У��,School_Tel AS �绰,School_Zip AS ��������,School_Address AS ѧУ��ַ,School_Type_Year AS ѧУѧ������ FROM View_School";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			button1.Enabled=false;
		}

		private void DataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid1.Select(DataGrid1.CurrentRowIndex);
			textBox_School_ID.Text=DataGrid1[DataGrid1.CurrentRowIndex,0].ToString();

			button1.Enabled=true;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string str_LocationDBBackup="";
			string errorstring="",str_Sql="";
			//DELETE from School WHERE School_ID='"+textBox_School_ID.Text+"'";
			
			DialogResult result=MessageBox.Show(this,"���Ҫɾ������ѧУ����Ϣ��?���ɻָ���","���ѣ�",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			if (result==DialogResult.OK)
			{
				try
				{
					string path="SchoolManage.exe.config";
					XmlDocument xd=new XmlDocument();
					xd.Load(path);
					foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
					{
						if(xn1.Attributes["key"].Value=="DatabaseBackup")
						{
							str_LocationDBBackup=xn1.Attributes["value"].Value;
							break;
						}
					}
				}
				catch
				{
					//return false;
					throw new Exception("Config�����ļ���ȡʧ�ܣ�");
				}
				str_Sql="backup database "+ConfigurationSettings.AppSettings["Database"]
					+" TO disk='"+str_LocationDBBackup+"\\��"+System.DateTime.Now.ToString().Replace(":","-")+"��֣���н���ͳ�Ƽ��ϵͳ�����ݱ���.bak'";
			
				try
				{
					errorstring=conn.ExeSql(str_Sql);
				}
				catch
				{				
					MessageBox.Show("����ʧ�ܣ�", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					conn.Close();
				}

				str_Sql="DELETE from Student";
				errorstring=conn.ExeSql(str_Sql);

				str_Sql="DELETE from Class";
				errorstring=conn.ExeSql(str_Sql);

				str_Sql="DELETE from Teacher";
				errorstring=conn.ExeSql(str_Sql);

				str_Sql="DELETE from School";
				errorstring=conn.ExeSql(str_Sql);
				if(errorstring!="OK")
				{
					MessageBox.Show("δ�ɹ�ɾ�������鱾�����ݿ⣡"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					button3.Enabled=false;
					return;
				}
				MessageBox.Show("�ɹ�ɾ�����������ļ���"+str_LocationDBBackup, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				return;
			}
			str_Sql="SELECT School_ID AS ѧУ����,School_Name AS ѧУ����,School_Type_Name AS ѧУ���,Schoolmaster AS У��,School_Tel AS �绰,School_Zip AS ��������,School_Address AS ѧУ��ַ,School_Type_Year AS ѧУѧ������ FROM View_School";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			button3.Enabled=false;
		}
	}
}
