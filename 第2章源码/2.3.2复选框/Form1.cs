using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ��ѡ��
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private string [] ti_mu=new string[4] ;	// �����Ŀ
		private string [,] Item=new string[4,5]; //���A��B��C��D�ĸ�ѡ����	
		private string [] Answer=new string[4]; //�����Ŀ���硰AC��
		private int s;                  	// ���

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "�ж϶Դ�";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "��һ��";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 224);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(16, 183);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(216, 32);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "checkBox4";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(16, 138);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(216, 32);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "checkBox3";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(16, 85);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(216, 40);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "checkBox2";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(16, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(216, 32);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "checkBox1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(320, 294);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "����ѡ��";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
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
            Application.Run(new Form2());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string d="";
			if(checkBox1.Checked) d=d+"A";
			if(checkBox2.Checked) d=d+"B";
			if(checkBox3.Checked) d=d+"C";
			if(checkBox4.Checked) d=d+"D";				
			if(d==Answer[s])
				MessageBox.Show("��ϲ����ѡ���ˣ�");
			else
				MessageBox.Show("ѡ�����");

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			s = s + 1;
			//ȡ��ѡ��״̬
			if(checkBox1.Checked) checkBox1.Checked=false;
			if(checkBox2.Checked) checkBox2.Checked=false;
			if(checkBox3.Checked) checkBox3.Checked=false;
			if(checkBox4.Checked) checkBox4.Checked=false;	
			if( s > 3 )
				MessageBox.Show("��ϲ�㣬��Ŀ�Ѿ����꣡");
			else
				chu_ti();	

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ti_mu[1] = "���й��ڹ��캯���������У���ȷ���ǣ�   ��";
			ti_mu[2] = " C#�ĺϷ�ע���ǣ�    ��";
			ti_mu[3] = "����Form1��Text����Ϊfrm������Load�¼���Ϊ����";
			Item[1, 1] = "A. ���캯����������Ĭ�ϲ���";
			Item[1, 2] = "B. ���캯�������ж������ ";
			Item[1, 3] = "C. ���캯����������ʾ����";
			Item[1, 4] = "D. ���캯������������";
			Item[2, 1] = "A. /*This is a C program/*";
			Item[2, 2] = "B. // This is a C program ";
			Item[2, 3] = "C. /This is a C program/";
			Item[2, 4] = "D. /*This is a C program*/";
			Item[3, 1] = "A. Form_Load";		Item[3, 2] = "B. Form1_Load";
			Item[3, 3] = "C. Frm_Load";		Item[3, 4] = "D. Me_Load";
			Answer[1] = "AB";
			Answer[2] = "BD";
			Answer[3] = "A";
			s = 1;
			chu_ti();	

		}
		private void chu_ti()
		{
			label1.Text  = ti_mu[s];
			checkBox1.Text = Item[s, 1];
			checkBox2.Text = Item[s, 2];
			checkBox3.Text = Item[s, 3];
			checkBox4.Text = Item[s, 4];
		}

	}
}
