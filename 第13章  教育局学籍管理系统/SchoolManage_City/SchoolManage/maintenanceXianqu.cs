using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// maintenanceXianqu ��ժҪ˵����
	/// </summary>
	public class maintenanceXianqu : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_QuXian_Name;
		private System.Windows.Forms.TextBox textBox_QuXian_ID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		public maintenanceXianqu()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			
			//��DataGrid��ʾ,δѡ���κ���Ч����button1.Enabled=false;
			string str_Sql,errorstring;
			str_Sql="SELECT QuXian_ID AS ���ش���,QuXian_Name AS �������� FROM QuXian";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			button1.Enabled=false;
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
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_QuXian_Name = new System.Windows.Forms.TextBox();
			this.textBox_QuXian_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(208, 401);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 41;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 361);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 40;
			this.label2.Text = "��������";
			// 
			// textBox_QuXian_Name
			// 
			this.textBox_QuXian_Name.Location = new System.Drawing.Point(232, 360);
			this.textBox_QuXian_Name.Name = "textBox_QuXian_Name";
			this.textBox_QuXian_Name.Size = new System.Drawing.Size(104, 21);
			this.textBox_QuXian_Name.TabIndex = 39;
			this.textBox_QuXian_Name.Text = "";
			// 
			// textBox_QuXian_ID
			// 
			this.textBox_QuXian_ID.Enabled = false;
			this.textBox_QuXian_ID.Location = new System.Drawing.Point(112, 359);
			this.textBox_QuXian_ID.Name = "textBox_QuXian_ID";
			this.textBox_QuXian_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_QuXian_ID.TabIndex = 38;
			this.textBox_QuXian_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(72, 361);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 37;
			this.label1.Text = "���";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 401);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 36;
			this.button1.Text = "ȷ���޸�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                   �����������";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(70, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 300);
			this.DataGrid1.TabIndex = 35;
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(112, 448);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 23);
			this.label3.TabIndex = 42;
			this.label3.Text = "��ϵͳ���,����ɾ�����е����أ�";
			// 
			// maintenanceXianqu
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(464, 494);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_QuXian_Name);
			this.Controls.Add(this.textBox_QuXian_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "maintenanceXianqu";
			this.Text = "�����޸�";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (conn.KickOut(textBox_QuXian_Name.Text)=="") 
			{
				MessageBox.Show("���������������ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_QuXian_Name.Text.Length>15)
			{
				MessageBox.Show("�벻Ҫ���������������ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			//ȥ��'"?%=�ո�,�޸�ѧУ���ͱ�
			string str_Sql,errorstring="";
			str_Sql="UPDATE QuXian SET QuXian_Name='"+conn.KickOut(textBox_QuXian_Name.Text)
				+"' WHERE QuXian_ID="+textBox_QuXian_ID.Text;
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("�޸Ĳ��ɹ����������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("�ɹ��޸ģ�", "���ѣ�",
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			//ˢ��DataGrid��ʾ,�ÿո���Ϣ��,�ȴ�ѡ���µ���Ч��
			str_Sql="SELECT QuXian.QuXian_ID AS ���ش���,QuXian.QuXian_Name AS �������� FROM QuXian";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");	

			textBox_QuXian_ID.Text="";
			textBox_QuXian_Name.Text="";

			button1.Enabled=false;			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{				
			this.Dispose();	
		}
		
		//���ݵ�ǰѡ�еĵ�Ԫ��,���ݵ�ǰ�е�����趨��ǰѡ�е�ѧУ���͵�ԭ����Ϣ,��ʱ�޸İ�ť��Ч
		private void DataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid1.Select(DataGrid1.CurrentRowIndex);

			textBox_QuXian_ID.Text=DataGrid1[DataGrid1.CurrentRowIndex,0].ToString();
			textBox_QuXian_Name.Text=conn.QuXian_IDtoWhat(textBox_QuXian_ID.Text,"QuXian_Name");
			
			button1.Enabled=true;
		}
	}
}
