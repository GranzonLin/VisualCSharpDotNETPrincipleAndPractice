<%@ Page language="c#" Codebehind="adminQuestionslist.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminquestionslist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminquestionslist</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">BODY TD {
	FONT-SIZE: 12px
}
.zz {
	FILTER: glow(color=#213a5a,Strength=1); COLOR: #ffffff
}
.front {
	FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #00258f; FONT-FAMILY: "����"; TEXT-DECORATION: none
}
.bfront {
	FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #ffffff; FONT-FAMILY: "����"; TEXT-DECORATION: none
}
.bxfront {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: "����"; TEXT-DECORATION: none
}
.frontx {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #00258f; FONT-FAMILY: "����"; TEXT-DECORATION: none
}
.STYLE9 {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #133694
}
.bk2 {
	BORDER-RIGHT: #8ebeea 1px solid; BORDER-TOP: #8ebeea 1px solid; BORDER-LEFT: #8ebeea 1px solid; BORDER-BOTTOM: #8ebeea 1px solid
}
		</style>
	</HEAD>
	<body bgColor="#ecf6f8" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td style="BORDER-RIGHT: #7dafd4 1px solid; BORDER-TOP: #153693 0px solid; BORDER-LEFT: #153693 0px solid; BORDER-BOTTOM: #153693 0px solid"
						width="11" bgColor="#ecf6f8"><br>
					</td>
					<td style="BORDER-RIGHT: #7dafd4 0px solid; BORDER-TOP: #153693 0px solid; BORDER-LEFT: #e3f1fa 1px solid; BORDER-BOTTOM: #153693 0px solid"
						vAlign="top" bgColor="#cde8fb">
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td height="8"></td>
							</tr>
						</table>
						<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="98%" border="2">
							<tr>
								<td style="BORDER-RIGHT: #00258f 1px solid; BORDER-TOP: #00258f 1px solid; BORDER-LEFT: #00258f 1px solid; BORDER-BOTTOM: #00258f 1px solid"
									vAlign="top" align="center" bgColor="#ffffff" height="440">
									<div align="center">
										<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a02.jpg"
											border="0">
											<tr>
												<td align="left" width="14"><IMG height="26" src="../images/a01.jpg" width="13"></td>
												<td width="317">
													<table cellSpacing="0" cellPadding="0" width="100%" border="0">
														<tr>
															<td style="WIDTH: 21px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
															<td><span class="bxfront"><asp:label id="lbl_Title" runat="server"></asp:label></span></td>
														</tr>
													</table>
												</td>
												<td align="right"><IMG height="26" src="../images/a03.jpg" width="12"></td>
											</tr>
										</table>
										<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
											<TBODY>
												<tr>
													<td style="BORDER-RIGHT: #c2c2c2 1px solid; BORDER-TOP: #00258f 0px solid; BORDER-LEFT: #c2c2c2 1px solid; BORDER-BOTTOM: #00258f 0px solid"
														height="197">
														<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
															<TBODY>
																<tr>
																	<td height="4"><FONT face="����"></FONT></td>
																</tr>
																<TR>
																	<TD height="8"><FONT face="����"></FONT></TD>
																</TR>
																<tr>
																	<td style="HEIGHT: 24px" height="24">&nbsp;
																		<asp:dropdownlist id="DDLtixing" runat="server" Width="66px" AutoPostBack="True">
																			<asp:ListItem Value="��ѡ��" Selected="True">��ѡ��</asp:ListItem>
																			<asp:ListItem Value="��ѡ��">��ѡ��</asp:ListItem>
																			<asp:ListItem Value="�ж���">�ж���</asp:ListItem>
																			<asp:ListItem Value="�����">�����</asp:ListItem>
																			<asp:ListItem Value="�����">�����</asp:ListItem>
																			<asp:ListItem Value="�����">�����</asp:ListItem>
																		</asp:dropdownlist><FONT face="����"></FONT><asp:dropdownlist id="DdlSearchKind" runat="server" Width="72px" Height="24px"></asp:dropdownlist><asp:dropdownlist id="DdlSelectcondition" runat="server" Width="64px">
																			<asp:ListItem Value="like">������</asp:ListItem>
																			<asp:ListItem Value="&gt;">����</asp:ListItem>
																			<asp:ListItem Value="&gt;=">���ڵ���</asp:ListItem>
																			<asp:ListItem Value="&lt;">С��</asp:ListItem>
																			<asp:ListItem Value="&lt;=">С�ڵ���</asp:ListItem>
																			<asp:ListItem Value="=">����</asp:ListItem>
																			<asp:ListItem Value="&lt;&gt;">������</asp:ListItem>
																		</asp:dropdownlist><asp:textbox id="TxtSearchContent" runat="server" Width="104px"></asp:textbox><asp:dropdownlist id="DdlConnect" runat="server">
																			<asp:ListItem Selected="True"></asp:ListItem>
																			<asp:ListItem Value="and">����</asp:ListItem>
																			<asp:ListItem Value="or">����</asp:ListItem>
																		</asp:dropdownlist><asp:button id="BtnAdd" runat="server" Width="64px" BorderStyle="Groove" Text="��������"></asp:button><asp:button id="BtnReset" runat="server" Width="64px" BorderStyle="Groove" Text="��������"></asp:button><asp:button id="BtnSearch" runat="server" Width="64px" BorderStyle="Groove" Text="������¼"></asp:button><asp:button id="BtnAll" runat="server" Width="64px" BorderStyle="Groove" Text="ȫ����ʾ"></asp:button><FONT face="����">&nbsp;</FONT>
																		<asp:button id="btn_Add" runat="server" Width="64px" BorderStyle="Groove" Text="��Ӽ�¼"></asp:button></td>
																</tr>
																<TR>
																	<TD><asp:label id="lbl_S_Title" runat="server" CssClass="front">����������</asp:label><asp:listbox id="DdlSelected" runat="server" Width="628px" Height="26px" Rows="2"></asp:listbox></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 340px" align="center"><asp:panel id="Panel_dan" runat="server"><FONT face="����">
																				<asp:datagrid id="DG_xuan" runat="server" Width="730px" BorderStyle="None" Font-Size="10pt" PageSize="15"
																					DataKeyField="id" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px"
																					BackColor="White" CellPadding="2" AllowSorting="True">
																					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																					<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																					<Columns>
																						<asp:BoundColumn DataField="�½�����" SortExpression="�½�����" HeaderText="�½�����"></asp:BoundColumn>
																						<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
																						<asp:BoundColumn DataField="ѡ��A" SortExpression="ѡ��A" HeaderText="ѡ��A"></asp:BoundColumn>
																						<asp:BoundColumn DataField="ѡ��B" SortExpression="ѡ��B" HeaderText="ѡ��B"></asp:BoundColumn>
																						<asp:BoundColumn DataField="ѡ��C" SortExpression="ѡ��C" HeaderText="ѡ��C">
																							<HeaderStyle Width="80px"></HeaderStyle>
																						</asp:BoundColumn>
																						<asp:BoundColumn DataField="ѡ��D" SortExpression="ѡ��D" HeaderText="ѡ��D"></asp:BoundColumn>
																						<asp:BoundColumn DataField="��ȷ��" SortExpression="��ȷ��" HeaderText="��ȷ��"></asp:BoundColumn>
																						<asp:ButtonColumn Text="�༭" CommandName="Select">
																							<HeaderStyle Width="35px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:ButtonColumn>
																						<asp:ButtonColumn Text="ɾ��" CommandName="Delete">
																							<HeaderStyle Width="35px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:ButtonColumn>
																					</Columns>
																					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																				</asp:datagrid></asp:panel></FONT><asp:panel id="Panel1" runat="server"><FONT face="����"></asp:panel></FONT><asp:panel id="Panel2" runat="server"><FONT face="����">
																				<asp:datagrid id="DG_tian" runat="server" Width="730px" BorderStyle="None" Font-Size="10pt" PageSize="15"
																					DataKeyField="id" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px"
																					BackColor="White" CellPadding="2" AllowSorting="True">
																					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																					<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																					<Columns>
																						<asp:BoundColumn DataField="�½�����" SortExpression="�½�����" HeaderText="�½�����"></asp:BoundColumn>
																						<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
																						<asp:BoundColumn DataField="�����" SortExpression="�����" HeaderText="�����"></asp:BoundColumn>
																						<asp:BoundColumn DataField="���1��" SortExpression="���1��" HeaderText="���1��"></asp:BoundColumn>
																						<asp:BoundColumn DataField="���2��" SortExpression="���2��" HeaderText="���2��">
																							<HeaderStyle Width="80px"></HeaderStyle>
																						</asp:BoundColumn>
																						<asp:BoundColumn DataField="���3��" SortExpression="���3��" HeaderText="���3��"></asp:BoundColumn>
																						<asp:BoundColumn DataField="���4��" SortExpression="���4��" HeaderText="���4��"></asp:BoundColumn>
																						<asp:ButtonColumn Text="�༭" CommandName="Select">
																							<HeaderStyle Width="35px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:ButtonColumn>
																						<asp:ButtonColumn Text="ɾ��" CommandName="Delete">
																							<HeaderStyle Width="35px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:ButtonColumn>
																					</Columns>
																					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																				</asp:datagrid></asp:panel></FONT><asp:panel id="Panel3" runat="server"><FONT face="����">
																				<asp:datagrid id="DG_pan_jian" runat="server" Width="730px" BorderStyle="None" Font-Size="10pt"
																					PageSize="15" DataKeyField="id" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA"
																					BorderWidth="1px" BackColor="White" CellPadding="2" AllowSorting="True">
																					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																					<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																					<Columns>
																						<asp:BoundColumn DataField="�½�����" SortExpression="�½�����" HeaderText="�½�����"></asp:BoundColumn>
																						<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
																						<asp:BoundColumn DataField="��ȷ��" SortExpression="��ȷ��" HeaderText="��ȷ��"></asp:BoundColumn>
																						<asp:ButtonColumn Text="�༭" CommandName="Select">
																							<HeaderStyle Width="35px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:ButtonColumn>
																						<asp:ButtonColumn Text="ɾ��" CommandName="Delete">
																							<HeaderStyle Width="35px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:ButtonColumn>
																					</Columns>
																					<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																				</asp:datagrid></asp:panel></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"><asp:panel id="Panel4" runat="server"><FONT face="����">
																					<asp:datagrid id="DG_bian" runat="server" Width="730px" BorderStyle="None" Font-Size="10pt" PageSize="15"
																						DataKeyField="id" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#8EBEEA" BorderWidth="1px"
																						BackColor="White" CellPadding="2" AllowSorting="True">
																						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
																						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
																						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
																						<HeaderStyle Font-Size="10pt" Font-Bold="True" HorizontalAlign="Center" ForeColor="#133694" BackColor="#CDE8FB"></HeaderStyle>
																						<Columns>
																							<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
																							<asp:BoundColumn DataField="��ȷ��" SortExpression="��ȷ��" HeaderText="��ȷ��"></asp:BoundColumn>
																							<asp:ButtonColumn Text="�༭" CommandName="Select">
																								<HeaderStyle Width="35px"></HeaderStyle>
																								<ItemStyle HorizontalAlign="Center"></ItemStyle>
																							</asp:ButtonColumn>
																							<asp:ButtonColumn Text="ɾ��" CommandName="Delete">
																								<HeaderStyle Width="35px"></HeaderStyle>
																								<ItemStyle HorizontalAlign="Center"></ItemStyle>
																							</asp:ButtonColumn>
																						</Columns>
																						<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
																					</asp:datagrid></asp:panel></FONT></FONT></TD>
																</TR>
															</TBODY>
														</table>
													</td>
												</tr>
											</TBODY>
										</table>
										<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a05.jpg"
											border="0">
											<tr>
												<td vAlign="top"><IMG height="8" src="../images/a04.jpg" width="8"></td>
												<td>
													<div align="right"><IMG height="8" src="../images/a06.jpg" width="8"></div>
												</td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td height="25">
									<div align="center">Copy right&nbsp;��ԭ��ѧԺ All rights reserved</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
