using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace csharp7_4_1
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
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
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("����_GB2312", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(88, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "ѧ��������Ϣ";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(96, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 40);
			this.button1.TabIndex = 13;
			this.button1.Text = "˳���ȡ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(16, 56);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(328, 244);
			this.listBox1.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(360, 366);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "˳���ȡʾ��";
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
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            string str=@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage";
			//string str="server=(local);Integrated Security=SSPI;database=stumanage";
			string sqlstr="select * from stuinfo where sex='��'";
			string strRow="";//�ø��ַ���������Ű����ݼ��ж�ȡ������ת���ɵ��ַ���
			SqlConnection con=new SqlConnection(str);//�������Ӷ���
			con.Open();//������
			SqlCommand cmd=new SqlCommand(sqlstr,con);//����command����
			cmd.Connection=con;//ͨ��con���Ӷ���������ݿ�
			cmd.CommandType=CommandType.Text;//������������
			cmd.CommandText=sqlstr;//����Ҫִ�е�����
			SqlDataReader dr=cmd.ExecuteReader();//ִ��SELECT����õ��������ݼ�
			
			while(dr.Read())//ѭ����ȡ���ݼ��е�ÿһ����¼������
			{
				strRow=dr.GetString(0);//��ȡstu_id�е�ֵ
				strRow=strRow+" : "+dr.GetString(1)+"  ";//�ӣ�
				strRow=strRow+dr.GetString(2)+"  ";//����
				strRow=strRow+Convert.ToString(dr.GetInt32(3))+"  ";//����
				strRow=strRow+dr.GetString(4)+"  ";//�༶//strRow=strRow+dr.GetString(5)+" ";
				this.listBox1.Items.Add(strRow);//�ѵ�ǰ�е��������ӵ�ListBox�ؼ���
			}
			dr.Close();//�ر�˳�����ݼ�
			con.Close();//�ر�����
		}

	}
}
