
<%@ Page Title="Add Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="WebApplication1.NewUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   



    <div class="jumbotron">
        
         <h1>Add User</h1>
                
        
        <br />

        <div>
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True"  Width="176px" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
            <asp:ListItem>Faculty</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
            <asp:ListItem>Supervisor</asp:ListItem>
            <asp:ListItem>Panel Member</asp:ListItem>
        </asp:DropDownList>
            <br /><br />

        
        <asp:Label ID="Label1" runat="server"  Text="Input1"></asp:Label>
            <br />
        <asp:DropDownList ID="DropDown_Faculty" AutoPostBack="true" runat="server"   Width="150px" OnSelectedIndexChanged="DropDown_Faculty_SelectedIndexChanged"  ></asp:DropDownList>
        <%--<asp:Button ID="showFaculty" runat="server" Text="Show Data" OnClick="showFaculty_Click" />--%>
             
         <asp:TextBox ID="input1" runat="server"></asp:TextBox>         
            <br />

        <asp:Label ID="Label2" runat="server"  Text="Input2"></asp:Label>
        <br />
        <asp:TextBox ID="input2" runat="server"></asp:TextBox>
            <asp:RadioButton ID="Check_newPanel" runat="server" AutoPostBack="true" OnCheckedChanged="Check_newPanel_CheckedChanged"></asp:RadioButton>
        <asp:Label ID="Lbl_Check1" runat="server"  Text="New Panel"></asp:Label>
        <asp:RadioButton ID="Check_ExistingPanel" runat="server"  AutoPostBack="true" Checked="True" OnCheckedChanged="Check_ExistingPanel_CheckedChanged"></asp:RadioButton>
        <asp:Label ID="Lbl_Check2" runat="server"  Text="Existing Panel"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server"  Text="Input3"></asp:Label>
        <br />
        <asp:TextBox ID="input3" runat="server"></asp:TextBox>

         <asp:DropDownList ID="Exist_panel" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Exist_panel_SelectedIndexChanged" ></asp:DropDownList>

        <br /> 
          
        <asp:Label ID="Label4" runat="server"  Text="Input4"></asp:Label>
        <br />
        <asp:TextBox ID="input4" runat="server"></asp:TextBox>  
         <br />
        
        
         <asp:Button ID="Insert_data" runat="server"  style=" margin-top:10px;" Text="Add" OnClick="Insert_data_Click" />
             
            <asp:Label ID="lblSuccess" runat="server" style="color:green ;margin-left:20px;" Text="Data Inserted Successfully"></asp:Label>
         <asp:Label ID="lblError" runat="server" style="color:red;margin-left:20px;" Text="Invalid Data Entered"></asp:Label>     
            </div>
        <br />
        
         <div>
             <asp:GridView ID="GridView" runat="server" CssClass="gridClass" ForeColor="#333333" GridLines="None">
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
             <br />
             <asp:GridView ID="GridView1" runat="server" CssClass="gridClass" ForeColor="#333333" GridLines="None">
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
        
         
           

        
    </div>


    


</asp:Content>

