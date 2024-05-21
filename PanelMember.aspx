<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelMember.aspx.cs" Inherits="WebApplication1.PanelMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
    <p style="margin-left: 80px">
        &nbsp;</p>
            <p style="margin-left: 80px">
        Welcome to the <strong>Panel Member Webpage</strong>.
    </p>
    <p style="margin-left: 80px">
        What would you like to view?</p>
            <p style="margin-left: 80px">
                &nbsp;</p>
            <p style="margin-left: 200px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridView3" runat="server">
                </asp:GridView>
            </p>
            <p style="margin-left: 80px">
                &nbsp;</p>
    <p style="margin-left: 80px">
        <strong>FYP Related Options:</strong></p>
            <p style="margin-left: 80px">
        <asp:Button ID="Button1" runat="server" style="margin-left: 58px" Text="View Group Members" Width="191px" OnClick="Button1_Click" />
            </p>
            <div style="margin-left: 200px">
                <asp:GridView ID="GridView4" runat="server">
                </asp:GridView>
    </div>
    <p style="margin-left: 40px">
        <asp:Button ID="Button2" runat="server" style="margin-left: 61px" Text="View Description" Width="186px" OnClick="Button2_Click" />
    </p>
    <p style="margin-left: 200px">
        &nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
            </p>
            <p style="margin-left: 200px">
                &nbsp;</p>
    <p style="margin-left: 80px">
        <strong>General Options:</strong></p>
            <p style="margin-left: 80px">
        <asp:Button ID="Button3" runat="server" style="margin-left: 61px" Text="Check Evaluation Forms" Width="186px" OnClick="Button3_Click" />
            </p>
            <p style="margin-left: 200px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p style="margin-left: 40px">
        <asp:Button ID="Button4" runat="server" style="margin-left: 61px" Text="Fill Evaluation Forms" Width="186px" OnClick="Button4_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
            <p style="margin-left: 40px">
                &nbsp;</p>


        </div>
    </form>
</body>
</html>


