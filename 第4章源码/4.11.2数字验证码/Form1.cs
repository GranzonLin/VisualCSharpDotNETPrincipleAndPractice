using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ������֤��
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        private  string str_ValidateCode;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(136, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(80, 16);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "��֤";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "��������֤��";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(32, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(256, 182);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "��½";
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
		//  ������������ַ���
public string GetRandomNumberString(int int_NumberLength)
{
string str_Number = string.Empty;
Random theRandomNumber = new Random();
for (int int_index = 0; int_index < int_NumberLength; int_index++)
str_Number += theRandomNumber.Next(10).ToString();
return str_Number;
}
		//���������ɫ
public Color GetRandomColor()
{
Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
//  ����C#���������ûʲô��˵��
System.Threading.Thread.Sleep(RandomNum_First.Next(50));
Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);       
//  Ϊ���ڰ�ɫ��������ʾ������������ɫ
int int_Red = RandomNum_First.Next(256);
int int_Green = RandomNum_Sencond.Next(256);
int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
int_Blue = (int_Blue > 255) ? 255 : int_Blue;
return Color.FromArgb(int_Red, int_Green, int_Blue);
}
		//������֤�ַ�����������ͼ��
public void CreateImage(string str_ValidateCode)
{
int int_ImageWidth = str_ValidateCode.Length * 13;
Random newRandom = new Random();
//  ͼ��20px
Bitmap theBitmap = new Bitmap(int_ImageWidth, 20);
Graphics theGraphics = Graphics.FromImage(theBitmap);
//  ��ɫ����
theGraphics.Clear(Color.White);
//  ��ɫ�߿�
theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, int_ImageWidth - 1, 19);
//  10pt������
Font theFont = new Font("Arial", 10);
for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
{            
string str_char = str_ValidateCode.Substring(int_index, 1);
Brush newBrush = new SolidBrush(GetRandomColor());
Point thePos = new Point(int_index * 13 + 1 + newRandom.Next(3), 1 + newRandom.Next(3));
theGraphics.DrawString(str_char, theFont, newBrush, thePos);
}
//  �����ɵ�ͼƬ��ʾ��ͼƬ����
pictureBox1.Image=theBitmap;
}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//  4λ���ֵ���֤��
			str_ValidateCode = GetRandomNumberString(4);
			CreateImage(str_ValidateCode);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		   if(str_ValidateCode==textBox1.Text)
			   MessageBox.Show ("��֤ͨ��");
			else
			   MessageBox.Show ("��֤ʧ��,��������һ��");

		}
	}
}
