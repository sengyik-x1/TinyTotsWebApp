<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" Inherits="TinyTotsWebApp.RegistrationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration List</title>
    <style>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav-menu">
            <a href="RegisterChild.aspx">Register Child</a>
            <a href="RegisterList.aspx">Registration List</a>
        </div>

        <div>
            <h1 class="green-title">Registration List</h1>

            <div class="grid-container">
                <asp:GridView ID="gvRegistrations" runat="server" AutoGenerateColumns="false" DataKeyNames="RegistrationId" EmptyDataText="No registration found.">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="SecondName" HeaderText="Second Name" />
                        <asp:BoundField DataField="Race" HeaderText="Race" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="FoodAllergies" HeaderText="Food Allergies" />
                        <asp:HyperLinkField HeaderText="Action" Text="Edit" DataNavigateUrlFields="RegistrationId" DataNavigateUrlFormatString="EditRegistration.aspx?RegistrationId={0}" />
                    </Columns>
                </asp:GridView>



            </div>
        </div>
    </form>
</body>
</html>
