using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace CityEduWebService
{
	/// <summary>
	/// StringReverse ��ժҪ˵����
	/// </summary>
	public class StringReverse : System.Web.Services.WebService
	{
		public StringReverse()
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
		[WebMethod(Description="��ת�ַ���")]
		public string WebMethod_StringReverse(string OriginString)
		{
			int i,j;
			string  newString="";
			for(i=OriginString.Length-1;i>=0;i--)
			{
				newString=newString+OriginString[i];
			}
			return newString;
		}
	}
}
