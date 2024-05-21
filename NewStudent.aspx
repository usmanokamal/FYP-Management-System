<%@ Page Title="Add Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewStudent.aspx.cs" Inherits="WebApplication1.NewStudent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   



    <div class="jumbotron">
        
         <h1>Register FYP Group</h1>
                
        
         Supervisor:<br />

        <div>
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True"  Width="176px">
        </asp:DropDownList>
            <br /><br />

            Group Member 1<br />
         <asp:TextBox ID="input1" runat="server"></asp:TextBox>         
            <br />

            Group Member 2<br />
        <asp:TextBox ID="input2" runat="server"></asp:TextBox>
        <br />
            Group Member 3<br />
        <asp:TextBox ID="input3" runat="server"></asp:TextBox>
        <br />
            Project Title<br />
        <asp:TextBox ID="input4" runat="server"></asp:TextBox>  
            <br />
            Project Description<br />
        <asp:TextBox ID="input5" runat="server"></asp:TextBox>  
            <br />
         <br />
        
        
         <asp:Button ID="Insert_data" runat="server" Text="Add" OnClick="Insert_data_Click" />
             
            <asp:Label ID="lblSuccess" runat="server" style="color:green ;margin-left:20px;" Text="Data Inserted Successfully"></asp:Label>
         <asp:Label ID="lblError" runat="server" style="color:red;margin-left:20px;" Text="Invalid Data Entered"></asp:Label>     
            </div>
        <br />
        
         <div>
             <br />
         </div>   
        
         
           

        
    </div>


    


</asp:Content>

