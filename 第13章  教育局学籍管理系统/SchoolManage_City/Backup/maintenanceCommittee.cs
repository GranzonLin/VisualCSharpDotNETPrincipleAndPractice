using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// maintenanceCommittee ��ժҪ˵����
	/// </summary>
	public class maintenanceCommittee : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox_Office;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_Committee_Name;
		private System.Windows.Forms.TextBox textBox_Committee_ID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		public maintenanceCommittee()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			//�������б���ʾ���е���������
			string str_Sql,errorstring;
			errorstring=conn.BindComboBox("Select * from QuXian WHERE QuXian_ID<>9",comboBox_QuXian,"QuXian_ID","QuXian_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			//��DataGrid��ʾ,δѡ���κ���Ч����button1.Enabled=false;
			str_Sql="SELECT Committee_ID AS ��ί�����,Committee_Name AS ��ί������,Office_Name AS ���´�����,QuXian_Name AS �������� FROM View_Committee";

			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
					
			textBox_Committee_ID.Text=conn.GetMaxId("Committee_ID","Committee");

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
			this.comboBox_Office = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Committee_Name = new System.Windows.Forms.TextBox();
			this.textBox_Committee_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox_Office
			// 
			this.comboBox_Office.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Office.Location = new System.Drawing.Point(383, 456);
			this.comboBox_Office.Name = "comboBox_Office";
			this.comboBox_Office.Size = new System.Drawing.Size(96, 20);
			this.comboBox_Office.TabIndex = 65;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(279, 456);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 64;
			this.label3.Text = "��ί�����ڰ��´�";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(183, 456);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(96, 20);
			this.comboBox_QuXian.TabIndex = 63;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(87, 456);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 62;
			this.label4.Text = "��ί����������";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(279, 528);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 61;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(183, 496);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 60;
			this.label2.Text = "��ί������";
			// 
			// textBox_Committee_Name
			// 
			this.textBox_Committee_Name.Location = new System.Drawing.Point(247, 496);
			this.textBox_Committee_Name.Name = "textBox_Committee_Name";
			this.textBox_Committee_Name.Size = new System.Drawing.Size(232, 21);
			this.textBox_Committee_Name.TabIndex = 59;
			this.textBox_Committee_Name.Text = "";
			// 
			// textBox_Committee_ID
			// 
			this.textBox_Committee_ID.Enabled = false;
			this.textBox_Committee_ID.Location = new System.Drawing.Point(127, 496);
			this.textBox_Committee_ID.Name = "textBox_Committee_ID";
			this.textBox_Committee_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_Committee_ID.TabIndex = 58;
			this.textBox_Committee_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(87, 496);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 57;
			this.label1.Text = "���";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(127, 528);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 56;
			this.button1.Text = "ȷ���޸�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionText = "                                       ���о�ί�����";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.Location = new System.Drawing.Point(20, 20);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.PreferredColumnWidth = 100;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.Size = new System.Drawing.Size(550, 400);
			this.DataGrid1.TabIndex = 55;
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
			// 
			// maintenanceCommittee
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(608, 573);
			this.Controls.Add(this.comboBox_Office);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_Committee_Name);
			this.Controls.Add(this.textBox_Committee_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "maintenanceCommittee";
			this.Text = "��ί���޸�";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			conn.BindComboBox("Select * from Office WHERE QuXian_ID_OfficeIn="+comboBox_QuXian.SelectedValue.ToString(),comboBox_Office,"Office_ID","Office_Name");	
		}

		private void DataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{			
			DataGrid1.Select(DataGrid1.CurrentRowIndex);

			textBox_Committee_ID.Text=DataGrid1[DataGrid1.CurrentRowIndex,0].ToString();
			textBox_Committee_Name.Text=conn.Committee_IDtoWhat(textBox_Committee_ID.Text,"Committee_Name");
			comboBox_QuXian.SelectedValue=(int.Parse(conn.Office_IDtoWhat(conn.Committee_IDtoWhat(textBox_Committee_ID.Text,"Office_ID"),"QuXian_ID_OfficeIn")));
			
			//�����ݿ���ߴ洢�İ��´��������б�
			string errorstring=conn.BindComboBox("Select * from Office Where QuXian_ID_OfficeIn="+comboBox_QuXian.SelectedValue.ToString(),comboBox_Office,"Office_ID","Office_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			comboBox_Office.SelectedValue=(int.Parse(conn.Committee_IDtoWhat(textBox_Committee_ID.Text,"Office_ID")));
			button1.Enabled=true;
			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(comboBox_Office.SelectedItem==null)
			{
				MessageBox.Show("��ѡ��þ�ί�����ڰ��´���", "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (conn.KickOut(textBox_Committee_Name.Text)=="") 
			{
				MessageBox.Show("���������ί�����ƣ�", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_Committee_Name.Text.Length>15)
			{
				MessageBox.Show("�벻Ҫ���������ί�����ƣ�", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			//ȥ��'"?%=�ո�,�޸İ��´���
			string str_Sql,errorstring="";
			str_Sql="UPDATE Committee SET Committee_Name='"+conn.KickOut(textBox_Committee_Name.Text)
				+"',Office_ID="+comboBox_Office.SelectedValue.ToString()
				+" WHERE Committee_ID="+textBox_Committee_ID.Text;
			
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�޸Ĳ��ɹ����������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("�ɹ��޸ģ�", "���ѣ�",
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			//ˢ��DataGrid��ʾ,ѡ�����һ�з�ɫ��ʾ
			str_Sql="SELECT Committee_ID AS ��ί�����,Committee_Name AS ��ί������,Office_Name AS ���´�����,QuXian_Name AS �������� FROM View_Committee";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			textBox_Committee_Name.Text="";		
		}
	}
}
