using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// maintenanceOffice ��ժҪ˵����
	/// </summary>
	public class maintenanceOffice : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.TextBox textBox_Office_Name;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1_QuXian;
		private System.Windows.Forms.TextBox textBox_Office_ID;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();

		public maintenanceOffice()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//�������б���ʾ���е���������
			string str_Sql,errorstring;
			errorstring=conn.BindComboBox("Select * from QuXian WHERE QuXian_ID<>9",comboBox1_QuXian,"QuXian_ID","QuXian_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			//��DataGrid��ʾ,δѡ���κ���Ч����button1.Enabled=false;
			str_Sql="SELECT Office.Office_ID AS ���´�����,Office.Office_Name AS ���´�����,QuXian.QuXian_Name AS �������� FROM Office  inner join QuXian  on Office.QuXian_ID_OfficeIn=QuXian.QuXian_ID ";
			conn.Fill(str_Sql);
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
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Office_Name = new System.Windows.Forms.TextBox();
			this.textBox_Office_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1_QuXian = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(153, 429);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 23);
			this.label3.TabIndex = 50;
			this.label3.Text = "��ϵͳ���,����ɾ�����е����أ�";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(249, 382);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 49;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(104, 344);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 48;
			this.label2.Text = "���´�����";
			// 
			// textBox_Office_Name
			// 
			this.textBox_Office_Name.Location = new System.Drawing.Point(176, 342);
			this.textBox_Office_Name.Name = "textBox_Office_Name";
			this.textBox_Office_Name.Size = new System.Drawing.Size(104, 21);
			this.textBox_Office_Name.TabIndex = 47;
			this.textBox_Office_Name.Text = "";
			// 
			// textBox_Office_ID
			// 
			this.textBox_Office_ID.Enabled = false;
			this.textBox_Office_ID.Location = new System.Drawing.Point(72, 342);
			this.textBox_Office_ID.Name = "textBox_Office_ID";
			this.textBox_Office_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_Office_ID.TabIndex = 46;
			this.textBox_Office_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 344);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 45;
			this.label1.Text = "���";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(97, 382);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 44;
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
			this.DataGrid1.CaptionText = "                   ���а��´����";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(100, 11);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 300);
			this.DataGrid1.TabIndex = 43;
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(296, 344);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 48;
			this.label4.Text = "��������";
			// 
			// comboBox1_QuXian
			// 
			this.comboBox1_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1_QuXian.Location = new System.Drawing.Point(368, 342);
			this.comboBox1_QuXian.MaxDropDownItems = 10;
			this.comboBox1_QuXian.Name = "comboBox1_QuXian";
			this.comboBox1_QuXian.Size = new System.Drawing.Size(104, 20);
			this.comboBox1_QuXian.TabIndex = 51;
			// 
			// maintenanceOffice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 462);
			this.Controls.Add(this.comboBox1_QuXian);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_Office_Name);
			this.Controls.Add(this.textBox_Office_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.label4);
			this.Name = "maintenanceOffice";
			this.Text = "���´��޸�";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (conn.KickOut(textBox_Office_Name.Text)=="") 
			{
				MessageBox.Show("����������´����ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_Office_Name.Text.Length>15)
			{
				MessageBox.Show("�벻Ҫ����������´����ƣ�", "���棡", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
						
			//ȥ��'"?%=�ո�,�޸İ��´���
			string str_Sql,errorstring="";
			str_Sql="UPDATE Office SET Office_Name='"+conn.KickOut(textBox_Office_Name.Text)
				+"',QuXian_ID_OfficeIn="+comboBox1_QuXian.SelectedValue
				+" WHERE Office_ID="+textBox_Office_ID.Text;
			
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
			str_Sql="SELECT Office.Office_ID AS ���´�����,Office.Office_Name AS ���´�����,QuXian.QuXian_Name AS �������� FROM Office  inner join QuXian  on Office.QuXian_ID_OfficeIn=QuXian.QuXian_ID ";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");	
	
			textBox_Office_ID.Text="";
			textBox_Office_Name.Text="";

			button1.Enabled=false;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{			
			this.Dispose();			
		}
		
		//���ݵ�ǰѡ�еĵ�Ԫ��,���ݵ�ǰ�е�����趨��ǰѡ�еİ��´���ԭ����Ϣ,��ʱ�޸İ�ť��Ч
		private void DataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid1.Select(DataGrid1.CurrentRowIndex);

			textBox_Office_ID.Text=DataGrid1[DataGrid1.CurrentRowIndex,0].ToString();
			textBox_Office_Name.Text=conn.Office_IDtoWhat(textBox_Office_ID.Text,"Office_Name");
			comboBox1_QuXian.SelectedValue=(int.Parse(conn.Office_IDtoWhat(textBox_Office_ID.Text,"QuXian_ID_OfficeIn")));
		
			button1.Enabled=true;
		}
	}
}
