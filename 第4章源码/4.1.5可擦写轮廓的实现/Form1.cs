using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace C_11_1
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
		public Point StartPt,EndPt;//�����ʼ�������
		public Graphics g;//���Graphics����
		public Pen MyPen;//��Ż��ʶ���
		public SolidBrush MyBrush;//��Ż�ˢ����
		public bool DrawShould=false;//�Ƿ�����

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

		#region Windows Form Designer generated code
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(216, 118);
			this.Name = "Form1";
			this.Text = "�ɲ�дͼ������";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);

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
			g=this.CreateGraphics();//����Graphics����
			MyPen=new Pen(Color.Black ,1);//�������ʶ���
			MyBrush=new SolidBrush(Color.Blue);//������ˢ����
		}

		private void Form1_MouseDown(object sender,MouseEventArgs e)
		{
			this.Capture =true;//�������
			DrawShould=true;//������ͼ
			StartPt.X=e.X ;//��ʼ��
			StartPt.Y=e.Y ;
			EndPt=StartPt;//��ֹ��
		}

		private void Form1_MouseMove(object sender,MouseEventArgs e)
		{
				if (DrawShould==true)//��������˻�ͼ
				{ MyPen.Color=this.BackColor ;//���û��ʵ���ɫΪ����ɫ
					//���ǰ����Ƶ�ͼ��
				  g.DrawEllipse (MyPen,StartPt.X ,StartPt.Y,EndPt.X-StartPt.X ,EndPt.Y-StartPt.Y  );
				  MyPen.Color=Color.Black ;  //���û��ʵ���ɫΪ��ɫ 
					MyPen.DashStyle=DashStyle.Dash;//����������ʽ
					//��������
				  g.DrawEllipse (MyPen,StartPt.X ,StartPt.Y ,e.X-StartPt.X ,e.Y-StartPt.Y  ) ;
				  EndPt.X =e.X ;//�ѵ�ǰ������Ϊ�յ�
				  EndPt.Y=e.Y;
			   }
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			DrawShould=false;//ֹͣ��ͼ
			MyPen.Color=this.BackColor ;//����ͼ����ɫΪ����ɫ
			//�����ǰ������
			g.DrawEllipse (MyPen,StartPt.X ,StartPt.Y,EndPt.X-StartPt.X ,EndPt.Y-StartPt.Y  );
			//��������ɫ������Բ
			g.FillEllipse(MyBrush,StartPt.X ,StartPt.Y ,e.X-StartPt.X ,e.Y-StartPt.Y);
			this.Capture =false;//������겶��
			
		}
	}
}
