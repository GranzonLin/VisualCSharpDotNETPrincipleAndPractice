using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// StatisticsClass_City ��ժҪ˵����
	/// </summary>
	public class StatisticsClass_City : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_ClassCount;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		//����Ӧ�ó���,������,������
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private System.Windows.Forms.DataGrid DataGrid1;
		private Excel.Worksheet excelSheet;

		public StatisticsClass_City()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			/*
Count(*) AS CountHowmany
["CountHowmany"].ToString();

			string str_Sql="Select * from Class"; 
			string errorstring=conn.Fill(str_Sql);
			label_ClassCount.Text=conn.ds.Tables[0].Rows.Count.ToString();*/

			string str_Sql="Select Count(*) AS CountHowmany from Class"; 
			string errorstring=conn.Fill(str_Sql);
			label_ClassCount.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();

			conn.ds.Clear();
			str_Sql="Select * from View_City_Class_Statistics"; 
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label_ClassCount = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(296, 448);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 43;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 448);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 42;
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
			this.DataGrid1.CaptionText = "                             ��Ͻ���༶��Ϣͳ��";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(30, 70);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 20;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(450, 350);
			this.DataGrid1.TabIndex = 41;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(96, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 47;
			this.label1.Text = "��Ͻ�����а༶";
			// 
			// label_ClassCount
			// 
			this.label_ClassCount.Location = new System.Drawing.Point(200, 16);
			this.label_ClassCount.Name = "label_ClassCount";
			this.label_ClassCount.Size = new System.Drawing.Size(56, 23);
			this.label_ClassCount.TabIndex = 46;
			this.label_ClassCount.Text = "����";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(280, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 45;
			this.label2.Text = "��";
			// 
			// StatisticsClass_City
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 493);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_ClassCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "StatisticsClass_City";
			this.Text = "��Ͻ���༶��Ϣͳ��";
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
				excelSheet.Cells[1,1]=" ���а༶"+label_ClassCount.Text+"��";
				excelSheet.Cells[2,1]="ѧУ����";
				excelSheet.Cells[2,2]="�༶����";
				excelSheet.Cells[2,3]="����";

				//���ñ�ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).Font.Bold = true;
							
				string str_Sql="Select * from View_City_Class_Statistics"; 
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
