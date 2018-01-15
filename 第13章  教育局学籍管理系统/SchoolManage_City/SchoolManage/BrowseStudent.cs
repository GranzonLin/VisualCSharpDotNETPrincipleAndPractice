using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// BrowseStudent ��ժҪ˵����
	/// </summary>
	public class BrowseStudent : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_Class;
		private System.Windows.Forms.ComboBox comboBox_Class_Type;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_School;

		protected config conn=new config();

		//����Ӧ�ó���,������,������
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.Label label_;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private Excel.Worksheet excelSheet;

		public BrowseStudent()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
						
			string str_Sql,errorstring;
			
			str_Sql="Select * from Class"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("��������༶��Ϣ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;				
				return;
			}
			//�������б���ʾ���ݿ������е�ѧУ
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count==0)
			{
				return;
			}
			else
			{
				//����ѡ���ѧУ�������б���ʾ��ѧУ��Ӧ�����а༶����
				conn.BindComboBox("Select * FROM Class_Type WHERE School_Type_ID_Class_Belong="+conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Type_ID"),comboBox_Class_Type,"Class_Type_ID","Class_Type_Name");
				//����ѡ���ѧУ��ѡ��İ༶���Ͱ������б���ʾ��ѧУ�����ְ༶���Ͷ�Ӧ�İ༶
				conn.BindComboBox("Select * FROM Class WHERE Class_Type_ID="+comboBox_Class_Type.SelectedValue.ToString()+"AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'",comboBox_Class,"Class_ID","Class_Name");	
			}

			if(comboBox_Class.Items.Count==0)
			{
				return;
			}
			else
			{
			//��DataGrid��ʾ

				DataGrid1.CaptionText=comboBox_Class_Type.Text.ToString()+"-"
					+comboBox_Class.Text.ToString()+"  "
					+"����ѧ����Ϣ";

				str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
				
				DataGridTableStyle MyStyle =new DataGridTableStyle();
				MyStyle.MappingName = "TableIn";
				DataGrid1.TableStyles.Add(MyStyle);
				MyStyle.GridColumnStyles["���֤����"].Width=120;
				MyStyle.GridColumnStyles["�Ա�"].Width=30;
				MyStyle.GridColumnStyles["��ͥסַ"].Width=200;
				MyStyle.GridColumnStyles["��ϵ�绰"].Width=80;
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
			if(useExcel==true)
			{
				try
				{
					excelApp.Application.Workbooks.Close();
					excelApp.Application.Quit();
					excelApp.Quit();
					excelBook=null;
					excelSheet=null;
					excelApp=null;
					GC.Collect();
				}
				catch
				{
					throw new Exception("Excel �رմ���");
				}
			}

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
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_School = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_Class = new System.Windows.Forms.ComboBox();
			this.comboBox_Class_Type = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.label_ = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                                �ð�����ѧ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(20, 200);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(750, 350);
			this.DataGrid1.TabIndex = 45;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(368, 576);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 46;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.comboBox_School);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboBox_Class);
			this.groupBox1.Controls.Add(this.comboBox_Class_Type);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(72, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 112);
			this.groupBox1.TabIndex = 54;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "������ѡ��Ҫ������꼶�༶";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 53;
			this.label3.Text = "ѧУ";
			// 
			// comboBox_School
			// 
			this.comboBox_School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School.Location = new System.Drawing.Point(80, 32);
			this.comboBox_School.Name = "comboBox_School";
			this.comboBox_School.Size = new System.Drawing.Size(240, 20);
			this.comboBox_School.TabIndex = 52;
			this.comboBox_School.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 51;
			this.label2.Text = "�꼶";
			// 
			// comboBox_Class
			// 
			this.comboBox_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Class.Location = new System.Drawing.Point(232, 72);
			this.comboBox_Class.Name = "comboBox_Class";
			this.comboBox_Class.Size = new System.Drawing.Size(88, 20);
			this.comboBox_Class.TabIndex = 2;
			this.comboBox_Class.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Class_SelectionChangeCommitted);
			// 
			// comboBox_Class_Type
			// 
			this.comboBox_Class_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Class_Type.Location = new System.Drawing.Point(80, 72);
			this.comboBox_Class_Type.Name = "comboBox_Class_Type";
			this.comboBox_Class_Type.Size = new System.Drawing.Size(88, 20);
			this.comboBox_Class_Type.TabIndex = 1;
			this.comboBox_Class_Type.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Class_Type_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(184, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "�༶";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(232, 576);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 55;
			this.button1.Text = "��ӡ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "��",
																	  "Ů"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(432, 24);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 98;
			this.comboBox_School_Type.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_Type_SelectionChangeCommitted);
			// 
			// label_
			// 
			this.label_.Location = new System.Drawing.Point(352, 32);
			this.label_.Name = "label_";
			this.label_.Size = new System.Drawing.Size(56, 16);
			this.label_.TabIndex = 97;
			this.label_.Text = "ѧУ���";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 23);
			this.label4.TabIndex = 96;
			this.label4.Text = "����";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(104, 24);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 95;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// BrowseStudent
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 621);
			this.Controls.Add(this.comboBox_School_Type);
			this.Controls.Add(this.label_);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.DataGrid1);
			this.Name = "BrowseStudent";
			this.Text = "���ѧ����Ϣ";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{			
			this.Dispose();	
		}

		private void comboBox_Class_Type_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			string str_Sql;
			//�༶���������б��,��ѧУ�ĸð༶���͵����а༶�����б���ű�,�ð༶����û�а�Ļ��������������
			conn.BindComboBox("Select * FROM Class WHERE Class_Type_ID="+comboBox_Class_Type.SelectedValue.ToString()+"AND School_ID="+comboBox_School.SelectedValue.ToString(),comboBox_Class,"Class_ID","Class_Name");	
			
			if(comboBox_Class.Items.Count==0)
			{//�ð༶����û�а�Ļ��������������
				str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,Birthday As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ�� FROM Student WHERE Class_ID=-1";
				conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
				DataGrid1.CaptionText="";
				return;
			}
			else
			{//����ѡ�еİ༶,ˢ��DataGrid��ʾ
				str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");			

				DataGrid1.CaptionText=comboBox_Class_Type.Text.ToString()+"-"
					+comboBox_Class.Text.ToString()+"  "
					+"����ѧ����Ϣ";
				//DataGrid1.CaptionText=conn.Class_Type_IDtoWhat(comboBox_Class_Type.SelectedValue.ToString(),"Class_Type_Name")+"-"
				//	+conn.Class_IDtoWhat(comboBox_Class.SelectedValue.ToString(),"Class_Name")+"  "
				//	+"����ѧ����Ϣ";
			}
		}

		//�ı�ѡ�еİ༶,ˢ��DataGrid��ʾ�ð�ѧ����Ϣ
		private void comboBox_Class_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			string str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
			DataGrid1.CaptionText=comboBox_Class_Type.Text.ToString()+"-"
				+comboBox_Class.Text.ToString()+"  "
				+"����ѧ����Ϣ";
		}

		//����Excel�ļ�,�Ա��ӡ
		private void button1_Click(object sender, System.EventArgs e)
		{
			int i=0,j=0;

			useExcel=true;
			excelApp = new Excel.ApplicationClass();
			Excel.Workbook excelBook =excelApp.Workbooks.Add(1);
			Excel.Worksheet excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];

			if(conn.ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("�޿ɴ�ӡ���ݣ�", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				 return;
			}
	
			try
			{
				//���ñ�ͷ
				excelSheet.Cells[1,1]=comboBox_School.Text+"��"+comboBox_Class_Type.Text+"-"+conn.Class_IDtoWhat(comboBox_Class.SelectedValue.ToString(),"Class_Name");
				excelSheet.Cells[2,1]="���֤����";
				excelSheet.Cells[2,2]="����";
				excelSheet.Cells[2,3]="�Ա�";
				excelSheet.Cells[2,4]="��������";
				excelSheet.Cells[2,5]="����";
				excelSheet.Cells[2,6]="ĸ��";
				excelSheet.Cells[2,7]="�໤��";
				excelSheet.Cells[2,8]="��ϵ�绰";
				excelSheet.Cells[2,9]="��ͥסַ";

				excelSheet.Cells[2,10]="����ְҵ";
				excelSheet.Cells[2,11]="����ѧ��";
				excelSheet.Cells[2,12]="ĸ��ְҵ";
				excelSheet.Cells[2,13]="ĸ��ѧ��";

				excelSheet.Cells[2,14]="����";
				excelSheet.Cells[2,15]="���´�";
				excelSheet.Cells[2,16]="��ί��";

				//���ñ����ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,16]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,16]).Font.Bold = true;
			
				string str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
				//�����и���Ԫ��
				for(i=1;i<=conn.ds.Tables[0].Rows.Count;i++)
				{				
					for(j=1;j<=conn.ds.Tables[0].Columns.Count;j++)
					{
						excelSheet.Cells[i+2,j]="'"+conn.ds.Tables[0].Rows[i-1][j-1].ToString();
					}
				}
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Select();
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Columns.AutoFit();
			
				excelApp.Visible=true;
			}
			catch
			{
				throw new Exception("Excel error");
			}
		}

		private void comboBox_School_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//����ѡ���ѧУ�������б���ʾ��ѧУ��Ӧ�����а༶����
			conn.BindComboBox("Select * FROM Class_Type WHERE School_Type_ID_Class_Belong="+conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Type_ID"),comboBox_Class_Type,"Class_Type_ID","Class_Type_Name");
			//����ѡ���ѧУ��ѡ��İ༶���Ͱ������б���ʾ��ѧУ�����ְ༶���Ͷ�Ӧ�İ༶
			conn.BindComboBox("Select * FROM Class WHERE Class_Type_ID="+comboBox_Class_Type.SelectedValue.ToString()+"AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'",comboBox_Class,"Class_ID","Class_Name");	

			string str_Sql;
			if(comboBox_Class.Items.Count==0)
			{//�ð༶����û�а�Ļ��������������
				str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,Birthday As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ�� FROM Student WHERE Class_ID=-1";
				conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
				DataGrid1.CaptionText="";
				return;
			}
			else
			{//����ѡ�еİ༶,ˢ��DataGrid��ʾ
				str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");

				DataGrid1.CaptionText=comboBox_Class_Type.Text.ToString()+"-"
					+comboBox_Class.Text.ToString()+"  "
					+"����ѧ����Ϣ";
			}
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//��DataGrid��ʾ
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				//����ѡ���ѧУ�������б���ʾ��ѧУ��Ӧ�����а༶����
				conn.BindComboBox("Select * FROM Class_Type WHERE School_Type_ID_Class_Belong="+conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Type_ID"),comboBox_Class_Type,"Class_Type_ID","Class_Type_Name");
				//����ѡ���ѧУ��ѡ��İ༶���Ͱ������б���ʾ��ѧУ�����ְ༶���Ͷ�Ӧ�İ༶
				conn.BindComboBox("Select * FROM Class WHERE Class_Type_ID="+comboBox_Class_Type.SelectedValue.ToString()+"AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'",comboBox_Class,"Class_ID","Class_Name");	

				if(comboBox_Class.Items.Count==0)
				{//�ð༶����û�а�Ļ��������������
					str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,Birthday As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ�� FROM Student WHERE Class_ID=-1";
					conn.Fill(str_Sql);
					DataGrid1.SetDataBinding(conn.ds,"TableIn");
					DataGrid1.CaptionText="";
					return;
				}
				else
				{//����ѡ�еİ༶,ˢ��DataGrid��ʾ
					str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
					conn.Fill(str_Sql);
					DataGrid1.SetDataBinding(conn.ds,"TableIn");

					DataGrid1.CaptionText=comboBox_Class_Type.Text.ToString()+"-"
						+comboBox_Class.Text.ToString()+"  "
						+"����ѧ����Ϣ";
				}
			}
		
		}

		private void comboBox_School_Type_SelectionChangeCommitted(object sender, System.EventArgs e)
		{			
			//��DataGrid��ʾ
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				//����ѡ���ѧУ�������б���ʾ��ѧУ��Ӧ�����а༶����
				conn.BindComboBox("Select * FROM Class_Type WHERE School_Type_ID_Class_Belong="+conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Type_ID"),comboBox_Class_Type,"Class_Type_ID","Class_Type_Name");
				//����ѡ���ѧУ��ѡ��İ༶���Ͱ������б���ʾ��ѧУ�����ְ༶���Ͷ�Ӧ�İ༶
				conn.BindComboBox("Select * FROM Class WHERE Class_Type_ID="+comboBox_Class_Type.SelectedValue.ToString()+"AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'",comboBox_Class,"Class_ID","Class_Name");	

				if(comboBox_Class.Items.Count==0)
				{//�ð༶����û�а�Ļ��������������
					str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,Birthday As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ�� FROM Student WHERE Class_ID=-1";
					conn.Fill(str_Sql);
					DataGrid1.SetDataBinding(conn.ds,"TableIn");
					DataGrid1.CaptionText="";
					return;
				}
				else
				{//����ѡ�еİ༶,ˢ��DataGrid��ʾ
					str_Sql="SELECT Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ��,QuXian_Name AS ����,Office_Name AS ���´�,Committee_Name AS ��ί�� FROM View_StudentClass_Detail_City4 WHERE Class_ID="+comboBox_Class.SelectedValue+" AND School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
					conn.Fill(str_Sql);
					DataGrid1.SetDataBinding(conn.ds,"TableIn");

					DataGrid1.CaptionText=comboBox_Class_Type.Text.ToString()+"-"
						+comboBox_Class.Text.ToString()+"  "
						+"����ѧ����Ϣ";
				};
			}
		
		}
	}
}
