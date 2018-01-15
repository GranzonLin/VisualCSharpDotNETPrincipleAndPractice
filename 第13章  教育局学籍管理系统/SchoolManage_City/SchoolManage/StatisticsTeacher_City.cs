using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// StatisticsTeacher_City ��ժҪ˵����
	/// </summary>
	public class StatisticsTeacher_City : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_TeacherCount;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		
		protected config conn=new config();

		//����Ӧ�ó���,������,������
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private Excel.Worksheet excelSheet;

		public StatisticsTeacher_City()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			/*
Count(*) AS CountHowmany
[0]["CountHowmany"].ToString();

			string str_Sql="Select * from Teacher"; 
			string errorstring=conn.Fill(str_Sql);
			label_TeacherCount.Text=conn.ds.Tables[0].Rows.Count.ToString();*/
			string str_Sql="Select Count(*) AS CountHowmany from Teacher"; 
			string errorstring=conn.Fill(str_Sql);
			label_TeacherCount.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();

			conn.ds.Clear();
			str_Sql="Select * from View_City_Teacher_Statistics"; 
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
			this.label_TeacherCount = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(93, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 50;
			this.label1.Text = "���н�ʦ";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(229, 339);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 47;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(109, 339);
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
			this.DataGrid1.CaptionText = "          ��Ͻ����ʦ��Ϣͳ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(83, 65);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 20;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(250, 250);
			this.DataGrid1.TabIndex = 45;
			// 
			// label_TeacherCount
			// 
			this.label_TeacherCount.Location = new System.Drawing.Point(181, 19);
			this.label_TeacherCount.Name = "label_TeacherCount";
			this.label_TeacherCount.Size = new System.Drawing.Size(56, 23);
			this.label_TeacherCount.TabIndex = 49;
			this.label_TeacherCount.Text = "����ѧУ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(261, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 48;
			this.label2.Text = "��";
			// 
			// StatisticsTeacher_City
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(416, 381);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.label_TeacherCount);
			this.Controls.Add(this.label2);
			this.Name = "StatisticsTeacher_City";
			this.Text = "��Ͻ����ʦ��Ϣͳ��";
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
				excelSheet.Cells[1,1]=" ���н�ʦ"+label_TeacherCount.Text+"��";
				excelSheet.Cells[2,1]="ѧ��";
				excelSheet.Cells[2,2]="����";

				//���ñ�ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).Font.Bold = true;
							
				string str_Sql="Select * from View_City_Teacher_Statistics"; 
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
