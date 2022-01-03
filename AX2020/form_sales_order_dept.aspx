<%@ Page Language="VB" AutoEventWireup="false" CodeFile="form_sales_order_dept.aspx.vb" Inherits="subsystem2_form_sales_order_dept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ import Namespace="System" %>
<%@ import Namespace="System.Configuration" %>
<%@ import Namespace="System.Data" %>
<%@ import Namespace="System.Data.OleDB" %>
<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Data.SqlTypes" %>
<%@ import Namespace="System.Web.Security" %>
<HTML>
	<HEAD>
		<TITLE>SAPS - SB Adventure Production System </TITLE>
		
		<LINK href="http://192.168.1.210/SAPS/script/style.css" type="text/css" rel="stylesheet">
			<meta content="MSHTML 6.00.2900.2523" name="GENERATOR">
			<script language="Javascript">
			var ErrMsg = "Sorry ! Right Click is disabled ";
			function disableRightClick(btnClick)
			{
			if (navigator.appName == "Netscape" && btnClick.which == 3) // check for netscape and right click
			{ 
			alert(ErrMsg);
			return false;
			}
			else if (navigator.appName =="Microsoft Internet Explorer" && event.button == 2) // for IE and Right Click
			{
			alert(ErrMsg);
			return false;
			}
			}
			document.onmousedown = disableRightClick;
			</script>
    <script language="javascript" src=Calendar.js type="text/javascript"></script>    
	</HEAD>
	<body>
		<form id="Form1" runat="server">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tbody>
					<tr vAlign="top">
						<td colSpan="2">
							<table class="HeadBg" cellSpacing="0" width="100%" border="0">
								<tbody>
									<tr>
										<td height="40">
											<script language="JavaScript" src="http://192.168.1.210/SAPS/script/header1.js"></script>
										</td>
										<td align="center" rowSpan="2">
											<!--ASP.NET Logo was here//--></td>
									</tr>
									<tr>
										<td>
											<table class="OtherTabsBg" id="Banner_tabs" style="BORDER-COLLAPSE: collapse" cellSpacing="0"
												border="0">
												<tbody>
													<tr>
														<script language="JavaScript" src="http://192.168.1.210/SAPS/script/header3.js"></script>
														<td height="25">&nbsp;<font color="orange"><asp:label id="displayCredentials" runat="server"></asp:label></font></td>
													</tr>
												</tbody>
											</table>
										</td>
									</tr>
								</tbody>
							</table>
						</td>
					</tr>
				</tbody>
			</table>
