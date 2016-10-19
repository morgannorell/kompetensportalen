<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="kompetensportalen.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset= "utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="js/menu.js"></script>
	<link rel="stylesheet" href="css/style.css" />
	<link rel="stylesheet" href="css/start.css" />
	<link rel="stylesheet" href="css/responsiv.css" />
    <title>JE-Bankens kunskapsportal</title>
</head>
<body>
    <form id="form1" runat="server">
		<div class="top-black"></div>
		<div class="top-white"></div>
		<div class="container">
			
			<div class="title">
				<h1>KOMPETENSPORTALEN</h1>
			</div>
			<div class="nav">
				<ul class="topnav" id="myTopnav">
                    <li class="icon"><a href="javascript:void(0);" onclick="myFunction()">&#9776;</a></li>
                    <li><a href="index.aspx">Hem</a></li>
                    <li><a href="startcourse.aspx">Kurs</a></li>
                    <li><a href="admin.aspx">Hantera</a></li>
                    <li><a href="support.aspx">Support</a></li>
                    <li><a href="answers.aspx">Frågor</a></li>			
				</ul>
			</div>  
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
				<a class="link" href="answers.aspx">
				<div class="section section-answers">
					<div class="circle"><img src="images\circle.png" alt="Circle" /></div>
					<h2>Frågor och svar</h2>
					<p>Här hittar du svar på de vanligaste frågorna.</p>
					<div class="arrow arrow-four"><img src="images\arrow.png" alt="arrow" /></div>
				</div>
				</a>
			</div>
			<div class="footer">
				<h3>JE-Bankens kompetensportal</h3>
				<p>Ansvarig för sidan: Morgan Norell</p>
			</div>
			<div class="bottom-black"></div>	
		</div>
    </form>
</body>
</html>
