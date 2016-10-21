<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="kompetensportalen.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<div class="article-start">
				<a class="link" href="startcourse.aspx">
				<div class="section section-course">
					<div class="leaf-one"><img src="images\leaf.png" alt="Leaf" /></div>
					<h2>Gå en kurs</h2>
					<p>Här kan du logga in och genomföra ditt licenstest
						eller din årliga kunskapsuppdatering.</p>
					<div class="arrow arrow-one"><img src="images\arrow.png" alt="arrow" /></div>	
				</div>
				</a>
				<a class="link" href="admin.aspx">
				<div class="section section-admin">
					<div class="leaf-two"><img src="images\leaf.png" alt="Leaf" /></div>
					<h2>Hantera användare</h2>
					<p>Här kan du administrera användare, 
						tilldela kurser och läsa rapporter.</p>
					<div class="arrow arrow-two"><img src="images\arrow.png" alt="arrow" /></div>
				</div>
				</a>
				<a class="link" href="support.aspx">
				<div class="section section-support">
					<div class="glas"><img src="images\glas.png" alt="Glas" /></div>					
					<h2>Support</h2>
					<p>Här kan du få hjälp med problem.</p>
					<div class="arrow arrow-three"><img src="images\arrow.png" alt="arrow" /></div>
				</div>
				</a>
				<a class="link" href="faq.aspx">
				<div class="section section-answers">
					<div class="circle"><img src="images\circle.png" alt="Circle" /></div>
					<h2>Frågor och svar</h2>
					<p>Här hittar du svar på de vanligaste frågorna.</p>
					<div class="arrow arrow-four"><img src="images\arrow.png" alt="arrow" /></div>
				</div>
				</a>
                </div>
</asp:Content>


