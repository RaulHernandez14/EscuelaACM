<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterfazAlumno.aspx.cs" Inherits="EscuelaACM.Interfaz.InterfazAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@latest/css/pico.min.css">  <!--vinculo de api-->
    <title>Ingresar | Alumno</title> 
    <link href="Styles/Style.css" rel="stylesheet" /> <!--vinculo a la hoja de estilos-->
</head>
<body>
    <div class ="container">
        <header>
            <h1>
                LLENADO EN LA TABLA ALUMNO
            </h1>
        </header>
        <form id="form1" runat="server">
            <ul class="campos">
                <li>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder ="Ingresa el nombre del alumno"></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="intEdad" runat="server" placeholder ="Ingresa la edad" TextMode="Number"></asp:TextBox>
                </li>
            </ul>
            <div>
                <asp:Button class="" ID="BtnEnviar1"  runat="server" Text="Registrar" OnClick="BtnEnviar1_Click"  />
            </div>
            <div id="Cont-Buttom">
                <ul class="botones">
                    <li>
                        <a class="Btn" href="InterfazGrupo.aspx">Llenar grupos</a>
                    </li>
                    <li>
                        <a class="Btn" href="InterfazGrupoAlumno.aspx">Asignar grupo a alumno</a>
                    </li>
                </ul>
            </div>
            <div class ="Tabla">
                <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" Width="600px">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Edad" HeaderText="Edad" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
