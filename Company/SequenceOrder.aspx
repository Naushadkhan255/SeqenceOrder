<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SequenceOrder.aspx.cs" Inherits="Company.SequenceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sequence Order</title>     
   <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.datatables.net/2.0.7/css/dataTables.dataTables.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="https://cdn.datatables.net/2.0.7/js/dataTables.js"></script>
    <script>
        $(document).ready(function () {
            $.ajax({
                url: 'CompanyService.asmx/GetCompanyDetail',
                method: 'Post',
                dataType: 'json',
                success: function (data) {
                    $('#CompanyTbl').DataTable({
                        data: data,
                        columns: [
                            {'data': 'Id'},
                            { 'data': 'CompanyId'},
                            { 'data': 'Number' },
                            { 'data': 'InsDT'}                                          
                        ]
                    });
                }
            })            
        });
    </script>

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
        <br />
        <br />
        <br />
        <section class="container" id="Section">
        <div class="row">
            <table id="CompanyTbl">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>CompanyId</th>
                        <th>Number</th>
                        <th>InsDT</th>
                    </tr>
                   
                </thead>

            </table>

        </div>
            </section>
    </form>
</body>
</html>
