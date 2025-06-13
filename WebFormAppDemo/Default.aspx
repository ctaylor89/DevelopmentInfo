<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormAppDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src = "<%=ResolveUrl("~/ Scripts/mycustom1.js") %>" type = "text/javascript"></script>

	<script type = "text/javascript" >
	    $(document).ready(function () {
	        $('div.first').click(function () {
	            // $(this).removeClass('outer').addClass('outer2');  // ('background-color', 'green');
	            $(this).toggleClass('first2');
	        });

	        $('div.second').click(function () {
	            $(this).html("Changed Html! Voila!")
	            $('div.first').text("Changed Text!")
	            // alert("text example: " + $('div').text()); // Dispays the text of all div elements
	        });
	        $('div.third').click(function() {
	            $("div.third .third1").html('<a href="example.html">Link</a><b>hello</b>');
	            $("div.third .third2").text('<a href="example.html">Link</a><b>hello</b>');
	        });
	        $('#button1').click(function () {
	            // $('li').add($('p')).css('background-color', 'red');
	            var colorthese = $('li').add($('p'));
	            colorthese.css('background-color', 'red');
	        });
	        $('#btn1').click(function () {
	            $('.first, .second').prepend("<input type='button' value='My New Button'/>");
	        });
	    });
	</script>
    <h1>Web forms practice</h1>
    
    <div class="first">
        A div with class first
    </div>    
    <div class="second">
        A div with class second
    </div>
    <div class="third">
        <div class="third1">
            Starting text displayed now
        </div>
        <div class="third2">
            Starting text displayed now
        </div>
        
    </div>
    <div class="fourth">
        <ul>
          <li>list item 1</li>
          <li>list item 2</li>
          <li>list item 3</li>
        </ul>
        <p>A paragraph</p>
        <input type="button" id="button1" value="Press to change backgrounds"/>
    </div>
    <div class="fourth">
        <ul>
            <li><input type="button" id="btn1" value="Add buttons test" /></li>
            <li><input type="button" id="btn2" value="test" /></li>
            <li><input type="button" id="btn3" value="test" /></li>

        </ul>
    </div>
</asp:Content>
