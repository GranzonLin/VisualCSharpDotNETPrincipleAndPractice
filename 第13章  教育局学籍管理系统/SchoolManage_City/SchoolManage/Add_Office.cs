using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// Add_Office ��ժҪ˵����
	/// </summary>
	public class Add_Office : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.TextBox textBox_Office_Name;
		private System.Windows.Forms.ComboBox comboBox1_QuXian_ID;
		private System.Windows.Forms.Label label4;

		protected config conn=new config();
		private System.Windows.Forms.TextBox textBox_Office_ID;

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Add_Office()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			
			//�����ݿ���ߴ洢�����ذ������б�
			string str_Sql,errorstring;
			errorstring=conn.BindComboBox("Select * from QuXian WHERE QuXian_ID<>9",comboBox1_QuXian_ID,"QuXian_ID","QuXian_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
								 MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}

			//�����ش���������ʾ��������,��DataGrid��ʾ
			str_Sql="SELECT Office.Office_ID AS ���´�����,Office.Office_Name AS ���´�����,QuXian.QuXian_Name AS �������� FROM QuXian inner join Office on QuXian.QuXian_ID=Office.QuXian_ID_OfficeIn";

			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
			textBox_Office_ID.Text=conn.GetMaxId("Office_ID","Office");
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
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Office_Name = new System.Windows.Forms.TextBox();
			this.textBox_Office_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.comboBox1_QuXian_ID = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(272, 424);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 41;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(128, 376);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 40;
			this.label2.Text = "���´�����";
			// 
			// textBox_Office_Name
			// 
			this.textBox_Office_Name.Location = new System.Drawing.Point(192, 376);
			this.textBox_Office_Name.Name = "textBox_Office_Name";
			this.textBox_Office_Name.Size = new System.Drawing.Size(104, 21);
			this.textBox_Office_Name.TabIndex = 39;
			this.textBox_Office_Name.Text = "";
			// 
			// textBox_Office_ID
			// 
			this.textBox_Office_ID.Enabled = false;
			this.textBox_Office_ID.Location = new System.Drawing.Point(80, 376);
			this.textBox_Office_ID.Name = "textBox_Office_ID";
			this.textBox_Office_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_Office_ID.TabIndex = 38;
			this.textBox_Office_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 376);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 37;
			this.label1.Text = "���";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 424);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 36;
			this.button1.Text = "ȷ�����";
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
			this.DataGrid1.CaptionText = "                   ���а��´����";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(112, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 320);
			this.DataGrid1.TabIndex = 35;
			// 
			// comboBox1_QuXian_ID
			// 
			this.comboBox1_QuXian_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1_QuXian_ID.Location = new System.Drawing.Point(416, 376);
			this.comboBox1_QuXian_ID.Name = "comboBox1_QuXian_ID";
			this.comboBox1_QuXian_ID.Size = new System.Drawing.Size(96, 20);
			this.comboBox1_QuXian_ID.TabIndex = 43;
			this.comboBox1_QuXian_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_QuXian_ID_KeyPress);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(320, 376);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 42;
			this.label4.Text = "���´���������";
			// 
			// Add_Office
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(536, 477);
			this.Controls.Add(this.comboBox1_QuXian_ID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_Office_Name);
			this.Controls.Add(this.textBox_Office_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "Add_Office";
			this.Text = "���´����";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (conn.KickOut(textBox_Office_Name.Text)=="") 
			{
				MessageBox.Show("����������´����ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			 }
			if (textBox_Office_Name.Text.Length>15)
			{
				MessageBox.Show("�벻Ҫ����������´����ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//ȥ��'"?%=�ո�,������´���
			string str_Sql,errorstring="";
			str_Sql="INSERT INTO Office values("+conn.KickOut(textBox_Office_ID.Text.Trim())+",'"
				+conn.KickOut(textBox_Office_Name.Text.Trim())+"',"+conn.KickOut(comboBox1_QuXian_ID.SelectedValue.ToString())+")";
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
			str_Sql="SELECT Office.Office_ID AS ���´�����,Office.Office_Name AS ���´�����,QuXian.QuXian_Name AS �������� FROM QuXian inner join Office on QuXian.QuXian_ID=Office.QuXian_ID_OfficeIn";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			DataGrid1.Select(conn.ds.Tables["TableIn"].Rows.Count-1);

			textBox_Office_Name.Text="";
			textBox_Office_ID.Text=conn.GetMaxId("Office_ID","Office");
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{			
			this.Dispose();
		}

		private void comboBox1_QuXian_ID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}
