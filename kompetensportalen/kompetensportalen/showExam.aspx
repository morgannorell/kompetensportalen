<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="showExam.aspx.cs" Inherits="kompetensportalen.showExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="CorrectExam">
        <div class="examDone" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" CssClass="label"></asp:Label>

            <asp:Table ID="showExamTable" runat="server" CellPadding="5" CellSpacing="5" BackColor="#ffffff" CssClass="table" Width="800px" Visible="false">
            <asp:TableHeaderRow runat="server" Font-Bold="true" BackColor="#62983c" ForeColor="#ffffff">
            <asp:TableHeaderCell>#</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fråga</asp:TableHeaderCell>
            <asp:TableHeaderCell>Ditt svar</asp:TableHeaderCell>
            <asp:TableHeaderCell>Rätt svar</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            </asp:Table>


            <div id="test" runat="server">


            </div>


            <asp:Button ID="btnBack" runat="server" Text="Tillbaka" OnClientClick="javascript:history.back(1); return false;" Visible="true" CssClass="exam-button"/>

         </div>
     </div>
     </form>
</asp:Content>
