<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examDone.aspx.cs" Inherits="kompetensportalen.examDone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="CorrectExam">
            <div class="examDone" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Label" CssClass="label"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label" CssClass="label"></asp:Label>
            <asp:Table ID="ExamTable" runat="server" CellPadding="5" CellSpacing="5" BackColor="#ffffff" CssClass="table" Width="800px">
            <asp:TableHeaderRow runat="server" Font-Bold="true" BackColor="#62983c" ForeColor="#ffffff">
            <asp:TableHeaderCell>#</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fråga</asp:TableHeaderCell>
            <asp:TableHeaderCell>Ditt svar</asp:TableHeaderCell>
            <asp:TableHeaderCell>Rätt svar</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            </asp:Table>

            <asp:Button ID="Button1" runat="server" Text="Återvänd till startsidan" OnClick="Button1_Click" CssClass="exam-button"/>
                </div>
        </div>
    </form>
    
</asp:Content>
