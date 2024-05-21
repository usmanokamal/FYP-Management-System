<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WebApplication1.Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Student Dashboard</h1>
        <p class="lead">View all group information, and evaluation.</p>
        <p><asp:Button ID="Button2" runat="server" Text="View Grade" Width="180px" BackColor="#337AB7" CssClass="btn btn-primary btn-lg" Height="40px" OnClick="Button2_Click1" />
        <asp:Button ID="Button1" runat="server" Text="View Evaluation" Width="180px" BackColor="#337AB7" CssClass="btn btn-primary btn-lg" Height="40px" OnClick="Button1_Click1" />
        </p>
        <asp:Label ID="gradeNA" runat="server" style="color:red ;" Text="Grade not yet Assigned!"></asp:Label>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Project Information
            </h2>
            <asp:Label ID="Label1" runat="server" style="color:black;" Text="Project Title: "></asp:Label> <br />
            <asp:Label ID="Label4" runat="server" style="color:black;" Text="Project Description: "></asp:Label> <br />
            <asp:Label ID="Label2" runat="server" style="color:black;" Text="Supervised By: "></asp:Label> <br />
            <asp:Label ID="Label3" runat="server" style="color:black ;" Text="Group Members:"></asp:Label>
            <br /><br />
            <asp:GridView ID="GridView1" cellspacing="5" runat="server" CellPadding="4" CssClass="gridClass" ForeColor="#333333" GridLines="both">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div class="col-md-4">
            <h2>Panel Information</h2>
            
            <asp:Label ID="Label5" runat="server" style="color:black;" Text="Panel Title: "></asp:Label> <br />
            <asp:Label ID="Label6" runat="server" style="color:black;" Text="Panel Members: "></asp:Label> <br /><br />
            <p>
                <asp:GridView ID="GridView3" runat="server" CssClass="gridClass" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView></p>
        </div>
        <div class="col-md-4">
            <h2>Deadlines</h2>
            <p>
                All assigned deadlines</p>
            <p>
                 
                <asp:GridView ID="GridView2" runat="server" CssClass="gridClass" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                 
            </p>
        </div>
    </div>

</asp:Content>
