using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ��������
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
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
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 64);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "��Բ��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(88, 128);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "����";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(88, 184);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 2;
			this.button3.Text = "����";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(280, 270);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
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
              System.Drawing.Drawing2D.GraphicsPath p= new System.Drawing.Drawing2D.GraphicsPath ( ) ;
��            int   Width = this.ClientSize.Width;
��            int   Height = this.ClientSize.Height;
��            //����Ҫ������Բ����״����дAddEllipse��������Բ��Ӧ����Ӧ����
			  p.AddEllipse ( 0 , 0 , Width - 50 , Height - 100 ); ��           
��            Region = new Region ( p ); 
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			System.Drawing.Drawing2D.GraphicsPath p= new System.Drawing.Drawing2D.GraphicsPath ( ) ;
            //����Ҫʵ�ֵ�������״����дAddPie�����е���Ӧ����
			p.AddPie ( 10 , 10 , 250 , 250 , 5 , 150 );            
            Region = new Region ( p ); 
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
              System.Drawing.Drawing2D.GraphicsPath p= new System.Drawing.Drawing2D.GraphicsPath ( ) ;
��            int   width = 100;
��            int   Height =this.ClientSize.Height; 
			  //���ݻ��ε���״���ֱ���дAddEllipse��������Ӧ�Ĳ�����
			  p.AddEllipse ( 0 , 0 , Height , Height ) ;
��            p.AddEllipse ( width , width , Height - ( width * 2 ) , Height - ( width * 2 ) ) ;��            
��            Region = new Region ( p ); 
		}

	}
}
