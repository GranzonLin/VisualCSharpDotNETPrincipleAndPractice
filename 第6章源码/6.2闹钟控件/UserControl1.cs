using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
//�Ҽ������������ӿؼ�������Ŀ���Ҽ��ؼ����ԣ�������Ŀ��������ÿؼ�����Ϊ������Ŀ
namespace clock
{
	/// <summary>
	/// UserControl1 ��ժҪ˵����
	/// </summary>
public delegate void My_EventHandler(DateTime pdteTime,string pstrMessage); //����ӵ�ί��
    public class myclock : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lbTime;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		//��ͨ����������
		private Font myFont=new Font("����", 21.75F);
		private bool TimerEnable=false;
		private string ShowCont;
		private bool _visible=true;
		private string message_context="ʱ�䵽��";
		//����һ���¼�
	    public event My_EventHandler OnTime;            //**********************�½��¼�
        int alreadyrun = 0;
public myclock()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();
			//���¼���ί�й�������,ͨ��ί�е���my_method2
            this.OnTime += new My_EventHandler(my_method2); //*************************��;	
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("����", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.Coral;
            this.lbTime.Location = new System.Drawing.Point(-2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(151, 33);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "dd:dd:dd";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myclock
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.Controls.Add(this.lbTime);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Name = "myclock";
            this.Size = new System.Drawing.Size(146, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

public string GetTime()
		{
			string TimeInString="";
			int hour=DateTime.Now.Hour;
			int min=DateTime.Now.Minute;
			int sec=DateTime.Now.Second;

			TimeInString=(hour < 10)?"0" + hour.ToString() :hour.ToString();
			TimeInString+=":" + ((min<10)?"0" + min.ToString() :min.ToString());
			TimeInString+=":" + ((sec<10)?"0" + sec.ToString() :sec.ToString());
			return TimeInString;
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.lbTime.Text=GetTime(); 
			if (ShowCont!=""&& this.lbTime.Text==ShowCont)
				OnTime(DateTime.Now, message_context);
		}
		//����е�Visible���ԣ��ؼ��������Ƿ�ɼ�
[DefaultValue(true),Description("�ؼ��������Ƿ�ɼ�"),Category("Appearance")] 
public  bool FontVisible
		{
			get{  return _visible ;}
			set
			{
				_visible = value;
				this.lbTime.Visible=value;//��ǩVisible����			    
			}
		}
		//��ʱ�Ƿ�����
public bool Timer_Enable
		{
			get{  return TimerEnable ;}
			set
			{
				TimerEnable = value;
				this.timer1.Enabled=TimerEnable;	
			}
		}
		//Show_IntervalInterval���Ե�ѭ���ӳ٣���λ�����룩��Ĭ��Ϊ1000��
[DefaultValue(100),Description("ѭ���ӳ� ��λ������"),Category("Appearance")] 
public  int Show_Interval  //ֻ��
		{
			get{  return timer1.Interval ;}
		}
//SetCall����������ʱ�䡣��ʽΪ�� ʱ���֣��롱��
		[Description("����ʱ��,��ʽΪ ʱ���֣���")] 
public string SetCall
		{
			get{  return ShowCont ;}
			set
			{
				ShowCont= value;
			}
		}
		private void  my_method2(DateTime pdteTime,string pstrMessage)//*************************�½���Ϣ
		{
            //alreadyrun++;
            //if (alreadyrun == 1)
            //{
                DialogResult s = MessageBox.Show(pstrMessage);
                if (s == DialogResult.OK)
                    alreadyrun = 0;
            //}
            
		}
public Font set_myFont
		{   
			get{  return myFont ;}
			set
			{
				myFont=value;
				this.lbTime.Font=myFont; 
				this.lbTime.Invalidate();
			}
		}
[DefaultValue("HotTrack"),Description("������ɫ"),Category("Appearance")] 
		public override Color ForeColor
		{
			get 
			{
				return this.lbTime.ForeColor;
			}
			set 
			{
				this.lbTime.ForeColor=value;
				this.Invalidate();
			}
		}
public void AddTime(string pdteTime,string pstrMessage)
		{
            ShowCont=pdteTime;
			message_context=pstrMessage;
		}
	}
}
