using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace Test
{
	/// <summary>
	/// MyMethods ��ժҪ˵����
	/// </summary>
	public class MyMethods
	{
		public MyMethods()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public void AlertAndRedirect(string msg ,string tourl)//��������Ի��򣬾�����ϢΪ����msg������,�����ز���tourl����ָ��URL������֤�û���½ʱ����û��½����ô˷����������û�������Login.aspxҳ��
		{
			string js = "<script language=javascript>alert('{0}');window.location.replace('{1}');</script>";
			HttpContext.Current.Response.Write(String.Format(js, msg, tourl));
		}
		public string DateId()//���ص�ǰ������ʱ���������ɵ��ַ�������Ϊ�����ݿ��������ʱ����¼�Ĺؼ���
		{
			DateTime now=DateTime.Now;
			return now.Year.ToString()+now.Month.ToString()+now.Day.ToString()+now.Hour.ToString()+now.Minute.ToString()+now.Second.ToString()+now.Millisecond.ToString();
		}
		public void DG_bind(DataGrid dg,string sqlstr,string SearchCondition,string SortExpression,string connstr)
		{// �������ַ���connstr��ָ�����ݿ⣬ִ�в�ѯ���sqlstr�������䷵�صĹ�ϵ����DataGrid�ؼ�dg��SearchConditionΪ����ʱ�ļ���������SortExpressionΪ��ǰ���ݱ�������ģʽ
		    MyData md=new MyData(connstr);
		    DataSet ds1=md.FillDataset(sqlstr);
			if (SearchCondition != "")
				ds1.Tables[0].DefaultView.RowFilter = SearchCondition;

			ds1.Tables[0].DefaultView.Sort = SortExpression;
			dg.DataSource = ds1.Tables[0].DefaultView;
			try
			{
				dg.DataBind();
			}
			catch
			{
				dg.CurrentPageIndex-=1;
				dg.DataBind();

			}
		}
		public void Repeater_bind(Repeater rp,ref DataSet ds,string sqlstr,string connstr)
		{   //�������ַ���connstr��ָ�����ݿ⣬ִ�в�ѯ���sqlstr�������䷵�صĹ�ϵ����Repeater�ؼ�rp.�����������ݼ�,����һ������
			MyData md=new MyData(connstr);
			ds=md.FillDataset(sqlstr);
			
			rp.DataSource=ds.Tables[0].DefaultView;
			rp.DataBind();
			
		}
		public void fill_dropdownlist(DropDownList[] ddl,string connstr,string sql,string textfield,string valuefield)
		{   //�������ַ���connstr��ָ�����ݿ⣬ִ�в�ѯ���sql�������䷵�صĹ�ϵ��textfield�ֶκ�valuefield�ֶηֱ�󶨸�ddl�����и��ؼ���DataTextField���Ժ�DataValueField����
			MyData md=new MyData(connstr);
			DataSet ds1 = md.FillDataset(sql); 
			for(int i=0;i<ddl.Length;i++)
			{
				ddl[i].DataSource=ds1.Tables[0].DefaultView;
				ddl[i].DataTextField=textfield;
				ddl[i].DataValueField=valuefield;
				ddl[i].DataBind();
			}
		
		}
	}
}
