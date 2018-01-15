using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NumPuzzle
{
	/// <summary>
	/// Form2 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		int GameSize;              //���ִ�С
		byte[] Position;           //���Ե�ַ  
		Button[] Buttons;          //���ְ�Ť
		const int MAP_WIDTH = 260; //ͼƬ���
		bool IsRun = false;        //��Ϸ״̬
		int Clicks = 0;            //���ƶ���

		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
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

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 296);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(608, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "��ѡ���Ѷ�";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(344, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(260, 260);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "��Ϸ";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "2*2��";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "3*3��";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "4*4��";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "�˳�";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(608, 318);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "����ƴͼ��Ϸ";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
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
		//��ʼ����Ϸ�������
		private void InitGame()
		{
			//����������̰�Ť
			if(Buttons != null)
			{
				for(int i=0;i<Buttons.Length;i++)
					Buttons[i].Dispose();			    
			}
			Buttons = new Button[GameSize*GameSize];
			Position = new byte[GameSize*GameSize];

			Position[0] = 0;         //�յ�λ��
			for(int i=1;i<Position.Length;i++)
			{
				Position[i] = (byte)i;//��ʼ������
			}
			//������������㷨
			byte[] key = new byte[GameSize*GameSize];
			Random Rnd1= new Random();
			Rnd1.NextBytes(key);
			Array.Sort(key,Position);
			//��̬���ɰ�Ť����ʵ������GDI��
			int BWidth = MAP_WIDTH / GameSize;
			for(int i=0;i<Buttons.Length;i++)
			{
				Buttons[i] = new Button();
				Buttons[i].Size = new Size(BWidth,BWidth);
				int j = i / GameSize;
				int k = i % GameSize;
				Buttons[i].Location = new Point(24+k*BWidth,16+j*BWidth);
				if(Position[i] == 0)
				{
					Buttons[i].Visible = false;
				}
				Buttons[i].Text = Position[i].ToString();
				//���ð�ť����ͼƬ***************
				Buttons[i].BackgroundImage= create_image(Convert.ToInt16( Position[i].ToString()));
				Buttons[i].Enabled = false;
				this.Controls.Add(Buttons[i]);
			}
			IsRun = true; //������Ϸ���б�־
			this.Clicks = 0;		
		}

		private void DoChange(Keys key)
		{			
    		int offest = -1;
    		int MoveIndex = -1;
			for(int i=0;i<Position.Length;i++)//Ѱ�ҿ�λ��
			{
				if(Position[i] == 0)
				{
					offest = i;//offest��¼��λ��
					break;
				}
			}
			 //�ж���Ұ��������ݿ�λ�����㱻�ƶ��İ�ť
			switch(key)
			{
				case Keys.Up:
					MoveIndex = offest + GameSize;
					break;
				case Keys.Down:
					MoveIndex = offest - GameSize;
					break;
				case Keys.Left:
					MoveIndex = offest + 1;
					if(offest % GameSize == GameSize - 1) 
						return;
					break;
				case Keys.Right:
					MoveIndex = offest - 1;
					if(offest % GameSize == 0) 
						return;
					break;
				default:
					break;
			}//End Switch
			//�ж���Ч��Χ,�ж��Ƿ����ƶ�
			if(MoveIndex < 0 || MoveIndex >= Position.Length)
				return;
			Clicks++;
			this.statusBar1.Text = Clicks.ToString()+" Move";
			PlaySound.Play("MOVE.WAV");
			byte temp;
			//����������offest��MoveIndexλ��
			temp = Position[offest];
			Position[offest] = Position[MoveIndex];
			Position[MoveIndex] = temp;

			//������Ϸ����
			UpDataUI(offest,MoveIndex);
			//�����Ϸ�Ƿ���� 
			CheckWin();
		}

		private void UpDataUI(int offest,int MoveIndex)
		{
			if(this.IsRun == false)
				return;
			Buttons[offest].Visible = true;
			Buttons[offest].Text = Position[offest].ToString();
			Buttons[offest].BackgroundImage= create_image(Convert.ToInt16( Position[offest].ToString()));
			Buttons[MoveIndex].Visible = false;
		}

		//����Ƿ�ʤ��
		private void CheckWin()
		{
			for(int i=1;i<Position.Length;i++)
			{
				if(Position[i] != (byte)i)
				{
					return;  //��������������
				}
			}
			//��ʾȥ����ƴ��
			Buttons[0].Visible = true;
			Buttons[0].Text = "0";
			Buttons[0].BackgroundImage= create_image(0);			
			 //���غ󲥷���Ӧ����
			PlaySound.Play("WIN.WAV");
			IsRun = false;
			this.statusBar1.Text+=" ���أ�";
		}

		private void Form2_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(IsRun == false)
				return;
			switch (e.KeyCode)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Left:
					DoChange(e.KeyCode);
					break;
				default:
					break;
			}
		}
		private Bitmap create_image(int n)//�����n��ͼ
		{
			int W = MAP_WIDTH /GameSize ;
			Bitmap bit = new Bitmap( W, W );
			Graphics g = Graphics.FromImage( bit );
			//��ͼ
			g.DrawImage( pictureBox1.Image,	new Rectangle( 0, 0, W,W ),
				new Rectangle( n%GameSize*W,n/GameSize* W, W,W )/*Copy W*W part from source image */,
				GraphicsUnit.Pixel );  
			return bit;
		}
		private void menuItem2_Click(object sender, System.EventArgs e)//2*2��
		{
			GameSize = 2;
			InitGame();
		}
		private void menuItem3_Click(object sender, System.EventArgs e)//3*3��
		{
			GameSize = 3;
			InitGame();
		}		
		private void menuItem4_Click(object sender, System.EventArgs e)//4*4��
		{
			GameSize = 4;
			InitGame();
		}
		private void menuItem5_Click(object sender, System.EventArgs e)//�˳�
		{
			Application.Exit(); 
		}
	}
}
