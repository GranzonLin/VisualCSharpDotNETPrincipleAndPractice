using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ������
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
        private Button button1;
		private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(368, 266);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Ʈ���������";
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
			Point p = new Point (0 ,240);
			this.DesktopLocation = p ; //�趨��������ϽǵĶ�άλ�á�
            timer1.Enabled = true ;
            

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//��������ϽǺ���������timer1���ϼ�1 
			Point p = new Point ( this.DesktopLocation.X + 10 , this.DesktopLocation.Y ) ; 
			this.DesktopLocation = p ; 
			if(p.X == 550)//���������Ͻ�λ�õĺ�����Ϊ550ʱ��timer1ֹͣtimer2����
			{
				timer1.Enabled = false ; 
				timer2.Enabled = true ; 
			}

		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			//��������ϽǺ���������timer2���ϼ�1
			Point p = new Point ( this.DesktopLocation.X - 10 , this.DesktopLocation.Y ) ; 
			this.DesktopLocation = p ; 
			if(p.X == -150)//���������Ͻ�λ�õĺ�����Ϊ-150ʱ��timer2ֹͣtimer1����
			{
				timer1.Enabled = true ; 
				timer2.Enabled = false ;
			}

		}
	}
}
