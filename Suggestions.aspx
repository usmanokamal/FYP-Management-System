<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Suggestions.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Give Review</h3>
    <p style="direction: ltr">Select a group to check if review uploaded.</p>
    <p>
        <asp:DropDownList ID="DropDownList1" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="DropDownChange" runat="server">
        <asp:ListItem Text="Select Group..." Value="0" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />
    </p>
    <asp:Label ID="Label1" runat="server" Text="Review Status: "></asp:Label> <br /><br />
    
    <div ID="div1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Input Status: "></asp:Label> <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="77px" Width="429px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Send" CssClass="btn btn-primary btn-lg" Width="115px" OnClick="sendReview" />
    </div>
        </asp:Content>
    
