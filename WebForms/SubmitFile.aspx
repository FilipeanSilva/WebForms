<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SubmitFile.aspx.cs" Inherits="WebForms.SubmitFile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h2>Submit File</h2>
            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="UploadFile" />
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <p>
                <asp:Literal ID="lblMessage" runat="server"></asp:Literal>
            </p>

        </div>
    </main>
</asp:Content>
