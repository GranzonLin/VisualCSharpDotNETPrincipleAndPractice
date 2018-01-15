using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace csharp7_6_2
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// ����������������
		/// </summary>
		/////private string constr="server=(local);integrated security=SSPI; database=stumanage ";
        private string constr = @"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage";
SqlConnection con;
SqlDataAdapter adapter;
DataSet ds;
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
string sqlstr="select * from stuinfo";
			con=new SqlConnection(constr);
			adapter=new SqlDataAdapter(sqlstr,con);
SqlCommandBuilder builder=new SqlCommandBuilder(adapter);
adapter.UpdateCommand=builder.GetUpdateCommand();
ds=new DataSet();
adapter.Fill(ds,"stuinfo");
this.textBox1.DataBindings.Add(new Binding("Text",ds,"stuinfo.stu_name"));//��textbox1��textbox2��textbox3��Text����
this.textBox2.DataBindings.Add(new Binding("Text",ds,"stuinfo.sex"));//�ֱ�󶨵�dataset�е�stuinfo���stu_name,sex,class_id�ֶ���
this.textBox3.DataBindings.Add(new Binding("Text",ds,"stuinfo.classes"));//class_id"));
for(int i=0;i<ds.Tables[0].Rows.Count;i++)//��comboBox1�󶨵�dataset�е�stuinfo���stu_id�ֶ���
			{	
this.comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
			}
this.comboBox1.SelectedIndex=0;
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(144, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ѧ��ͼ��ɼ���Ϣ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.Location = new System.Drawing.Point(48, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "�� ����";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "�� ����";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox3.Location = new System.Drawing.Point(88, 216);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 21);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "textBox3";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(88, 152);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 21);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "textBox2";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ѧ �ţ�";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "�� ��";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(88, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 21);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "textBox1";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("������κ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(40, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "�޸���Ƭ";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Font = new System.Drawing.Font("������κ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(184, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "ɾ����Ƭ";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Font = new System.Drawing.Font("������κ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(344, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 32);
            this.button3.TabIndex = 12;
            this.button3.Text = "������Ƭ";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(248, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 264);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 240);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(496, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "���ݿ��е�ͼ���ȡ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
private void ShowImage()
		{
			if(this.pictureBox1.Image!=null)//�ͷ�ռ�ÿռ�
			{
				this.pictureBox1.Image.Dispose();
			}//�����ǰ��¼��ͼ���ֶβ���SQL SERVER�Ŀ�ֵ������ʾͼ��//ע�⣬��C#����convert.DBNull��ʾSQL Server�Ŀ�ֵNULL
if(ds.Tables[0].Rows[this.comboBox1.SelectedIndex][6]!=Convert.DBNull)
			{//�����ݼ��б��photo�ֶ�ֵ����bytes�ֽ�������
byte[] bytes=(byte[])ds.Tables[0].Rows[this.comboBox1.SelectedIndex][6];
MemoryStream memStream=new MemoryStream(bytes);//�����ֽ��������MemoryStream����
Bitmap myImage=new Bitmap(memStream);//����MemoryStream�������Bitmapλͼ����
this.pictureBox1.Image=myImage;//��Bitmap����ֵ��pictureBox1������ʾͼ��
			}
			else 
			{
this.pictureBox1.Image=null;
			}
		}
private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)//���comboBox1���¼����룬���Ը����û���ѡ����ʾͼ�񣬸�����Ӧ���ı���
		{
ShowImage();
this.BindingContext[ds,"stuinfo"].Position=this.comboBox1.SelectedIndex;
		}
private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFile=new OpenFileDialog();//����ѡ���ļ��Ի���ѡȡͼ���ļ�
			openFile.Filter="*.jpg;*.bmp;*.*|*.jpg;*.bmp;*.*";
if(openFile.ShowDialog()==DialogResult.OK)//����û�ѡȡ��ͼ���ļ�
			{
	Stream myStream=openFile.OpenFile();//����Stream������
	int length=(int)myStream.Length;
	byte[] bytes=new byte[length];//�����ֽ��������
	myStream.Read(bytes,0,length);//��ȡͼ���ļ��������ݷ����ֽ�������
	myStream.Close();
ds.Tables[0].Rows[this.comboBox1.SelectedIndex][6]=bytes;//���ֽ������е�ֵ������ݼ��ı��Ӧ��image�ֶ�
ShowImage();//������ʾͼ��
			}
		}
private void button2_Click(object sender, System.EventArgs e)//ɾ��ͼƬ
		{
ds.Tables[0].Rows[this.comboBox1.SelectedIndex][6]=Convert.DBNull;
ShowImage();
		}
private void button3_Click(object sender, System.EventArgs e)//����ͼƬ�������ݿ�
		{
			try
			{
				adapter.Update(ds,"stuinfo");
				MessageBox.Show("����ɹ���");
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"����ʧ��");
			}
		}

	}
}
