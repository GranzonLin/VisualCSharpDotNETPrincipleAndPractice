using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text;
using System.Data.OleDb;
using System.Configuration;

namespace CityEduWebService
{
	/// <summary>
	/// TransInfoService ��ժҪ˵����
	/// </summary>
	public class TransInfoService : System.Web.Services.WebService
	{		
		protected config conn=new config();

		public TransInfoService()
		{
			//CODEGEN: �õ����� ASP.NET Web ����������������
			InitializeComponent();
		}

		#region �����������ɵĴ���
		
		//Web ����������������
		private IContainer components = null;
				
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB ����ʾ��
		// HelloWorld() ʾ�����񷵻��ַ��� Hello World
		// ��Ҫ���ɣ���ȡ��ע�������У�Ȼ�󱣴沢������Ŀ
		// ��Ҫ���Դ� Web �����밴 F5 ��
		[WebMethod]
		public int School_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //������DataSet�еļ�¼����
			int iSuccessCount = 0; //���سɹ�����ļ�¼��
			string errorstring,str_Sql="";
			
			try
			{				
				//һ��һ�������������ݿ�
				for(int i=0;i<iCount;i++)
				{
					//�û�Ӧ���ȵ���School_Receive,���ϴ�ѧУ��Ϣ,�ϴ�ǰɾ������School_ID�����Ϣ:ѧУ,�༶,ѧ��
					str_Sql="Delete From Student WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);

					str_Sql="Delete From Class WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);
	
					str_Sql="Delete From Teacher WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);

					str_Sql="Delete From School WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);

					str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address,QuXian_Code) VALUES (";

					//�������
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Name"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Type_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Schoolmaster"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Tel"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Zip"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Address"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["QuXian_Code"])+"')";

					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				
				//�����ִ���ֱ�ӷ����Ѿ��ɹ��ϴ��ļ�¼��
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//���سɹ��ϴ��ļ�¼��
			return iSuccessCount;
		}

		[WebMethod]
		public int Class_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //������DataSet�еļ�¼����
			int iSuccessCount = 0; //���سɹ�����ļ�¼��
			
			string errorstring,str_Sql="";
			
			try
			{				
				//һ��һ�������������ݿ�
				for(int i=0;i<iCount;i++)
				{					
					str_Sql="INSERT INTO Class (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values(";

					//�������
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_Type_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_Name"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["TeacherInCharge"])+"')";
                    
					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				//�����ִ���ֱ�ӷ����Ѿ��ɹ��ϴ��ļ�¼��
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//���سɹ��ϴ��ļ�¼��
			return iSuccessCount;
		}

		[WebMethod]
		public int Student_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //������DataSet�еļ�¼����
			int iSuccessCount = 0; //���سɹ�����ļ�¼��
			
			string errorstring,str_Sql="";
			
			try
			{				
				//һ��һ�������������ݿ�
				for(int i=0;i<iCount;i++)
				{
					str_Sql="insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) VALUES (";
			
					//�������
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Student_ID"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Name"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Birthday"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Sex"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Father"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Mother"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Keeper"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["StudentTel"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["QuXian_ID"])+",";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Office_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Committee_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Student_Address"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Father_Job"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Father_XueLi"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Mother_Job"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Mother_XueLi"])+"')";
			
					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				
				//�����ִ���ֱ�ӷ����Ѿ��ɹ��ϴ��ļ�¼��
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//���سɹ��ϴ��ļ�¼��
			return iSuccessCount;
		}

		[WebMethod]
		public int Teacher_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //������DataSet�еļ�¼����
			int iSuccessCount = 0; //���سɹ�����ļ�¼��
			
			string errorstring,str_Sql="";
			
			try
			{				
				//һ��һ�������������ݿ�
				for(int i=0;i<iCount;i++)
				{
					str_Sql="insert into Teacher (School_ID,Teacher_ID,Name,Birthday,WorkTime,Sex,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,InWorkSheet,IsFullTime,LessonTeach) values (";
			
					//�������
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Teacher_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Name"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Birthday"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["WorkTime"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Sex"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["SchoolType"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["PostCan"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["PostIn"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["SchoolGrad"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["GradTime"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["SpecialIn"])+"',";
					if(Convert.ToString(dsReceived.Tables[0].Rows[i]["InWorkSheet"])=="True")
						str_Sql=str_Sql+"1,";
					else
						str_Sql=str_Sql+"0,";
					if(Convert.ToString(dsReceived.Tables[0].Rows[i]["IsFullTime"])=="True")
						str_Sql=str_Sql+"1,";
					else
						str_Sql=str_Sql+"0,";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["LessonTeach"])+"')";
				
					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				
				//�����ִ���ֱ�ӷ����Ѿ��ɹ��ϴ��ļ�¼��
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//���سɹ��ϴ��ļ�¼��
			return iSuccessCount;
		}
	}
}
