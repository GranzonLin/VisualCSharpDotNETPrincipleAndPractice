using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;

namespace CityEduWebService
{
	/// <summary>
	/// MassgageService ��ժҪ˵����
	/// </summary>
	public class MassgageService : System.Web.Services.WebService
	{
		
		protected config conn=new config();
		private string[] ArraytSql=new String[1111];

		public MassgageService()
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
		public string DataBaseModifyToSchool()//�����޸����ݿ��Sql���
		{
			string str_Sql="";
			StreamReader sr = new StreamReader(Server.MapPath(".")+"\\�޸����ݿ�.sql",Encoding.GetEncoding("gb2312"));
			
			try	{str_Sql="\r\n"+sr.ReadToEnd()+"\r\n";}
			catch{//�Ի���
			}
			try{sr.Close();}
			catch{//�Ի���
			}
			
			return  str_Sql;
		}
	}
}
