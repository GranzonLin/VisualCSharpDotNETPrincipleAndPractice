using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Library.UserInterface;
using Library.DataLevel;
namespace Library
{
	/// <summary>
	/// Query ��ժҪ˵����
	/// </summary>
	public class Query : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboDataTable;
		private System.Windows.Forms.ComboBox comboDataItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textValue;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnQuery;
		public string SqlString;
		public string OrderString;
		public string QueryString;
		private System.Windows.Forms.ComboBox comboCondition;
		private System.Windows.Forms.GroupBox groupBox1;
		
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataBaseConnection dbc=new DataBaseConnection();
		private string userSort;
		private System.Data.SqlClient.SqlConnection conn;
		private System.Windows.Forms.DataGrid dg;
		private string userName;
		public Query(string username,string usersort)
		{
			//
			// Windows ���������֧���������
			//
			this.userName=username;			
		
			InitializeComponent();
			conn.ConnectionString=dbc.databaseConnection;
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
			this.comboDataTable = new System.Windows.Forms.ComboBox();
			this.comboDataItem = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textValue = new System.Windows.Forms.TextBox();
			this.dg = new System.Windows.Forms.DataGrid();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnQuery = new System.Windows.Forms.Button();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.comboCondition = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboDataTable
			// 
			this.comboDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDataTable.Items.AddRange(new object[] {
																"������Ϣ",
																"ͼ����Ϣ",
																"��������Ϣ",
																"������Ϣ"});
			this.comboDataTable.Location = new System.Drawing.Point(104, 24);
			this.comboDataTable.Name = "comboDataTable";
			this.comboDataTable.Size = new System.Drawing.Size(104, 20);
			this.comboDataTable.TabIndex = 0;
			this.comboDataTable.SelectedIndexChanged += new System.EventHandler(this.comboDataTable_SelectedIndexChanged);
			// 
			// comboDataItem
			// 
			this.comboDataItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDataItem.Location = new System.Drawing.Point(104, 56);
			this.comboDataItem.Name = "comboDataItem";
			this.comboDataItem.Size = new System.Drawing.Size(104, 20);
			this.comboDataItem.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "ѡ���ѯ��Ϣ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "ѡ���ѯ��";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(240, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "ѡ���ѯ����";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(320, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "����ָ��ֵ";
			// 
			// textValue
			// 
			this.textValue.Location = new System.Drawing.Point(320, 48);
			this.textValue.Name = "textValue";
			this.textValue.Size = new System.Drawing.Size(88, 21);
			this.textValue.TabIndex = 7;
			this.textValue.Text = "";
			// 
			// dg
			// 
			this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dg.DataMember = "";
			this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dg.Location = new System.Drawing.Point(16, 128);
			this.dg.Name = "dg";
			this.dg.ReadOnly = true;
			this.dg.Size = new System.Drawing.Size(504, 223);
			this.dg.TabIndex = 8;
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClear.Location = new System.Drawing.Point(456, 48);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(64, 24);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "����";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(456, 80);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(64, 24);
			this.btnExit.TabIndex = 10;
			this.btnExit.Text = "�˳�";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnQuery
			// 
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuery.Location = new System.Drawing.Point(456, 16);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(64, 23);
			this.btnQuery.TabIndex = 11;
			this.btnQuery.Text = "��ѯ";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=YXY1681;packet size=4096;integrated security=SSPI;data source=yxy1" +
				"681;persist security info=False;initial catalog=BookManager";
			// 
			// comboCondition
			// 
			this.comboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCondition.Items.AddRange(new object[] {
																"=",
																">",
																">=",
																"<",
																"<=",
																"<>",
																"Like"});
			this.comboCondition.Location = new System.Drawing.Point(224, 48);
			this.comboCondition.Name = "comboCondition";
			this.comboCondition.Size = new System.Drawing.Size(80, 20);
			this.comboCondition.TabIndex = 12;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboDataTable);
			this.groupBox1.Controls.Add(this.comboDataItem);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textValue);
			this.groupBox1.Controls.Add(this.comboCondition);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 96);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "��ѯ����";
			// 
			// Query
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(536, 373);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.dg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Query";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�ۺϲ�ѯ";
			this.Load += new System.EventHandler(this.Query_Load);
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void ErrorHandle(System.Exception E)
		{
			MessageBox.Show(E.ToString());
		}		


		
		
		

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void comboDataTable_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strTable=this.comboDataTable.SelectedItem.ToString();
			SetcomboDataItem(strTable);	
		}
			
			
	
		
		private void SetcomboDataItem(string strTable)
		{
				switch(strTable)
				{
					case"������Ϣ"://���б���"������Ϣ"�ѡ��
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("����֤��");
						this.comboDataItem.Items.Add("��������");
						this.comboDataItem.Items.Add("��������");
						this.comboDataItem.Items.Add("���ߵ绰����");
						this.comboDataItem.Items.Add("��������");
						this.comboDataItem.Items.Add("�����ѽ�����Ŀ");
						break;
				
					case"ͼ����Ϣ"://���б���"ͼ����Ϣ"�ѡ��
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("ͼ����");
						this.comboDataItem.Items.Add("����");
						this.comboDataItem.Items.Add("����");
						this.comboDataItem.Items.Add("������");
						this.comboDataItem.Items.Add("��������");
						this.comboDataItem.Items.Add("����");
						this.comboDataItem.Items.Add("����");
						this.comboDataItem.Items.Add("�ݲ�����");
						this.comboDataItem.Items.Add("ʣ����Ŀ");
						break;
				
					case"��������Ϣ"://���б���"��������Ϣ"�ѡ��
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("��������");
						this.comboDataItem.Items.Add("��ַ");
						this.comboDataItem.Items.Add("�绰����");
						this.comboDataItem.Items.Add("����");
						break;
				
					case"������Ϣ"://���б���"������Ϣ"�ѡ��
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("����֤��");
						this.comboDataItem.Items.Add("ͼ����");
						this.comboDataItem.Items.Add("��������");
						this.comboDataItem.Items.Add("Ӧ��������");
						this.comboDataItem.Items.Add("ʵ�ʻ�������");
						break;
				}
		}
		
		
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.comboDataTable.Text="";
			this.comboDataItem.Text="";
			this.comboCondition.Text="";
			this.textValue.Text="";
		}

		private string SetSelectTable(string strTable)
		{
			string SqlString="";
			switch(strTable)
			{
				case"ͼ����Ϣ"://���б���"ͼ����Ϣ"�ѡ��
					SqlString="SELECT BookID AS ͼ����, BookName AS ����, BookWriter AS ����, ";
					SqlString+="BookPublish AS ������, BookPublishDate AS ��������, BookPrice AS ����, ";
					SqlString+="  BookSort AS ����, BookAmount AS �ݲ�����, BookRemain AS ʣ����Ŀ";
					SqlString+="  FROM dbo.Book";
					break;
					
				case"������Ϣ"://���б���"������Ϣ"�ѡ��
					SqlString="SELECT ReaderID AS ����֤��, ReaderName AS ��������, ReaderPassword AS ��������, ";
					SqlString+="  ReaderPhoneNo AS ���ߵ绰����, ReaderEmail AS ��������, ";
					SqlString+="  ReaderBorrowedbooks AS �����ѽ�����Ŀ";
					SqlString+=" FROM dbo.Reader";
					break;
				case"��������Ϣ"://���б���"��������Ϣ"�ѡ��
					SqlString="SELECT PublishName AS ��������, PublishAddress AS ��ַ, ";
					SqlString+="  PublishPhoneNo AS �绰����, PbulishEmail AS ���� ";
					SqlString+=" FROM dbo.PublishCompany";
					break;
				case"������Ϣ"://���б���"������Ϣ"�ѡ��
					SqlString="SELECT ReaderID AS ����֤��, BookID AS ͼ����, BorrowDate AS ��������, ";
					SqlString+="  ReturnDate AS Ӧ��������, FactReturnDate AS ʵ�ʻ�������";
					SqlString+="  FROM dbo.BorrowBook";
					break;
			}
			return SqlString;
		}
		private string SetSelectData(string dataItem)
		{
			string Item="";
			switch(dataItem)
			{
				case"����֤��"://���б���"����֤��"�ѡ��
					Item=" ReaderID";
					break;
				case"��������"://���б���"��������"�ѡ��
					Item=" ReaderName ";
					break;
				case"��������"://���б���"��������"�ѡ��
					Item=" ReaderPassword";
					break;
				case"��������"://���б���"��������"�ѡ��
					Item=" ReaderEmail";
					break;
				case"�����ѽ�����Ŀ"://���б���"�����ѽ���Ŀ"�ѡ��
					Item=" ReaderBorrowedbooks";
					break;
				case"���ߵ绰����": ////���б���"���ߵ绰����"�ѡ��
					Item=" ReaderPhoneNo";
					break;
				case"ͼ����":
					Item=" BookID";
					break;
				case"����":
					Item=" BookName";
					break;
				case"����":
					Item=" BookWriter";
					break;
				case"������":
					Item=" BookPublish";
					break;
				case"��������":
					Item=" BookPublishDate";
					break;
				case"����":
					Item=" BookPrice";
					break;
				case"����":
					Item=" BookSort";
					break;
				case"�ݲ�����":
					Item=" BookAmount";
					break;
				case"ʣ����Ŀ":
					Item=" BookRemain";
					break;
				case"��������":
					Item=" PublishName";
					break;
				case"��ַ":
					Item=" PublishAddress";
					break;
				case"�绰����":
					Item=" PublishPhoneNo";
					break;
				case"����":
					Item=" PbulishEmail";
					break;
				case"��������":
					Item=" BorrowDate";
					break;
				case"Ӧ��������":
					Item=" ReturnDate";
					break;
				case"ʵ�ʻ�������":
					Item=" FactReturnDate";
					break;
			}
			return Item;
		}
		private string SetTableName(string tableName)
		{
			string TableName="";
			switch(tableName)
			{
				case"ͼ����Ϣ":
					TableName="Book";
					break;
				case"������Ϣ":
					TableName="Reader";
					break;
				case"��������Ϣ":
					TableName="PublishCompany";
					break;
				case"������Ϣ":
					TableName="BorrowBook";
					break;
			
			}
			return TableName;
		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string conValue = this.textValue.Text;//ָ��������ֵ
			string strTable=this.comboDataTable.Text;
			SqlString=SetSelectTable(strTable);
			if ((this.comboCondition.Text == "Like") && (this.textValue.Text != ""))
				conValue = "%"+this.textValue.Text+"%";
			string dataItem=SetSelectData(this.comboDataItem.Text);
			if ((this.comboDataItem.Text != "") && (this.comboCondition.Text != "") && (this.textValue.Text != ""))
				SqlString=SqlString+" where "+dataItem+" "+this.comboCondition.Text+" '"+conValue+"'";
				DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(SqlString,conn);
			try
			{
				da.Fill(ds,"Query");
				dg.DataSource=ds.Tables["Query"].DefaultView;
				
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}

		private void Query_Load(object sender, System.EventArgs e)
		{
			
		}

		
	}
}
