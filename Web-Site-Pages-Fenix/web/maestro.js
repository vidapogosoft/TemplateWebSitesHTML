function administrar(tipo,acc)	
{
vari=tipo;
accion=acc;

switch (accion)
 { case "borrahtml":
		document.getElementById(vari).innerHTML="";
		break;
		
   case "ocultacapa": 
		document.getElementById(vari).style.display='none';   				
   		break;
	case "mostrarcapa":
		document.getElementById(vari).style.display='block';
   		break;

	case "invisiblecapa": 		
		document.getElementById(vari).style.visibility="hidden";
   		break;
   		
	case "visiblecapa":		
		document.getElementById(vari).style.visibility="visible";
   		break;
   		
	case "invisibletodos": 		
		document.getElementById('layer1').style.visibility="hidden";
		document.getElementById('layer1a').style.visibility="hidden";
		document.getElementById('layer1b').style.visibility="hidden";
		document.getElementById('layer1c').style.visibility="hidden";
		
		document.getElementById('layer2').style.visibility="hidden";
		document.getElementById('layer2a').style.visibility="hidden";
		document.getElementById('layer2b').style.visibility="hidden";
		document.getElementById('layer2c').style.visibility="hidden";
		
		document.getElementById('layer3').style.visibility="hidden";
		document.getElementById('layer3a').style.visibility="hidden";
		document.getElementById('layer3b').style.visibility="hidden";
		
		document.getElementById('layer4').style.visibility="hidden";
		document.getElementById('layer4a').style.visibility="hidden";
		document.getElementById('layer4b').style.visibility="hidden";
		
   		break;

   		

   case "alertarcapa":
   		elemento =document.getElementById(vari);
		alert(elemento.innerHTML);
		break;



   case "deshabilitarcampo":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  if (formulario.elements[i].name==vari) 
			  {	formulario.elements[i].disabled=1;};
		  	  }
		break;
		
	case "deshabilitartodos":
	   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  formulario.elements[i].disabled=1;
		  	  }
		break;		
		
	case "habilitarcampo":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  if (formulario.elements[i].name==vari) 
			  {	formulario.elements[i].disabled=0;};
		  	  }
		break;
		
		
	case "habilitartodos":
	   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  formulario.elements[i].disabled=0;
		  	  }
		break;		
		
		
		
		

	case "sololectura":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  if (formulario.elements[i].name==vari) 
			  {	formulario.elements[i].readonly=1;};
		  	  }
		break;
		
	case "sololecturatodos":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  	formulario.elements[i].readonly=1;
		  	  }
		break;
		
	case "silectura":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  if (formulario.elements[i].name==vari) 
			  {	formulario.elements[i].readonly=0;};
		  	  }
		break;
				
	case "silecturatodos":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
				formulario.elements[i].readonly=0;
		  	  }
		break;




	case "valornulo":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  if (formulario.elements[i].name==vari) 
			  {	formulario.elements[i].value="";};
		  	  }
		break;


	
	case "valornulotodos":
   		formulario=document.forms[0];
		for (var i=0;i<formulario.length;i++)
			  {
			  if (formulario.elements[i].type!='submit')
			  {
				formulario.elements[i].value="";
				};
		  	  }
		break;

			

		
   default:  alert("Funcion no formateada, deja de inventar!");
  }
}


function leerDropdwon(selectbox,llave)
 {
    var i;
    for(i=selectbox.options.length-1;i>=0;i--)
    {
	if(selectbox.options[i].value == llave) 
	selectbox.options[i].selected=selectbox.options(i).text;       
      }
    }



function removeSelect(Campo,texto)
{
  if (document.frmtarea.OBProperty_ItemNum.value==""){
    var i;
       for(i=document.frmtarea.Campo.options.length-1;i>=0;i--)
        {
        if (document.frmtarea.Campo.options[i].text != texto)
         {          document.frmtarea.Campo.remove(i);         } 
        }
   }   
   }