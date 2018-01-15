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
	/// QuXianDataIn ��ժҪ˵����
	/// </summary>
	public class QuXianDataIn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_LocationDBOut;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();
		protected config connSchool=new config();
		protected config connClass=new config();
		protected config connTeacher=new config();
		protected config connStudent=new config();

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		public QuXianDataIn()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			string str_Sql,errorstring;
			str_Sql="SELECT School_Type_ID As ѧУ������,School_Type_Name As ѧУ�����,School_Type_Year As ѧУ���ѧ�� FROM School_Type";
			errorstring=connSchool.Fill(str_Sql);
			errorstring=conn.Fill(str_Sql);

			str_Sql="SELECT * FROM Class_Type";
			errorstring=connClass.Fill(str_Sql);
			
			str_Sql="SELECT * FROM Class_Type";
			errorstring=connTeacher.Fill(str_Sql);
			
			str_Sql="SELECT * FROM Class_Type";
			errorstring=connStudent.Fill(str_Sql);			

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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_LocationDBOut = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(44, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "��ǰ����Ŀ¼";
			// 
			// textBox_LocationDBOut
			// 
			this.textBox_LocationDBOut.Location = new System.Drawing.Point(124, 49);
			this.textBox_LocationDBOut.Name = "textBox_LocationDBOut";
			this.textBox_LocationDBOut.Size = new System.Drawing.Size(320, 21);
			this.textBox_LocationDBOut.TabIndex = 13;
			this.textBox_LocationDBOut.Text = "D:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(268, 103);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 16;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(148, 103);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 15;
			this.button1.Text = "����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(448, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 17;
			this.button3.Text = "��Ŀ¼";
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// QuXianDataIn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(568, 173);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBOut);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "QuXianDataIn";
			this.Text = "�¼�������������";
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=false;
			string str_Sql,errorstring="OK",str_School_ID_In;
			StringBuilder  StringBuilder_Sql=new StringBuilder();

			connSchool.ds.Reset();
			try
			{
				connSchool.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
				connSchool.ds.ReadXml(textBox_LocationDBOut.Text+"\\School.xml");
			}
			catch
			{//�Ի���
				MessageBox.Show("School�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			int SchoolCount=connSchool.ds.Tables[0].Rows.Count;

			//����༶��Ϣ
			connClass.ds.Reset();
			try
			{
				connClass.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Class.xsd");
				connClass.ds.ReadXml(textBox_LocationDBOut.Text+"\\Class.xml");
			}
			catch
			{//�Ի���
				MessageBox.Show("Class�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//�����ʦ��Ϣ
			connTeacher.ds.Reset();
			try
			{
				connTeacher.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Teacher.xsd");
				connTeacher.ds.ReadXml(textBox_LocationDBOut.Text+"\\Teacher.xml");
			}
			catch
			{//�Ի���
				MessageBox.Show("Teacher�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//����ѧ����Ϣ	
			connStudent.ds.Reset();
			try
			{
				connStudent.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Student.xsd");
				connStudent.ds.ReadXml(textBox_LocationDBOut.Text+"\\Student.xml");
			}
			catch
			{//�Ի���
				MessageBox.Show("Student�ļ���ʧ�ܣ�"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

            for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				connSchool.dr=connSchool.ds.Tables[0].Rows[indexSchool];
				str_School_ID_In=connSchool.dr["School_ID"].ToString();
			
				DialogResult result;

				/*������֤
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
				
				if (result==DialogResult.OK)*/
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
	
//					str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address) values ('"
//						+str_School_ID_In+"','"
//						+connSchool.dr["School_Name"].ToString()+"',"
//						+connSchool.dr["School_Type_ID"].ToString()+",'"
//						+connSchool.dr["Schoolmaster"].ToString()+"','"
//						+connSchool.dr["School_Tel"].ToString()+"','"
//						+connSchool.dr["School_Zip"].ToString()+"','"
//						+connSchool.dr["School_Address"].ToString()+"')";

					str_Sql=StringBuilder_Sql.ToString();
					StringBuilder_Sql.Remove(0,str_Sql.Length);

					StringBuilder_Sql.Append("insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address) values ('");
					StringBuilder_Sql.Append(str_School_ID_In);
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Name"].ToString());
					StringBuilder_Sql.Append("',");
					StringBuilder_Sql.Append(connSchool.dr["School_Type_ID"].ToString());
					StringBuilder_Sql.Append(",'");
					StringBuilder_Sql.Append(connSchool.dr["Schoolmaster"].ToString());
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Tel"].ToString());
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Zip"].ToString());
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Address"].ToString());
					StringBuilder_Sql.Append("')");

					str_Sql=StringBuilder_Sql.ToString();

					errorstring=conn.ExeSql(str_Sql);

					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ�����ѧУ��Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*��ʾ�ɹ�����
					MessageBox.Show("�ɹ�����ѧУ��Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					*/

					//int TeacherCount=connTeacher.ds.Tables[0].Rows.Count;
					//for(int i=0;i<TeacherCount;i++)
					foreach(System.Data.DataRow drtemp in connTeacher.ds.Tables[0].Rows)
					{
						//connTeacher.dr=connTeacher.ds.Tables[0].Rows[i];
						connTeacher.dr=drtemp;
						
						if(connTeacher.dr["School_ID"].ToString()==str_School_ID_In)
						{
							string str_InWorkSheet,str_IsFullTime;
							if(connTeacher.dr["InWorkSheet"].ToString()=="True")
								str_InWorkSheet="1";
							else str_InWorkSheet="0";
							if(connTeacher.dr["IsFullTime"].ToString()=="True")
								str_IsFullTime="1";
							else str_IsFullTime="0";
							 							
//							str_Sql="INSERT INTO Teacher (School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,LessonTeach,InWorkSheet,IsFullTime) values('"
//								+conn.dr["School_ID"].ToString()
//								+"','"+conn.dr["Teacher_ID"].ToString()
//								+"','"+conn.dr["Name"].ToString()
//								+"','"+conn.dr["Sex"].ToString()
//								+"','"+conn.dr["Birthday"].ToString()
//								+"','"+conn.dr["WorkTime"].ToString()
//								+"','"+conn.dr["SchoolType"].ToString()
//								+"','"+conn.dr["PostCan"].ToString()
//								+"','"+conn.dr["PostIn"].ToString()
//								+"','"+conn.dr["SchoolGrad"].ToString()
//								+"','"+conn.dr["GradTime"].ToString()
//								+"','"+conn.dr["SpecialIn"].ToString()
//								+"','"+conn.dr["LessonTeach"].ToString()
//								+"',"+str_InWorkSheet
//								+","+str_IsFullTime+")";

							StringBuilder_Sql.Remove(0,str_Sql.Length);

							StringBuilder_Sql.Append("INSERT INTO Teacher (School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,LessonTeach,InWorkSheet,IsFullTime) values('");
							StringBuilder_Sql.Append(connTeacher.dr["School_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Teacher_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Name"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Sex"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Birthday"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["WorkTime"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["SchoolType"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["PostCan"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["PostIn"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["SchoolGrad"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["GradTime"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["SpecialIn"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["LessonTeach"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(str_InWorkSheet);
							StringBuilder_Sql.Append(",");
							StringBuilder_Sql.Append(str_IsFullTime);
							StringBuilder_Sql.Append(")");

							str_Sql=StringBuilder_Sql.ToString();

							errorstring=connTeacher.ExeSql(str_Sql);
						}
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ������ʦ��Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*��ʾ�ɹ�����
					MessageBox.Show("�ɹ������ʦ��Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();
					*/
	
					//int ClassCount=connClass.ds.Tables[0].Rows.Count;
					//for(int i=0;i<ClassCount;i++)
					//{
					foreach(System.Data.DataRow drtemp in connClass.ds.Tables[0].Rows)
					{		
						connClass.dr=drtemp;
						
						//connClass.dr=connClass.ds.Tables[0].Rows[i];

						if(connClass.dr["School_ID"].ToString()==str_School_ID_In)
						{
//							str_Sql="INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values("
//								+conn.dr["Class_ID"].ToString()+",'"
//								+conn.dr["School_ID"].ToString()+"',"
//								+conn.dr["Class_Type_ID"].ToString()+",'"
//								+conn.dr["Class_Name"].ToString()+"','"
//								+conn.dr["TeacherInCharge"].ToString()+"')";
							
							StringBuilder_Sql.Remove(0,str_Sql.Length);

							StringBuilder_Sql.Append("INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values(");
							StringBuilder_Sql.Append(connClass.dr["Class_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connClass.dr["School_ID"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(connClass.dr["Class_Type_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connClass.dr["Class_Name"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connClass.dr["TeacherInCharge"].ToString());
							StringBuilder_Sql.Append("')");

							str_Sql=StringBuilder_Sql.ToString();

							errorstring=conn.ExeSql(str_Sql);
						}
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ�����༶��Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*��ʾ�ɹ�����
					MessageBox.Show("�ɹ�����༶��Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();
					*/

					//int StudentCount=connStudent.ds.Tables[0].Rows.Count;					
					//for(int i=0;i<connStudent.ds.Tables[0].Rows.Count;i++)
					//{
					//	connStudent.dr=connStudent.ds.Tables[0].Rows[i];

					foreach(System.Data.DataRow drtemp in connStudent.ds.Tables[0].Rows)
					{		
						connStudent.dr=drtemp;
						
						if(connStudent.dr["School_ID"].ToString()==str_School_ID_In)
						{
//							str_Sql="insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) values ('"
//								+conn.dr["School_ID"].ToString()+"','"
//								+conn.dr["Student_ID"].ToString()+"',"
//								+conn.dr["Class_ID"].ToString()+",'"
//								+conn.dr["Name"].ToString()+"','"
//								+conn.dr["Birthday"].ToString()+"','"
//								+conn.dr["Sex"].ToString()+"','"
//								+conn.dr["Father"].ToString()+"','"
//								+conn.dr["Mother"].ToString()+"','"
//								+conn.dr["Keeper"].ToString()+"','"
//								+conn.dr["StudentTel"].ToString()+"',"
//								+conn.dr["QuXian_ID"].ToString()+","
//								+conn.dr["Office_ID"].ToString()+",'"
//								+conn.dr["Committee_ID"].ToString()+"','"
//								+conn.dr["Student_Address"].ToString()+"','"
//								+conn.dr["Father_Job"].ToString()+"','"
//								+conn.dr["Father_XueLi"].ToString()+"','"
//								+conn.dr["Mother_Job"].ToString()+"','"
//								+conn.dr["Mother_XueLi"].ToString()+"')";

							StringBuilder_Sql.Remove(0,str_Sql.Length);

							StringBuilder_Sql.Append("insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) values ('");
							StringBuilder_Sql.Append(connStudent.dr["School_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Student_ID"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(connStudent.dr["Class_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connStudent.dr["Name"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Birthday"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Sex"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Father"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Mother"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Keeper"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["StudentTel"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(connStudent.dr["QuXian_ID"].ToString());
							StringBuilder_Sql.Append(",");
							StringBuilder_Sql.Append(connStudent.dr["Office_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connStudent.dr["Committee_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Student_Address"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Father_Job"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Father_XueLi"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Mother_Job"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Mother_XueLi"].ToString());
							StringBuilder_Sql.Append("')");

							str_Sql=StringBuilder_Sql.ToString();

							errorstring=connStudent.ExeSql(str_Sql);							
						}
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("δ�ɹ�����ѧ����Ϣ���������ݿ⣡"+errorstring, "���ѣ�", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*��ʾ�ɹ�����
					MessageBox.Show("�ɹ�����ѧ����Ϣ��"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					*/
			
				}

				/*�Ի���if�ķ������
				else
				{
					return;
				}
				*/		
			}
			MessageBox.Show("�ɹ�����"+SchoolCount.ToString()+"��ѧУ��Ϣ��"+errorstring, "���ѣ�", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();
		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{
			DialogResult resulttemp =  folderBrowserDialog1.ShowDialog();
			if( resulttemp == DialogResult.OK )
			{
				string folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBOut.Text=folderName;
			}
		}
	}
}
