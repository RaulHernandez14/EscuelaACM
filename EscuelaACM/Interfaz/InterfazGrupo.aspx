<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterfazGrupo.aspx.cs" Inherits="EscuelaACM.Interfaz.InterfazGrupo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@latest/css/pico.min.css">  <!--vinculo de api-->
    <title>Ingresar | Grupo</title> 
    <link href="Styles/Style.css" rel="stylesheet" /> <!--vinculo a la hoja de estilos-->
</head>
<body>
        <div class ="container">
        <header>
            <h1>
                LLENADO EN LA TABLA GRUPO
            </h1>
        </header>
        <form id="form1" runat="server">
            <ul class="campos">
                <li>
                    <asp:TextBox ID="txtGrupo" runat="server" placeholder ="Ingresa el nuevo grupo"></asp:TextBox>
                </li>
                <li>
                    <asp:TextBox ID="intAula" runat="server" placeholder ="Ingresa el numero de aula" TextMode="Number"></asp:TextBox>
                </li>
            </ul>
            <div>
                <asp:Button class="" ID="BtnEnviar2"  runat="server" Text="Registrar" OnClick="BtnEnviar2_Click"/>
            </div>
            <div id="Cont-Buttom">
                <ul class="botones">
                    <li>
                        <a class="Btn" href="InterfazAlumno.aspx">Llenar alumnos</a>
                    </li>
                    <li>
                        <a class="Btn" href="InterfazGrupoAlumno.aspx">Asignar grupo a alumno</a>
                    </li>
                </ul>
            </div>
            <div class ="Tabla">
                <asp:GridView ID="gvGrupos" runat="server" AutoGenerateColumns="False" Width="500px">
                    <Columns>
                        <asp:BoundField DataField="ID"          HeaderText="ID" />
                        <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                        <asp:BoundField DataField="Aula"        HeaderText="Aula" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
