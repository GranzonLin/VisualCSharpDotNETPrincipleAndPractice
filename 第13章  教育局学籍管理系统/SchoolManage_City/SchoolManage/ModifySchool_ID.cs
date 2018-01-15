using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// ModifySchool_ID ��ժҪ˵����
	/// </summary>
	public class ModifySchool_ID : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_School;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_Old_School_ID;
		private System.Windows.Forms.TextBox textBox_New_School_ID;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.Label label_;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox_QuXian;

		protected config conn=new config();

		public ModifySchool_ID()
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
			
			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				
				textBox_Old_School_ID.Text=comboBox_School.SelectedValue.ToString();
			}
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_School = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_Old_School_ID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_New_School_ID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.label_ = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 39;
			this.label1.Text = "ѧУ";
			// 
			// comboBox_School
			// 
			this.comboBox_School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School.Location = new System.Drawing.Point(112, 120);
			this.comboBox_School.Name = "comboBox_School";
			this.comboBox_School.Size = new System.Drawing.Size(240, 20);
			this.comboBox_School.TabIndex = 38;
			this.comboBox_School.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_SelectionChangeCommitted);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(272, 256);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 41;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 256);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 40;
			this.button1.Text = "�޸�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_Old_School_ID
			// 
			this.textBox_Old_School_ID.Enabled = false;
			this.textBox_Old_School_ID.Location = new System.Drawing.Point(216, 168);
			this.textBox_Old_School_ID.Name = "textBox_Old_School_ID";
			this.textBox_Old_School_ID.Size = new System.Drawing.Size(96, 21);
			this.textBox_Old_School_ID.TabIndex = 43;
			this.textBox_Old_School_ID.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(112, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 42;
			this.label2.Text = "ԭѧУ���룺";
			// 
			// textBox_New_School_ID
			// 
			this.textBox_New_School_ID.Location = new System.Drawing.Point(216, 216);
			this.textBox_New_School_ID.Name = "textBox_New_School_ID";
			this.textBox_New_School_ID.Size = new System.Drawing.Size(96, 21);
			this.textBox_New_School_ID.TabIndex = 45;
			this.textBox_New_School_ID.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(112, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 44;
			this.label3.Text = "�µ�ѧУ���룺";
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "��",
																	  "Ů"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(112, 72);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 67;
			this.comboBox_School_Type.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_Type_SelectionChangeCommitted);
			// 
			// label_
			// 
			this.label_.Location = new System.Drawing.Point(40, 80);
			this.label_.Name = "label_";
			this.label_.Size = new System.Drawing.Size(56, 16);
			this.label_.TabIndex = 66;
			this.label_.Text = "ѧУ���";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 23);
			this.label4.TabIndex = 65;
			this.label4.Text = "����";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(112, 24);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 64;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// ModifySchool_ID
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(448, 317);
			this.Controls.Add(this.comboBox_School_Type);
			this.Controls.Add(this.label_);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.textBox_New_School_ID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_Old_School_ID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_School);
			this.Name = "ModifySchool_ID";
			this.Text = "�޸�ѧУ����";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (conn.KickOut(textBox_New_School_ID.Text)=="") 
			{
				MessageBox.Show("��������ѧУ���룡", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			if (textBox_New_School_ID.Text.Length!=12)
			{
				MessageBox.Show("ѧУ����ֻ��Ϊ12λ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (conn.School_ID_Had(textBox_New_School_ID.Text))
			{
				MessageBox.Show("�벻Ҫ�����ظ���ѧУ���룡", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			//ת��ѧУ��Ϣ����Ҫɾ��
			string str_Sql="Select * from School Where School_ID='"+textBox_Old_School_ID.Text+"'"; 
			string errorstring=conn.Fill(str_Sql);		

			conn.dr=conn.ds.Tables[0].Rows[0];
			str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address) values ('"
				+conn.KickOut(textBox_New_School_ID.Text)+"','"
				+conn.dr["School_Name"].ToString()+"',"
				+conn.dr["School_Type_ID"].ToString()+",'"				
				+conn.dr["Schoolmaster"].ToString()+"','"
				+conn.dr["School_Tel"].ToString()+"','"
				+conn.dr["School_Zip"].ToString()+"','"
				+conn.dr["School_Address"].ToString()+"')";
			errorstring=conn.ExeSql(str_Sql);
			
			//���½�ʦ��Ϣ������ɾ��
			str_Sql="Update Teacher Set School_ID='"+textBox_New_School_ID.Text
				+"' Where School_ID='"+textBox_Old_School_ID.Text+"'";
			errorstring=conn.ExeSql(str_Sql);

			//ת��༶��Ϣ����Ҫɾ��
			conn.ds.Reset();
			str_Sql="Select * from Class Where School_ID='"+textBox_Old_School_ID.Text+"'"; 
			errorstring=conn.Fill(str_Sql);		

			for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
			{
				conn.dr=conn.ds.Tables[0].Rows[i];
				str_Sql="INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values("
					+conn.dr["Class_ID"].ToString()+",'"
					+textBox_New_School_ID.Text+"',"
					+conn.dr["Class_Type_ID"].ToString()+",'"
					+conn.dr["Class_Name"].ToString()+"','"
					+conn.dr["TeacherInCharge"].ToString()+"')";
				errorstring=conn.ExeSql(str_Sql);
			}

			//ת��ѧ����Ϣ������Ҫɾ��
			str_Sql="Update Student Set School_ID='"+textBox_New_School_ID.Text
				+"' Where School_ID='"+textBox_Old_School_ID.Text+"'";
			errorstring=conn.ExeSql(str_Sql);

			//ɾ����ѧУ�����Ӧ��������Ϣ,��ɾ��ѧ��,��ɾ���༶,���ɾ��ѧУ,�Է������ͻ
			str_Sql="DELETE from Class WHERE School_ID='"+textBox_Old_School_ID.Text+"'";
			conn.ExeSql(str_Sql);
			
			str_Sql="DELETE from School WHERE School_ID='"+textBox_Old_School_ID.Text+"'";
			conn.ExeSql(str_Sql);

			MessageBox.Show("�ɹ��޸ģ�", "���ѣ�",
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			button1.Enabled=false;

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();	
		}

		private void comboBox_School_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			textBox_Old_School_ID.Text=comboBox_School.SelectedValue.ToString();
		
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				
				textBox_Old_School_ID.Text=comboBox_School.SelectedValue.ToString();
			}
		
		}

		private void comboBox_School_Type_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				
				textBox_Old_School_ID.Text=comboBox_School.SelectedValue.ToString();
			}
		}
	}
}
