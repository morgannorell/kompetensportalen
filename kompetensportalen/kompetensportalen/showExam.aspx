<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="showExam.aspx.cs" Inherits="kompetensportalen.showExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="CorrectExam">
        <div class="examDone" runat="server">            
            <div id="testTitle" runat="server">

            </div>
            <div id="testresult" runat="server">

            </div>
            <asp:Button ID="btnBack" runat="server" Text="Tillbaka" OnClientClick="javascript:history.back(1); return false;" Visible="true" CssClass="exam-button"/>
         </div>
     </div>
     </form>
</asp:Content>
