using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// DeleteManyOld ��ժҪ˵����
	/// </summary>
	public class DeleteManyOld : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.CheckBox checkBox_InQuXian;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox checkBox_School_Type;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

		protected config conndelete=new config();
		protected config conn=new config();
		
		public DeleteManyOld()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
			
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
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.checkBox_InQuXian = new System.Windows.Forms.CheckBox();
			this.checkBox_School_Type = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "��",
																	  "Ů"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(168, 80);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 63;
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(168, 40);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 60;
			// 
			// checkBox_InQuXian
			// 
			this.checkBox_InQuXian.Location = new System.Drawing.Point(32, 40);
			this.checkBox_InQuXian.Name = "checkBox_InQuXian";
			this.checkBox_InQuXian.Size = new System.Drawing.Size(120, 24);
			this.checkBox_InQuXian.TabIndex = 64;
			this.checkBox_InQuXian.Text = "������ɾ��";
			// 
			// checkBox_School_Type
			// 
			this.checkBox_School_Type.Location = new System.Drawing.Point(32, 80);
			this.checkBox_School_Type.Name = "checkBox_School_Type";
			this.checkBox_School_Type.Size = new System.Drawing.Size(120, 24);
			this.checkBox_School_Type.TabIndex = 64;
			this.checkBox_School_Type.Text = "��ѧУ����ɾ��";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(80, 136);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 65;
			this.button1.Text = "ɾ��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 136);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 66;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DeleteManyOld
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 197);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox_InQuXian);
			this.Controls.Add(this.comboBox_School_Type);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.checkBox_School_Type);
			this.Name = "DeleteManyOld";
			this.Text = "����ɾ������Ϣ";
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			bool HadSome=false;
			string errorstring,str_Sql="Select * FROM School";
			
			DialogResult result=MessageBox.Show(this,"���Ҫ����ɾ����?","���ѣ�",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			if (result==DialogResult.OK)
			{
				//�����������������������,���ҵ������ݺ�DataGrid��
				if(checkBox_InQuXian.Checked==true&&checkBox_School_Type.Checked==false)
				{
					str_Sql="Select * FROM School WHERE School_ID Like '____"+comboBox_QuXian.SelectedValue+"%'";
					HadSome=true;				
				}

				//�����������������������,���ҵ������ݺ�DataGrid��
				if(checkBox_InQuXian.Checked==false&&checkBox_School_Type.Checked==true)
				{
					str_Sql="Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue;
					HadSome=true;				
				}

				//�����������������������,���ҵ������ݺ�DataGrid��
				if(checkBox_InQuXian.Checked==true&&checkBox_School_Type.Checked==true)
				{
					str_Sql="Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%'";
					HadSome=true;				
				}

				int i=conndelete.GetRowCount(str_Sql);
				conndelete.Fill(str_Sql);
				
				if(HadSome==true&&i>0)
				{
					
					for(;i>0;i--)
					{
						conndelete.dr=conndelete.ds.Tables[0].Rows[i-1];

						str_Sql="DELETE from Student WHERE School_ID='"+conndelete.dr["School_ID"].ToString()+"'";
						errorstring=conn.ExeSql(str_Sql);

						str_Sql="DELETE from Class WHERE School_ID='"+conndelete.dr["School_ID"].ToString()+"'";
						errorstring=conn.ExeSql(str_Sql);

						str_Sql="DELETE from Teacher WHERE School_ID='"+conndelete.dr["School_ID"].ToString()+"'";
						errorstring=conn.ExeSql(str_Sql);

						str_Sql="DELETE from School WHERE School_ID='"+conndelete.dr["School_ID"].ToString()+"'";
						errorstring=conn.ExeSql(str_Sql);
					}
				}
				MessageBox.Show("�ɹ�ɾ����", "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				return;
			}
		}
	}
}
