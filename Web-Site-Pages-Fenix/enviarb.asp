<%
nombre =request.form("nombre")
email= request.form("email")
perfil= request.form("perfil")
codigo1=request.form("codigo1")
codigo2=request.form("codigo2")
comentarios= request.form("comentarios")
motivo="Email desde sitio Web Figbiz.net"

cuerpo="Este es un mensaje autogenerado desde el formulario de envío del Sitio de Internet de figbiz.net. Estos son datos de una persona interesada en Oportunidades laborales:"
cuerpo= cuerpo & "<p>Nombre: " & nombre & "<br> Perfil: " & perfil & "<br>Email: " & email & "<br>Resumen de Vida: "& comentarios & "</p><p>.</p>"

if nombre="" then
	response.redirect("oportunidad.asp?error=1")
end if

if email="" then
	response.redirect("oportunidad.asp?error=2")
end if

if codigo1="" then
	response.redirect("oportunidad.asp?error=7")
end if


if codigo1=codigo2 then
	Set myMail=CreateObject("CDO.Message")
	myMail.Subject=motivo
	myMail.From=email
	myMail.To="crodriguez@figbiz.net"
	myMail.HTMLBody = cuerpo
	myMail.Send
	set myMail=nothing
	response.redirect("ok2.htm")
else
	response.redirect("oportunidad.asp?error=6")
end if


%>
