using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace ��3_2
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 32);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(224, 184);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(264, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(264, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "���";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "��";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(264, 184);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "�˳�";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(384, 246);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "��3_1";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void button1_Click(object sender, System.EventArgs e)//�����ļ�
		{   //�Դ򿪺ʹ�����ֻ��д�ķ�ʽ�����ļ���MyFile
			FileStream MyFile=new FileStream("C:\\EXAMPLE1.TXT"
				,FileMode.OpenOrCreate ,FileAccess.Write);
			byte a;char ch;
			int i; 
			for(i=0;i<textBox1.Text.Length ;i++)//�������е��ַ�
			{
					ch=textBox1.Text[i];//��ȡһ���ַ�
				a=(byte)ch;//�Ѹ��ַ�ת�����ֽ���
				MyFile.WriteByte(a);//�Ѹ��ֽ�д���ļ���ȥ
			}
			MyFile.Flush();//ˢ���ļ�
			MyFile.Close();//�ر��ļ�
		}
		private void button3_Click(object sender, System.EventArgs e)//����ʾ�ļ�
		{
				string MyText="",ch;//MyText���Ҫ��ʾ���ļ�����,��֮Ϊ����ַ���
			int a=0;
			//�Դ򿪣�ֻ���ķ�ʽ�����ļ���MyFile
			FileStream MyFile=new FileStream("C:\\EXAMPLE1.TXT"
				,FileMode.Open,FileAccess.Read );
			a=MyFile.ReadByte();//���ļ��ж�ȡһ���ֽ�
			while(a!=-1)//��������ļ��Ľ�β
			{
					ch=((char)a).ToString();//�Ѷ�ȡ���ֽ�ת��Ϊ�ַ�����
				MyText=MyText+ch;//�Ѹ��ַ������ӵ�����ַ�����ĩβ
				a=MyFile.ReadByte();//�ٶ�һ���ֽ�
			}
			textBox1.Text =MyText;//�ѽ���ַ������ı�������ʾ����
			MyFile.Close();//�ر��ļ�
		}
		private void button2_Click(object sender, System.EventArgs e) //��հ�ť
		{
			textBox1.Clear();
		}
		private void button4_Click(object sender, System.EventArgs e)//�˳�
		{
			Application.Exit();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
