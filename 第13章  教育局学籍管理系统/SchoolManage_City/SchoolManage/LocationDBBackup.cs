using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace SchoolManage
{
	/// <summary>
	/// LocationDBBackup ��ժҪ˵����
	/// </summary>
	public class LocationDBBackup : System.Windows.Forms.Form
	{
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_LocationDBBackup;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button3;

		private string  folderName;

		public LocationDBBackup()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//��ʾԭ�ȵ����ݿⱸ��λ��
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{					
					if(xn1.Attributes["key"].Value=="DatabaseBackup")
					{
						textBox_LocationDBBackup.Text=xn1.Attributes["value"].Value;
						break;
					}
				}
			}
			catch
			{
				//return false;
				throw new Exception("Config�����ļ���ȡʧ�ܣ�");
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.textBox_LocationDBBackup = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox_LocationDBBackup
			// 
			this.textBox_LocationDBBackup.Location = new System.Drawing.Point(88, 49);
			this.textBox_LocationDBBackup.Name = "textBox_LocationDBBackup";
			this.textBox_LocationDBBackup.Size = new System.Drawing.Size(248, 21);
			this.textBox_LocationDBBackup.TabIndex = 0;
			this.textBox_LocationDBBackup.Text = "D:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "��ǰ����Ŀ¼";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "��Ŀ¼";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 104);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "�����˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(64, 104);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "�趨�˳�";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// LocationDBBackup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 198);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBBackup);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Name = "LocationDBBackup";
			this.Text = "�޸ı���λ��";
			this.ResumeLayout(false);

		}
		#endregion

		//����µ����ݿⱸ��λ��
		private void button1_Click(object sender, System.EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBBackup.Text=folderName;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		//�趨�µ����ݿⱸ��λ��
		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				//�жϽڵ��Ƿ���ڣ�����������޸ĵ�ǰ�ڵ�
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="DatabaseBackup")
					{
						xn1.Attributes["value"].Value=textBox_LocationDBBackup.Text;
						break;
					}
				}
				//����web.config
				xd.Save(path);
				//return true;
				MessageBox.Show("�ɹ��޸ģ�", "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
				//return false;
				throw new Exception("Config�����ļ���ȡʧ�ܣ�");
			}

			this.Dispose();
		}
	}
}
