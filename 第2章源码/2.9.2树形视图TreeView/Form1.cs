using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ������ͼTreeView
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textBoxChild;
		private System.Windows.Forms.Button buttonAddRoot;
		private System.Windows.Forms.Button buttonAddChild;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.TextBox textBoxRoot;
		private System.Windows.Forms.Button buttonClear;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.textBoxRoot = new System.Windows.Forms.TextBox();
			this.textBoxChild = new System.Windows.Forms.TextBox();
			this.buttonAddRoot = new System.Windows.Forms.Button();
			this.buttonAddChild = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(8, 16);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(208, 216);
			this.treeView1.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// textBoxRoot
			// 
			this.textBoxRoot.Location = new System.Drawing.Point(232, 48);
			this.textBoxRoot.Name = "textBoxRoot";
			this.textBoxRoot.Size = new System.Drawing.Size(96, 21);
			this.textBoxRoot.TabIndex = 1;
			this.textBoxRoot.Text = "�ƿ�ϵ";
			// 
			// textBoxChild
			// 
			this.textBoxChild.Location = new System.Drawing.Point(232, 104);
			this.textBoxChild.Name = "textBoxChild";
			this.textBoxChild.Size = new System.Drawing.Size(96, 21);
			this.textBoxChild.TabIndex = 2;
			this.textBoxChild.Text = "����051";
			// 
			// buttonAddRoot
			// 
			this.buttonAddRoot.Location = new System.Drawing.Point(344, 40);
			this.buttonAddRoot.Name = "buttonAddRoot";
			this.buttonAddRoot.Size = new System.Drawing.Size(88, 32);
			this.buttonAddRoot.TabIndex = 3;
			this.buttonAddRoot.Text = "���ϵ��";
			this.buttonAddRoot.Click += new System.EventHandler(this.buttonAddRoot_Click);
			// 
			// buttonAddChild
			// 
			this.buttonAddChild.Location = new System.Drawing.Point(344, 104);
			this.buttonAddChild.Name = "buttonAddChild";
			this.buttonAddChild.Size = new System.Drawing.Size(88, 32);
			this.buttonAddChild.TabIndex = 4;
			this.buttonAddChild.Text = "��Ӱ༶";
			this.buttonAddChild.Click += new System.EventHandler(this.buttonAddChild_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(232, 160);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(96, 32);
			this.buttonDelete.TabIndex = 5;
			this.buttonDelete.Text = "ɾ���ڵ�";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(344, 160);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(88, 32);
			this.buttonClear.TabIndex = 6;
			this.buttonClear.Text = "���";
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(456, 238);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonAddChild);
			this.Controls.Add(this.buttonAddRoot);
			this.Controls.Add(this.textBoxChild);
			this.Controls.Add(this.textBoxRoot);
			this.Controls.Add(this.treeView1);
			this.Name = "Form1";
			this.Text = "ѧУ�ķֲ��б�";
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

		//���չ��ĳ���ڵ�󷢳���AfterExpand�¼���
		private void treeView1_AfterExpand(object sender,TreeViewEventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
			//selectedNode.SelectedImageIndex=1;
			selectedNode.ImageIndex=1;

			e.Node.ImageIndex=3;
			e.Node.SelectedImageIndex=3;			
		}
		//����۵�ĳ���ڵ�󷢳���AfterCollapse�¼���
		private void treeView1_AfterCollapse(object sender,TreeViewEventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
			//selectedNode.SelectedImageIndex=1;
			selectedNode.ImageIndex=0;
		}
		//��Ӱ�ť���¼���
		private void buttonAddRoot_Click(object sender, System.EventArgs e)
		{
			//����ڵ���ʾ���ݡ�ȡ��ѡ��ʱ��ʾͼ�������š�ѡ��ʱ��ʾͼ��������
			TreeNode newNode=new  TreeNode(this.textBoxRoot.Text,0,1);
			this.treeView1.Nodes.Add(newNode);
            this.treeView1.Select();//Select()����ؼ������̳��� Control����
            //Select(Boolean, Boolean)�����ӿؼ���������ָ������ѡ��ؼ��� Tab ��˳��ķ��򡣣��̳��� Control����
		}
		private void buttonAddChild_Click(object sender, System.EventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
			if(selectedNode==null)
			{
				MessageBox.Show("����ӽڵ�֮ǰ������ѡ��һ���ڵ㡣","��ʾ��Ϣ");
				return;
			}
			TreeNode newNode=new TreeNode(this.textBoxChild.Text,2,3);
			selectedNode.Nodes.Add(newNode);
			//selectedNode.SelectedImageIndex=1;
			selectedNode.Expand();
			this.treeView1.Select();
		}
		private void buttonDelete_Click(object sender,System.EventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("ɾ���ڵ�֮ǰ��ѡ��һ���ڵ㡣", "��ʾ��Ϣ");
                return;
            }
            TreeNode parentNode = selectedNode.Parent;
            if (parentNode == null)
                this.treeView1.Nodes.Remove(selectedNode);
            else
                parentNode.Nodes.Remove(selectedNode);
//else
//treeView1.Nodes.Remove(selectedNode);
			this.treeView1.Select();
		}
		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			treeView1.Nodes.Clear(); 		
		}

	}
}
