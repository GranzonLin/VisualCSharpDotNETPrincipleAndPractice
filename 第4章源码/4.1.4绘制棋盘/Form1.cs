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
		private System.Windows.Forms.PictureBox pictureBox1;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(304, 264);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "������������";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(24, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(248, 296);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 342);
			this.Controls.Add(this.pictureBox1);
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
		private void DrawBoard()
		{
    		int  i, r;
	    	//��ȡ�Խ����ڻ�ͼ��ͼ�ζ�������ô���ͼ��ͼ�� 
    	   Graphics g  = this.pictureBox1.CreateGraphics();
		   Pen myPen=new Pen(Color.Red);
		   myPen.Width = 1;
		  r = this.pictureBox1.ClientRectangle.Width / 18;
		  pictureBox1.Height = r * 20;
		  for( i = 0;i<=8;i++) //����
			{
				if( i == 0 || i ==8)					 
					myPen.Width = 2;
				else
					myPen.Width = 1;
				g.DrawLine(myPen, r + i * 2 * r, r, r + i * 2 * r, r * 2 * 10 - r + 1);
			}
			for( i = 0;i<=9;i++) //����
			{
				if( i ==0 || i == 9)					 
					myPen.Width = 2;
				else
					myPen.Width = 1;
		        g.DrawLine(myPen, r, r + i * 2 * r, r * 2 * 9 - r, r + i * 2 * r);
		    }
		Rectangle rectangle =new System.Drawing.Rectangle(r + 1, r + r * 8 + 1, r * 9 * 2 - 2 * r - 2, 2 * r - 2);
		SolidBrush  brush1=new System.Drawing.SolidBrush(Color.Brown);
		g.DrawEllipse(System.Drawing.Pens.Black, rectangle);
		g.DrawRectangle(System.Drawing.Pens.Blue, rectangle);
		g.FillRectangle(brush1, rectangle);
		Font font1   = new System.Drawing.Font("Arial", 18);
		SolidBrush  brush2=  new System.Drawing.SolidBrush(Color.Yellow);
		g.DrawString("   ����       ����", font1, brush2, (r + 1), (r + r * 8 + 1));
		//���Ź�б��
		g.DrawLine(myPen, r + r * 6 + 1, r + 1, r + r * 6 + r * 4 - 1, r + r * 4 - 1);
		g.DrawLine(myPen, r + r * 6 + 1, r + r * 4 - 1, r + r * 6 + r * 4 - 1, r + 1);
		g.DrawLine(myPen, r + r * 6 + 1, r * 14 + r + 1, r + r * 6 + r * 4 - 1, r * 14 + r + r * 4 - 1);
		g.DrawLine(myPen, r + r * 6 + 1, r * 14 + r + r * 4 - 1, r + r * 6 + r * 4 - 1, r * 14 + r + 1);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		    DrawBoard();
		}
	}
}
