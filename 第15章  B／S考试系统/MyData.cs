using System;
using System.Data;
using System.Data.OleDb;
namespace Test
{
	/// <summary>
	/// MyData ��ժҪ˵����
	/// </summary>
	public class MyData
	{
		protected string strconn;
		protected OleDbConnection objconn;
		protected OleDbCommand objcomm;
	    //��ȡ�����ַ�����������Connection����
		public MyData(string connectionString)
		{
			strconn = connectionString;
			objconn = new OleDbConnection(strconn);
		}
		
		public int eInsertUpdateDelete(string sqlstr)
		{//ִ��Insert��Update��Delete��䣬������Ӱ�������
			int i=0;
			objconn.Open();
			objcomm=new OleDbCommand(sqlstr,objconn);
		    try
			{
				 i = (int)objcomm.ExecuteNonQuery();
			} 
			catch
			{
				//objcomm.Transaction.Rollback();					
			}
			objconn.Close();
			objconn.Dispose();
			return i;
		}
		public OleDbDataReader eSelect(string sqlstr)
		{
			//ִ��Select��䣬������DataReader����
			OleDbDataReader dr=null;
			objconn.Open();
			objcomm=new OleDbCommand(sqlstr,objconn);
			try
			{
				dr= objcomm.ExecuteReader();
			} 
			catch
			{			
			}
			return dr;

		}
		public DataSet FillDataset(string sqlstr)
		{
			//ִ��Select��䣬��������DataSet����
			OleDbDataAdapter da=new OleDbDataAdapter(sqlstr,objconn);
			DataSet ds=new DataSet();
			try
			{
				da.Fill(ds);
			}
			catch
			{}
			return ds;
			
		}
		public void CloseConn()
		{
			//�رղ�����Connection����
			objconn.Close();
			objconn.Dispose();
		}
	}
}
