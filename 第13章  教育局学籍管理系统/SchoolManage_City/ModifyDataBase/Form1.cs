using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ModifyDataBase
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

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
				if (components != null) 
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(96, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "�޸����ݿ�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 109);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "�޸����ݿ�";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{

			string str_Sql,errorstring="";

//			str_Sql="Select * from QuXian WHERE QuXian_Name='����'"; 
//			errorstring=conn.Fill(str_Sql);
//			if(conn.ds.Tables[0].Rows.Count==1)
//			{
//				MessageBox.Show("�Ѿ��޸ģ������ظ��޸ģ�", "���ѣ�", 
//					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
//				return;
//			}

			//str_Sql="INSERT INTO QuXian (QuXian_ID,QuXian_Name,QuXian_Code) values(17,'����','81')";
			str_Sql="UPDATE QuXian Set QuXian_Code='08' WHERE QuXian_ID=4";
			errorstring=conn.ExeSql(str_Sql);

			str_Sql="UPDATE QuXian Set QuXian_Code='09' WHERE QuXian_ID=5";
			errorstring=conn.ExeSql(str_Sql);

			str_Sql="UPDATE QuXian Set QuXian_Code='10' WHERE QuXian_ID=6";
			errorstring=conn.ExeSql(str_Sql);

			if(errorstring!="OK")
			{
				MessageBox.Show("δ�ɹ��޸ģ��������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("�ɹ��޸ģ������ظ��޸ģ�", "���ѣ�", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			
			button1.Enabled=false;
		}
	}
}
