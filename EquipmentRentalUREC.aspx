<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EquipmentRentalUREC.aspx.vb" Inherits="EquipmentRentalUREC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>University Recreation Equipment Rental System</title>
      <link rel="stylesheet" type="text/css" href="Master.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 406px;
        }
        .auto-style3 {
            width: 100%;
            border: 1px solid #000000;
            background-color: #C0C0C0;
        }
        .auto-style5 {
            width: 339px;
        }
        .auto-style6 {
            width: 227px;
        }
        .auto-style7 {
            width: 307px;
        }
        .auto-style8 {
            width: 594px;
        }
        .auto-style9 {
            width: 559px;
        }
        .auto-style10 {
            width: 576px;
        }
        .auto-style11 {
            width: 330px;
        }
        .auto-style12 {
            width: 307px;
            height: 57px;
        }
        .auto-style13 {
            height: 57px;
        }
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
    <div id="Headings">
    <h1> University Recreation</h1>
        <h2>Equipment Rental System&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>
    </div>
        <p>
            &nbsp;</p>
        <div id="Buttons">
        <p>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">Please Login with valid Credentials</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Username:</td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Password:</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="Username and/or Password not found!" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">(same credentials as my.wsu.edu)</td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Login" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">(Admin , AdminPass)</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                
                <asp:View ID="View2" runat="server">
                    <table class="auto-style3">
                        <tr>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Checkout Equipment" />
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Checkin Equipment" />
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Manual Return" />
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="Charge Damaged/Missing" />
                            </td>
                            <td>
                                <asp:Button ID="Button20" runat="server" Text="Patron Information" />
                            </td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Text="Admininstrator Usage" />
                            </td>
                        </tr>
                    </table>
                    
                    <br />
                    <br />
                </asp:View>
            </asp:MultiView>
        </p></div>
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View4" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5">Patron Hand Swipe:</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Red" Text="Patron not found!" Visible="False"></asp:Label>
                        </td>
                        <td rowspan="4">
                            <asp:MultiView ID="MultiView3" runat="server">
                                <asp:View ID="View9" runat="server">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style7">Scan item:</td>
                                            <td>
                                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Red" Text="Item not found!" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">or </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">Choose Manually:</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">Select Category:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">Select Item:</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button9" runat="server" Text="Enter" />
                                                <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="Green" Text="Item checked out✓" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">or</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Manually Enter Patron&#39;s Student ID:</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Red" Text="Patron not found!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">(Guest Number)</td>
                        <td class="auto-style6">
                            <asp:Button ID="Button8" runat="server" Text="Enter" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style7">Scan item:</td>
                        <td class="auto-style8">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Text="Item not found!" Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">or </td>
                        <td class="auto-style8">
                            <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="Red" Text="NO ITEMS CHECKED OUT!" Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Choose Manually:</td>
                        <td class="auto-style8">
                            <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="Red" Text="CANNOT DETERMINE ITEM!" Visible="False"></asp:Label>
                        </td>
                        <td>NOTE: Attendant must check all equipment for damages upon return before checking back in!</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Select Item to Return:<asp:Button ID="Button24" runat="server" Text="View DropDownList" />
                        </td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="DropDownList4" runat="server" Visible="False">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style8">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style8">
                            <asp:Button ID="Button10" runat="server" Text="Enter" />
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="Green" Text="Item Returned✓" Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style9">Select Item:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td>
                            <asp:Button ID="Button11" runat="server" Text="Enter" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Green" Text="Item Returned✓" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Red" Text="NO ITEMS CHECKED OUT!" Visible="False"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Current Checked Out Items:</td>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View7" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style9">NOTE: FLAT RATE of $15 per Item</td>
                        <td>ITEMS MUST BE CURRENTLY CHECKED OUT TO BE REPORTED!</td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Select Patron:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                            <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Red" Text="PATRON HAS NO ITEMS CHECKED OUT!" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Select Category:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Select Item:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Payment Type:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList9" runat="server" AutoPostBack="True">
                                <asp:ListItem>Credit</asp:ListItem>
                                <asp:ListItem>Cash</asp:ListItem>
                                <asp:ListItem>Check</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Charged Amount:</td>
                        <td>
                            <asp:TextBox ID="TextBox9" runat="server">$15.00</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            <asp:Button ID="Button25" runat="server" Text="Submit" />
                            <asp:Label ID="Label18" runat="server" ForeColor="Green" Text="Customer charged and  item deleted from inventory!" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button12" runat="server" Text="Enter Data" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Charge Transcations:</td>
                        <td>
                            <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style9">Current Checked Out Items:<br />
                            <asp:Button ID="Button27" runat="server" Text="Hide" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button26" runat="server" Text="View" />
                        </td>
                        <td>
                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View15" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style7">Get Patron Information:</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style11">Add Patron Information:</td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Green" Text="Patron Added ✓" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Patron ID:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Red" Text="Patron not found!" Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="Button21" runat="server" Text="Get Info" />
                        </td>
                        <td class="auto-style7">Patron ID:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox25" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Patron Name:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox21" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style7">Patron Name:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Patron Email:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox22" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style7">Patron Email:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Patron Phone:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox23" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style7">Patron Phone:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Membership Status:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="TextBox29" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style7">Membership Status:</td>
                        <td class="auto-style10">
                            <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                                <asp:ListItem>True</asp:ListItem>
                                <asp:ListItem>False</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style10">
                            <asp:Button ID="Button22" runat="server" Text="Enter" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Button ID="Button23" runat="server" Text="View Patrons" />
                        </td>
                        <td class="auto-style10">
                            <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style10">&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View8" runat="server">
                <asp:MultiView ID="MultiView4" runat="server">
                    <asp:View ID="View10" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style2">Please Enter the <strong>Admin Pass</strong>word</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Password:</td>
                                <td>
                                    <asp:TextBox ID="TextBox11" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Red" Text="Password not found!" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">AdminPass</td>
                                <td>
                                    <asp:Button ID="Button13" runat="server" Text="Login" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <br />
                    <asp:View ID="View11" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td>Select:</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button14" runat="server" Text="Reports and Charts" />
                                </td>
                                <td>
                                    <asp:Button ID="Button15" runat="server" Text="Add/Remove Items" />
                                </td>
                                <td>
                                    <asp:Button ID="Button16" runat="server" Text="Edit Items" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <br />
                </asp:MultiView>
                <asp:MultiView ID="MultiView5" runat="server">
                    <asp:View ID="View12" runat="server">
                        Reports:<br /> 
                        <iframe id="I1" allowfullscreen="true" frameborder="0" height="700" name="I1" src="https://app.powerbi.com/view?r=eyJrIjoiYmFlMmQwMTgtNGM3Zi00MmYxLTlhYjMtMTY1NWY3YzhkNDc4IiwidCI6ImI1MmJlNDcxLWY3ZjEtNDdiNC1hODc5LTBjNzk5YmI1M2RiNSIsImMiOjZ9" width="933"></iframe>
                    </asp:View>
                    <asp:View ID="View13" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style7">Scan barcode of item:</td>
                                <td>
                                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Enter Category:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Enter Item Name (Type):</td>
                                <td>
                                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Example: Locker 1</td>
                                <td>
                                    <asp:Button ID="Button17" runat="server" Text="Insert New Item" />
                                    <asp:Label ID="Label19" runat="server" ForeColor="Red" Text="Check DATA!" Visible="False"></asp:Label>
                                    <asp:Label ID="Label20" runat="server" ForeColor="Green" Text="Item Added" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Or</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Remove Item</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Scan barcode of item:</td>
                                <td>
                                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">or</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Select Category:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList11" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Select Item Type:</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td>
                                    <asp:Button ID="Button18" runat="server" Text="Delete Item" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View14" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style7">Barcode:</td>
                                <td>
                                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button28" runat="server" Text="Fill" />
                                    <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="Check DATA!" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Category:</td>
                                <td>&nbsp;
                                    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                                    <asp:Label ID="Label22" runat="server" ForeColor="Red" Text="No Records Found!" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">Item Type:<br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    And Extras:</td>
                                <td class="auto-style13">
                                    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" AutoPostBack="True">
                                        <asp:ListItem Value="True">Damaged</asp:ListItem>
                                        <asp:ListItem Value="False">Not Damaged</asp:ListItem>
                                    </asp:CheckBoxList>
                                    <br />
                                    <asp:CheckBoxList ID="CheckBoxList4" runat="server" AutoPostBack="True">
                                        <asp:ListItem Value="True">Checked Out</asp:ListItem>
                                        <asp:ListItem Value="False">Not Checked Out</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Example: Locker 1</td>
                                <td>
                                    <asp:Button ID="Button19" runat="server" Text="Edit Item" />
                                    <asp:Label ID="Label23" runat="server" ForeColor="Green" Text="Item Edited!" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <br />
                    <br />
                </asp:MultiView>
                <br />
            </asp:View>
        </asp:MultiView>
   
        <br />
   
    <p>
        &nbsp;</p>
   
        <p>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/couglogo.png" />
            Created 4/22/2019 by Evan Bullock for academic purposes only</p>
        <p>
            &nbsp;</p>
    </form>
   
    </body>
</html>
