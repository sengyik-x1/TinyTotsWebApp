<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRegistration.aspx.cs" Inherits="TinyTotsWebApp.EditRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Registration</title>
     <style>
     .green-title{
         color: green;

     }

     .form-element{
         margin-bottom: 10px;
     }

     .nav-menu{
         background-color: #f1f1f1;
         padding: 10px;
         text-align: center;
     }

     .nav-menu a{
         margin: 0 15px;
         text-decoration: none;
         font-weight: bold;
         color: #333;
     }

     .nav-menu a:hover{
         color: green;
     }

     .grid-container{
         display: flex;
         justify-content: center;
     }

     .grid-container .gridview-style{
         width: 80%;
     }
 </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav-menu">
            <a href="RegistrationChild.aspx">Register Child</a>
            <a href="RegistrationList.aspx">Registration List</a>
        </div>

        <div>
            <h1 class="green-title">Edit  Registration</h1>
            <asp:HiddenField ID="hfRegistrationId" runat="server" />
            
            <label for="txtFirstName">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" CssClass="form-element"></asp:TextBox><br />

            <label for="txtSecondName">Second Name:</label>
            <asp:TextBox ID="txtSecondName" runat="server" placeholder="Second Name" CssClass="form-element"></asp:TextBox><br />

            <label for="ddlRace">Race:</label>
            <asp:DropDownList ID="ddlRace" runat="server" CssClass="form-element">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem Value="Malay">Malay</asp:ListItem>
                <asp:ListItem Value="Chinese">Chinese</asp:ListItem>
                <asp:ListItem Value="Indian">Indian</asp:ListItem>
                <asp:ListItem Value="Other">Other</asp:ListItem>
            </asp:DropDownList><br />

            <label for="rblGender">Gender:</label>
            <asp:RadioButtonList ID="rblGender" runat="server" CssClass="form-element">
                <asp:ListItem Value="Boy">Boy</asp:ListItem>
                <asp:ListItem Value="Girl">Girl</asp:ListItem>
            </asp:RadioButtonList><br />

            <label for="cblAllergies">Food Allergies</label>
            <asp:CheckBoxList ID="cblAllergies" runat="server" CssClass="form-element">
                <asp:ListItem Value="None">None</asp:ListItem>
                <asp:ListItem Value="Dairy">Dairy</asp:ListItem>
                <asp:ListItem Value="Peanuts">Peanuts and Tree Nuts</asp:ListItem>
                <asp:ListItem Value="Soybean">Soybean</asp:ListItem>
                <asp:ListItem Value="Wheat">Wheat</asp:ListItem>
            </asp:CheckBoxList><br />

            <asp:Button ID="btnEdit" runat="server" Text="Save" CssClass="form-element" OnClick="btnEdit_Click" />

        </div>
    </form>
</body>
</html>
