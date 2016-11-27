<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examDone.aspx.cs" Inherits="kompetensportalen.examDone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Rätta test" OnClick="Button1_Click"/>
        <asp:Table ID="ExamTable" runat="server">

            <asp:TableHeaderRow runat="server" Font-Bold="true" BackColor="#666666" ForeColor="#ffffff">
            <asp:TableHeaderCell>#</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fråga</asp:TableHeaderCell>
            <asp:TableHeaderCell>Ditt svar</asp:TableHeaderCell>
            <asp:TableHeaderCell>Rätt svar</asp:TableHeaderCell>
        </asp:TableHeaderRow>

        </asp:Table>
    </form>
    
</asp:Content>
