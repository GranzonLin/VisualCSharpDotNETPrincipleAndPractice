using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text; //add
using System.Drawing;  
namespace ������֤��ͼƬ
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
			this.button1.Location = new System.Drawing.Point(72, 152);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "������֤��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(72, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(152, 40);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
//��ȡGB2312����ҳ���� 
Encoding gb=Encoding.GetEncoding("gb2312"); 
//���ú�������4��������ĺ��ֱ��� 
object[] bytes=CreateRegionCode(4);  
//���ݺ��ֱ�����ֽ������������ĺ��� 
			string str1=gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[]))); 
			string str2=gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[]))); 
			string str3=gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[]))); 
			string str4=gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[]))); 
string s=str1 + str2 +str3 +str4;//���
//			Graphics g  = this.pictureBox1.CreateGraphics();
//			Font font1   = new System.Drawing.Font("Arial", 18);
//			SolidBrush  brush2=  new System.Drawing.SolidBrush(Color.Red );
//			g.Clear(pictureBox1.BackColor); 
//			g.DrawString(s, font1, brush2,1,1);
//pictureBox1.Image.Save("aa.bmp"); 
//pictureBox1.Height =200;
			Bitmap memBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics g = Graphics.FromImage(memBitmap);
			SolidBrush brush = new System.Drawing.SolidBrush(Color.Red);
Font drawFont = new Font("Arial", 18);
g.DrawString(s, drawFont, brush, 0, 0);
pictureBox1.Image = memBitmap ;//	��ͼ  
pictureBox1.Image.Save(s+".bmp"); 
����    } 
/* ��CreateRegionCode�����ں��ֱ��뷶Χ���������������Ԫ�ص�ʮ�������ֽ����飬ÿ���ֽ��������һ�����֣������ĸ��ֽ�����洢��object�����С� 
������strlength��������Ҫ�����ĺ��ָ���*/ 
		public static object[] CreateRegionCode(int strlength) 
		{ 
//����һ���ַ������鴢�溺�ֱ�������Ԫ�� 
			string[] rBase=new String [16]{"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"}; 
Random rnd=new Random(); 
//����һ��object�������� 
			object[] bytes=new object[strlength]; 
/*ÿѭ��һ�β���һ��������Ԫ�ص�ʮ�������ֽ����飬���������bject������ÿ���������ĸ���λ�����  ��λ���1λ����λ���2λ��Ϊ�ֽ������һ��Ԫ�� 
 ��λ���3λ����λ���4λ��Ϊ�ֽ�����ڶ���Ԫ��*/ 
			for(int i=0;i<strlength;i++) 
			{ 
//��λ���1λ 
int r1=rnd.Next(11,14); 
				string str_r1=rBase[r1].Trim(); 
//��λ���2λ 
rnd=new Random(r1*unchecked((int)DateTime.Now.Ticks)+i);//��������������������ӱ�������ظ�ֵ 
int r2; 
				if (r1==13) 
				{ 
r2=rnd.Next(0,7); 
				} 
				else 
				{ 
r2=rnd.Next(0,16); 
				} 
				string str_r2=rBase[r2].Trim(); 
//��λ���3λ 
rnd=new Random(r2*unchecked((int)DateTime.Now.Ticks)+i); 
int r3=rnd.Next(10,16); 
				string str_r3=rBase[r3].Trim(); 
//��λ���4λ 
rnd=new Random(r3*unchecked((int)DateTime.Now.Ticks)+i); 
int r4; 
				if (r3==10) 
				{ 
r4=rnd.Next(1,16); 
				} 
				else if (r3==15) 
				{ 
r4=rnd.Next(0,15); 
				} 
				else 
				{ 
r4=rnd.Next(0,16); 
				} 
				string str_r4=rBase[r4].Trim(); 
//���������ֽڱ����洢���������������λ�� 
				byte byte1=Convert.ToByte(str_r1 + str_r2,16); 
				byte byte2=Convert.ToByte(str_r3 + str_r4,16); 
//�������ֽڱ����洢���ֽ������� 
				byte[] str_r=new byte[]{byte1,byte2};  
//��������һ�����ֵ��ֽ��������object������ 
				bytes.SetValue(str_r,i);                  
			} 
 			return bytes; 	 
		}
	}
}
