using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// BrowseClass 的摘要说明。
	/// </summary>
	public class BrowseClass : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_School;

		protected config conn=new config();

		//创建应用程序,工作表,工作簿
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.Label label_;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private Excel.Worksheet excelSheet;

		public BrowseClass()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
			
			//绑定DataGrid显示
			string str_Sql,errorstring;
			str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任,Student_Count AS 学生人数 FROM View_Class";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}

			str_Sql="Select * from School"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("请先输入学校信息！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;				
				return;
			}
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任,Student_Count AS 学生人数 FROM View_Class WHERE View_Class.School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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
					throw new Exception("Excel 关闭错误！");
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox_School = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.label_ = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
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
			this.DataGrid1.CaptionText = "                           该学校 现有所有班级情况";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(42, 130);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(500, 350);
			this.DataGrid1.TabIndex = 28;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(336, 520);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 35;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(168, 520);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 35;
			this.button1.Text = "打印";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox_School
			// 
			this.comboBox_School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School.Location = new System.Drawing.Point(88, 88);
			this.comboBox_School.Name = "comboBox_School";
			this.comboBox_School.Size = new System.Drawing.Size(240, 20);
			this.comboBox_School.TabIndex = 36;
			this.comboBox_School.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 37;
			this.label1.Text = "学校";
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "男",
																	  "女"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(416, 24);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 63;
			this.comboBox_School_Type.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_Type_SelectionChangeCommitted);
			// 
			// label_
			// 
			this.label_.Location = new System.Drawing.Point(336, 32);
			this.label_.Name = "label_";
			this.label_.Size = new System.Drawing.Size(56, 16);
			this.label_.TabIndex = 62;
			this.label_.Text = "学校类别";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 61;
			this.label2.Text = "区县";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(88, 24);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 60;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// BrowseClass
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(592, 573);
			this.Controls.Add(this.comboBox_School_Type);
			this.Controls.Add(this.label_);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_School);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.button1);
			this.Name = "BrowseClass";
			this.Text = "览班级信息";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();	
		}

		//生成Excel文件,以便打印
		private void button1_Click(object sender, System.EventArgs e)
		{
			useExcel=true;
			int i=0,j=0;

			excelApp = new Excel.ApplicationClass();
			Excel.Workbook excelBook =excelApp.Workbooks.Add(1);
			Excel.Worksheet excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];

			if(conn.ds.Tables[0].Rows.Count==0)
			{
				 MessageBox.Show("无可打印内容！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			try
			{
				//设置表头
				excelSheet.Cells[1,1]=conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Name");
				excelSheet.Cells[2,1]="班级代码";
				excelSheet.Cells[2,2]="班级类别";
				excelSheet.Cells[2,3]="班级名";
				excelSheet.Cells[2,4]="班主任";
				excelSheet.Cells[2,5]="学生人数";
			
				//设置表头格式
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,5]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,5]).Font.Bold = true;
			
				string str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任,Student_Count AS 学生人数 FROM View_Class WHERE View_Class.School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				string errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");

				//填充表中各单元格
				for(i=1;i<=conn.ds.Tables[0].Rows.Count;i++)
				{				
					for(j=1;j<=conn.ds.Tables[0].Columns.Count;j++)
					{
						excelSheet.Cells[i+2,j]="'"+conn.ds.Tables[0].Rows[i-1][j-1].ToString();
					}
				}
				//设置报表表格为最适应宽度
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

		//选择一个学校查看其所有的班级
		private void comboBox_School_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			string str_Sql,errorstring;
			str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任,Student_Count AS 学生人数 FROM View_Class WHERE View_Class.School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//绑定DataGrid显示
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任,Student_Count AS 学生人数 FROM View_Class WHERE View_Class.School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}		
		}

		private void comboBox_School_Type_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//绑定DataGrid显示
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任,Student_Count AS 学生人数 FROM View_Class WHERE View_Class.School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}
		
		}
	}
}
