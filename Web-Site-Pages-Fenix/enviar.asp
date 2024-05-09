<%
nombre =request.form("nombre")
empresa=request.form("empresa")
pais=request.form("pais")
email= request.form("email")
codigo1=request.form("codigo1")
codigo2=request.form("codigo2")
comentarios= request.form("comentarios")
motivo="Email desde sitio Web Figbiz.net"

cuerpo="Este es un mensaje autogenerado desde el formulario de envío del Sitio de Internet de figbiz.net. Estos son datos de la persona que desea contactar a la empresa:"
cuerpo= cuerpo & "<p>Nombre: " & nombre & "<br> Empresa: " & empresa & "<br>País: " & pais & "<br>Email: " & email & "<br>Comentarios: "& comentarios & "</p><p>Recuerde dar respuesta a este email cuanto antes.</p>"

if nombre="" then
	response.redirect("contactenos.asp?error=1")
end if

if email="" then
	response.redirect("contactenos.asp?error=2")
end if

if codigo1="" then
	response.redirect("contactenos.asp?error=7")
end if


if codigo1=codigo2 then
	Set myMail=CreateObject("CDO.Message")
	myMail.Subject=motivo
	myMail.From=email
	myMail.To="crodriguez@figbiz.net"
	myMail.HTMLBody = cuerpo
	myMail.Send
	set myMail=nothing
	response.redirect("ok.htm")
else
	response.redirect("contactenos.asp?error=6")
end if


%>
