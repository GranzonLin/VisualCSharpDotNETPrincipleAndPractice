using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// StatisticsStudent_City ��ժҪ˵����
	/// </summary>
	public class StatisticsStudent_City : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();
		
		//����Ӧ�ó���,������,������
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private System.Windows.Forms.Label label_StudentCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label_Class_Type_ID_chu;
		private System.Windows.Forms.Label label_Class_Type_ID_gao;
		private Excel.Worksheet excelSheet;

		public StatisticsStudent_City()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			/*
			string str_Sql="Select School_ID,Student_ID from Student"; 
			string errorstring=conn.Fill(str_Sql);
			label_StudentCount.Text=conn.ds.Tables[0].Rows.Count.ToString();*/

			string str_Sql="Select Count(*) AS CountHowmany from Student"; 
			string errorstring=conn.Fill(str_Sql);
			label_StudentCount.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();

            conn.ds.Clear();
			str_Sql="Select School_ID,Student_ID from View_StudentClass Where Class_Type_ID=12 OR Class_Type_ID=13 OR Class_Type_ID=14"; 
			errorstring=conn.Fill(str_Sql);
			label_Class_Type_ID_chu.Text=conn.ds.Tables[0].Rows.Count.ToString();

			conn.ds.Clear();
			str_Sql="Select School_ID,Student_ID from View_StudentClass Where Class_Type_ID=15 OR Class_Type_ID=16 OR Class_Type_ID=17"; 
			errorstring=conn.Fill(str_Sql);
			label_Class_Type_ID_gao.Text=conn.ds.Tables[0].Rows.Count.ToString();

			conn.ds.Clear();
			str_Sql="Select * from View_City_Student_Statistics"; 
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
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.label_StudentCount = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label_Class_Type_ID_chu = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label_Class_Type_ID_gao = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 50;
			this.label1.Text = "��Ͻ������ѧ��";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 343);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 47;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(72, 343);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 46;
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
			this.DataGrid1.CaptionText = "          ��Ͻ��ѧ����Ϣͳ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(50, 69);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 20;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(250, 200);
			this.DataGrid1.TabIndex = 45;
			// 
			// label_StudentCount
			// 
			this.label_StudentCount.Location = new System.Drawing.Point(160, 23);
			this.label_StudentCount.Name = "label_StudentCount";
			this.label_StudentCount.Size = new System.Drawing.Size(56, 23);
			this.label_StudentCount.TabIndex = 49;
			this.label_StudentCount.Text = "����ѧУ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 48;
			this.label2.Text = "��";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 288);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 53;
			this.label3.Text = "���г��в�";
			// 
			// label_Class_Type_ID_chu
			// 
			this.label_Class_Type_ID_chu.Location = new System.Drawing.Point(152, 288);
			this.label_Class_Type_ID_chu.Name = "label_Class_Type_ID_chu";
			this.label_Class_Type_ID_chu.Size = new System.Drawing.Size(56, 23);
			this.label_Class_Type_ID_chu.TabIndex = 52;
			this.label_Class_Type_ID_chu.Text = "12,13,14";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(232, 288);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 23);
			this.label5.TabIndex = 51;
			this.label5.Text = "��";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(48, 320);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 23);
			this.label6.TabIndex = 53;
			this.label6.Text = "���и��в�";
			// 
			// label_Class_Type_ID_gao
			// 
			this.label_Class_Type_ID_gao.Location = new System.Drawing.Point(152, 320);
			this.label_Class_Type_ID_gao.Name = "label_Class_Type_ID_gao";
			this.label_Class_Type_ID_gao.Size = new System.Drawing.Size(56, 23);
			this.label_Class_Type_ID_gao.TabIndex = 52;
			this.label_Class_Type_ID_gao.Text = "15,16,17";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(232, 320);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 23);
			this.label8.TabIndex = 51;
			this.label8.Text = "��";
			// 
			// StatisticsStudent_City
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(360, 389);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label_Class_Type_ID_chu);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.label_StudentCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label_Class_Type_ID_gao);
			this.Controls.Add(this.label8);
			this.Name = "StatisticsStudent_City";
			this.Text = "��Ͻ��ѧ����Ϣͳ��";
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
				excelSheet.Cells[1,1]=" ��Ͻ������ѧ��"+label_StudentCount.Text+"��";
				excelSheet.Cells[2,1]="ѧУ����";
				excelSheet.Cells[2,2]="����";

				//���ñ�ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).Font.Bold = true;
							
				string str_Sql="Select * from View_City_Student_Statistics"; 
				string errorstring=conn.Fill(str_Sql);
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
	}
}
