<%@ Page language="c#" Codebehind="adminChapters.aspx.cs" AutoEventWireup="false" Inherits="Test.admin.adminzhangjie" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminzhangjie</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">BODY TD { FONT-SIZE: 12px }
	.zz { FILTER: glow(color=#213a5a,Strength=1); COLOR: #ffffff }
	.front { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #00258f; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.bfront { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #ffffff; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.bxfront { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.frontx { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #00258f; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.STYLE9 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #133694 }
	.bk2 { BORDER-RIGHT: #8ebeea 1px solid; BORDER-TOP: #8ebeea 1px solid; BORDER-LEFT: #8ebeea 1px solid; BORDER-BOTTOM: #8ebeea 1px solid }
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
									<table cellSpacing="0" cellPadding="0" width="98%" align="center" background="../images/a02.jpg"
										border="0">
										<tr>
											<td align="left" width="14"><IMG height="26" src="../images/a01.jpg" width="13"></td>
											<td width="317">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td style="WIDTH: 20px"><font color="#ffffff"><IMG height="20" src="../images/6.jpg" width="18"></font></td>
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
													vAlign="top" align="center" height="197">
													<TABLE id="Table1" style="WIDTH: 432px; HEIGHT: 400px" cellSpacing="1" cellPadding="1"
														width="432" border="1">
														<TR>
															<TD style="WIDTH: 78px" bgColor="#d6e6ff">�½�����:</TD>
															<TD style="WIDTH: 181px; HEIGHT: 28px" align="left" bgColor="#eaeaea"><asp:textbox id="TXTzjmc" runat="server" Width="248px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 78px; HEIGHT: 30px" bgColor="#d6e6ff">˵����Ϣ:</TD>
															<TD style="WIDTH: 350px; HEIGHT: 30px" bgColor="#eaeaea"><asp:textbox id="TXTsmxx" runat="server" Width="248px"></asp:textbox><asp:button id="BtnSave" runat="server" Text="���"></asp:button><asp:button id="BtnReset" runat="server" Text="����"></asp:button></TD>
														<TR>
															<TD style="WIDTH: 78px; HEIGHT: 37px" bgColor="#d6e6ff">�����б�:</TD>
															<TD style="WIDTH: 350px; HEIGHT: 37px" bgColor="#eaeaea"><asp:dropdownlist id="DdlSearchKind" runat="server" Width="96px">
																	<asp:ListItem Value="�½�����">�½�����</asp:ListItem>
																	<asp:ListItem Value="˵����Ϣ">˵����Ϣ</asp:ListItem>
																</asp:dropdownlist><asp:textbox id="TxtSearchContent" runat="server" Width="152px"></asp:textbox><asp:button id="BtnSearch" runat="server" Width="40px" Text="����" Height="25px"></asp:button><asp:button id="BtnAll" runat="server" Width="35px" Text="ȫ��"></asp:button></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 78px" bgColor="#d6e6ff"><FONT face="����"></FONT></TD>
															<TD style="WIDTH: 181px" bgColor="#eaeaea"><asp:datagrid id="Dg_zhangjie" runat="server" Width="330px" Height="250px" AutoGenerateColumns="False"
																	AllowPaging="True" DataKeyField="�½ں�">
																	<Columns>
																		<asp:BoundColumn DataField="�½�����" SortExpression="�½�����" HeaderText="�½�����"></asp:BoundColumn>
																		<asp:BoundColumn DataField="˵����Ϣ" SortExpression="˵����Ϣ" HeaderText="˵����Ϣ"></asp:BoundColumn>
																		<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" CancelText="ȡ��" EditText="�༭"></asp:EditCommandColumn>
																		<asp:ButtonColumn Text="ɾ��" CommandName="Delete"></asp:ButtonColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
													</TABLE>
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
