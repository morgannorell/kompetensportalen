<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course_one.aspx.cs" Inherits="kompetensportalen.course_one" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset= "utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="javascript/menu.js"></script>
	<link rel="stylesheet" href="css/style.css" />
	<link rel="stylesheet" href="css/main.css" />
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
			<div class="article">
                <div class="textfield-left">
                    <div class="leaf-login"><img src="images/leaf.png" /></div>
                    <div class="center"><h2>Hej</h2></div>
                    <p><b>Välkommen till din sida</b></p>
                    <p>Från den här sidan kan du starta ditt test. 
                        Om det är första gången så kommer du att få besvara 25 frågor. 
                        Om du ska genomföra din årliga kunskapsuppdatering besvarar du 15 frågor.</p>
                    <p>För att klara testet så måste du svara rätt på minst 70% av frågorna
                        och minst 60% på varje delmoment.</p>
                    <p>Testet består av 3 delar som är:
                        <ul>
                            <li>Produkter och hantering av kundens affärer</li>
                            <li>Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi</li>
                            <li>Etik och regelverk</li>
                        </ul>
                    </p>                   
                </div>
                <div class="vr"></div>
                <div class="textfield-right textfield-responsive">
                    <p>Du lämnar normalt ett svar per fråga men det kan finnas frågor som
                        kräver flera svar. Detta står då på respektive fråga.</p>
                    <p>Du har 30 minuter på dig att slutföra testet.</p>
                    <p><i>Lycka till!!</i></p>
                    <form>                        
                        <p><input type="button" name="Login" value="Tidigare testresultat" />
                            <input type="button" name="Login" value="Starta testet" /></p>
                    </form>
                </div>
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
