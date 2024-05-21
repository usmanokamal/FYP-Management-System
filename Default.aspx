<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>FYP LOGIN PAGE</title>

    <style type="text/css">

         *{
             background-color:aquamarine;
         }   
         h1{

             font-family:'Agency FB';
             text-align :center;

         }

         .log_form{

             display:flex;
             justify-content: center;

         }
         

    </style>
</head>
<body>
    
    <h1>FYP LOGIN</h1>
    <form id="loginform" runat="server" class="log_form">
       
    <table>

            <tr>
                <td>
                <asp:Label ID="Label1" runat="server" style="color:darkblue " Text="Username :"></asp:Label>
                </td>

                <td>
                <asp:TextBox ID="txtusername" runat="server" ></asp:TextBox>
                </td>
            </tr> 

            <tr>

                <td>
                <asp:Label ID="Label2" runat="server"  Text="Password :"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtpassword" runat="server" textmode="password" ></asp:TextBox>
                </td>
            </tr>
           

        <tr>
            <td>
            <asp:Button ID="loginButton" runat="server" Text="Login" style="background-color:aliceblue;"  OnClick="loginButton_Click"/>
            </td>
            <td>
                <br /> 
                <asp:Label text-align="center" ID="Label3" runat="server" Text="Login as" style="text-align: center"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>FYPCommittee</asp:ListItem>
                    <asp:ListItem>Supervisor</asp:ListItem>
                    <asp:ListItem>PanelMember</asp:ListItem>
                    <asp:ListItem>Student</asp:ListItem>
                </asp:RadioButtonList>
           </td>
               </tr>  

             <tr> 
            <td>
            <asp:Label ID="LblErrormsg" runat="server" style="color:red ;" Text="Incorrect Username or Password"></asp:Label>
            </td>
             </tr> 
           <tr>  
           <td>
             <asp:Label ID="Lblsuccess" runat="server" style="color:darkgreen;" Text="Authentication Successful"></asp:Label>
           </td>
           </tr>  
    </table>
    </form>
   
</body>
</html>