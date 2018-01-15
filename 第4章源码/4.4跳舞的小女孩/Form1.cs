using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace �����СŮ��
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private int PicNo;
		private System.Windows.Forms.StatusBar statusBar1;//ͼƬ���
        private Bitmap []bitmap;
		
		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			//my add
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(48, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(192, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "����";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 24);
			this.button2.TabIndex = 2;
			this.button2.Text = "����";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 192);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(328, 22);
			this.statusBar1.TabIndex = 3;
			this.statusBar1.Text = "statusBar1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(328, 214);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void timer1_Tick(object sender, System.EventArgs e)
		{
		    PicNo = PicNo + 1; 
			if (PicNo == 5) PicNo = 0; 
            pictureBox1.Image = bitmap[PicNo];
             

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			statusBar1.Text="���ڼ���";
			button2.Enabled=true;
            timer1.Interval = timer1.Interval - 150;
			if( timer1.Interval <=160) 
			{
				statusBar1.Text="̫���˰���������!";
				button1.Enabled=false;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			 statusBar1.Text="���ڼ���";
			 button1.Enabled=true;
		     timer1.Interval = timer1.Interval + 150;
			 if( timer1.Interval  >= 2000 )  
			{
				statusBar1.Text="���ֲ�ס������! ";
				button2.Enabled=false;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
        {			
//my add
            timer1.Interval = 600;
            timer1.Enabled = true;
            statusBar1.Text = "";
            bitmap = new Bitmap[5];
            PicNo = 0;

            for (int i = 1; i <= 5; i++)
            {
                string file = Application.StartupPath + "\\DG0" + i.ToString() + ".bmp";
                bitmap[i - 1] = new Bitmap(file);
            }
		}
	}
}
