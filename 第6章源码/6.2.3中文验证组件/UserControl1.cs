using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text; //add
namespace ������֤���
{
	/// <summary>
	/// UserControl1 ��ժҪ˵����
	/// </summary>
	public class verifyControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private string chinese_char;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public verifyControl()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			// TODO: �� InitComponent ���ú�����κγ�ʼ��

		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(144, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// verifyControl
			// 
			this.Controls.Add(this.pictureBox1);
			this.Name = "verifyControl";
			this.Size = new System.Drawing.Size(110, 50);
			this.Load += new System.EventHandler(this.verifyControl_Load);
			this.ResumeLayout(false);

		}
		#endregion
		[Description("��֤��ͼ���ж�Ӧ�����ַ���"),Category("Appearance")] 
		public string ChineseChar
		{
			get{  return chinese_char ;}
            //set
            //{
            //    chinese_char = value;					    
            //}
		}
		public static object[] CreateRegionCode(int strlength) 
		{ 
//����һ���ַ������鴢�溺�ֱ�������Ԫ�� 
			string[] rBase=new String [16]{"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"}; 
Random rnd=new Random(); 
object[] bytes=new object[strlength];//����һ��object�������� 
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
string str_r4=rBase[r4].Trim();//���������ֽڱ����洢���������������λ�� 
byte byte1=Convert.ToByte(str_r1 + str_r2,16); 
byte byte2=Convert.ToByte(str_r3 + str_r4,16);//�������ֽڱ����洢���ֽ������� 
byte[] str_r=new byte[]{byte1,byte2};//��������һ�����ֵ��ֽ��������object������ 
bytes.SetValue(str_r,i);                  
			} 
			return bytes; 	 
		}
		private void create()////�����֤��ͼ�β���ȡ��֤�뺺��
		{
			Encoding gb=Encoding.GetEncoding("gb2312");//��ȡGB2312����ҳ���� 
			object[] bytes=CreateRegionCode(4);//���ú�������4��������ĺ��ֱ��� 
//���ݺ��ֱ�����ֽ������������ĺ��� 
			string str1=gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[]))); 
			string str2=gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[]))); 
			string str3=gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[]))); 
			string str4=gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[]))); 
//��֤�뺺�� 
����        string s=str1 + str2 +str3 +str4;
			chinese_char=s;
//�����֤��ͼ��
			Bitmap memBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics g = Graphics.FromImage(memBitmap);
			SolidBrush brush = new System.Drawing.SolidBrush(Color.Red);
			Font drawFont = new Font("Arial", 18);
			g.DrawString(s, drawFont, brush, 0, 0);
			pictureBox1.Image = memBitmap ;//��ͼ 
		}
		private void verifyControl_Load(object sender, System.EventArgs e)
		{
			create();//ͼƬ�ϵ��������µ���֤��ͼƬ
			
		}
		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
            create();
		}

	}
}
