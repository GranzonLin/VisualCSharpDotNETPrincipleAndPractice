using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// AddClass_Typ ��ժҪ˵����
	/// </summary>
	public class AddClass_Type : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid DataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_Class_Type_Name;
		private System.Windows.Forms.TextBox textBox_Class_Type_ID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1_School_Type;
		protected config conn=new config();

		public AddClass_Type()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//�����ݿ���ߴ洢��ѧУ���Ͱ������б�
			
			string str_Sql,errorstring;
			errorstring=conn.BindComboBox("Select * from School_Type",comboBox1_School_Type,"School_Type_ID","School_Type_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}

			//��ѧУ���ʹ���������ʾѧУ���͵�����,��DataGrid��ʾ
			str_Sql="SELECT Class_Type.Class_Type_ID AS �༶������,Class_Type.Class_Type_Name AS �༶�����,School_Type.School_Type_Name AS ѧУ����� FROM Class_Type inner join School_Type on Class_Type.School_Type_ID_Class_Belong=School_Type.School_Type_ID";
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("�������ݿ⣡", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.Dispose();				
			}
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			textBox_Class_Type_ID.Text=conn.GetMaxId("Class_Type_ID","Class_Type");
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
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Class_Type_Name = new System.Windows.Forms.TextBox();
			this.textBox_Class_Type_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1_School_Type = new System.Windows.Forms.ComboBox();
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
			this.DataGrid1.CaptionText = "            ���м��ְ༶������";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(80, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 300);
			this.DataGrid1.TabIndex = 8;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(240, 392);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 25;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(264, 352);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 24;
			this.label4.Text = "������ѧУ����";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(104, 352);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 23;
			this.label2.Text = "�������";
			// 
			// textBox_Class_Type_Name
			// 
			this.textBox_Class_Type_Name.Location = new System.Drawing.Point(168, 350);
			this.textBox_Class_Type_Name.Name = "textBox_Class_Type_Name";
			this.textBox_Class_Type_Name.Size = new System.Drawing.Size(80, 21);
			this.textBox_Class_Type_Name.TabIndex = 22;
			this.textBox_Class_Type_Name.Text = "";
			// 
			// textBox_Class_Type_ID
			// 
			this.textBox_Class_Type_ID.Enabled = false;
			this.textBox_Class_Type_ID.Location = new System.Drawing.Point(64, 350);
			this.textBox_Class_Type_ID.Name = "textBox_Class_Type_ID";
			this.textBox_Class_Type_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_Class_Type_ID.TabIndex = 20;
			this.textBox_Class_Type_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 352);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "���";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 392);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "ȷ�����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1_School_Type
			// 
			this.comboBox1_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1_School_Type.Location = new System.Drawing.Point(360, 350);
			this.comboBox1_School_Type.Name = "comboBox1_School_Type";
			this.comboBox1_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox1_School_Type.TabIndex = 26;
			this.comboBox1_School_Type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_School_Type_KeyPress);
			// 
			// AddClass_Type
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(536, 445);
			this.Controls.Add(this.comboBox1_School_Type);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_Class_Type_Name);
			this.Controls.Add(this.textBox_Class_Type_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "AddClass_Type";
			this.Text = "�༶������";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (conn.KickOut(textBox_Class_Type_Name.Text)=="") 
			{
				MessageBox.Show("��������༶�������ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_Class_Type_Name.Text.Length>15)
			{
				MessageBox.Show("�벻Ҫ��������༶�������ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			//ȥ��'"?%=�ո�,����༶���ͱ�
			string str_Sql,errorstring="";
			str_Sql="INSERT INTO Class_Type values("+textBox_Class_Type_ID.Text.Trim()+",'"
				+conn.KickOut(textBox_Class_Type_Name.Text.Trim())+"',"
				+comboBox1_School_Type.SelectedValue.ToString()+")";
			
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("δ�ɹ���ӣ��������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("�ɹ���ӣ�", "���ѣ�", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			
			//ˢ��DataGrid��ʾ,ѡ�����һ�з�ɫ��ʾ
			str_Sql="SELECT Class_Type.Class_Type_ID AS �༶������,Class_Type.Class_Type_Name AS �༶�����,School_Type.School_Type_Name AS ѧУ����� FROM Class_Type inner join School_Type on Class_Type.School_Type_ID=School_Type.School_Type_ID";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			DataGrid1.Select(conn.ds.Tables["TableIn"].Rows.Count-1);

			textBox_Class_Type_ID.Text=conn.GetMaxId("Class_Type_ID","Class_Type");

		}

		private void button2_Click(object sender, System.EventArgs e)
		{	
			this.Dispose();		
		}

		private void comboBox1_School_Type_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}
