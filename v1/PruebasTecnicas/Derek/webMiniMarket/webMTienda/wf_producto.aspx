<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_producto.aspx.cs" Inherits="webMTienda.Views.Producto.wf_producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Interfaz Web Facturas</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="author" content="Derek Mejia" />
    
</head>

<body style="height: 100%; margin: 0; padding: 0;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
        <div class="panel panel-default">
            <div class="panel-heading">               
                <h3 class="panel-title">Ingreso de Productos</h3>
            </div>
            <div class="panel-body">

                <!-- MENSAJES -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="row" style="padding: 10px;">
                            <div class="col-md-1" style="padding-top: 5px;"></div>
                            <asp:Label class="label label-success" ForeColor="Green" runat="server" ID="lblMensaje" />
                            <asp:Label class="label label-danger" ForeColor="Red" runat="server" ID="lblError" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <!-- DATOS DEL PRODUCTO -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-4" style="padding-top: 5px;">
                        <asp:Label ID="Label1" Font-Size="Medium" Font-Bold="true" Text="Datos del Producto" runat="server" />
                    </div>

                </div>
                <!-- NUMERO DEL PRODUCTO -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="Label9" Font-Size="Medium" Text="# Producto:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtIdProducto" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                </div>

                <!-- DESCRIPCION - CATEGORIA -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="lblDescripcion" Font-Size="Medium" Text="Descripción:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtDescripcion" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="lblCategoria" Font-Size="Medium" Text="Categoria:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtCategoria" runat="server" type="text" CssClass="text form-control" Style="width: 145px; font-size: 11px;" Enabled="true" />
                    </div>
                </div>

                <!-- PROVEEDOR - MARCA -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="Label2" Font-Size="Medium" Text="Proveedor:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtProveedor" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="Label3" Font-Size="Medium" Text="Marca:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtMarca" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                </div>

                <!-- MEDIDA - CANTIDAD -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="Label4" Font-Size="Medium" Text="Medida:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtMedida" CssClass="text form-control text-right" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="Label5" Font-Size="Medium" Text="Cantidad:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtCantidad" CssClass="text form-control text-right allownumericwithdecimal" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                </div>

                <!-- PRECIO UNITARIO -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Label ID="Label6" Font-Size="Medium" Text="Precio Unitario:" runat="server" />
                    </div>
                    <div class="col-md-3" style="padding-top: 5px;">
                        <asp:TextBox ID="txtPrecioUnitario" CssClass="text form-control text-right allownumericwithdecimal" runat="server" Enabled="true" Font-Size="12px" />
                    </div>
                </div>
                
                <!-- BOTONES -->
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-1" style="padding-top: 5px;"></div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Button ID="btnNuevo" Text="Nuevo" runat="server" OnClick="btnNuevo_Click" CssClass="btn" BackColor="Gray" ForeColor="White" />
                    </div>
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Button ID="btnFinalizar" Text="Finalizar" runat="server" CssClass="btn" OnClick="btnFinalizar_Click" BackColor="Gray" ForeColor="White" />
                    </div> 
                    <div class="col-md-1" style="padding-top: 5px;">
                        <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn" OnClick="btnModificar_Click" BackColor="Gray" ForeColor="White" />
                    </div>    
                </div>               


                <!-- FIN -->
            </div>
        </div>


    </form>


    <script type="text/javascript">
        //Validaciones importantes        
        $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {

            $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

        $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
            $(this).val($(this).val().replace(/[^\d].+/, ""));
            if ((event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });

        function mayus(e) {
            e.value = e.value.toUpperCase();
        }

        function confirmation() {
            if (confirm('Está seguro de eliminar la línea ?')) {
                return true;
            } else {
                return false;
            }
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            // example - CssClass="allownumericwithdecimal"
            $(".allownumericwithdecimal").on("keypress keyup blur", function (event) {

                $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
                if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            $(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
                $(this).val($(this).val().replace(/[^\d].+/, ""));
                if ((event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            function mayus(e) {
                e.value = e.value.toUpperCase();
            }
        });

    </script>

</body>
</html>
