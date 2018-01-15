using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace SchoolManage
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem_In;
		private System.Windows.Forms.MenuItem menuItem_System;
		private System.Windows.Forms.MenuItem menuItem_Browse;
		private System.Windows.Forms.MenuItem menuItem_BrowseSchool;
		private System.Windows.Forms.MenuItem menuItem_SearchBrowseStudent;
		private System.Windows.Forms.MenuItem menuItem_BrowseClass;
		private System.Windows.Forms.MenuItem menuItem_Modify;
		private System.Windows.Forms.MenuItem menuItem_ModifySchool;
		private System.Windows.Forms.MenuItem menuItem_maintenanceSchoolType;
		private System.Windows.Forms.MenuItem menuItem_maintenanceClassType;
		private System.Windows.Forms.MenuItem menuItem_maintenanceXianqu;
		private System.Windows.Forms.MenuItem menuItem_maintenanceOffice;
		private System.Windows.Forms.MenuItem menuItem_maintenanceCommittee;
		private System.Windows.Forms.MenuItem menuItem_maintenanceType;
		private System.Windows.Forms.MenuItem menuItem_Data;
		private System.Windows.Forms.MenuItem menuItem_BackupDB;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem_AddSchool_Type;
		private System.Windows.Forms.MenuItem menuItem_AddClass_Type;
		private System.Windows.Forms.MenuItem menuItem_AddQuXian;
		private System.Windows.Forms.MenuItem menuItem_Add_Office;
		private System.Windows.Forms.MenuItem menuItem_Add_Committee;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem_RestoreDB;
		private System.Windows.Forms.MenuItem menuItem_BrowseStudent;
		private System.Windows.Forms.MenuItem menuItem_AddSchool;
		private System.Windows.Forms.MenuItem menuItem6;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem menuItem_LocationDBBackup;
		private System.Windows.Forms.MenuItem menuItem_ModifyUser;
		private System.Windows.Forms.MenuItem menuItem_AddUser;
		private System.Windows.Forms.MenuItem menuItem_DeleteUser;
		private System.Windows.Forms.MenuItem menuItem_DataIn;
		private System.Windows.Forms.MenuItem menuItem_DeleteOld;
		private System.Windows.Forms.MenuItem menuItem_BrowseTeacher;
		private System.Windows.Forms.MenuItem menuItem_DataOut;
		private System.Windows.Forms.MenuItem menuItem_QuXianDataIn;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem_StatisticsStudent;
		private System.Windows.Forms.MenuItem menuItem_StatisticsTeacher;
		private System.Windows.Forms.MenuItem menuItem_StatisticsClass;
		private System.Windows.Forms.MenuItem menuItem_StatisticsSchool;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem_StatisticsClass_City;
		private System.Windows.Forms.MenuItem menuItem_StatisticsStudent_City;
		private System.Windows.Forms.MenuItem menuItem_StatisticsTeacher_City;
		private System.Windows.Forms.MenuItem menuItem_StatisticsSchool_QuXian;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem_StatisticsTeacher_QuXian;
		private System.Windows.Forms.MenuItem menuItem_StatisticsClass_QuXian;
		private System.Windows.Forms.MenuItem menuItem_StatisticsStudent_QuXian;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem_SchoolPassword;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem_StudentTeacherCount;
		private System.Windows.Forms.MenuItem menuItem_ModifySchool_ID;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem_QuXian_Office_Committee;
		private System.Windows.Forms.MenuItem menuItem_SearchSchool;
		private System.Windows.Forms.MenuItem menuItem_SearchTeacher;
		private System.Windows.Forms.MenuItem menuItem_NonlegalData;
		private System.Windows.Forms.MenuItem menuItem_DeleteManyOld;
		private System.Windows.Forms.MenuItem menuItem_QuXianDataOut;
		
		protected config conn=new config();

		public Form1(string str_User_login)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			/*�����û���������
			menuItem_StatisticsSchool_QuXian.Visible=false;
			menuItem_StatisticsTeacher_QuXian.Visible=false;
			menuItem_StatisticsClass_QuXian.Visible=false;
			menuItem_StatisticsStudent_QuXian.Visible=false;
			menuItem_maintenanceType.Visible=false;*/

			//ֻ���û���������
			if(conn.UserName_ToWhat(str_User_login,"ReadOnly")=="True")
			{			
				menuItem_System.Visible=false;
				menuItem_In.Visible=false;
				menuItem_Modify.Visible=false;
				menuItem_Data.Visible=false;
				menuItem_maintenanceType.Visible=false;
			}
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem_System = new System.Windows.Forms.MenuItem();
			this.menuItem_AddUser = new System.Windows.Forms.MenuItem();
			this.menuItem_ModifyUser = new System.Windows.Forms.MenuItem();
			this.menuItem_DeleteUser = new System.Windows.Forms.MenuItem();
			this.menuItem_In = new System.Windows.Forms.MenuItem();
			this.menuItem_AddSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_Browse = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseClass = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseStudent = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseTeacher = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem_SearchSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_SearchTeacher = new System.Windows.Forms.MenuItem();
			this.menuItem_SearchBrowseStudent = new System.Windows.Forms.MenuItem();
			this.menuItem_Modify = new System.Windows.Forms.MenuItem();
			this.menuItem_ModifySchool = new System.Windows.Forms.MenuItem();
			this.menuItem_ModifySchool_ID = new System.Windows.Forms.MenuItem();
			this.menuItem_Data = new System.Windows.Forms.MenuItem();
			this.menuItem_LocationDBBackup = new System.Windows.Forms.MenuItem();
			this.menuItem_BackupDB = new System.Windows.Forms.MenuItem();
			this.menuItem_RestoreDB = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem_DeleteOld = new System.Windows.Forms.MenuItem();
			this.menuItem_DeleteManyOld = new System.Windows.Forms.MenuItem();
			this.menuItem_DataIn = new System.Windows.Forms.MenuItem();
			this.menuItem_QuXianDataIn = new System.Windows.Forms.MenuItem();
			this.menuItem_DataOut = new System.Windows.Forms.MenuItem();
			this.menuItem_QuXianDataOut = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsClass = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsStudent = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsTeacher = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsClass_City = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsStudent_City = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsTeacher_City = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsSchool_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsTeacher_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsClass_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsStudent_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem_QuXian_Office_Committee = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem_NonlegalData = new System.Windows.Forms.MenuItem();
			this.menuItem_StudentTeacherCount = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceType = new System.Windows.Forms.MenuItem();
			this.menuItem_AddSchool_Type = new System.Windows.Forms.MenuItem();
			this.menuItem_AddClass_Type = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceSchoolType = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceClassType = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem_AddQuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_Add_Office = new System.Windows.Forms.MenuItem();
			this.menuItem_Add_Committee = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceXianqu = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceOffice = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceCommittee = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem_SchoolPassword = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem_System,
																					  this.menuItem_In,
																					  this.menuItem_Browse,
																					  this.menuItem_Modify,
																					  this.menuItem_Data,
																					  this.menuItem1,
																					  this.menuItem_maintenanceType});
			// 
			// menuItem_System
			// 
			this.menuItem_System.Index = 0;
			this.menuItem_System.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem_AddUser,
																							this.menuItem_ModifyUser,
																							this.menuItem_DeleteUser});
			this.menuItem_System.Text = "�û�����";
			// 
			// menuItem_AddUser
			// 
			this.menuItem_AddUser.Index = 0;
			this.menuItem_AddUser.Text = "����û�";
			this.menuItem_AddUser.Click += new System.EventHandler(this.menuItem_AddUser_Click);
			// 
			// menuItem_ModifyUser
			// 
			this.menuItem_ModifyUser.Index = 1;
			this.menuItem_ModifyUser.Text = "�޸��û�";
			this.menuItem_ModifyUser.Click += new System.EventHandler(this.menuItem_ModifyUser_Click);
			// 
			// menuItem_DeleteUser
			// 
			this.menuItem_DeleteUser.Index = 2;
			this.menuItem_DeleteUser.Text = "ɾ���û�";
			this.menuItem_DeleteUser.Click += new System.EventHandler(this.menuItem_DeleteUser_Click);
			// 
			// menuItem_In
			// 
			this.menuItem_In.Index = 1;
			this.menuItem_In.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuItem_AddSchool});
			this.menuItem_In.Text = "¼�����";
			// 
			// menuItem_AddSchool
			// 
			this.menuItem_AddSchool.Index = 0;
			this.menuItem_AddSchool.Text = "¼��ѧУ��Ϣ";
			this.menuItem_AddSchool.Click += new System.EventHandler(this.menuItem_AddSchool_Click);
			// 
			// menuItem_Browse
			// 
			this.menuItem_Browse.Index = 2;
			this.menuItem_Browse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem_BrowseSchool,
																							this.menuItem_BrowseClass,
																							this.menuItem_BrowseStudent,
																							this.menuItem_BrowseTeacher,
																							this.menuItem6,
																							this.menuItem_SearchSchool,
																							this.menuItem_SearchTeacher,
																							this.menuItem_SearchBrowseStudent});
			this.menuItem_Browse.Text = "��ѯ���";
			// 
			// menuItem_BrowseSchool
			// 
			this.menuItem_BrowseSchool.Index = 0;
			this.menuItem_BrowseSchool.Text = "���ѧУ��Ϣ";
			this.menuItem_BrowseSchool.Click += new System.EventHandler(this.menuItem_BrowseSchool_Click);
			// 
			// menuItem_BrowseClass
			// 
			this.menuItem_BrowseClass.Index = 1;
			this.menuItem_BrowseClass.Text = "����༶��Ϣ";
			this.menuItem_BrowseClass.Click += new System.EventHandler(this.menuItem_BrowseClass_Click);
			// 
			// menuItem_BrowseStudent
			// 
			this.menuItem_BrowseStudent.Index = 2;
			this.menuItem_BrowseStudent.Text = "���ѧ����Ϣ";
			this.menuItem_BrowseStudent.Click += new System.EventHandler(this.menuItem_BrowseStudent_Click);
			// 
			// menuItem_BrowseTeacher
			// 
			this.menuItem_BrowseTeacher.Index = 3;
			this.menuItem_BrowseTeacher.Text = "�����ʦ��Ϣ";
			this.menuItem_BrowseTeacher.Click += new System.EventHandler(this.menuItem_BrowseTeacher_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "-";
			// 
			// menuItem_SearchSchool
			// 
			this.menuItem_SearchSchool.Index = 5;
			this.menuItem_SearchSchool.Text = "��ѯѧУ��Ϣ";
			this.menuItem_SearchSchool.Click += new System.EventHandler(this.menuItem_SearchSchool_Click);
			// 
			// menuItem_SearchTeacher
			// 
			this.menuItem_SearchTeacher.Index = 6;
			this.menuItem_SearchTeacher.Text = "��ѯ��ʦ��Ϣ";
			this.menuItem_SearchTeacher.Click += new System.EventHandler(this.menuItem_SearchTeacher_Click);
			// 
			// menuItem_SearchBrowseStudent
			// 
			this.menuItem_SearchBrowseStudent.Index = 7;
			this.menuItem_SearchBrowseStudent.Text = "��ѯѧ����Ϣ";
			this.menuItem_SearchBrowseStudent.Click += new System.EventHandler(this.menuItem_SearchBrowseStudent_Click);
			// 
			// menuItem_Modify
			// 
			this.menuItem_Modify.Index = 3;
			this.menuItem_Modify.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem_ModifySchool,
																							this.menuItem_ModifySchool_ID});
			this.menuItem_Modify.Text = "�޸�";
			// 
			// menuItem_ModifySchool
			// 
			this.menuItem_ModifySchool.Index = 0;
			this.menuItem_ModifySchool.Text = "�޸�ѧУ��Ϣ";
			this.menuItem_ModifySchool.Click += new System.EventHandler(this.menuItem_ModifySchool_Click);
			// 
			// menuItem_ModifySchool_ID
			// 
			this.menuItem_ModifySchool_ID.Index = 1;
			this.menuItem_ModifySchool_ID.Text = "�޸�ѧУ����";
			this.menuItem_ModifySchool_ID.Click += new System.EventHandler(this.menuItem_ModifySchool_ID_Click);
			// 
			// menuItem_Data
			// 
			this.menuItem_Data.Index = 4;
			this.menuItem_Data.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItem_LocationDBBackup,
																						  this.menuItem_BackupDB,
																						  this.menuItem_RestoreDB,
																						  this.menuItem3,
																						  this.menuItem_DeleteOld,
																						  this.menuItem_DeleteManyOld,
																						  this.menuItem_DataIn,
																						  this.menuItem_QuXianDataIn,
																						  this.menuItem_DataOut,
																						  this.menuItem_QuXianDataOut});
			this.menuItem_Data.Text = "����ά��";
			// 
			// menuItem_LocationDBBackup
			// 
			this.menuItem_LocationDBBackup.Index = 0;
			this.menuItem_LocationDBBackup.Text = "���ݿⱸ��λ���趨";
			this.menuItem_LocationDBBackup.Click += new System.EventHandler(this.menuItem_LocationDBBackup_Click);
			// 
			// menuItem_BackupDB
			// 
			this.menuItem_BackupDB.Index = 1;
			this.menuItem_BackupDB.Text = "���ݱ�������";
			this.menuItem_BackupDB.Click += new System.EventHandler(this.menuItem_BackupDB_Click);
			// 
			// menuItem_RestoreDB
			// 
			this.menuItem_RestoreDB.Index = 2;
			this.menuItem_RestoreDB.Text = "�ָ���������";
			this.menuItem_RestoreDB.Click += new System.EventHandler(this.menuItem_RestoreDB_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// menuItem_DeleteOld
			// 
			this.menuItem_DeleteOld.Index = 4;
			this.menuItem_DeleteOld.Text = "ɾ������Ϣ";
			this.menuItem_DeleteOld.Click += new System.EventHandler(this.menuItem_DalataOld_Click);
			// 
			// menuItem_DeleteManyOld
			// 
			this.menuItem_DeleteManyOld.Index = 5;
			this.menuItem_DeleteManyOld.Text = "����ɾ������Ϣ";
			this.menuItem_DeleteManyOld.Click += new System.EventHandler(this.menuItem_DeleteManyOld_Click);
			// 
			// menuItem_DataIn
			// 
			this.menuItem_DataIn.Index = 6;
			this.menuItem_DataIn.Text = "�¼�ѧУ���ݵ���";
			this.menuItem_DataIn.Click += new System.EventHandler(this.menuItem_DataIn_Click);
			// 
			// menuItem_QuXianDataIn
			// 
			this.menuItem_QuXianDataIn.Index = 7;
			this.menuItem_QuXianDataIn.Text = "�¼�������������";
			this.menuItem_QuXianDataIn.Click += new System.EventHandler(this.menuItem_QuXianDataIn_Click);
			// 
			// menuItem_DataOut
			// 
			this.menuItem_DataOut.Index = 8;
			this.menuItem_DataOut.Text = "�¼�������������";
			this.menuItem_DataOut.Click += new System.EventHandler(this.menuItem_DataOut_Click);
			// 
			// menuItem_QuXianDataOut
			// 
			this.menuItem_QuXianDataOut.Index = 9;
			this.menuItem_QuXianDataOut.Text = "��������������";
			this.menuItem_QuXianDataOut.Click += new System.EventHandler(this.menuItem_QuXianDataOut_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 5;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem_StatisticsClass,
																					  this.menuItem_StatisticsStudent,
																					  this.menuItem_StatisticsTeacher,
																					  this.menuItem7,
																					  this.menuItem_StatisticsSchool,
																					  this.menuItem_StatisticsClass_City,
																					  this.menuItem_StatisticsStudent_City,
																					  this.menuItem_StatisticsTeacher_City,
																					  this.menuItem9,
																					  this.menuItem_StatisticsSchool_QuXian,
																					  this.menuItem_StatisticsClass_QuXian,
																					  this.menuItem_StatisticsStudent_QuXian,
																					  this.menuItem_StatisticsTeacher_QuXian,
																					  this.menuItem10,
																					  this.menuItem_QuXian_Office_Committee,
																					  this.menuItem8,
																					  this.menuItem_NonlegalData,
																					  this.menuItem_StudentTeacherCount});
			this.menuItem1.Text = "ͳ����Ϣ";
			// 
			// menuItem_StatisticsClass
			// 
			this.menuItem_StatisticsClass.Index = 0;
			this.menuItem_StatisticsClass.Text = "��ѧУ�༶��Ϣͳ��";
			this.menuItem_StatisticsClass.Click += new System.EventHandler(this.menuItem_StatisticsClass_Click);
			// 
			// menuItem_StatisticsStudent
			// 
			this.menuItem_StatisticsStudent.Index = 1;
			this.menuItem_StatisticsStudent.Text = "��ѧУѧ����Ϣͳ��";
			this.menuItem_StatisticsStudent.Click += new System.EventHandler(this.menuItem_StatisticsStudent_Click);
			// 
			// menuItem_StatisticsTeacher
			// 
			this.menuItem_StatisticsTeacher.Index = 2;
			this.menuItem_StatisticsTeacher.Text = "��ѧУ��ʦ��Ϣͳ��";
			this.menuItem_StatisticsTeacher.Click += new System.EventHandler(this.menuItem_StatisticsTeacher_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.Text = "-";
			// 
			// menuItem_StatisticsSchool
			// 
			this.menuItem_StatisticsSchool.Index = 4;
			this.menuItem_StatisticsSchool.Text = "��Ͻ��ѧУ��Ϣͳ��";
			this.menuItem_StatisticsSchool.Click += new System.EventHandler(this.menuItem_StatisticsSchool_Click);
			// 
			// menuItem_StatisticsClass_City
			// 
			this.menuItem_StatisticsClass_City.Index = 5;
			this.menuItem_StatisticsClass_City.Text = "��Ͻ���༶��Ϣͳ��";
			this.menuItem_StatisticsClass_City.Click += new System.EventHandler(this.menuItem_StatisticsClass_City_Click);
			// 
			// menuItem_StatisticsStudent_City
			// 
			this.menuItem_StatisticsStudent_City.Index = 6;
			this.menuItem_StatisticsStudent_City.Text = "��Ͻ��ѧ����Ϣͳ��";
			this.menuItem_StatisticsStudent_City.Click += new System.EventHandler(this.menuItem_StatisticsStudent_City_Click);
			// 
			// menuItem_StatisticsTeacher_City
			// 
			this.menuItem_StatisticsTeacher_City.Index = 7;
			this.menuItem_StatisticsTeacher_City.Text = "��Ͻ����ʦ��Ϣͳ��";
			this.menuItem_StatisticsTeacher_City.Click += new System.EventHandler(this.menuItem_StatisticsTeacher_City_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.Text = "-";
			// 
			// menuItem_StatisticsSchool_QuXian
			// 
			this.menuItem_StatisticsSchool_QuXian.Index = 9;
			this.menuItem_StatisticsSchool_QuXian.Text = "������ѧУ��Ϣͳ��";
			this.menuItem_StatisticsSchool_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsSchool_QuXian_Click);
			// 
			// menuItem_StatisticsTeacher_QuXian
			// 
			this.menuItem_StatisticsTeacher_QuXian.Index = 12;
			this.menuItem_StatisticsTeacher_QuXian.Text = "�����ؽ�ʦ��Ϣͳ��";
			this.menuItem_StatisticsTeacher_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsTeacher_QuXian_Click);
			// 
			// menuItem_StatisticsClass_QuXian
			// 
			this.menuItem_StatisticsClass_QuXian.Index = 10;
			this.menuItem_StatisticsClass_QuXian.Text = "�����ذ༶��Ϣͳ��";
			this.menuItem_StatisticsClass_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsClass_QuXian_Click);
			// 
			// menuItem_StatisticsStudent_QuXian
			// 
			this.menuItem_StatisticsStudent_QuXian.Index = 11;
			this.menuItem_StatisticsStudent_QuXian.Text = "������ѧ����Ϣͳ��";
			this.menuItem_StatisticsStudent_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsStudent_QuXian_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 13;
			this.menuItem10.Text = "-";
			// 
			// menuItem_QuXian_Office_Committee
			// 
			this.menuItem_QuXian_Office_Committee.Index = 14;
			this.menuItem_QuXian_Office_Committee.Text = " ������_���´�_����ͳ��";
			this.menuItem_QuXian_Office_Committee.Click += new System.EventHandler(this.menuItem_QuXian_Office_Committee_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 15;
			this.menuItem8.Text = "-";
			// 
			// menuItem_NonlegalData
			// 
			this.menuItem_NonlegalData.Index = 16;
			this.menuItem_NonlegalData.Text = "�Ƿ����ݲ�ѯ";
			this.menuItem_NonlegalData.Click += new System.EventHandler(this.menuItem_NonlegalData_Click);
			// 
			// menuItem_StudentTeacherCount
			// 
			this.menuItem_StudentTeacherCount.Index = 17;
			this.menuItem_StudentTeacherCount.Text = "Ԥͳ��";
			this.menuItem_StudentTeacherCount.Click += new System.EventHandler(this.menuItem_StudentTeacherCount_Click);
			// 
			// menuItem_maintenanceType
			// 
			this.menuItem_maintenanceType.Index = 6;
			this.menuItem_maintenanceType.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									 this.menuItem_AddSchool_Type,
																									 this.menuItem_AddClass_Type,
																									 this.menuItem4,
																									 this.menuItem_maintenanceSchoolType,
																									 this.menuItem_maintenanceClassType,
																									 this.menuItem2,
																									 this.menuItem_AddQuXian,
																									 this.menuItem_Add_Office,
																									 this.menuItem_Add_Committee,
																									 this.menuItem5,
																									 this.menuItem_maintenanceXianqu,
																									 this.menuItem_maintenanceOffice,
																									 this.menuItem_maintenanceCommittee,
																									 this.menuItem11,
																									 this.menuItem_SchoolPassword});
			this.menuItem_maintenanceType.Text = "����ά��";
			// 
			// menuItem_AddSchool_Type
			// 
			this.menuItem_AddSchool_Type.Index = 0;
			this.menuItem_AddSchool_Type.Text = "ѧУ������";
			this.menuItem_AddSchool_Type.Click += new System.EventHandler(this.menuItem_AddSchool_Type_Click);
			// 
			// menuItem_AddClass_Type
			// 
			this.menuItem_AddClass_Type.Index = 1;
			this.menuItem_AddClass_Type.Text = "�༶������";
			this.menuItem_AddClass_Type.Click += new System.EventHandler(this.menuItem_AddClass_Type_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuItem_maintenanceSchoolType
			// 
			this.menuItem_maintenanceSchoolType.Index = 3;
			this.menuItem_maintenanceSchoolType.Text = "ѧУ����޸�";
			this.menuItem_maintenanceSchoolType.Click += new System.EventHandler(this.menuItem_maintenanceSchoolType_Click);
			// 
			// menuItem_maintenanceClassType
			// 
			this.menuItem_maintenanceClassType.Index = 4;
			this.menuItem_maintenanceClassType.Text = "�༶����޸�";
			this.menuItem_maintenanceClassType.Click += new System.EventHandler(this.menuItem_maintenanceClassType_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// menuItem_AddQuXian
			// 
			this.menuItem_AddQuXian.Index = 6;
			this.menuItem_AddQuXian.Text = "�������";
			this.menuItem_AddQuXian.Click += new System.EventHandler(this.menuItem_AddQuXian_Click);
			// 
			// menuItem_Add_Office
			// 
			this.menuItem_Add_Office.Index = 7;
			this.menuItem_Add_Office.Text = "���´����";
			this.menuItem_Add_Office.Click += new System.EventHandler(this.menuItem_Add_Office_Click);
			// 
			// menuItem_Add_Committee
			// 
			this.menuItem_Add_Committee.Index = 8;
			this.menuItem_Add_Committee.Text = "��ί�����";
			this.menuItem_Add_Committee.Click += new System.EventHandler(this.menuItem_Add_Committee_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 9;
			this.menuItem5.Text = "-";
			// 
			// menuItem_maintenanceXianqu
			// 
			this.menuItem_maintenanceXianqu.Index = 10;
			this.menuItem_maintenanceXianqu.Text = "�����޸�";
			this.menuItem_maintenanceXianqu.Click += new System.EventHandler(this.menuItem_maintenanceXianqu_Click);
			// 
			// menuItem_maintenanceOffice
			// 
			this.menuItem_maintenanceOffice.Index = 11;
			this.menuItem_maintenanceOffice.Text = "���´��޸�";
			this.menuItem_maintenanceOffice.Click += new System.EventHandler(this.menuItem_maintenanceOffice_Click);
			// 
			// menuItem_maintenanceCommittee
			// 
			this.menuItem_maintenanceCommittee.Index = 12;
			this.menuItem_maintenanceCommittee.Text = "��ί���޸�";
			this.menuItem_maintenanceCommittee.Click += new System.EventHandler(this.menuItem_maintenanceCommittee_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 13;
			this.menuItem11.Text = "-";
			// 
			// menuItem_SchoolPassword
			// 
			this.menuItem_SchoolPassword.Index = 14;
			this.menuItem_SchoolPassword.Text = "����������";
			this.menuItem_SchoolPassword.Click += new System.EventHandler(this.menuItem_SchoolPassword_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 545);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "����ͳ���������ϵͳ����ί��";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		private void menuItem_InSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			InSchool child_InSchool=new InSchool();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_maintenanceSchoolType_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			maintenanceSchoolType child_InSchool=new maintenanceSchoolType();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_maintenanceClassType_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			maintenanceClassType child_InSchool=new maintenanceClassType();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_AddSchool_Type_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				 this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			 }

			AddSchool_Type child_InSchool=new AddSchool_Type();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_AddClass_Type_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				 this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			 }

			AddClass_Type child_InSchool=new AddClass_Type();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_AddQuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
			 this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			 }

			AddQuXian child_InSchool=new AddQuXian();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_maintenanceXianqu_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			maintenanceXianqu child_InSchool=new maintenanceXianqu();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_maintenanceOffice_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			maintenanceOffice child_InSchool=new maintenanceOffice();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_AddSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			InSchool child_InSchool=new InSchool();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_Add_Office_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			Add_Office child_InSchool=new Add_Office();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_BrowseSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			BrowseSchool child_InSchool=new BrowseSchool();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_BrowseClass_Click(object sender, System.EventArgs e)
		{
			string str_Sql="Select * from School"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("��������ѧУ��Ϣ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			BrowseClass child_InSchool=new BrowseClass();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_BrowseStudent_Click(object sender, System.EventArgs e)
		{
			string str_Sql="Select * from Class"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("��������༶��Ϣ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			BrowseStudent child_InSchool=new BrowseStudent();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();		
		}

		private void menuItem_SearchBrowseStudent_Click(object sender, System.EventArgs e)
		{
			string str_Sql="Select * from Class"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("��������༶��Ϣ��", "���棡", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			SearchBrowseStudent child_InSchool=new SearchBrowseStudent();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();		
		}

		private void menuItem_ModifySchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			ModifySchool child_InSchool=new ModifySchool();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_DBSet_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			DBSet child_InSchool=new DBSet();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		//���ݿⱸ��
		private void menuItem_BackupDB_Click(object sender, System.EventArgs e)
		{
			string str_LocationDBBackup="";
			string str_Sql,errorstring;

			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="DatabaseBackup")
					{
						str_LocationDBBackup=xn1.Attributes["value"].Value;
						break;
					}
				}
			}
			catch
			{
				//return false;
				throw new Exception("Config�����ļ���ȡʧ�ܣ�");
			}
			//�����ļ�����ԭ��:����ʱ��yyyy-mm-dd hh-mm-ss-�Խ���ͳ���������ϵͳ�����ݱ���.bak
			//str_Sql="Select * FROM School";
			//conn.GetRowRecord(str_Sql);
			//string str_School_ID=conn.dr["School_ID"].ToString();
			//string str_School_Name=conn.School_IDtoWhat(str_School_ID,"School_Name");
			str_Sql="backup database "+ConfigurationSettings.AppSettings["Database"]
				+" TO disk='"+str_LocationDBBackup+"\\��"+System.DateTime.Now.ToString().Replace(":","-")+"�Խ���ͳ���������ϵͳ�����ݱ���.bak'";
			
			try
			{
				//errorstring=conn.ExeSql(str_Sql);
				errorstring=conn.DBRestore(str_Sql);
			}
			catch
			{				
				MessageBox.Show("����ʧ�ܣ�", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				conn.Close();
			}
			
			MessageBox.Show("�ɹ�������  "+str_LocationDBBackup+" ��", "���ѣ�",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void menuItem_LocationDBBackup_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			LocationDBBackup child_InSchool=new LocationDBBackup();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();			
		}

		private void menuItem_RestoreDB_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			RestoreDB child_InSchool=new RestoreDB();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();		
		}

		private void menuItem_ModifyUser_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			ModifyUser child_InSchool=new ModifyUser();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_AddUser_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			AddUser child_InSchool=new AddUser();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_DeleteUser_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			DeleteUser child_InSchool=new DeleteUser();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_DataIn_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			DataIn child_InSchool=new DataIn();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_SchoolPassword_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			SchoolPassword child_InSchool=new SchoolPassword();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_Add_Committee_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			Add_Committee child_InSchool=new Add_Committee();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_maintenanceCommittee_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			maintenanceCommittee child_InSchool=new maintenanceCommittee();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_DalataOld_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			DeleteOld child_InSchool=new DeleteOld();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_BrowseTeacher_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			BrowseTeacher child_InSchool=new BrowseTeacher();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_DataOut_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			DataOut child_InSchool=new DataOut();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_QuXianDataIn_Click(object sender, System.EventArgs e)
		{		
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			QuXianDataIn child_InSchool=new QuXianDataIn();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsStudent_Click(object sender, System.EventArgs e)
		{			
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsStudent child_InSchool=new StatisticsStudent();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsTeacher_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsTeacher child_InSchool=new StatisticsTeacher();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClass_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsClass child_InSchool=new StatisticsClass();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsSchool child_InSchool=new StatisticsSchool();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClassInCity_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			//StatisticsClassInCity child_InSchool=new StatisticsClassInCity();
			//child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			//child_InSchool.Show();
		}

		private void menuItem_StatisticsTeacher_City_Click(object sender, System.EventArgs e)
		{		
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsTeacher_City child_InSchool=new StatisticsTeacher_City();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsStudent_City_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsStudent_City child_InSchool=new StatisticsStudent_City();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClass_City_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsClass_City child_InSchool=new StatisticsClass_City();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsSchool_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsSchool_QuXian child_InSchool=new StatisticsSchool_QuXian();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_StatisticsTeacher_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsTeacher_QuXian child_InSchool=new StatisticsTeacher_QuXian();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClass_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsClass_QuXian child_InSchool=new StatisticsClass_QuXian();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_StatisticsStudent_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			StatisticsStudent_QuXian child_InSchool=new StatisticsStudent_QuXian();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();		
		}

		private void menuItem_SchoolPassword_Click_1(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			SchoolPassword child_InSchool=new SchoolPassword();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();		
		}

		private void menuItem_StudentTeacherCount_Click(object sender, System.EventArgs e)
		{
			//ѧ������ͳ��
			string str_Sql="select School_ID,Count(Student_ID) AS Student_Count FROM Student Group By School_ID";
			string errorstring=conn.Fill(str_Sql);

			int SchoolCount=conn.ds.Tables[0].Rows.Count;
			for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				conn.dr=conn.ds.Tables[0].Rows[indexSchool];
				
				str_Sql="Update School Set Student_Count="+conn.dr["Student_Count"].ToString()
					+" Where School_ID='"+conn.dr["School_ID"].ToString()+"'";
				errorstring=conn.ExeSql(str_Sql);
			}

			//��ʦ����ͳ��
			str_Sql="select School_ID,Count(Teacher_ID) AS Teacher_Count FROM Teacher Group By School_ID";
			errorstring=conn.Fill(str_Sql);
			
			SchoolCount=conn.ds.Tables[0].Rows.Count;
			for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				conn.dr=conn.ds.Tables[0].Rows[indexSchool];
			
				str_Sql="Update School Set Teacher_Count="+conn.dr["Teacher_Count"].ToString()
					+" Where School_ID='"+conn.dr["School_ID"].ToString()+"'";
				errorstring=conn.ExeSql(str_Sql);

				//ѧУ���������
				str_Sql="Update School Set QuXian_Code='"+conn.dr["School_ID"].ToString().Substring(4,2)
					+"' Where School_ID='"+conn.dr["School_ID"].ToString()+"'";
				errorstring=conn.ExeSql(str_Sql);
			}

			//�༶ѧ������ͳ��
			str_Sql="select School_ID,Class_ID,Count(Student_ID) AS Student_Count FROM Student Group By School_ID,Class_ID";
			errorstring=conn.Fill(str_Sql);

			SchoolCount=conn.ds.Tables[0].Rows.Count;
			for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				conn.dr=conn.ds.Tables[0].Rows[indexSchool];
				
				str_Sql="Update Class Set Student_Count="+conn.dr["Student_Count"].ToString()
					+" Where School_ID='"+conn.dr["School_ID"].ToString()+"' AND Class_ID="+conn.dr["Class_ID"].ToString();
				errorstring=conn.ExeSql(str_Sql);
			}

			MessageBox.Show("�ɹ����հ༶��ѧУͳ��ѧ��������\n�ɹ�����ѧУͳ�ƽ�ʦ������"+errorstring, "���ѣ�", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			
		}

		private void menuItem_ModifySchool_ID_Click(object sender, System.EventArgs e)
        {
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			ModifySchool_ID child_InSchool=new ModifySchool_ID();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_QuXian_Office_Committee_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			QuXian_Office_Committee child_InSchool=new QuXian_Office_Committee();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_SearchSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			SearchSchool child_InSchool=new SearchSchool();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		
		}

		private void menuItem_SearchTeacher_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			SearchTeacher child_InSchool=new SearchTeacher();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_NonlegalData_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			NonlegalData child_InSchool=new NonlegalData();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_DeleteManyOld_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			DeleteManyOld child_InSchool=new DeleteManyOld();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();
		}

		private void menuItem_QuXianDataOut_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //�ر��Ѿ��򿪵��Ӵ���
			}

			QuXianDataOut child_InSchool=new QuXianDataOut();
			child_InSchool.MdiParent=this;//this��ʾ������Ϊ�丸����
			child_InSchool.Show();		
		
		}		
	}
}
