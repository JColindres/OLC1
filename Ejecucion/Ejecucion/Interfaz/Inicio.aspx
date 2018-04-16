<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Ejecucion.Interfaz.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ejemplo de ejecucion</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtCodigo" runat="server" Height="600px" Width="600px" TextMode="MultiLine" >
Double contador=1+2*3;
void principal(){
    imprimir("Hola soy el metodo principal");
    imprimir("Operacion aritmetica basica");
    imprimir(1+2);
    imprimir("---------------------------");
    imprimir("operacion aritmetica media");
    imprimir(1+2*3+5*2);
    imprimir("---------------------------");
    imprimir("operacion artimetica avanzada y concatenacion con un string");
    imprimir(1+2*3+5+"hola");
    imprimir("---------------------------");
    imprimir("Sentencia if cuando se cumple la condicion");
    if(2==2){
        imprimir("verdadero");
    }
    imprimir("---------------------------");
    imprimir("Sentencia if cuando no se cumple la condicion");
    imprimir("Falta programar la sentencia else, por esa razon es asi como se imprime");
    imprimir("cuando no se cumple la condicion");
    if(1==2){
    }
    imprimir("falso");

    /*
    La sentencia while en teoria ya funciona, solo que no para porque no hay forma de cambiar el valor
    la variable contador porque aun falta programar esa parte, tambien falta programar el acceso a los ID
    de la tabla de simbolos.
    while(contador==20){
        imprimir("contador");
    }

    */
}
void metodo2(){
    imprimir("hola soy el metodo2");
}
        </asp:TextBox>
        <asp:TextBox ID="txtSalida" runat="server" Height="600px" Width="600px" TextMode="MultiLine">Salida</asp:TextBox>
        <asp:Image ID="Image1" runat="server" />
    </div>
        <p>
        <asp:Button ID="Button1" runat="server" Text="Ejecutar" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
