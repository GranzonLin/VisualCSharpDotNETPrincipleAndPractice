using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace �Ĺ�����
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
		private System.Windows.Forms.PictureBox qi_pan;		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		//����class Form1������˽�е����ݳ�Ա����
		private PictureBox[] Qizi_Pic; 
		private int Pic_Width;
		private int [ ]Q;
		private int [ , ]Map;
		bool _isDragging = false;
		bool Layout_Flag=true;//�����־
		bool first=true;//����ʱ��һ�ε�����־
		int mouse_x, mouse_y;
		int old_x,old_y; //��������
		int old_Left,old_Top;
		int tempx,tempy;//����ʱ��һ�ε�������
		bool IsMyTurn;
		enum PlayerColor{Red,Black,Green,Glue}; 
		PlayerColor player;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Button button3;//����ԭʼλ��(����)
		int r;//��վ�������
	
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.qi_pan = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// qi_pan
			// 
			this.qi_pan.Image = ((System.Drawing.Image)(resources.GetObject("qi_pan.Image")));
			this.qi_pan.Location = new System.Drawing.Point(32, 0);
			this.qi_pan.Name = "qi_pan";
			this.qi_pan.Size = new System.Drawing.Size(447, 446);
			this.qi_pan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.qi_pan.TabIndex = 1;
			this.qi_pan.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(488, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(488, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "label2";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 320);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "���沼��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(344, 360);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.TabIndex = 5;
			this.button2.Text = "��ȡ����";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(488, 136);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 184);
			this.listBox1.TabIndex = 6;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 464);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(640, 22);
			this.statusBar1.TabIndex = 7;
			this.statusBar1.Text = "��ӭʹ�ÿ��־���1.0";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(344, 408);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 24);
			this.button3.TabIndex = 8;
			this.button3.Text = "��ʼ��ս";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(640, 486);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.qi_pan);
			this.Name = "Form1";
			this.Text = "����2.1";
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

		//��Ӵ���������ʼλ�÷���
		private void begin_pos(int m)
		{
			String filename="", path;
            path = System.Windows.Forms.Application.StartupPath;// bin·��
			Qizi_Pic=new PictureBox[25*m];
			int  i;
			int n=1;
			for( i = 0;i<25*m;i++)//���25*m������
			{
				Qizi_Pic[i] = new PictureBox();
				this.Controls.Add(Qizi_Pic[i]);
				Qizi_Pic[i].Width = 22;
				Qizi_Pic[i].Height = 22;
				Qizi_Pic[i].Name = "R" +i.ToString();
				Qizi_Pic[i].Tag = i.ToString();
				Qizi_Pic[i].Parent = qi_pan;
				if(i<25)
				{
					filename = path + "\\..\\..\\bmp\\" + Q[i].ToString() + ".bmp";}
				if(i<50&&i>=25)
				{
					filename = path + "\\..\\..\\bmp\\G" + Q[i%25].ToString() + ".bmp";
					//����filename = path + "\\..\\..\\bmp\\G.bmp";
				}
				Qizi_Pic[i].Image = Image.FromFile(filename);
				Qizi_Pic[i].Click+=new System.EventHandler(bt_Click);
				Qizi_Pic[i].MouseDown+=new System.Windows.Forms.MouseEventHandler(bt_MouseDown); 
				Qizi_Pic[i].MouseMove+=new System.Windows.Forms.MouseEventHandler(bt_MouseMove); 
				Qizi_Pic[i].MouseUp+=new System.Windows.Forms.MouseEventHandler(bt_MouseUp); 
				if(i%5==0)n++;
				Qizi_Pic[i].Top = 250+n*24;Qizi_Pic[i].Left = 10 + 23 *(i%5);
				Qizi_Pic[i].Visible=false; 

			}
				
		}
		private void bt_Click(object sender, System.EventArgs e) //���ﴦ�����¼�����
		{
			int x1,y1;						
			PictureBox  picBox1=(PictureBox)sender;
			int i=Convert.ToInt16(picBox1.Tag);
			//ת������������(x1,y1)
			x1=(picBox1.Left -10+picBox1.Width/2)/r+1;
			y1=(picBox1.Top -10+picBox1.Width/2)/r+1;
			if(Layout_Flag==true) //�Ƿ񲼾�
			{
				if(first==true){tempx=x1;tempy=y1;first=false;return; }
				else{old_x=tempx;old_y=tempy;first=true;}
				if(Layout_Juge(old_x,old_y,x1,y1))//�Ƿ���Ըı䲼��
					if(Map[x1,y1]==101)//û������
					{
						MoveChess(Map[old_x,old_y],x1,y1);
						Map[old_x,old_y]=101;
					}					 
					else //�Ե�����
					{ MoveChess(Map[old_x,old_y],x1,y1); MoveChess(i,old_x,old_y);}
				else 
					//statusBar1.Text="���ܸı�ԭ�в���";
					MessageBox.Show("��һ�Ų��������ը�������õ����ں����ţ�����ֻ���ڴ�Ӫ",
                       "Υ�����첼�ֹ���");
			}
		}
		private void bt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			PictureBox  picBox1=(PictureBox)sender;//�������ĸ��������picBox1����
			int i=Convert.ToInt16(picBox1.Tag);				
			if(Q[i%25]==30||Q[i%25]==29)return; //���ײ��ܶ�
			if(IsBigHome(old_x,old_y))return;  //��Ӫ�����Ӳ��ܶ�
			if (_isDragging)
			{
				picBox1.Left = picBox1.Left - mouse_x + e.X;
				picBox1.Top = picBox1.Top - mouse_y + e.Y;
			}
			picBox1.BringToFront();
		}
		private bool IsBigHome(int old_x,int old_y) //�ж��Ƿ��Ӫ
		{
			if(old_x==8&& old_y==17)return true;
			if(old_x==8&& old_y==10)return true;
			if(old_x==8&& old_y==1)return true;
			if(old_x==10&&old_y==17)return true;
			if(old_y==8&& old_x==17)return true;
			if(old_y==8&& old_x==10)return true;
			if(old_y==8&& old_x==1)return true;
			if(old_y==10&&old_x==17)return true;
			return false;
		}
		private void bt_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			_isDragging = false;
			int x,y;
			string path = System.Windows.Forms.Application.StartupPath;// bin·��
			path += "\\..\\..\\wav\\";
			
			PictureBox  picBox1=(PictureBox)sender;
            int idx=Convert.ToInt16(picBox1.Tag);
			//ת������������(x1,y1)
			x=(picBox1.Left -10+picBox1.Width/2)/r+1;
			y=(picBox1.Top -10+picBox1.Width/2)/r+1;
			if(Layout_Flag==true) //�Ƿ񲼾�
			{
				if(!(x<=12&&x>=7 &&y>=12 && y<=17))
				{
					picBox1.Left=old_Left;picBox1.Top=old_Top;
					MessageBox.Show("ֻ������������","Υ�����첼������");
				}

			}
			else //����״̬
			{

				if(old_x==x&&old_y==y)return ;				
				if(IsmyChess2(idx)&&Go_Juge(old_x,old_y,x,y))//&&Q[idx%25]!=29 &&Q[idx%25]!=30�����ߵ��������	
				{
					go_chess(old_x,old_y,x,y,idx);

					PlaySound.Play(path+"move.wav");
					IsMyTurn=!IsMyTurn;
					reverse();
				}
				else //��������
				{	picBox1.Left=old_Left;picBox1.Top=old_Top;}
			}
		}
		private void go_chess(int old_x,int old_y,int x,int y,int idx)//���������ӹ���
		{
			if(Map[x,y]==101)//Ŀ�괦������					
			{
				MoveChess(idx,x,y);
				Map[old_x,old_y]=101;
			}
			else//Ŀ�������� �ж��Ƿ����
			{
				int other_idx=Map[x,y];
				int other_big=Q[other_idx%25];
				int my_idx=idx;
				int my_big=Q[my_idx%25];
				MoveChess(idx,x,y);//�ƶ��Լ�������
				Map[old_x,old_y]=101;
				//�жϱ����Ƿ�����
				//(1)��Ϊ����˾��
				if(my_big>=32 && my_big<=40 &&other_big>=32 &&other_big<=40) //��Ϊ����˾��
				{
					if(other_big<my_big) //�Է����Ե���Map[x,y]��Ϊ������
					{
						Qizi_Pic[other_idx].Visible=false; 
						Map[x,y]=my_idx;
					}
					else if(other_big==my_big)//˫����ȥ��
					{
						Qizi_Pic[other_idx].Visible=false; 
						Qizi_Pic[my_idx].Visible=false; 
						Map[x,y]=101;

					}
					else//�Լ����Ե���Map[x,y]����
					{
						Qizi_Pic[my_idx].Visible=false; 
						Map[x,y]=other_idx;
					}
					return;
				}
				//(2)һ��Ϊը����ͬʱȥ��
				if(other_big==31||my_big==31)
				{
					Qizi_Pic[other_idx].Visible=false; 
					Qizi_Pic[my_idx].Visible=false; 
					Map[x,y]=101;
					return;
				}
				//(3)һ��Ϊ����(30),�Է�Ϊ��(32)
				if((other_big==30&&my_big==32)||(other_big==32&&my_big==30))
				{
					if(other_big==30){Qizi_Pic[other_idx].Visible=false; Map[x,y]=my_idx;}
					if(my_big==30){Qizi_Pic[my_idx].Visible=false; Map[x,y]=other_idx;}
					return;
							
				}
				//(3)һ��Ϊ����(30),�Է���Ϊ��(32)
				if((other_big==30&&my_big!=32)||(other_big!=32&&my_big==30))
				{
					if(other_big==30){Qizi_Pic[my_idx].Visible=false; Map[x,y]=other_idx;}
					if(my_big==30){Qizi_Pic[other_idx].Visible=false; Map[x,y]=other_idx;}
					return;
							
				}
				//(4)�Է�Ϊ����,��Ӯ��
				if(other_big==29)//29�������
				{
					
					if(player==PlayerColor.Red)MessageBox.Show("��ʤ����");
					else MessageBox.Show("��ʤ����");					
					return;
				}					
				statusBar1.Text=Map[x,y].ToString(); 

			}	
		}
		private void reverse()
		{
			if(!IsMyTurn)
			{
				player=PlayerColor.Green ;
				statusBar1.Text= "�öԷ�����";
			}
			else
			{
				player=PlayerColor.Red;
				statusBar1.Text= "���Լ�������";
			}
		}
		private void bt_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Cursor.Current = Cursors.Hand ;	
			PictureBox  picBox1=(PictureBox)sender;			
			old_x=(picBox1.Left-10)/r+1;
			old_y=(picBox1.Top-10)/r+1; 
			old_Left=picBox1.Left;
			old_Top=picBox1.Top; 
			if (e.Button == MouseButtons.Left)
			{
				mouse_x = e.X;	mouse_y = e.Y;
				_isDragging = true;
			}			
		}
		private void MoveChess(int  idx ,int x,int y)//�ƶ�����
			//idx���������ţ���x,y)Ŀ��λ��
		{			
			Qizi_Pic[idx].Left =  (x - 1) *  r+10;
			Qizi_Pic[idx].Top =  (y - 1) *  r+10 ;
			Map[x, y] = idx;
		}
		private bool Layout_Juge(int old_x,int old_y,int x1,int y1) //�жϲ������ӵ�λ���Ƿ��ʵ�
		{
			//��һ�Ų��������ը������1��2��3��4�Ų�������õ��ף�
			//�Լ��ľ���ֻ�ܷ����ڴ�Ӫ
			if(Map[old_x,old_y]==4 && y1==12)
				return false;
			if(Map[x1,y1]==4 && old_y==12)
				return false;//ը���ؼ����4��5,��һ��(y1=12)���������ը��
			if(Map[old_x,old_y]==5 && y1==12)
				return false;
			if(Map[x1,y1]==5 && old_y==12)
				return false;//ը���ؼ����4��5,��һ��(y1=12)���������ը��
			if(Map[old_x,old_y]==0 && !(x1==8&&y1==17||x1==10&&y1==17))
				return false;//�Լ��ľ���ؼ����0,ֻ�ܷ����ڴ�Ӫ
			if(Map[x1,y1]==0 && !(old_x==8&&old_y==17||old_x==10&&old_y==17))
				return false;//�Լ��ľ���ؼ����0,ֻ�ܷ����ڴ�Ӫ
			if(Q[Map[x1,y1]]==30 && !(old_y==16||old_y==17))
				return false;//��1��2��3��4�Ų�������õ��ף�
			if(Q[Map[old_x,old_y]]==30 && !(y1==16||y1==17))
				return false;//��1��2��3��4�Ų�������õ��ף�       
              
			return true;//������������� 

		}
		private bool Go_Juge(int old_x,int old_y,int x,int y)//�ж������λ���Ƿ��ʵ�
		{
			label1.Text=old_x.ToString()+"old_x:old_y"+old_y.ToString();
			label2.Text=x.ToString()+"x:y"+y.ToString()+Map[x,y].ToString() ;
			//�Ƿ�����������
			if( (x<=6 && y>=1 && y<=6) || (x>=12 && y>=1 && y<=6) ||
				(x<=6 && y>=12 && y<=17) || (x>=12 && y>=12 && y<=17)|| y>17 )
				return false;
			//Ŀ��λ�����Լ���������
			if(IsmyChess(x,y)) return false;

			//����Ӫ����Ӫ�Ƿ�����
			if(Is_Home( x, y)&& Map[x,y]!=101)return false;

			//�硰ʿ��б�ߴ���Ӫ�г���**********
			if(Is_Home( old_x, old_y)&& Map[x,y]==101&& Math.Abs(x-old_x)*Math.Abs(y-old_y)==1 )return true;

			//�硰ʿ��б��������Ӫ************
			if(Is_Home( x, y)&& Map[x,y]==101 && Math.Abs(x-old_x)*Math.Abs(y-old_y)==1 )return true;


			//�ƶ�һ��
			if( Math.Abs(x-old_x)==1 && y==old_y ||Math.Abs(y-old_y)==1 && x==old_x) return  true;
			//������
			if(T_Juge(old_x,old_y,x,y))	return true;
			//if(T_Juge(old_y,old_x,y,x))	return true;
			
			return false;
			
		}
		private bool T_Juge(int old_x,int old_y, int x,int y)//�����߿����߷�
		{
			//����ֱ��·�������������
			if(old_x==7)
			{
				if(x==7 && y<17 &&y>1 &&y!=8 &&y!=10 && VLine_Juge(old_y,y,x))return true;//����ֱ��·��
				if(x<7 &&x>1 &&y==7 && old_y<=7
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
				if(x<7 &&x>1 &&y==11 && old_y>=11
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
			}
			if(old_x==11)
			{
				if(x==11 && y<17 &&y>1&&y!=8 &&y!=10 && VLine_Juge(old_y,y,x))return true;//����ֱ��·��
				if(x<17 &&x>=12 &&y==7 && old_y<=7
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
				if(x<17 &&x>=12 &&y==11 && old_y>=11
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
			}
			//��ˮƽ��·��
			if(old_y==2||old_y==6||old_y==12||old_y==16)
				if(y==old_y && Math.Abs(x-old_x)<=4 && HLine_Juge(old_x,x,y))
					return true;
			//********************************
			//��ˮƽ��·�������������
			if(old_y==7)
			{
				if(y==7 && x<17 &&x>1 &&x!=8 &&x!=10 && HLine_Juge(old_x,x,y))return true;
				//************
				if(y<7 &&y>1 &&x==7 && old_x<=7
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;
				if(y<7 &&y>1 &&x==11 && old_x>=11
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;

			}
			if(old_y==11)
			{
				if(y==11 && x<17 &&x>1 &&x!=8 &&x!=10 && HLine_Juge(old_x,x,y))return true;
				//*************************
				if(y<17 &&y>=12 &&x==7 && old_x<=7
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;
				if(y<17 &&y>=12 &&x==11 && old_x>=11
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;			}
			//�̴�ֱ��·��
			if(old_x==2||old_x==6||old_x==12||old_x==16)
				if(x==old_x && Math.Abs(y-old_y)<=4 && VLine_Juge(old_y,y,x))
					return true;
			//***********************************
			//�м䡰���֡���·��
			if(old_y==9)
			{
				if(y==9 && x<=12 &&x>=6 &&x!=8 &&x!=10 && HLine_Juge(old_x,x,y))return true;
			}
			if(old_x==9)
			{
				if(x==9 && y<=12 &&y>=6 &&y!=8 &&y!=10 && VLine_Juge(old_y,y,x))return true;
			}


			return false;
		}


		//��ֱ�����ж��Ƿ��б�����ӵ�·
		private bool VLine_Juge(int m,int n, int x)
		{
			int t=Math.Max(m,n);
			m=Math.Min(m,n);
			n=t;
			for(int i=m+1;i<n;i++)
				if(Map[x,i]!=101) //�б������
					return false;
			return true;
		}
		//ˮƽ�����ж��Ƿ��б�����ӵ�·
		private bool HLine_Juge(int m,int n, int y)
		{
			int t=Math.Max(m,n);
			m=Math.Min(m,n);
			n=t;
			for(int i=m+1;i<n;i++)
				if(Map[i,y]!=101) //�б������
					return false;
			return true;
		}
		//�Ƿ�����Ӫ
		private bool Is_HalfHome(int x, int y)
		{
			if(
				(x==8&&y==3)||(x==8&&y==5)||(x==10&&y==3)||(x==10&&y==5)||
				(x==8&&y==13)||(x==8&&y==15)||(x==10&&y==13)||(x==10&&y==15)||
				(x==9&&y==4)||(x==9&&y==14)
				)return true;
			else return false;
		}
		private bool Is_Home(int x, int y)
		{
			if(Is_HalfHome(x, y)||Is_HalfHome(y,x))
				return true;
			else
				return false;
		}

		private bool IsmyChess(int x,int y)//�Ƿ����Լ�������
		{
			int idx=Map[x,y];
			if(idx==101)return false;
			else return IsmyChess2(idx);

		}
		private bool IsmyChess2(int idx)//���������ж��Ƿ����Լ�������
		{
			if(IsMyTurn)
			{
				if(idx>=0&& idx<=24) //������ �Ĺ�ʱ24+25
					return true;
				else
					return false;
			}
			else
			{
				if(!(idx>=0&& idx<=24)) //������ �Ĺ�ʱ24+25
					return true;
				else
					return false;
			}
		}																																	
        
		private void Form1_Load(object sender, System.EventArgs e)
		{
            Pic_Width=qi_pan.Width;  //���̴�С
            r=(Pic_Width)/17;
            Map=new int[18,18];
		    for(int i=1;i<18;i++)
			  for(int j=1;j<18;j++)
			   Map[i,j]=101;  //101��ʾ(i,j)��û��������

		    qi_index();     //���ӱ�Ų����ö�Ӧ���Ӻ���
			begin_pos(2);	//�Ӳ��������ļ��ж�ȡλ�ã���������			
		}
		private void qi_index()
		{
			Q=new int[25];
			Q[0]=29; //����29
			Q[1]=30;Q[2]=30;Q[3]=30;//����30
		    Q[4]=31;Q[5]=31;//ը��31
			Q[6]=32;Q[7]=32;Q[8]=32;//����32
			Q[9]=33;Q[10]=33;Q[11]=33;//�ų�33
			Q[12]=34;Q[13]=34;Q[14]=34;//����34
			Q[15]=35;Q[16]=35;//Ӫ��35
			Q[17]=36;Q[18]=36;//�ų�36
			Q[19]=37;Q[20]=37;//�ó�37
			Q[21]=38;Q[22]=38;//ʦ��38
			Q[23]=39;//����39
			Q[24]=40;//˾��40
		}
		private void read_qi_pu()//�Ӳ��������ļ��ж�ȡλ�ã���������
		{
			FileStream Myfile = new  FileStream("MyFile.txt",FileMode.Open,FileAccess.Read );
			int  x,y,idx;
			while((x=Myfile.ReadByte())!=-1)
			{				
				y=Myfile.ReadByte(); 
				idx=Myfile.ReadByte(); 
				label1.Text=x.ToString()+","+y.ToString()+","+idx.ToString()+";";
				if(idx!=101){MoveChess(idx,x,y);Qizi_Pic[idx].Visible=true; }
				listBox1.Items.Add(label1.Text);
			}
			Myfile.Close();			
		}
		private void write_qi_pu()
		{
			FileStream fw = new  FileStream("MyFile.txt",FileMode.Create,FileAccess.Write);
			//������Mapд�벼���ļ���
			for(byte x=7;x<=11;x++)
				for(byte y=12;y<=17;y++)
				{
					fw.WriteByte(x);
					fw.WriteByte(y);
					fw.WriteByte((byte)Map[x,y]);
					label2.Text=x.ToString()+","+y.ToString()+","+Map[x,y].ToString()+"*";
					listBox1.Items.Add(label2.Text); 					
				}
			fw.Flush();  //ˢ���ļ���������������д���ļ�
			fw.Close();
		}
		private void button1_Click(object sender, System.EventArgs e)//���沼��
		{
			write_qi_pu();		
		}

		private void button2_Click(object sender, System.EventArgs e)//��ȡ����
		{
			read_qi_pu();		
	
		}

		private void button3_Click(object sender, System.EventArgs e)//��ʼ��Ϸ��ս
		{
			Layout_Flag=false;//�����־		
			get_message();
			IsMyTurn=true;
			player=PlayerColor.Red;
			statusBar1.Text= "�Լ�Red��������";
			string path = System.Windows.Forms.Application.StartupPath;// bin·��
			path += "\\..\\..\\wav\\";
			PlaySound.Play(path+"junqistart.wav");
		}
		private void get_message()//��ȡ�Է�����������Ϣ
		{
			//��ȡ�Է�����
			FileStream Myfile = new  FileStream("MyFile2.txt",FileMode.Open,FileAccess.Read );
			int  x,y,idx;
			int x2,y2;
			int a,i;
			byte[ ]m=new byte[90]; //30*3��ע�ⲻ��25*3
			for(i=0;(a=Myfile.ReadByte())!=-1;i++) 
				m[i]=(byte)a;
			Myfile.Close();	
			for(i=0;i<90;i+=3)
			{
				x=m[i];
				y=m[i+1]; 				
				x2=18-x;//OneConvertTwo(x,y,x2,y2)
				y2=18-y;
				idx=m[i+2]; 
				label1.Text=x2.ToString()+","+y2.ToString()+","+(idx+25).ToString()+"$";
				if(idx!=101){MoveChess(idx+25,x2,y2);Qizi_Pic[idx+25].Visible=true; }
				listBox1.Items.Add(label1.Text);
			}
		}


	}
}
