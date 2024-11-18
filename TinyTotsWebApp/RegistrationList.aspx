<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" Inherits="TinyTotsWebApp.RegistrationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration List</title>
    <style>
        body {
            margin: 20px; /* Adjust value as needed */
            padding: 0; /* Optional: reset padding */
            box-sizing: border-box; /* Ensures consistent box-sizing */
        }

        .green-title {
            color: green;
        }

        .form-element {
            margin-bottom: 10px;
        }

        .nav-menu {
            background-color: #f1f1f1;
            padding: 10px;
            text-align: center;
        }

            .nav-menu a {
                margin: 0 15px;
                text-decoration: none;
                font-weight: bold;
                color: #333;
            }

                .nav-menu a:hover {
                    color: green;
                }

        .grid-container {
            display: flex;
            justify-content: center;
        }

            .grid-container .gridview-style {
                width: 80%;
            }

        .search-bar {
            /*            display: flex;
            flex-direction:row;*/
            gap: 10px;
            /*            align-items: center;
            justify-content: center;*/
            justify-self: center;
            font-weight: bold;
            color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav-menu">
            <a href="RegisterChild.aspx">Register Child</a>
            <a href="RegisterList.aspx" style="color: green">Registration List</a>
        </div>

        <div>
            <h1 class="green-title">Registration List</h1>

            <div class="search-bar">
                <label for="txtSearch">Search</label>
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search" CssClass="form-element"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="form-element" />
            </div>

            <div class="grid-container">
                <asp:GridView ID="gvRegistrations" runat="server" AutoGenerateColumns="false" DataKeyNames="RegistrationId" EmptyDataText="No registration found." OnRowDeleting="gvRegistrations_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="SecondName" HeaderText="Second Name" />
                        <asp:BoundField DataField="Race" HeaderText="Race" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="FoodAllergies" HeaderText="Food Allergies" />
                        <asp:HyperLinkField HeaderText="Edit Action" Text="Edit" DataNavigateUrlFields="RegistrationId" DataNavigateUrlFormatString="EditRegistration.aspx?RegistrationId={0}" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete Action" />
                    </Columns>
                </asp:GridView>



            </div>
        </div>
    </form>
</body>
</html>
