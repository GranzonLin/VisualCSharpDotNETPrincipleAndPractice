using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Library.UserInterface
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{		
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraNavBar.NavBarControl navBarControl1;
		private DevExpress.XtraNavBar.NavBarGroup groData;
		private DevExpress.XtraNavBar.NavBarItem lkBook;
		private DevExpress.XtraNavBar.NavBarItem lkUser;
		private DevExpress.XtraNavBar.NavBarItem lkReader;
		private DevExpress.XtraNavBar.NavBarItem lkPublishing;
		private DevExpress.XtraNavBar.NavBarGroup groOther;
		private DevExpress.XtraNavBar.NavBarItem lkQuery;
		private DevExpress.XtraNavBar.NavBarItem lkBorrowback;
		private DevExpress.XtraNavBar.NavBarGroup groExit;
		private DevExpress.XtraNavBar.NavBarItem lkExit;
		private System.Windows.Forms.Splitter splitter;
		private DevExpress.XtraNavBar.NavBarItem lkReturn;
		
		private string userName;

		private void ExitApplication(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
				this.Close();
		}
		private string userSort;
		private string Sort;
	
		public MainForm(string username,string usersort)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			this.userName=username;			
			this.userSort=usersort;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
			this.groExit = new DevExpress.XtraNavBar.NavBarGroup();
			this.lkExit = new DevExpress.XtraNavBar.NavBarItem();
			this.lkReturn = new DevExpress.XtraNavBar.NavBarItem();
			this.groData = new DevExpress.XtraNavBar.NavBarGroup();
			this.lkBook = new DevExpress.XtraNavBar.NavBarItem();
			this.lkUser = new DevExpress.XtraNavBar.NavBarItem();
			this.lkReader = new DevExpress.XtraNavBar.NavBarItem();
			this.lkPublishing = new DevExpress.XtraNavBar.NavBarItem();
			this.groOther = new DevExpress.XtraNavBar.NavBarGroup();
			this.lkQuery = new DevExpress.XtraNavBar.NavBarItem();
			this.lkBorrowback = new DevExpress.XtraNavBar.NavBarItem();
			this.splitter = new System.Windows.Forms.Splitter();
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// navBarControl1
			// 
			this.navBarControl1.ActiveGroup = this.groExit;
			this.navBarControl1.AllowDrop = true;
			this.navBarControl1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
																							this.groData,
																							this.groOther,
																							this.groExit});
			this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
																						  this.lkReader,
																						  this.lkPublishing,
																						  this.lkBook,
																						  this.lkUser,
																						  this.lkBorrowback,
																						  this.lkQuery,
																						  this.lkExit,
																						  this.lkReturn});
			this.navBarControl1.Location = new System.Drawing.Point(0, 0);
			this.navBarControl1.Name = "navBarControl1";
			this.navBarControl1.Size = new System.Drawing.Size(140, 525);
			this.navBarControl1.Styles.AddReplace("Button", new DevExpress.Utils.ViewStyleEx("Button", "NavBarControl", "", true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
			this.navBarControl1.TabIndex = 19;
			this.navBarControl1.Text = "navBarControl1";
			this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
			// 
			// groExit
			// 
			this.groExit.Caption = "�˳�ϵͳ";
			this.groExit.Expanded = true;
			this.groExit.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						   new DevExpress.XtraNavBar.NavBarItemLink(this.lkReturn),
																						   new DevExpress.XtraNavBar.NavBarItemLink(this.lkExit)});
			this.groExit.Name = "groExit";
			// 
			// lkExit
			// 
			this.lkExit.Caption = "�˳�ϵͳ";
			this.lkExit.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkExit.LargeImage")));
			this.lkExit.Name = "lkExit";
			this.lkExit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ExitApplication);
			// 
			// lkReturn
			// 
			this.lkReturn.Caption = "���ص�¼";
			this.lkReturn.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkReturn.LargeImage")));
			this.lkReturn.Name = "lkReturn";
			this.lkReturn.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.Return);
			// 
			// groData
			// 
			this.groData.Caption = "����ά��";
			this.groData.Expanded = true;
			this.groData.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																						   new DevExpress.XtraNavBar.NavBarItemLink(this.lkBook),
																						   new DevExpress.XtraNavBar.NavBarItemLink(this.lkUser),
																						   new DevExpress.XtraNavBar.NavBarItemLink(this.lkReader),
																						   new DevExpress.XtraNavBar.NavBarItemLink(this.lkPublishing)});
			this.groData.Name = "groData";
			// 
			// lkBook
			// 
			this.lkBook.Caption = "ͼ����Ϣ";
			this.lkBook.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkBook.LargeImage")));
			this.lkBook.Name = "lkBook";
			this.lkBook.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShowBook);
			// 
			// lkUser
			// 
			this.lkUser.Caption = "�û���Ϣ";
			this.lkUser.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkUser.LargeImage")));
			this.lkUser.Name = "lkUser";
			this.lkUser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShowUser);
			// 
			// lkReader
			// 
			this.lkReader.Caption = "������Ϣ";
			this.lkReader.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkReader.LargeImage")));
			this.lkReader.Name = "lkReader";
			this.lkReader.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShowReader);
			// 
			// lkPublishing
			// 
			this.lkPublishing.Caption = "��������Ϣ";
			this.lkPublishing.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkPublishing.LargeImage")));
			this.lkPublishing.Name = "lkPublishing";
			this.lkPublishing.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShowPublishing);
			// 
			// groOther
			// 
			this.groOther.Caption = "��������";
			this.groOther.Expanded = true;
			this.groOther.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
																							new DevExpress.XtraNavBar.NavBarItemLink(this.lkQuery),
																							new DevExpress.XtraNavBar.NavBarItemLink(this.lkBorrowback)});
			this.groOther.Name = "groOther";
			// 
			// lkQuery
			// 
			this.lkQuery.Caption = "�ۺϲ�ѯ";
			this.lkQuery.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkQuery.LargeImage")));
			this.lkQuery.Name = "lkQuery";
			this.lkQuery.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShowQuery);
			// 
			// lkBorrowback
			// 
			this.lkBorrowback.Caption = "���߽軹��";
			this.lkBorrowback.LargeImage = ((System.Drawing.Image)(resources.GetObject("lkBorrowback.LargeImage")));
			this.lkBorrowback.Name = "lkBorrowback";
			this.lkBorrowback.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ShowBorrow);
			// 
			// splitter
			// 
			this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter.Location = new System.Drawing.Point(140, 0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(3, 525);
			this.splitter.TabIndex = 21;
			this.splitter.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(780, 525);
			this.Controls.Add(this.splitter);
			this.Controls.Add(this.navBarControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ͼ�������Ϣϵͳ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		/*static void Main() 
		{
			Application.Run(new MainForm("andy","andy"));
		}*/

		

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			switch(this.userSort)
			{
				case "counter"://�����ǰ�û���"�軹�����Ա"
					this.lkReader.Enabled=false;
					this.lkBook.Enabled=false;
					this.lkPublishing.Enabled=false;
					this.lkUser.Enabled=false;
					break;
				case "bookmanager"://�����ǰ�û���"ͼ�����Ա"
					this.lkReader.Enabled=false;
					this.lkUser.Enabled=false;
					this.lkBorrowback.Enabled=false;
					break;
				case "reader"://�����ǰ�û���"��ͨ����"
					this.lkBook.Caption="ͼ����Ϣ��ѯ";
					this.lkReader.Caption="������Ϣ��ѯ";
					this.lkPublishing.Enabled=false;
					this.lkUser.Enabled=false;
					this.lkBorrowback.Enabled=false;
					this.lkQuery.Enabled=false;
					break;
				case "system"://�����ǰ�û���"ϵͳ����Ա"
					this.lkBook.Enabled=false;
					this.lkBorrowback.Enabled=false;
					this.lkPublishing.Enabled=false;
					break;
			}
		}

		private void ShowPublishing(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form publishForm=new publishingInfo(this.userName,this.userSort);			
			publishForm.MdiParent=this;
			publishForm.Show();
		}

		private void ShowReader(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form readerForm=new ReaderInfo(this.userName,this.userSort);			
			readerForm.MdiParent=this;
			readerForm.Show();
		}

		private void ShowBook(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form bookForm=new BookInfo(this.userName,this.userSort);			
			bookForm.MdiParent=this;
			bookForm.Show();
		}

		private void ShowUser(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form userForm=new UserInfo(this.userName,this.userSort);			
			userForm.MdiParent=this;
			userForm.Show();
		}

		private void ShowBorrow(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form borrowForm=new BorrowReturn(this.userName,this.userSort);			
			borrowForm.MdiParent=this;
			borrowForm.Show();
		}

		private void ShowQuery(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			Form QueryForm=new Query(this.userName,this.userSort);
			QueryForm.MdiParent=this;
			QueryForm.Show();	
		}

		private void Return(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			this.Visible=false;
			Form login=new Login();
			login.ShowDialog();
			this.Close();
		}
	}
}
