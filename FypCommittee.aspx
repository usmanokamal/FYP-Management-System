<%@ Page Title="FYPCommittee Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FypCommittee.aspx.cs" Inherits="WebApplication1.FypCommittee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>></script>

    <div class="jumbotron">

        <h1>FYP Committee Dashboard</h1>
        <br />      
        <p class="lead">Report Generation:</p>
        
         <asp:Button runat="server" ID="btn_Evaluations" Text="Missing Evaluations"  BackColor="#337AB7" CssClass="btn btn-primary btn-lg" style="width:240px;" Height="40px" OnClick="btn_Evaluations_Click"/>
         <asp:Button ID="btn_supervisors" runat="server" Text="Supervisors"  BackColor="#337AB7" CssClass="btn btn-primary btn-lg" style="margin-left:20px; width:240px;" Height="40px" OnClick="btn_supervisors_Click"/>
         <asp:Button runat="server" ID="btn_Grades" Text="Grade Statistics"  BackColor="#337AB7" CssClass="btn btn-primary btn-lg" style="width:240px;margin-left:20px;" Height="40px" OnClick="btn_Grades_Click" />
        <br />
         <br />
        <p ><asp:Label id="heading1" runat="server" Text="Supervisors and Number of FYPs they supervise"></asp:Label></p>
        <asp:GridView ID="GridView_Report1" runat="server"  CssClass="gridClass"  ForeColor="#333333" GridLines="None">
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
            <p ><asp:Label id="heading2" runat="server" Text="Supervisors and FYPs"></asp:Label></p>
            <asp:GridView ID="GridView_Report2" runat="server"  CssClass="gridClass"  ForeColor="#333333" GridLines="None">
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

    </div>


    <div class="row">
        <div class="col-md-4">

            <h4>Users</h4>
            <asp:Button class="btn btn-default" ID="newUser" runat="server" Text="Add Users" OnClick="newUser_Click" Height="30px" Width="115px" /> 
            
            <h4>User Priviledges</h4>
            <asp:DropDownList runat="server">
                <asp:ListItem>Student</asp:ListItem>
                <asp:ListItem>Supervisor</asp:ListItem>
                <asp:ListItem>Panel Member</asp:ListItem>

            </asp:DropDownList>
            <asp:Button style="background-color:lawngreen" runat="server" Text="INSERT" />
            <asp:Button  style="background-color:lawngreen" runat="server" Text="UPDATE" />
            <asp:Button  style="background-color:lawngreen" runat="server" Text="SELECT" />
        
        </div>

        <div class="col-md-4">

            <h4>Students</h4>

            <asp:Button ID="btn_students" runat="server" style="margin-bottom:10px;"   Text="View Students" OnClick="btn_students_Click" />
            <br />
          
            <asp:GridView ID="Grid_Students" runat="server"  CssClass="gridClass"  ForeColor="#333333" GridLines="None">
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

             <asp:Label ID="std_name" runat="server" Text="Roll Number:"></asp:Label>
            <br />
             <asp:TextBox ID="search_bar" style="margin-bottom:10px;" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="search" runat="server" Text="Search Group" OnClick="search_Click1" />
            <br />
            <asp:Label ID="LblError" runat="server" style="color:red;" Text="Invalid RollNumber."></asp:Label>
            <asp:Label ID="Label1" runat="server" style="color:black;" Text="Project Title: "></asp:Label> <br />
            <asp:Label ID="Label4" runat="server" style="color:black;" Text="Project Description: "></asp:Label> <br />
            <asp:Label ID="Label2" runat="server" style="color:black;" Text="Supervised By: "></asp:Label> <br />
            <asp:Label ID="Label3" runat="server" style="color:black ;" Text="Group Members"></asp:Label>

            <br />
            <asp:GridView ID="grp_members" runat="server" CssClass="gridClass" ForeColor="#333333" GridLines="None">
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
            
            <h4>Change FYP Deadline</h4>
            Project ID:<asp:DropDownList id="DropDown_projidDead" style="margin-bottom:20px;" AutoPostBack="True" runat="server" OnSelectedIndexChanged="DropDown_projidDead_SelectedIndexChanged" ></asp:DropDownList>
            <br />

           
            <br />
            <h5>Deadline:</h5>
            
            Day:<asp:TextBox ID="tbox_day" style="width:30px;" runat="server"></asp:TextBox>
           Month: <asp:TextBox ID="tbox_month" style="width:30px;" runat="server"></asp:TextBox>
          Year:<asp:TextBox ID="tbox_year" style="width:60px;" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="btn_UpdateDeadline" runat="server" style="margin-bottom:20px;" Text="Update" OnClick="btn_UpdateDeadline_Click"  />
            <asp:Label ID="lbl_Deadlineerr" style="color:red;" runat="server" Text="Invalid Date"></asp:Label>
        
        <br />
        Current Project Information:
        <asp:GridView ID="GridView_AllProjects" runat="server" CssClass="gridClass" ForeColor="#333333" GridLines="None">
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

            <h4>Supervisor</h4>
            <asp:Button ID="btn_Workload" text="Show Workload" runat="server" style="margin-bottom:10px;" OnClick="btn_Workload_Click" /> 
            <br />
            <asp:GridView ID="GridView_WorkLoad" runat="server"  CssClass="gridClass"  ForeColor="#333333" GridLines="None">
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

            <h4 style="margin-top:10px;" >Reallocate Workload</h4>

            <asp:Label runat="server" style="margin-top:10px;"  Text="New Supervisor Id:"></asp:Label>
            <br />
            <asp:DropDownList id="Dropdown_Supervisor" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="Dropdown_Supervisor_SelectedIndexChanged"></asp:DropDownList>
             <br /><br />
            <asp:Label runat="server" style="margin-top:20px;" Text="for Project Id:"></asp:Label>
             <br />
            <asp:DropDownList id="Dropdown_Projects" style="margin-bottom:20px;" AutoPostBack="True" runat="server" OnSelectedIndexChanged="Dropdown_Projects_SelectedIndexChanged"></asp:DropDownList>

            <br />

            Information of the Supervisor being allocated:
            <br />
            <asp:GridView ID="GridView_Supervisor" runat="server"  CssClass="gridClass" style="margin-bottom:10px;" ForeColor="#333333" GridLines="None">
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
             Current information of the Project:
            <br />
            <asp:GridView ID="GridView_Project" runat="server"  CssClass="gridClass"  ForeColor="#333333" GridLines="None">
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
            <asp:Button ID="btn_Allocate" runat="server" Text="Update" OnClick="btn_Allocate_Click" />
            <asp:Label ID="lblError2" style="color:red;" runat="server" Text="Could not Update"></asp:Label>
            <asp:Label ID="lblSuccess2" style="color:green;" runat="server" Text="Updated Successfully"></asp:Label>

            

        </div>
</div>
    
   

</asp:Content>