<asp:button id="Btn_SO" runat="server" Text="Sales Order-Printing Only"></asp:button>				
     	<br>
		<br>
        <Center>
			<font color="#2f4f4f" size="5"><strong>SALES ORDER RETRIEVAL</strong></font>
				<br>
				<asp:label id="Lbl_Message" runat="server" Font-Size="X-Large" ForeColor="Red" Font-Bold="True" BackColor="#FF80FF"></asp:label>
			    <br>
				<table id="TABLE1"  cellPadding="1" border="0" runat="server">
					<tbody>
						<tr>
							<td>
							System Login :							
							<asp:label id="Lbl_SystemUsername" runat="server" Font-Size="Smaller"></asp:label>
							&nbsp;&nbsp;&nbsp;&nbsp;
							Date :
							<asp:label id="Lbl_ReportDate" runat="server" Font-Size="Smaller"></asp:label>							
							&nbsp;&nbsp;&nbsp;&nbsp;
                            Ref No :
                            <asp:TextBox id="Lbl_RefNo" runat="server" Font-Size="Smaller"  Width="200px">0</asp:TextBox>
                            </td>
						</tr>						
					</tbody>
				</table>
				<br>		
		<table cellSpacing="0" cellPadding="2" width="100%" border="1" bordercolor="#000000">
          <tbody>
            <tr>
              <td style="width: 20%">
                  SALES ORDER</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_SO" runat="server" Text="" Width="300px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:button id="Btn_SearchSO" runat="server" Text="Search S/O" Font-Size="Smaller"></asp:button>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  </td>
            </tr>
            <tr>
              <td style="width: 20%">
                  S/O DATE</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_SODate" runat="server" Text="" Width="300px" ></asp:TextBox>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  CUSTOMER</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_Customer" runat="server" Text="" Width="300px" ></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:TextBox ID="TxtBx_CustomerCode" runat="server" Text="" Width="100px" ></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:TextBox ID="TxtBx_CustomerType" runat="server" Text="" Width="50px" ></asp:TextBox>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  CUSTOMER P/O</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_SOPO" runat="server" Text="" Width="300px" ></asp:TextBox>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  UNIT ORDERED</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_SOQTY" runat="server" Text="" Width="300px" ></asp:TextBox>
              </td>              
            </tr>            
            <tr>
              <td style="width: 20%">
                  ETD
              </td>
              <td style="width: 80%">
                  <asp:TextBox ID="Txtbx_SOETD" runat="server" Text="" Width="300px" ></asp:TextBox>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  INFO 1</td>
              <td style="width: 80%">
                  <asp:TextBox ID="Txtbx_Info1" runat="server" Text="" Width="600px" ></asp:TextBox>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  INFO 2</td>
              <td style="width: 80%">
                  <asp:TextBox ID="Txtbx_Info2" runat="server" Text="" Width="600px" ></asp:TextBox>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  INFO 3</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_Info3" runat="server" Text="" Width="600px" ></asp:TextBox>
              </td>              
            </tr>
            
            <tr>
              <td style="width: 20%">
                  GET S/O FILE</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LstFiles" runat="server" Text="Label"></asp:Label>
                 <asp:button id="btnLoad" runat="server" Text="DownLoad SO" Font-Size="Smaller" 
                      style="height: 21px"></asp:button>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  GET CARTON ARTWORK</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LstFiles2" runat="server" Text="Label"></asp:Label>
                 <asp:button id="btnLoad2" runat="server" Text="DownLoad" Font-Size="Smaller"></asp:button>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  GET PAPERCORE ARTWORK</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LSTFILES3" runat="server" Text="Label"></asp:Label>
                 <asp:button id="BTNLOAD3" runat="server" Text="DownLoad" Font-Size="Smaller"></asp:button>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  GET SHIPPING MARK</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LSTFILES4" runat="server" Text="Label"></asp:Label>
                 <asp:button id="BTNLOAD4" runat="server" Text="DownLoad" Font-Size="Smaller"></asp:button>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  GET OTHER1</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LSTFILES5" runat="server" Text="Label"></asp:Label>
                 <asp:button id="BTNLOAD5" runat="server" Text="DownLoad" Font-Size="Smaller"></asp:button>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  GET OTHER2</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LSTFILES6" runat="server" Text="Label"></asp:Label>
                 <asp:button id="BTNLOAD6" runat="server" Text="DownLoad" Font-Size="Smaller"></asp:button>
              </td>              
            </tr>
            <tr>
              <td style="width: 20%">
                  GET OTHER3</td>
              <td style="width: 80%">                 
                 <asp:Label ID="LSTFILES7" runat="server" Text="Label"></asp:Label>
                 <asp:button id="BTNLOAD7" runat="server" Text="DownLoad" Font-Size="Smaller"></asp:button>
              </td>              
            </tr>
            
            <tr>
              <td style="width: 20%">
                  KEY-IN BY</td>
              <td style="width: 80%">
                  <asp:TextBox ID="TxtBx_SOUser" runat="server" Text="" Width="300px" ></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  </td>              
            </tr>
          </tbody>
        </table>
        <br>
        <asp:datagrid id="DG_DATA" runat="server" Font-Size="Medium" AutoGenerateColumns="False"  ShowFooter="True" width="100%" OnItemCommand="Button_Click">
		<FooterStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="White" BackColor="#006633"></FooterStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006633"></HeaderStyle>
		<Columns>		
            <asp:ButtonColumn CommandName="GET" Text="GET_SO" ButtonType="PushButton"></asp:ButtonColumn>
            <asp:BoundColumn DataField="DocNo" HeaderText="DocNo"></asp:BoundColumn>
            <asp:BoundColumn DataField="SalesOrderNo" HeaderText="SalesOrderNo"></asp:BoundColumn>
            <asp:BoundColumn DataField="SODateTime" HeaderText="SalesOrderDate" DataFormatString="{0:dd/MM/yy}"></asp:BoundColumn>
            <asp:BoundColumn DataField="Customer" HeaderText="Customer"></asp:BoundColumn>
            <asp:BoundColumn DataField="SalesOrder" HeaderText="Desc" ></asp:BoundColumn>
            <asp:BoundColumn DataField="flag5" HeaderText="Checked" ></asp:BoundColumn>
            <asp:BoundColumn DataField="JM" HeaderText="Created JO" ></asp:BoundColumn>
        </Columns>
		</asp:datagrid>
        <br>
        </Center>
        </form>                     		
	</body>
</HTML>
