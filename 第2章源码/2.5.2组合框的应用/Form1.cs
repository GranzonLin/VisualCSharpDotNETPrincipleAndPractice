using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace �б���Ӧ��
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int ti_shu , right_shu, result;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
	 
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(40, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(120, 20);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.Text = "comboBox1";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 5;
			this.label2.Text = "���й���";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(192, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "��ӹ���";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 7;
			this.button2.Text = "ɾ������";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(192, 144);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 24);
			this.button3.TabIndex = 8;
			this.button3.Text = "�˳�";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(40, 144);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 21);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "textBox1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 120);
			this.label1.Name = "label1";
			this.label1.TabIndex = 5;
			this.label1.Text = "ѡ�еĹ���";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(328, 190);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "��Ͽ�";
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			comboBox1.Items.Add("�й�");
			comboBox1.Items.Add("����");
			comboBox1.Items.Add("�ձ�");
			comboBox1.Items.Add("����");
			comboBox1.Items.Add("��������");
			comboBox1.Text  = "";		
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			textBox1.Text= comboBox1.Text;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			bool Flag = false;		// ��־����Flag��ʾ��Ҫ���
			if( comboBox1.Text!="")
			{
				for(int  i = 0;i<comboBox1.Items.Count;i++)
				{
					if( comboBox1.Items[i].ToString()==comboBox1.Text)
					{
						Flag = true;//�ù��������Ѿ����ڣ��������
						break;
					}
				}
				if( Flag == false) comboBox1.Items.Add(comboBox1.Text);
			}
			else
				MessageBox.Show("���������������");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			 if( comboBox1.SelectedIndex== -1 )
                 MessageBox.Show("��ѡ��Ҫɾ������Ŀ!");
             else
				 comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Application.Exit(); 
		} 

	}
}
