<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startcourse.aspx.cs" Inherits="kompetensportalen.startcourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset= "utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="js/menu.js"></script>
	<link rel="stylesheet" href="css/style.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/responsiv.css" />
	<title>JE-Bankens kunskapsportal</title>
</head>
<body>
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
			<div class="article">
                <div class="textfield-left">
                    <div class="leaf-login"><img src="images/leaf.png" /></div>
                    <div class="center"><h2>Välkommen</h2></div>
                    <p><b>Såhär gör du!</b></p>
                    <p>För att kunna genomföra din utbildning så loggar
                        du in med det användarnamn och lösenord som du
                        har blivit tilldelad. Om du saknar uppgifter så kan
                        du klicka på förstoringsglaset så kommer du till supporten där
                        vi kan hjälpa dig.</p>
                    <p>När du sedan har loggat in så kan du starta 
                        din utbildning. Du kan också välja att se
                        resultatet av din senast genomförda utbildning
                        om du gjort den tidigare.</p>                    
                </div>
                <div class="vr"></div>
                <div class="login textfield-responsive">
                    <form action="course_one.aspx" runat="server">
                        <p>Användarnamn:<br /><input type="text" name="username" size="21" value="test" /></p>
                        <p>Lösenord:<br /><input type="password" name="password" size="22" value="test" /></p>
                        <p><input type="submit" name="Login" value="Logga in" /></p>
                        <p><a href="support.aspx">Glömt lösenord</a></p>
                    </form>
                </div>
			</div>
            <div class="footer">
				<h3>JE-Bankens kompetensportal</h3>
				<p>Ansvarig för sidan: Morgan Norell</p>
			</div>
			<div class="bottom-black"></div>	
		</div>
</body>
</html>
