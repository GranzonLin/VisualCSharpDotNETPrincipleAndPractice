using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace aa
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Button[] BT_NUM; 
		private Button[] Operator;
		string sOper;	bool bDot, bEqu;
		double dblAcc, dblDes, dblResult;


		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
	
			BT_NUM=new Button[10] ; 
			Operator=new Button[6];

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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox1.Location = new System.Drawing.Point(16, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(192, 26);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(232, 278);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "������";
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			int  i;
			for( i = 0;i<=9;i++)
			{
				BT_NUM[i] = new Button();
				this.Controls.Add(BT_NUM[i]);
				BT_NUM[i].Left = 10 + 50 * (i%3);
				BT_NUM[i].Top = 50 * (int)(i/3) + 70;
				BT_NUM[i].Width = 40;
				BT_NUM[i].Height = 40;
				BT_NUM[i].Name = "BT_NUM" +i.ToString();
				BT_NUM[i].Text = i.ToString();
				BT_NUM[i].Click+=new System.EventHandler(bt_Click);
			}
			for( i = 0;i<=5;i++)
			{
				Operator[i] = new Button();
				this.Controls.Add(Operator[i]);
				Operator[i].Left = 10 + 50 * 3;
				Operator[i].Top = 50 * i + 70;
				Operator[i].Width = 40;
				Operator[i].Height = 40;
				Operator[i].Click+=new System.EventHandler(bt_Click);
				//AddHandler( CType(Operator[i], Button).Click, AddressOf bt_Click);
			}
			Operator[0].Text = "+";
			Operator[1].Text = "-";
			Operator[2].Text = "*";
			Operator[3].Text = "/";
			Operator[4].Text = "=";
			Operator[5].Text = "CE";
			Operator[4].Left = 10 + 50 * 2;
			Operator[4].Top = 50 * 3 + 70;
			Operator[5].Left = 10 + 50 * 1;
			Operator[5].Top = 50 * 3 + 70;
		}
		private void bt_Click(object sender, System.EventArgs e)
			//���ﴦ�����¼�
		{
			String sText; 
			Button  bClick=(Button)sender;//��������İ�ť���������bClick����
			sText = bClick.Text;//��ȡ��ť������
			switch( sText)//ͨ����ť�����������ж����ĸ�Button���������ִ����Ӧ�Ĳ���					
			{
				case  "1":
				case  "2":
				case  "3":
				case  "4":
				case  "5":
				case  "6":
				case  "7":
				case  "8":
				case  "9":
				case  "0":	//����Ϊ����
					if( bEqu)	textBox1.Text = "";
					//����Ѿ�ִ�й�һ�μ��㣬��ô�ٴ���������ʱ��Ӧ���textBox1
					bEqu = false;
					textBox1.Text = textBox1.Text + sText; //  ��������ַ��ۼ�
					break;
				case "+":
				case "-":
				case "*":
				case "/":	dblAcc = Convert.ToDouble(textBox1.Text);
					textBox1.Text = "";
					sOper = sText;// ���±���������������
					break;
				case "=":
					bDot = false;
					if(!bEqu) dblDes = Convert.ToDouble(textBox1.Text);
					//������ζԡ�=���ĵ���������ĵڶ��ε������ô����������
					bEqu = true;
				switch( sOper)//���ݲ������Ĳ�ִͬ����Ӧ�ļ���
				{
					case "+": dblResult = dblAcc + dblDes;break;//ִ�мӷ�����
					case "-": dblResult = dblAcc - dblDes;break;//ִ�м�������
					case "*": dblResult = dblAcc * dblDes;break;//ִ�г˷�����
					case "/": dblResult = dblAcc / dblDes;break;//ִ�г˷�����
				}			
					textBox1.Text = dblResult.ToString();
					dblAcc = dblResult;
					//�����������������������Ա�ִ�������ĵڶ��β���
					break;
				case "CE":	
					textBox1.Text = "";//����ı�������
					break;
//				case ".":
//					textBox1.Text = textBox1.Text+".";
//					break;
                    

			}
		}

	}
}
