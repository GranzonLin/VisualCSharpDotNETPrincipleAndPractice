using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// NonlegalData ��ժҪ˵����
	/// </summary>
	public class NonlegalData : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
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

		public NonlegalData()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			string str_Sql="Select  School_ID AS ѧУ����,School_Name AS ѧУ����,Class_Type_Name AS �༶���,Class_Name AS �༶�� FROM View_ClassSchool inner join Class_Type on View_ClassSchool.Class_Type_ID=Class_Type.Class_Type_ID WHERE (View_ClassSchool.School_Type_ID=0 AND(View_ClassSchool.Class_Type_ID>5 OR View_ClassSchool.Class_Type_ID<0)) OR (View_ClassSchool.School_Type_ID=1 AND(View_ClassSchool.Class_Type_ID<6 OR View_ClassSchool.Class_Type_ID>8)) OR (View_ClassSchool.School_Type_ID=2 AND(View_ClassSchool.Class_Type_ID<9 OR View_ClassSchool.Class_Type_ID>11)) OR (View_ClassSchool.School_Type_ID=3 AND(View_ClassSchool.Class_Type_ID<12 OR View_ClassSchool.Class_Type_ID>17)) OR (View_ClassSchool.School_Type_ID=4 AND(View_ClassSchool.Class_Type_ID<18 OR View_ClassSchool.Class_Type_ID>26)) OR (View_ClassSchool.School_Type_ID=5 AND(View_ClassSchool.Class_Type_ID<30 OR View_ClassSchool.Class_Type_ID>32)) OR (View_ClassSchool.School_Type_ID=6 AND(View_ClassSchool.Class_Type_ID<33 OR View_ClassSchool.Class_Type_ID>44))"; 
			string errorstring=conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

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
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
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
			this.DataGrid1.CaptionText = "                ���в�����༶���";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(40, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(600, 300);
			this.DataGrid1.TabIndex = 45;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(360, 368);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 47;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(192, 368);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 46;
			this.button1.Text = "��ӡ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// NonlegalData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(680, 413);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "NonlegalData";
			this.Text = "�Ƿ����ݲ�ѯ";
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

			string str_Sql="Select  School_ID AS ѧУ����,School_Name AS ѧУ����,Class_Type_Name AS �༶���,Class_Name AS �༶�� FROM View_ClassSchool inner join Class_Type on View_ClassSchool.Class_Type_ID=Class_Type.Class_Type_ID WHERE (View_ClassSchool.School_Type_ID=0 AND(View_ClassSchool.Class_Type_ID>5 OR View_ClassSchool.Class_Type_ID<0)) OR (View_ClassSchool.School_Type_ID=1 AND(View_ClassSchool.Class_Type_ID<6 OR View_ClassSchool.Class_Type_ID>8)) OR (View_ClassSchool.School_Type_ID=2 AND(View_ClassSchool.Class_Type_ID<9 OR View_ClassSchool.Class_Type_ID>11)) OR (View_ClassSchool.School_Type_ID=3 AND(View_ClassSchool.Class_Type_ID<12 OR View_ClassSchool.Class_Type_ID>17)) OR (View_ClassSchool.School_Type_ID=4 AND(View_ClassSchool.Class_Type_ID<18 OR View_ClassSchool.Class_Type_ID>26)) OR (View_ClassSchool.School_Type_ID=5 AND(View_ClassSchool.Class_Type_ID<30 OR View_ClassSchool.Class_Type_ID>32)) OR (View_ClassSchool.School_Type_ID=6 AND(View_ClassSchool.Class_Type_ID<33 OR View_ClassSchool.Class_Type_ID>44))"; 
			
			try
			{
				//���ñ�ͷ
				excelSheet.Cells[1,1]="ѧУ����";
				excelSheet.Cells[1,2]="ѧУ����";
				excelSheet.Cells[1,3]="�༶���";
				excelSheet.Cells[1,4]="�༶��";
			
				//���ñ���ͷ��ʽ
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[1,4]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[1,4]).Font.Bold = true;
			
				//�����и���Ԫ��
				for(i=1;i<=conn.ds.Tables[0].Rows.Count;i++)
				{				
					for(j=1;j<=conn.ds.Tables[0].Columns.Count;j++)
					{
						excelSheet.Cells[i+1,j]="'"+conn.ds.Tables[0].Rows[i-1][j-1].ToString();
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
	}
}
