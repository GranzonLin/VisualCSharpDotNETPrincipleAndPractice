using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace SchoolManage
{
	/// <summary>
	/// DataIn ��ժҪ˵����
	/// </summary>
	public class DataIn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_LocationDBOut;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		protected config conn=new config();

		public DataIn()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//�������ݿ�����
			string str_Sql,errorstring;
			str_Sql="SELECT School_Type_ID As ѧУ������,School_Type_Name As ѧУ�����,School_Type_Year As ѧУ���ѧ�� FROM School_Type";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.Dispose();
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
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_LocationDBOut = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(432, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "��Ŀ¼";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "��ǰ����Ŀ¼";
			// 
			// textBox_LocationDBOut
			// 
			this.textBox_LocationDBOut.Location = new System.Drawing.Point(104, 48);
			this.textBox_LocationDBOut.Name = "textBox_LocationDBOut";
			this.textBox_LocationDBOut.Size = new System.Drawing.Size(320, 21);
			this.textBox_LocationDBOut.TabIndex = 8;
			this.textBox_LocationDBOut.Text = "D:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 104);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataIn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(544, 157);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBOut);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "DataIn";
			this.Text = "�¼�ѧУ���ݵ���";
			this.ResumeLayout(false);

		}
		#endregion

		
		//�õ������ļ�
		private void button3_Click(object sender, System.EventArgs e)
		{
			DialogResult result =  folderBrowserDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				string folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBOut.Text=folderName;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}


		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=false;
			string str_Sql,errorstring="OK",str_School_ID_In;
			
			//����ѧУ��Ϣ
			conn.ds.Reset();
			try
			{
				conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
				conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\School.xml");
			}
			catch
			{//�Ի���
				MessageBox.Show("School�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			conn.dr=conn.ds.Tables[0].Rows[0];
			str_School_ID_In=conn.dr["School_ID"].ToString();
			
			DialogResult result;
			if(conn.School_ID_Had(str_School_ID_In))
			{
				result=MessageBox.Show(this,"���Ҫ����ѧУ����Ϊ "+str_School_ID_In+" ��ѧУ��?"
					+"��ѧУ����Ϊ"+conn.School_IDtoWhat(str_School_ID_In,"School_Name")
					+"�������滻��ѧУԭ�е�������Ϣ","���ѣ�",
					MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			}
			else
			{
				result=MessageBox.Show(this,"���Ҫ������?","���ѣ�",
					MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			}


			if (result==DialogResult.OK)
			{
				//ɾ����ѧУ�����Ӧ��������Ϣ,��ɾ��ѧ��,��ɾ���༶,���ɾ��ѧУ,�Է������ͻ
					str_Sql="DELETE from Student WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);

					str_Sql="DELETE from Class WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);
				
					str_Sql="DELETE from Teacher WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);

					str_Sql="DELETE from School WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);

					conn.ds.Reset();
					conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
					conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\School.xml");
						
					conn.dr=conn.ds.Tables[0].Rows[0];
					str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address,QuXian_Code) values ('"
							+str_School_ID_In+"','"
							+conn.dr["School_Name"].ToString()+"',"
							+conn.dr["School_Type_ID"].ToString()+",'"
							+conn.dr["Schoolmaster"].ToString()+"','"
							+conn.dr["School_Tel"].ToString()+"','"
							+conn.dr["School_Zip"].ToString()+"','"
							+conn.dr["School_Address"].ToString()+"','"
							+conn.dr["QuXian_Code"].ToString()+"')";
					errorstring=conn.ExeSql(str_Sql);

					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ�����ѧУ��Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
								MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("�ɹ�����ѧУ��Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				
					//�����ʦ��Ϣ					
					conn.ds.Reset();
					try
					{
						conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Teacher.xsd");
						conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\Teacher.xml");
					}
					catch
					{//�Ի���
						MessageBox.Show("Teacher�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
					{
						string str_InWorkSheet,str_IsFullTime;
						conn.dr=conn.ds.Tables[0].Rows[i];
						
						if(conn.dr["InWorkSheet"].ToString()=="True")
							str_InWorkSheet="1";
						else str_InWorkSheet="0";
						if(conn.dr["IsFullTime"].ToString()=="True")
							str_IsFullTime="1";
						else str_IsFullTime="0";
							 
						str_Sql="INSERT INTO Teacher (School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,LessonTeach,InWorkSheet,IsFullTime) values('"
							+conn.dr["School_ID"].ToString()
							+"','"+conn.dr["Teacher_ID"].ToString()
							+"','"+conn.dr["Name"].ToString()
							+"','"+conn.dr["Sex"].ToString()
							+"','"+conn.dr["Birthday"].ToString()
							+"','"+conn.dr["WorkTime"].ToString()
							+"','"+conn.dr["SchoolType"].ToString()
							+"','"+conn.dr["PostCan"].ToString()
							+"','"+conn.dr["PostIn"].ToString()
							+"','"+conn.dr["SchoolGrad"].ToString()
							+"','"+conn.dr["GradTime"].ToString()
							+"','"+conn.dr["SpecialIn"].ToString()
							+"','"+conn.dr["LessonTeach"].ToString()
							+"',"+str_InWorkSheet
							+","+str_IsFullTime+")";
						errorstring=conn.ExeSql(str_Sql);
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ������ʦ��Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("�ɹ������ʦ��Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();

					//����༶��Ϣ					
					conn.ds.Reset();
					try
					{
						conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Class.xsd");
						conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\Class.xml");
					}
					catch
					{//�Ի���
						MessageBox.Show("Class�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
					{
						conn.dr=conn.ds.Tables[0].Rows[i];
						str_Sql="INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values("
							+conn.dr["Class_ID"].ToString()+",'"
							+conn.dr["School_ID"].ToString()+"',"
							+conn.dr["Class_Type_ID"].ToString()+",'"
							+conn.dr["Class_Name"].ToString()+"','"
							+conn.dr["TeacherInCharge"].ToString()+"')";
						errorstring=conn.ExeSql(str_Sql);
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ�����༶��Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("�ɹ�����༶��Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();

					//����ѧ����Ϣ					
					conn.ds.Reset();
					try
					{
						conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Student.xsd");
						conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\Student.xml");
					}
					catch
					{//�Ի���
						MessageBox.Show("Student�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
					{
						conn.dr=conn.ds.Tables[0].Rows[i];
						str_Sql="insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) values ('"
							+conn.dr["School_ID"].ToString()+"','"
							+conn.dr["Student_ID"].ToString()+"',"
							+conn.dr["Class_ID"].ToString()+",'"
							+conn.dr["Name"].ToString()+"','"
							+conn.dr["Birthday"].ToString()+"','"
							+conn.dr["Sex"].ToString()+"','"
							+conn.dr["Father"].ToString()+"','"
							+conn.dr["Mother"].ToString()+"','"
							+conn.dr["Keeper"].ToString()+"','"
							+conn.dr["StudentTel"].ToString()+"',"
							+conn.dr["QuXian_ID"].ToString()+","
							+conn.dr["Office_ID"].ToString()+",'"
							+conn.dr["Committee_ID"].ToString()+"','"
							+conn.dr["Student_Address"].ToString()+"','"
							+conn.dr["Father_Job"].ToString()+"','"
							+conn.dr["Father_XueLi"].ToString()+"','"
							+conn.dr["Mother_Job"].ToString()+"','"
							+conn.dr["Mother_XueLi"].ToString()+"')";
						errorstring=conn.ExeSql(str_Sql);
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ�����ѧ����Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("�ɹ�����ѧ����Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

					conn.Close();
					this.Dispose();				
				}
				else
				{
					return;
				}			
		}/**//**/
	}
}
