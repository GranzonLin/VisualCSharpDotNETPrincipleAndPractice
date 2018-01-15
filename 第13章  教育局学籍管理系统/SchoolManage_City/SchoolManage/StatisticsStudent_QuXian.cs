using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// StatisticsStudent_QuXian ��ժҪ˵����
	/// </summary>
	public class StatisticsStudent_QuXian : System.Windows.Forms.Form
	{
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label_Count;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label_Class_Type_ID_chu;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label_Class_Type_ID_gao;
		private System.Windows.Forms.Label label8;
		private Excel.Worksheet excelSheet;

		public StatisticsStudent_QuXian()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			
			conn.BindComboBox("Select * FROM QuXian WHERE QuXian_ID<>9",comboBox_QuXian,"QuXian_Code","QuXian_Name");	
			
			/*
Count(*) AS CountHowmany
[0]["CountHowmany"].ToString();

			string str_Sql="Select * from View_StudentSchool WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_Count.Text=conn.ds.Tables[0].Rows.Count.ToString();*/

			string str_Sql="Select Count(*) AS CountHowmany from View_StudentSchool WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_Count.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();
			
			conn.ds.Clear();
			str_Sql="Select View_StudentClass.School_ID,Student_ID from View_StudentClass inner join School on View_StudentClass.School_ID=School.School_ID Where (Class_Type_ID=12 OR Class_Type_ID=13 OR Class_Type_ID=14) AND School.QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			label_Class_Type_ID_chu.Text=conn.ds.Tables[0].Rows.Count.ToString();

			conn.ds.Clear();
			str_Sql="Select View_StudentClass.School_ID,Student_ID from View_StudentClass inner join School on View_StudentClass.School_ID=School.School_ID Where (Class_Type_ID=15 OR Class_Type_ID=16 OR Class_Type_ID=17) AND School.QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			label_Class_Type_ID_gao.Text=conn.ds.Tables[0].Rows.Count.ToString();
			
			conn.ds.Clear();
			str_Sql="select * FROM View_QuXian_Student_Statistics WHERE ���ش���='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			DataGridTableStyle MyStyle =new DataGridTableStyle();
			MyStyle.MappingName = "TableIn";
			DataGrid1.TableStyles.Add(MyStyle);
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
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.label_Count = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label_Class_Type_ID_chu = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label_Class_Type_ID_gao = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 392);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 58;
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
			this.DataGrid1.CaptionText = "          ������ѧ����Ϣͳ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(50, 70);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 20;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(350, 250);
			this.DataGrid1.TabIndex = 57;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 392);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 59;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label_Count
			// 
			this.label_Count.Location = new System.Drawing.Point(248, 24);
			this.label_Count.Name = "label_Count";
			this.label_Count.Size = new System.Drawing.Size(56, 23);
			this.label_Count.TabIndex = 55;
			this.label_Count.Text = "����";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(328, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 54;
			this.label2.Text = "��";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.ItemHeight = 12;
			this.comboBox_QuXian.Location = new System.Drawing.Point(96, 24);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(112, 20);
			this.comboBox_QuXian.TabIndex = 56;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(120, 336);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 64;
			this.label3.Text = "���г��в�";
			// 
			// label_Class_Type_ID_chu
			// 
			this.label_Class_Type_ID_chu.Location = new System.Drawing.Point(224, 336);
			this.label_Class_Type_ID_chu.Name = "label_Class_Type_ID_chu";
			this.label_Class_Type_ID_chu.Size = new System.Drawing.Size(56, 23);
			this.label_Class_Type_ID_chu.TabIndex = 63;
			this.label_Class_Type_ID_chu.Text = "12,13,14";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(304, 336);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 23);
			this.label5.TabIndex = 60;
			this.label5.Text = "��";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(120, 368);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 23);
			this.label6.TabIndex = 65;
			this.label6.Text = "���и��в�";
			// 
			// label_Class_Type_ID_gao
			// 
			this.label_Class_Type_ID_gao.Location = new System.Drawing.Point(224, 368);
			this.label_Class_Type_ID_gao.Name = "label_Class_Type_ID_gao";
			this.label_Class_Type_ID_gao.Size = new System.Drawing.Size(56, 23);
			this.label_Class_Type_ID_gao.TabIndex = 62;
			this.label_Class_Type_ID_gao.Text = "15,16,17";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(304, 368);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 23);
			this.label8.TabIndex = 61;
			this.label8.Text = "��";
			// 
			// StatisticsStudent_QuXian
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(456, 437);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label_Class_Type_ID_chu);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label_Class_Type_ID_gao);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.label_Count);
			this.Controls.Add(this.label2);
			this.Name = "StatisticsStudent_QuXian";
			this.Text = "������ѧ����Ϣͳ��";
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
			string str_Sql,errorstring;
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
				excelSheet.Cells[1,1]=comboBox_QuXian.Text+" ����ѧ�� "+label_Count.Text+" ��";
				excelSheet.Cells[2,1]="ѧУ����";
				excelSheet.Cells[2,2]="���ش���";
				excelSheet.Cells[2,3]="����";
				excelSheet.Cells[2,4]="����";
				//���ñ�ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).Font.Bold = true;
							
				str_Sql="select * FROM View_QuXian_Student_Statistics WHERE ���ش���='"+comboBox_QuXian.SelectedValue.ToString()+"'";
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
			
                excelSheet.Cells[i+3,1]="���г��в�";				
				excelSheet.Cells[i+3,2]=label_Class_Type_ID_chu.Text;
				excelSheet.Cells[i+3,3]="��";

				excelSheet.Cells[i+4,1]="���и��в�";				
				excelSheet.Cells[i+4,2]=label_Class_Type_ID_gao.Text;
				excelSheet.Cells[i+4,3]="��";

				excelApp.Visible=true;
				//excelApp.Quit();
			}
			catch
			{
				throw new Exception("Excel error");
			}		
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			/*string str_Sql="Select * from View_StudentSchool WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_Count.Text=conn.ds.Tables[0].Rows.Count.ToString();
			*/
			string str_Sql="Select Count(*) AS CountHowmany from View_StudentSchool WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_Count.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();			
			
			conn.ds.Clear();
			str_Sql="Select View_StudentClass.School_ID,Student_ID from View_StudentClass inner join School on View_StudentClass.School_ID=School.School_ID Where (Class_Type_ID=12 OR Class_Type_ID=13 OR Class_Type_ID=14) AND School.QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			label_Class_Type_ID_chu.Text=conn.ds.Tables[0].Rows.Count.ToString();

			conn.ds.Clear();
			str_Sql="Select View_StudentClass.School_ID,Student_ID from View_StudentClass inner join School on View_StudentClass.School_ID=School.School_ID Where (Class_Type_ID=15 OR Class_Type_ID=16 OR Class_Type_ID=17) AND School.QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			label_Class_Type_ID_gao.Text=conn.ds.Tables[0].Rows.Count.ToString();
			
			conn.ds.Clear();
			str_Sql="select * FROM View_QuXian_Student_Statistics WHERE ���ش���='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
		}
	}
}
