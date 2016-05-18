<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voorbeeld.aspx.cs" Inherits="WebTechnieken.Voorbeeld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Webtechnieken Demo</title>
    <link rel="stylesheet" href="Styles/style.css"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="Content/scrolling-nav.css" rel="stylesheet">
</head>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">

    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">Voorbeeld Demo</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav">
                    <!-- Hidden li included to remove active class from about link when scrolled up past about section -->
                    <li class="hidden">
                        <a class="page-scroll" href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#about">Voorbeeld 1</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#services">Voorbeeld 2</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#contact">Voorbeeld 3</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Intro Section -->
    <section id="intro" class="intro-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h1>Welkom</h1>
                    <p>Welkom op de voorbeeld pagina van onze demo. Hieronder staan een aantal voorbeeld om aan te tonen wat er nu allemaal mogelijk is met <code>html5</code>, <code>css3</code> en <code>javascript</code>.</p>
                    <a class="btn btn-default page-scroll" href="#about">Click Me to Scroll Down!</a>
                </div>
            </div>
        </div>
    </section>

    <!-- Voorbeeld 1 Section -->
    <section id="about" class="voorbeeld1-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h1>Voorbeeld 1</h1>
                </div>
            </div>
        </div>
    </section>

    <!-- voorbeeld 2 Section -->
    <section id="services" class="voorbeeld2-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h1>Voorbeeld 2</h1>
                </div>
            </div>
        </div>
    </section>

    <!-- Voorbeeld 3 Section -->
    <section id="contact" class="voorbeeld3-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h1>Voorbeeld 3</h1>
                </div>
            </div>
        </div>
    </section>

    <!-- jQuery -->
    <script src="Scripts/jquery-1.9.1.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="Scripts/bootstrap.min.js"></script>

    <!-- Scrolling Nav JavaScript -->
    <script src="Scripts/jquery.easing.min.js"></script>
    <script src="Scripts/scrolling-nav.js"></script>
    
    

    
</body>
</html>
