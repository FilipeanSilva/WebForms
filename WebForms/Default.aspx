<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <%--<p>Link to <a href="Names.aspx">NamesPage</a></p>--%>
        </section>

        <asp:Panel ID="AuthenticatedContent" runat="server" Visible="false">
            <h2>Welcome, <asp:Literal ID="litUserName" runat="server"></asp:Literal>!</h2>
            <div class="container">
                <h1 class="mt-5">Available Files</h1>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped mt-3">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Path" HeaderText="Path" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>

        <asp:Panel ID="NonAuthenticatedContent" runat="server" Visible="true">
            <h2>Welcome, guest!</h2>
            <p>Please <a href="Login.aspx">log in</a> to access more features.</p>
        </asp:Panel>
    </main>
</asp:Content>
