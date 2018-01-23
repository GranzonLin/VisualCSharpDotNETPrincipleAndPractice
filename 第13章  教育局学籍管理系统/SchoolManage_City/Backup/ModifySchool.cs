using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// ModifySchool ��ժҪ˵����
	/// </summary>
	public class ModifySchool : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid DataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBox1_School_Type;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_School_Address;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_School_Zip;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_School_Tel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_Schoolmaster;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2_School_Name;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_School_ID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;

		protected config conn=new config();

		public ModifySchool()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			string str_Sql,errorstring;
			errorstring=conn.BindComboBox("Select * from School_Type",comboBox1_School_Type,"School_Type_ID","School_Type_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("�������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
						
			//��DataGrid��ʾ,δѡ���κ���Ч����button1.Enabled=false;
			conn.BindComboBox("Select * from School_Type",comboBox1_School_Type,"School_Type_ID","School_Type_Name");
		
			str_Sql="SELECT School_ID AS ѧУ����,School_Name AS ѧУ����,School_Type_Name AS ѧУ���,Schoolmaster AS У��,School_Tel AS �绰,School_Zip AS ��������,School_Address AS ѧУ��ַ,School_Type_Year AS ѧУѧ������ FROM View_School Order By School_Type_ID,School_ID";
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
			this.button2 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.comboBox1_School_Type = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_School_Address = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_School_Zip = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_School_Tel = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_Schoolmaster = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2_School_Name = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_School_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(576, 368);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 48;
			this.button2.Text = "�˳�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AllowDrop = true;
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                     ѧУ��Ϣ";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(16, 40);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(752, 200);
			this.DataGrid1.TabIndex = 47;
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.DataGrid1_CurrentCellChanged);
			// 
			// comboBox1_School_Type
			// 
			this.comboBox1_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1_School_Type.Location = new System.Drawing.Point(120, 304);
			this.comboBox1_School_Type.Name = "comboBox1_School_Type";
			this.comboBox1_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox1_School_Type.TabIndex = 62;
			this.comboBox1_School_Type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_School_Type_KeyPress);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(40, 303);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 61;
			this.label7.Text = "ѧУ���";
			// 
			// textBox_School_Address
			// 
			this.textBox_School_Address.Location = new System.Drawing.Point(120, 368);
			this.textBox_School_Address.Name = "textBox_School_Address";
			this.textBox_School_Address.Size = new System.Drawing.Size(384, 21);
			this.textBox_School_Address.TabIndex = 60;
			this.textBox_School_Address.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(40, 368);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 59;
			this.label6.Text = "ѧУ��ַ��";
			// 
			// textBox_School_Zip
			// 
			this.textBox_School_Zip.Location = new System.Drawing.Point(360, 336);
			this.textBox_School_Zip.Name = "textBox_School_Zip";
			this.textBox_School_Zip.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_Zip.TabIndex = 58;
			this.textBox_School_Zip.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(280, 335);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 57;
			this.label5.Text = "�������룺";
			// 
			// textBox_School_Tel
			// 
			this.textBox_School_Tel.Location = new System.Drawing.Point(120, 336);
			this.textBox_School_Tel.Name = "textBox_School_Tel";
			this.textBox_School_Tel.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_Tel.TabIndex = 56;
			this.textBox_School_Tel.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 335);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 55;
			this.label4.Text = "�绰��";
			// 
			// textBox_Schoolmaster
			// 
			this.textBox_Schoolmaster.Location = new System.Drawing.Point(360, 304);
			this.textBox_Schoolmaster.Name = "textBox_Schoolmaster";
			this.textBox_Schoolmaster.Size = new System.Drawing.Size(96, 21);
			this.textBox_Schoolmaster.TabIndex = 54;
			this.textBox_Schoolmaster.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(280, 303);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 53;
			this.label3.Text = "У����";
			// 
			// textBox2_School_Name
			// 
			this.textBox2_School_Name.Location = new System.Drawing.Point(360, 272);
			this.textBox2_School_Name.Name = "textBox2_School_Name";
			this.textBox2_School_Name.Size = new System.Drawing.Size(192, 21);
			this.textBox2_School_Name.TabIndex = 52;
			this.textBox2_School_Name.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(280, 271);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 51;
			this.label2.Text = "ѧУ���ƣ�";
			// 
			// textBox_School_ID
			// 
			this.textBox_School_ID.Enabled = false;
			this.textBox_School_ID.Location = new System.Drawing.Point(120, 272);
			this.textBox_School_ID.Name = "textBox_School_ID";
			this.textBox_School_ID.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_ID.TabIndex = 50;
			this.textBox_School_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 271);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 49;
			this.label1.Text = "ѧУ���룺";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(576, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 48;
			this.button1.Text = "�޸�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ModifySchool
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 438);
			this.Controls.Add(this.comboBox1_School_Type);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox_School_Address);
			this.Controls.Add(this.textBox_School_Zip);
			this.Controls.Add(this.textBox_School_Tel);
			this.Controls.Add(this.textBox_Schoolmaster);
			this.Controls.Add(this.textBox2_School_Name);
			this.Controls.Add(this.textBox_School_ID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.button1);
			this.Name = "ModifySchool";
			this.Text = "�޸�ѧУ��Ϣ";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();	
		}

		//���ݵ�ǰѡ�еĵ�Ԫ��,���ݵ�ǰ�е�����趨��ǰѡ�е�ѧУ��ԭ����Ϣ,��ʱ�޸İ�ť��Ч
		private void DataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid1.Select(DataGrid1.CurrentRowIndex);

			textBox_School_ID.Text=DataGrid1[DataGrid1.CurrentRowIndex,0].ToString();
			textBox2_School_Name.Text=conn.School_IDtoWhat(textBox_School_ID.Text,"School_Name");
			comboBox1_School_Type.SelectedValue=int.Parse(conn.School_IDtoWhat(textBox_School_ID.Text,"School_Type_ID"));
			textBox_Schoolmaster.Text=conn.School_IDtoWhat(textBox_School_ID.Text,"Schoolmaster");
			textBox_School_Tel.Text=conn.School_IDtoWhat(textBox_School_ID.Text,"School_Tel");
			textBox_School_Zip.Text=conn.School_IDtoWhat(textBox_School_ID.Text,"School_Zip");
			textBox_School_Address.Text=conn.School_IDtoWhat(textBox_School_ID.Text,"School_Address");
			
			button1.Enabled=true;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (textBox_School_ID.Text==""||textBox2_School_Name.Text=="") 
			{
				MessageBox.Show("��������ѧУ���ƺ�ѧУ���룡", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_School_ID.Text.Length!=12||textBox2_School_Name.Text.Length>50||textBox_Schoolmaster.Text.Length>50||textBox_School_Tel.Text.Length>20||textBox_School_Zip.Text.Length>6||textBox_School_Address.Text.Length>100) 
			{
				MessageBox.Show("�벻Ҫ�������룡\r\nѧУ����ֻ��Ϊ12λ��\r\n�ʱ�ֻ��Ϊ��λ����", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			//ȥ��'"?%=�ո�,�޸�ѧУ��Ϣ��
			string errorstring="";
			string str_Sql="UPDATE School SET School_Name='"+conn.KickOut(textBox2_School_Name.Text)
				+"',School_Type_ID="+comboBox1_School_Type.SelectedValue.ToString()
				+",Schoolmaster='"+conn.KickOut(textBox_Schoolmaster.Text)
				+"',School_Tel='"+conn.KickOut(textBox_School_Tel.Text)
				+"',School_Zip='"+conn.KickOut(textBox_School_Zip.Text)
				+"',School_Address='"+conn.KickOut(textBox_School_Address.Text)
				+"' WHERE School_ID='"+conn.KickOut(textBox_School_ID.Text)+"'";
			
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("δ�ɹ��޸ģ��������ݿ⣡"+errorstring, "���ѣ�", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("�ɹ��޸ģ�", "���ѣ�",
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			//ˢ��DataGrid��ʾ,�ÿո���Ϣ��,�ȴ�ѡ���µ���Ч��
			str_Sql="SELECT School_ID AS ѧУ����,School_Name AS ѧУ����,School_Type_Name AS ѧУ���,Schoolmaster AS У��,School_Tel AS �绰,School_Zip AS ��������,School_Address AS ѧУ��ַ,School_Type_Year AS ѧУѧ������ FROM View_School";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			textBox_School_ID.Text="";
			textBox2_School_Name.Text="";
			textBox_Schoolmaster.Text="";
			textBox_School_Tel.Text="";
			textBox_School_Zip.Text="";
			textBox_School_Address.Text="";
			
			button1.Enabled=false;;			
		}

		private void comboBox1_School_Type_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}
