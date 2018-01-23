using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;

namespace SchoolManage
{
	/// <summary>
	/// RestoreDB ��ժҪ˵����
	/// </summary>
	public class RestoreDB : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBox_openFile;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		public RestoreDB()
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textBox_openFile = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "ѡ����ǰ��ϵͳ���ݵ��ļ�";
			// 
			// textBox_openFile
			// 
			this.textBox_openFile.Location = new System.Drawing.Point(184, 64);
			this.textBox_openFile.Name = "textBox_openFile";
			this.textBox_openFile.Size = new System.Drawing.Size(320, 21);
			this.textBox_openFile.TabIndex = 1;
			this.textBox_openFile.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(512, 64);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "=";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(136, 136);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "�ָ����ݿ�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(288, 136);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "�˳�";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(104, 208);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(360, 48);
			this.label2.TabIndex = 5;
			this.label2.Text = "�ָ����ݿ�Ĳ�������ָ����ݵ������ļ�������ʱ�䣡һ��ֻ�ڵ�ǰ���ݿ���ٵ�����²�ʹ�á����ȱ��ݵ�ǰ���ݿ⣡���������Լ�����ͼʱ���ã�";
			// 
			// RestoreDB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(552, 294);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_openFile);
			this.Controls.Add(this.label1);
			this.Name = "RestoreDB";
			this.Text = "�ָ����ݿ�";
			this.ResumeLayout(false);

		}
		#endregion

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		//ѡ��ԭ�ȱ����ļ�λ��
		private void button1_Click(object sender, System.EventArgs e)
		{
			string fileName;
			DialogResult result = openFileDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				fileName = openFileDialog1.FileName;;
				textBox_openFile.Text=fileName;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (textBox_openFile.Text=="") 
			{
				MessageBox.Show("����������ȡ�ļ�����", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			string str_Sql,errorstring="";
			DialogResult result=MessageBox.Show(this,"���Ҫ�ָ���?","���ѣ�",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			if (result==DialogResult.OK)
			{
				//����������ĵ�Master���ݿ������,�Ͽ�����SchoolManage��������ϵ,���ָܻ�
				str_Sql="restore database "+ConfigurationSettings.AppSettings["Database"]
					+" from disk='"+textBox_openFile.Text+"' with replace";
				errorstring=conn.DBRestore(str_Sql);
				if(errorstring!="OK")
				{
					MessageBox.Show("�ָ�ʧ�ܣ��������ݿ⣡"+errorstring, "���ѣ�", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					button1.Enabled=false;
					return;
				}
				MessageBox.Show("�ָ��ɹ���"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				return;
			}
		}
	}
}
