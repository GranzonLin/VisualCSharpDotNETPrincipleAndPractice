using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ͼ��ת���ɶ����ƴ���xml
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3; 
		private string MyFile = "";    //�ļ���
		private string MyFileExt = "";//��չ��
		

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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(296, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "���ѡ��ͼƬ��";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 224);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(296, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "��ͼ�񱣴��XML";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(296, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "��XML�еõ�ͼ��";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(424, 266);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "ͼ���XML��ʽ�ļ���������";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
		public System.Drawing.Imaging.ImageFormat GetImageType(string str) //��չ���õ��ļ�����
		{ 
			if (str.ToLower() == "jpg") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Jpeg; 
			} 
			else if (str.ToLower() == "gif") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Gif; 
			} 
			else if (str.ToLower() == "tiff") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Tiff; 
			} 
			else if (str.ToLower() == "icon") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Icon; 
			} 
			else if (str.ToLower() == "png") //image/
            { 
				return System.Drawing.Imaging.ImageFormat.Png; 
			} 
			else 
			{ 
				return System.Drawing.Imaging.ImageFormat.MemoryBmp; 
			} 
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog(); 
			openFileDialog1.InitialDirectory = "."; 
			openFileDialog1.Filter = 
                 "PNG(*.png)|*.png|Gif(*.gif)|*.gif|Jpg(*.jpg)|*.jpg|����ͼ���ļ�(*.*)|*.*"; 
			openFileDialog1.FilterIndex = 2; 
			openFileDialog1.RestoreDirectory = true; 
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{ 
				MyFile = openFileDialog1.FileName; 
				MyFileExt = MyFile.Substring(MyFile.LastIndexOf(".") + 1); //��չ��

			    pictureBox1.Image = Image.FromFile(MyFile);

            } 
		}
		
		//��ͼ��byte������base64����д��xml��Ӧ�ֶξͿ����ˡ�
		private void button2_Click(object sender, System.EventArgs e)//ͼ��ת���ɶ����ƴ���xml
		{
			if (MyFile == "") 
			{ 
				MessageBox.Show("��ѡ��һ��ͼƬ��", "����",
					MessageBoxButtons.OK, MessageBoxIcon.Warning); 
				return; 
			} 
			System.Drawing.Image MyImg =System.Drawing.Image.FromFile(MyFile); 
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(); 
			MyImg.Save(memoryStream, GetImageType(MyFileExt)); //��ͼ����ָ����ʽ���浽����
			byte[] b; 
			b = memoryStream.GetBuffer(); 
			string pic = Convert.ToBase64String(b); 
			memoryStream.Close(); 
			System.Xml.XmlDocument MyXml = new System.Xml.XmlDocument(); 
			//�ַ�����ʽ����XML
			MyXml.LoadXml("<pic><name>"+MyFile+"</name><photo>" + pic + "</photo></pic>"); 
			MyXml.Save("MyPhoto.xml");
			MessageBox.Show("�ļ������浽�ˣ�" + "MyPhoto.xml"); 
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string pic; 
			System.Xml.XmlDocument MyXml = new System.Xml.XmlDocument(); 
			MyXml.Load("MyPhoto.xml"); 
			System.Xml.XmlNode picNode; 
			picNode = MyXml.SelectSingleNode("/pic/photo"); 
			pic = picNode.InnerText; 
			System.IO.MemoryStream memoryStream; 
			memoryStream = new System.IO.MemoryStream(Convert.FromBase64String(pic));
			try
			{
				this.pictureBox1.Image = new System.Drawing.Bitmap(memoryStream); 
				memoryStream.Close(); 
			}
			catch(Exception e2)
            {
				MessageBox.Show(e2.Message,"�쳣"); 
			}
			MessageBox.Show("��ʾ�ɹ�"); 
		}
	}
}
