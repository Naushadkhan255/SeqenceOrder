<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SequenceOrder.aspx.cs" Inherits="Company.SequenceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sequence Order</title>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="clearfix">
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                
            </div>

            <div class="row">
                <div class="col-sm-2">
                    <label id="CompanyIDLab" runat="server">Company ID</label>
                    <asp:DropDownList ID="CompanyDDL" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CompanyDDL_SelectedIndexChanged">
                       <asp:ListItem>Please select value</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="NumberLab" runat="server" Text="Number"></asp:Label>
                    <asp:TextBox ID="NumberTxt" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />


            <div class="row">
                <div class="col-sm-2">
                    <asp:Button ID="Button1" runat="server" Text="Save" Width="100%"  OnClick="Button1_Click"/>
                    <asp:Label ID="lebMassage" runat="server" text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
