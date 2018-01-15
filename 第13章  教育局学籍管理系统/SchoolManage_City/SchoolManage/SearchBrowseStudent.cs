using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// SearchBrowseStudent ��ժҪ˵����
	/// </summary>
	public class SearchBrowseStudent : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_Student_ID;
		private System.Windows.Forms.TextBox textBox_Name;
		private System.Windows.Forms.ComboBox comboBox_Sex;
		private System.Windows.Forms.TextBox textBox_Father;
		private System.Windows.Forms.TextBox textBox_Mother;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid DataGrid1;

		protected config conn=new config();

		//����Ӧ�ó���,������,������
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.CheckBox checkBox_InQuXian;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_Student_QuXian;
		private System.Windows.Forms.CheckBox checkBox_Student_QuXian;
		private Excel.Worksheet excelSheet;

		public SearchBrowseStudent()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//������������
			string errorstring;
			errorstring=conn.ExeSql("Select * FROM School");
			if(errorstring!="OK")
			{
				MessageBox.Show("���鱾�����ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}

			string str_Sql="Select * from Class"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("��������༶��Ϣ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;				
				return;
			}
			
			//conn.BindComboBox("Select * FROM School Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");
			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT QuXian_ID,QuXian_Name FROM QuXian",comboBox_Student_QuXian,"QuXian_ID","QuXian_Name");
			
			str_Sql="SELECT School_Name AS ѧУ����,Class_Type_Name AS �꼶,Class_Name AS �༶,Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ�� FROM View_StudentClass_Detail_City Where School_ID='000'";//"+comboBox_School.SelectedValue+"'";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("����ʧ�ܣ��������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
			DataGridTableStyle MyStyle =new DataGridTableStyle();
			MyStyle.MappingName = "TableIn";
			DataGrid1.TableStyles.Add(MyStyle);
			MyStyle.GridColumnStyles["ѧУ����"].Width=150;
			MyStyle.GridColumnStyles["���֤����"].Width=120;
			MyStyle.GridColumnStyles["�Ա�"].Width=30;
			MyStyle.GridColumnStyles["��ͥסַ"].Width=200;
			MyStyle.GridColumnStyles["��ϵ�绰"].Width=80;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.checkBox_InQuXian = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox_Mother = new System.Windows.Forms.TextBox();
			this.textBox_Father = new System.Windows.Forms.TextBox();
			this.comboBox_Sex = new System.Windows.Forms.ComboBox();
			this.textBox_Name = new System.Windows.Forms.TextBox();
			this.textBox_Student_ID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_Student_QuXian = new System.Windows.Forms.ComboBox();
			this.checkBox_Student_QuXian = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox_QuXian);
			this.groupBox1.Controls.Add(this.checkBox_InQuXian);
			this.groupBox1.Location = new System.Drawing.Point(64, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 56);
			this.groupBox1.TabIndex = 57;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "��֪ѧ������ѧУ������";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 55;
			this.label1.Text = "����";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(80, 17);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 54;
			// 
			// checkBox_InQuXian
			// 
			this.checkBox_InQuXian.Location = new System.Drawing.Point(336, 20);
			this.checkBox_InQuXian.Name = "checkBox_InQuXian";
			this.checkBox_InQuXian.Size = new System.Drawing.Size(120, 24);
			this.checkBox_InQuXian.TabIndex = 52;
			this.checkBox_InQuXian.Text = "��ĳ�����ڲ�ѯ";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(656, 192);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 56;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox_Mother);
			this.groupBox2.Controls.Add(this.textBox_Father);
			this.groupBox2.Controls.Add(this.comboBox_Sex);
			this.groupBox2.Controls.Add(this.textBox_Name);
			this.groupBox2.Controls.Add(this.textBox_Student_ID);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Location = new System.Drawing.Point(64, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 88);
			this.groupBox2.TabIndex = 58;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "��ѧУ�ڲ�ѯ������ģ����ѯ��";
			// 
			// textBox_Mother
			// 
			this.textBox_Mother.Location = new System.Drawing.Point(376, 56);
			this.textBox_Mother.Name = "textBox_Mother";
			this.textBox_Mother.Size = new System.Drawing.Size(56, 21);
			this.textBox_Mother.TabIndex = 56;
			this.textBox_Mother.Text = "";
			// 
			// textBox_Father
			// 
			this.textBox_Father.Location = new System.Drawing.Point(240, 56);
			this.textBox_Father.Name = "textBox_Father";
			this.textBox_Father.Size = new System.Drawing.Size(56, 21);
			this.textBox_Father.TabIndex = 55;
			this.textBox_Father.Text = "";
			// 
			// comboBox_Sex
			// 
			this.comboBox_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Sex.Items.AddRange(new object[] {
															  "��",
															  "Ů"});
			this.comboBox_Sex.Location = new System.Drawing.Point(112, 56);
			this.comboBox_Sex.Name = "comboBox_Sex";
			this.comboBox_Sex.Size = new System.Drawing.Size(48, 20);
			this.comboBox_Sex.TabIndex = 54;
			// 
			// textBox_Name
			// 
			this.textBox_Name.Location = new System.Drawing.Point(376, 24);
			this.textBox_Name.Name = "textBox_Name";
			this.textBox_Name.Size = new System.Drawing.Size(56, 21);
			this.textBox_Name.TabIndex = 53;
			this.textBox_Name.Text = "";
			// 
			// textBox_Student_ID
			// 
			this.textBox_Student_ID.Location = new System.Drawing.Point(112, 24);
			this.textBox_Student_ID.Name = "textBox_Student_ID";
			this.textBox_Student_ID.Size = new System.Drawing.Size(184, 21);
			this.textBox_Student_ID.TabIndex = 52;
			this.textBox_Student_ID.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 51;
			this.label3.Text = "���֤����";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(328, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 51;
			this.label4.Text = "����";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.TabIndex = 51;
			this.label5.Text = "�Ա�";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(200, 58);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 16);
			this.label6.TabIndex = 51;
			this.label6.Text = "����";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(328, 58);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 16);
			this.label7.TabIndex = 51;
			this.label7.Text = "ĸ��";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(544, 152);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 56;
			this.button1.Text = "����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(544, 192);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 59;
			this.button3.Text = "��ӡ";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                                ����������ѧ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(30, 250);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 40;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(750, 350);
			this.DataGrid1.TabIndex = 60;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.comboBox_Student_QuXian);
			this.groupBox3.Controls.Add(this.checkBox_Student_QuXian);
			this.groupBox3.Location = new System.Drawing.Point(64, 72);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(480, 56);
			this.groupBox3.TabIndex = 61;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "��֪ѧ����������";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 55;
			this.label2.Text = "����";
			// 
			// comboBox_Student_QuXian
			// 
			this.comboBox_Student_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Student_QuXian.Location = new System.Drawing.Point(80, 17);
			this.comboBox_Student_QuXian.Name = "comboBox_Student_QuXian";
			this.comboBox_Student_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_Student_QuXian.TabIndex = 54;
			// 
			// checkBox_Student_QuXian
			// 
			this.checkBox_Student_QuXian.Location = new System.Drawing.Point(336, 20);
			this.checkBox_Student_QuXian.Name = "checkBox_Student_QuXian";
			this.checkBox_Student_QuXian.Size = new System.Drawing.Size(120, 24);
			this.checkBox_Student_QuXian.TabIndex = 52;
			this.checkBox_Student_QuXian.Text = "��ĳ�����ڲ�ѯ";
			// 
			// SearchBrowseStudent
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(808, 621);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "SearchBrowseStudent";
			this.Text = "��ѯѧ����Ϣ";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{			
			string str_Sql,errorstring;
			bool HadSome=false;
			str_Sql="SELECT School_Name AS ѧУ����,Class_Type_Name AS �꼶,Class_Name AS �༶,Student_ID As ���֤����,Name As ����,Sex AS �Ա�,convert(char(10),Birthday,120) As ��������,Father AS ����,Mother AS ĸ��,Keeper AS �໤��,StudentTel AS ��ϵ�绰,Student_Address AS ��ͥסַ,Father_Job AS ����ְҵ,Father_XueLi AS ����ѧ��,Mother_Job AS ĸ��ְҵ,Mother_XueLi AS ĸ��ѧ�� FROM View_StudentClass_Detail_City";
		
			//�����������������������,���ҵ������ݺ�DataGrid��
			if(checkBox_InQuXian.Checked==true)
			{
				str_Sql=str_Sql+" Where School_ID Like '____"+comboBox_QuXian.SelectedValue+"%'";
				HadSome=true;
			 }
			if(checkBox_Student_QuXian.Checked==true)
			{
				str_Sql=str_Sql+" Where QuXian_ID ="+comboBox_Student_QuXian.SelectedValue;
				HadSome=true;
			 }
			if(textBox_Student_ID.Text!="")
			{
				if(HadSome==false)str_Sql=str_Sql+" Where Student_ID LIKE '%"+textBox_Student_ID.Text+"%'";
				else str_Sql=str_Sql+" AND Student_ID LIKE '%"+conn.KickOut(textBox_Student_ID.Text)+"%'";
				HadSome=true;
			}
			if(textBox_Name.Text!="")
			{
				if(HadSome==false)str_Sql=str_Sql+" Where Name LIKE '%"+conn.KickOut(textBox_Name.Text)+"%'";
				else str_Sql=str_Sql+" AND Name LIKE '%"+textBox_Name.Text+"%'";
				HadSome=true;
			}
			if(textBox_Father.Text!="")
			{
				if(HadSome==false)str_Sql=str_Sql+" Where Father LIKE '%"+conn.KickOut(textBox_Father.Text)+"%'";
				else str_Sql=str_Sql+" AND Father LIKE '%"+textBox_Father.Text+"%'";
				HadSome=true;
			}
			if(textBox_Mother.Text!="")
			{
				if(HadSome==false)str_Sql=str_Sql+" Where Mother LIKE '%"+conn.KickOut(textBox_Mother.Text)+"%'";
				else str_Sql=str_Sql+" AND Mother LIKE '%"+textBox_Mother.Text+"%'";
				HadSome=true;
			}
			if(comboBox_Sex.Text!="")
			{
				if(HadSome==false)str_Sql=str_Sql+" Where Sex= '"+comboBox_Sex.SelectedItem+"'";
				else str_Sql=str_Sql+" AND Sex= '"+comboBox_Sex.SelectedItem+"'";
				HadSome=true;
			}

			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("����ʧ�ܣ��������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(conn.ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("�޿ɴ�ӡ���ݣ�", "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			int i,j=0;
	
			useExcel=true;
			excelApp = new Excel.ApplicationClass();
			Excel.Workbook excelBook =excelApp.Workbooks.Add(1);
			Excel.Worksheet excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];

			try
			{
				//���ñ�ͷ
				excelSheet.Cells[1,1]=" ����������ѧ����";
				excelSheet.Cells[2,1]="ѧУ��";
				excelSheet.Cells[2,2]="�꼶";
				excelSheet.Cells[2,3]="�༶";
				excelSheet.Cells[2,4]="���֤����";
				excelSheet.Cells[2,5]="����";
				excelSheet.Cells[2,6]="�Ա�";
				excelSheet.Cells[2,7]="��������";
				excelSheet.Cells[2,8]="����";
				excelSheet.Cells[2,9]="ĸ��";
				excelSheet.Cells[2,10]="�໤��";
				excelSheet.Cells[2,11]="��ϵ�绰";
				excelSheet.Cells[2,12]="��ͥסַ";

				excelSheet.Cells[2,13]="����ְҵ";
				excelSheet.Cells[2,14]="����ѧ��";
				excelSheet.Cells[2,15]="ĸ��ְҵ";
				excelSheet.Cells[2,16]="ĸ��ѧ��";
			
				//���ñ�ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,16]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,16]).Font.Bold = true;
			
				//�����и���Ԫ��
				for(i=1;i<=conn.ds.Tables[0].Rows.Count;i++)
				{				
					for(j=1;j<=conn.ds.Tables[0].Columns.Count;j++)
					{
						excelSheet.Cells[i+2,j]="'"+conn.ds.Tables[0].Rows[i-1][j-1].ToString();
					}
				}

				//���ñ�����Ϊ����Ӧ���
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Select();
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Columns.AutoFit();

				excelApp.Visible=true;
			}
			catch
			{
				throw new Exception("Excel error");
			}
		}
	
	}
}
