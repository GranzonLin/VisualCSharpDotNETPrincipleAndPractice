using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ��ѡ��ťӦ��
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	    private string [] ti_mu=new string[4] ;	// �����Ŀ
		private string [,] Item=new string[4,5];     	    //���A��B��C��D�ĸ�ѡ����
		//�����Ŀ�𰸣�1��2��3��4�ֱ����A��B��C��D �ĸ�ѡ����//���Ǵ�0��ʼ
		private int [] Answer=new int[4];
        private int s;// ���
		private System.Windows.Forms.Button button3;  //�����                	
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(48, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 184);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ѡ��";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(8, 136);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(144, 40);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "radioButton4";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 104);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(144, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "radioButton3";
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 64);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(144, 32);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(144, 32);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "�ж϶Դ�";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "��һ��";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(248, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "�����";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(344, 254);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
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
		private void chu_ti()
		{
			label1.Text  = ti_mu[s];
            radioButton1.Text = Item[s, 1];
            radioButton2.Text = Item[s, 2];
            radioButton3.Text = Item[s, 3];
            radioButton4.Text = Item[s, 4];

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			  if( Answer[s]== 1 && radioButton1.Checked)
                 MessageBox.Show("��ϲ����ѡ���ˣ�");
              else if ( Answer[s]== 2 && radioButton2.Checked)
                   MessageBox.Show("��ϲ����ѡ���ˣ�");
			      else if ( Answer[s]== 3 && radioButton3.Checked)
                   MessageBox.Show("��ϲ����ѡ���ˣ�");
					  else if ( Answer[s]== 4 && radioButton4.Checked)
                         MessageBox.Show("��ϲ����ѡ���ˣ�");
                        else
                          MessageBox.Show("ѡ�����");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ti_mu[1] = "����������ڣ�   ����";
			ti_mu[2] = "���ÿؼ��������е���Ѹ�ٷ����ǣ�    ��";
			ti_mu[3] = "������Form1��Text����Ϊfrm������Load�¼�������Ϊ��    ��";
			Item[1, 1] = "A.1944";
			Item[1, 2] = "B.1945";
			Item[1, 3] = "C.1946";
			Item[1, 4] = "D.1947";
			Item[2, 1] = "A.˫���������еĿؼ�";
			Item[2, 2] = "B.�����������еĿؼ�";
			Item[2, 3] = "C.�϶����";
			Item[2, 4] = "D.�����������еĿؼ����϶����";
			Item[3, 1] = "A. Form_Load";
			Item[3, 2] = "B. Form1_Load";
			Item[3, 3] = "C. Frm_Load";
			Item[3, 4] = "D. Me_Load";
			Answer[1] = 3;
			Answer[2] = 1;
			Answer[3] = 1;
			s = 1;
			chu_ti();		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			s = s + 1;
			if( s > 3 )
			   MessageBox.Show("��ϲ�㣬��Ŀ�Ѿ����꣡");
			else
			   chu_ti();
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if( Answer[s] == 1)   
				MessageBox.Show("��ϲ����ѡ���ˣ�");
            else
                 MessageBox.Show("ѡ�����");
		}
		public static string getRandom(int iCnt)
		{
			string allChar = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,0,1,2,3,4,5,6,7,8,9";
			string[] allCharArray = allChar.Split(',');
			string randomCode = "";
			//int temp = -1;
			Random random = new Random(); ;
			for (int i = 0; i < iCnt; i++)
			{
				int t = random.Next(62);
				randomCode += allCharArray[t];
			}
			return randomCode;
		}
		private void button3_Click(object sender, System.EventArgs e)
		{
		  MessageBox.Show(getRandom(4));
		  int t ='z';
		  MessageBox.Show( t.ToString());

		}
	}
}

