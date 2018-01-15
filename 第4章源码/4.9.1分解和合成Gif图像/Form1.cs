using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging; //add
namespace �ֽ�ͺϳ�Gifͼ��
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox comboBox1;
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
			this.button3 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 120);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "�ֽ�gif�ļ�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(168, 120);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "�ϳ�gif�ļ�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(168, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 32);
			this.button3.TabIndex = 2;
			this.button3.Text = "�ļ���ʽת��";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "*.bmp",
														   "*.jpg",
														   "*.tif",
														   "*.gif"});
			this.comboBox1.Location = new System.Drawing.Point(48, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(96, 20);
			this.comboBox1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 174);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
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
			Image imgGif = Image.FromFile(@"c:\test.gif");
			//system.drawing.imaging.framedimension .NET Framework ���. FrameDimension ��. �ṩ��ȡͼ��Ŀ��ά�ȵ����ԡ����ɼ̳С�  
            //��imgGif ����FrameDimension����
			FrameDimension ImgFrmDim = new FrameDimension( imgGif.FrameDimensionsList[0] );
			//���gif�����������
			int nFrameCount = imgGif.GetFrameCount( ImgFrmDim );
			//��Jpeg ��ʽ����ÿһ��
			for( int i = 0; i < nFrameCount; i++ )
			{
				//ѡ��һ��
				imgGif.SelectActiveFrame( ImgFrmDim, i );
				imgGif.Save( string.Format( @"c:\Frame{0}.jpg", i ), ImageFormat.Jpeg );
			} 
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		
		}
        //using System.Drawing.Imaging; //add
		private void button3_Click(object sender, System.EventArgs e)//�ļ���ʽת��
		{
			OpenFileDialog file=new OpenFileDialog();
			file.Filter=".jpg��.bmp�ļ�|*.jpg;*.bmp�ļ�|�����ļ�(*.*)|*.*";
			//"�ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*"
			if(file.ShowDialog()==DialogResult.OK)
			{ 
				Image m_bitmap = Image.FromFile(@"c:\test.gif");
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "ͼ�����Ϊ";
				sfd.OverwritePrompt = true;
				sfd.CheckPathExists = true;
				sfd.Filter = comboBox1.Text + "|" + comboBox1.Text;
				sfd.ShowHelp = true;
				if(sfd.ShowDialog() == DialogResult.OK)
				{
					string strFileName = sfd.FileName;
					switch(comboBox1.Text)
					{
						case "*.bmp":
							m_bitmap.Save(strFileName, ImageFormat.Bmp);
							break;
						case "*.jpg":
							m_bitmap.Save(strFileName, ImageFormat.Jpeg);
							break;
						case "*.gif":
							m_bitmap.Save(strFileName, ImageFormat.Gif);
							break;
						case "*.tif":
							m_bitmap.Save(strFileName, ImageFormat.Tiff);
							break;
					}
					MessageBox.Show("ͼ���ļ���ʽת���ɹ���", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
	}
}
