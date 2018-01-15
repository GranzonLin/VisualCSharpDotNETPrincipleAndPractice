using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace csharp7_3_3
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		/// 
		SqlDataAdapter adapter;
		DataSet ds;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			string str=@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage";
			//string str="server=(local);Integrated Security=SSPI;database=stumanage";
		    SqlConnection con=new SqlConnection(str);
			string sqlstr="select * from scores";
			adapter=new SqlDataAdapter(sqlstr,con);
			SqlCommandBuilder builder=new SqlCommandBuilder(adapter);
            //adapter.InsertCommand = builder.GetInsertCommand();
            //adapter.DeleteCommand = builder.GetDeleteCommand();
            //adapter.UpdateCommand = builder.GetUpdateCommand();
			ds=new DataSet();
			adapter.Fill(ds,"scores");
			this.dataGrid1.DataSource=ds.Tables["scores"];

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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ѧ��������Ϣcheck(english_score<100)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 48);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(505, 193);
            this.dataGrid1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(525, 250);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(ds.HasChanges())				
			{
				DialogResult result=MessageBox.Show("������δ���棬�����������޸���","��ʾ", MessageBoxButtons.YesNoCancel);
				switch(result)
				{
					case DialogResult.Yes:
						try
						{
							this.adapter.Update(ds,"scores");
							e.Cancel=false;
						}
						catch(Exception err)
						{
							MessageBox.Show(err.Message,"����",MessageBoxButtons.OK, MessageBoxIcon. Error);
							e.Cancel=true;
						}
						break;
					case DialogResult.No :
						e.Cancel=false;
						break;
					case DialogResult.Cancel:
						e.Cancel=true;
						break;							
				}				
			}
		
		}

	
		
	}
}
