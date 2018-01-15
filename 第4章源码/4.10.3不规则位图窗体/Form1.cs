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
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Point mouseOffset; //��¼���ָ�������
		private bool isMouseDown = false;//��¼��갴���Ƿ���
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem �ر�;
		private System.Windows.Forms.MenuItem ��������;
		private System.Windows.Forms.PictureBox pictureBox1; 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.�ر� = new System.Windows.Forms.MenuItem();
            this.�������� = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.�ر�,
            this.��������});
            // 
            // �ر�
            // 
            this.�ر�.Index = 0;
            this.�ر�.Text = "�ر�";
            this.�ر�.Click += new System.EventHandler(this.�ر�_Click);
            // 
            // ��������
            // 
            this.��������.Index = 1;
            this.��������.Text = "��������";
            this.��������.Click += new System.EventHandler(this.��������_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(126, 144);
            this.ContextMenu = this.contextMenu1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "��������";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
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

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int xOffset;
			int yOffset;
			if (e.Button == MouseButtons.Left)
			{
				xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
				yOffset = -e.Y - SystemInformation.CaptionHeight -
					SystemInformation.FrameBorderSize.Height;
				mouseOffset = new Point(xOffset, yOffset);
				isMouseDown = true;
			}
		
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// �޸����״̬isMouseDown��ֵ
			// ȷ��ֻ�����������²��ƶ�ʱ�����ƶ�����
			if (e.Button == MouseButtons.Left) 
			{
				isMouseDown = false;
			}		
		}
		private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (isMouseDown)
			{
				Point mousePos = Control.MousePosition;
				mousePos.Offset(mouseOffset.X, mouseOffset.Y);
				Location = mousePos;
			}
		}

		private void �ر�_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ��������_Click(object sender, System.EventArgs e)
		{
            Image m_bitmap = Image.FromFile(@"�Ͳ���.bmp");
			this.BackgroundImage= m_bitmap;
		}
	}
}
