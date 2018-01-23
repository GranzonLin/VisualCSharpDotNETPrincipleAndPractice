using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// StatisticsClass ��ժҪ˵����
	/// </summary>
	public class StatisticsClass : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		//����Ӧ�ó���,������,������
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_School;
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.Label label_;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private Excel.Worksheet excelSheet;

		public StatisticsClass()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			string str_Sql="Select * from School"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("��������ѧУ��Ϣ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;				
				return;
			}
			conn.BindComboBox("Select * FROM School Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
			
            str_Sql="Select * from View_Class_Statistics  WHERE View_Class_Statistics.ѧУ����='"+comboBox_School.SelectedValue.ToString()+"'";
			string errorstring=conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			DataGridTableStyle MyStyle =new DataGridTableStyle();
			MyStyle.MappingName = "TableIn";
			DataGrid1.TableStyles.Add(MyStyle);
			MyStyle.GridColumnStyles["ѧУ����"].Width=90;
			MyStyle.GridColumnStyles["ѧУ����"].Width=200;
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_School = new System.Windows.Forms.ComboBox();
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.label_ = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(313, 528);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 40;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(145, 528);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 39;
			this.button1.Text = "��ӡ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                 �༶��Ϣͳ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(30, 150);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 20;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(450, 350);
			this.DataGrid1.TabIndex = 38;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(88, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 42;
			this.label1.Text = "ѧУ";
			// 
			// comboBox_School
			// 
			this.comboBox_School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School.Location = new System.Drawing.Point(168, 104);
			this.comboBox_School.Name = "comboBox_School";
			this.comboBox_School.Size = new System.Drawing.Size(240, 20);
			this.comboBox_School.TabIndex = 41;
			this.comboBox_School.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_SelectionChangeCommitted);
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "��",
																	  "Ů"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(168, 64);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 67;
			this.comboBox_School_Type.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_Type_SelectionChangeCommitted);
			// 
			// label_
			// 
			this.label_.Location = new System.Drawing.Point(88, 72);
			this.label_.Name = "label_";
			this.label_.Size = new System.Drawing.Size(56, 16);
			this.label_.TabIndex = 66;
			this.label_.Text = "ѧУ���";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(88, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 65;
			this.label2.Text = "����";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(168, 24);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 64;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// StatisticsClass
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 573);
			this.Controls.Add(this.comboBox_School_Type);
			this.Controls.Add(this.label_);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_School);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "StatisticsClass";
			this.Text = "�༶��Ϣͳ��";
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
			string str_Sql;
			useExcel=true;
			int i=0,j=0;

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
				String str_SchoolName=conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Name");
				
				str_Sql="Select * from Class WHERE School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				string errorstring=conn.Fill(str_Sql);
				excelSheet.Cells[1,1]=str_SchoolName+" ���а༶ "+conn.ds.Tables[0].Rows.Count.ToString()+" ��";
				excelSheet.Cells[2,1]="ѧУ����";
				excelSheet.Cells[2,2]="ѧУ����";
				excelSheet.Cells[2,3]="�꼶";
				excelSheet.Cells[2,4]="����";

				//���ñ�ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,3]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,3]).Font.Bold = true;
							
				str_Sql="Select * from View_Class_Statistics  WHERE View_Class_Statistics.ѧУ����='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");

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
				//excelApp.Quit();
			}
			catch
			{
				throw new Exception("Excel error");
			}
		}

		private void comboBox_School_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			
			string str_Sql,errorstring;
			str_Sql="Select * from View_Class_Statistics  WHERE View_Class_Statistics.ѧУ����='"+comboBox_School.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//��DataGrid��ʾ
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="Select * from View_Class_Statistics  WHERE View_Class_Statistics.ѧУ����='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}
		}

		private void comboBox_School_Type_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//��DataGrid��ʾ
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="Select * from View_Class_Statistics  WHERE View_Class_Statistics.ѧУ����='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}
		}
	}
}
