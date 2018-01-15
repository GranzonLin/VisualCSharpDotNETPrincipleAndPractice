using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private string file_name="";//��Ӵ������

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
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 224);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "��ʾ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(208, 224);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 0;
			this.button2.Text = "����";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(392, 278);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
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

		private void button1_Click(object sender, System.EventArgs e)//��ʾ
		{
			OpenFileDialog file=new OpenFileDialog();
			file.Filter="jpg|*.jpg|bmp|*.bmp|*|*.*";//���ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*��
            //file.FilterIndex = 1;
			if(file.ShowDialog()==DialogResult.OK)
			{ 
				file_name=file.FileName;
				Bitmap bitmap = new Bitmap(file_name);
				Graphics g = this.CreateGraphics();
				//ԭͼ��С��ʾ
				g.DrawImage(bitmap,0,0,bitmap.Width, bitmap.Height);
	            //������ʾ
				g.DrawImage(bitmap,200,0,bitmap.Width/2, bitmap.Height/2);
               // //***********************************************************
               // //����һ��ָ�������С�Ŀ�ͼ��
               // Bitmap image2=new Bitmap(bitmap.Width/2,bitmap.Height/2);
               // //����ָ������õ�Graphics����
               // Graphics g2=Graphics.FromImage(image2);
               // //����ͼ��ı���ɫ
               // g2.Clear(this.BackColor);
               // Rectangle dest=new Rectangle(0,0,bitmap.Width/2, bitmap.Height/2);
               // Rectangle scr=new Rectangle(0,0,bitmap.Width, bitmap.Height);
               // g2.DrawImage(bitmap,dest,scr,GraphicsUnit.Pixel );
               // //���滭��image2�����е�ͼ��
               // image2.Save(@"c:\tu1.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
               ////********************************	



				bitmap.Dispose();//�ͷ�ռ�õ���Դ				
				g.Dispose();
                //image2.Dispose();//�ͷ�ռ�õ���Դ				
                //g2.Dispose();
			

			}
		}

		private void button2_Click(object sender, System.EventArgs e)//����
		{
			//����һ��ָ������Ŀ�ͼ��
			Bitmap image=new Bitmap(this.Width,this.Height);
			//����ָ������õ�Graphics����
			Graphics g=Graphics.FromImage(image);
			//��ͼ�λ���Graphics������
			//����ͼ��ı���ɫ
            g.Clear(this.BackColor);//Color.Black);//���������ͼ�沢��ָ������ɫ��䡣
			if(file_name=="")
			{
				MessageBox.Show("δ��ʾͼ���ļ�");
				return;
			}
			//Bitmap bitmap = new Bitmap(file_name);
			//ԭͼ��С
			//g.DrawImage(bitmap,0,0,bitmap.Width, bitmap.Height);
			//����
			//g.DrawImage(bitmap,200,0,bitmap.Width/2, bitmap.Height/2);
			try
			{
				//���滭��Graphics�����е�ͼ��
				image.Save(@"c:\tu1.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
				MessageBox.Show("����ɹ���","��ϲ");
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			image.Dispose();
			g.Dispose();		
		}

	}
}
