<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterfazGrupoAlumno.aspx.cs" Inherits="EscuelaACM.Interfaz.InterfazGrupoAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@latest/css/pico.min.css">  <!--vinculo de api-->
    <title>Asignar | Grupo</title> 
    <link href="Styles/Style.css" rel="stylesheet" /> <!--vinculo a la hoja de estilos-->
</head>
<body>
   <div class ="container">
        <header>
            <h1>
                ASIGNAR GRUPO ALUMNO
            </h1>
        </header>
        <form id="form1" runat="server">
            <ul class="campos">
                <li>
                    <asp:DropDownList ID="DDLalumno" runat="server"></asp:DropDownList>
                </li>
                <li>
                    <asp:DropDownList ID="DDLgrupo" runat="server" ></asp:DropDownList>
                </li>
            </ul>
            <div>
                <asp:Button class="" ID="BtnEnviar3"  runat="server" Text="Asignar" OnClick="BtnEnviar3_Click"/>
            </div>
            <div id="Cont-Buttom">
                <ul class="botones">
                    <li>
                        <a class="Btn" href="InterfazAlumno.aspx">Llenar alumnos</a>
                    </li>
                    <li>
                        <a class="Btn" href="InterfazGrupo.aspx">Llenar grupos</a>
                    </li>
                    <li>
                        <a class="Btn" href="InterfazCheckBox.aspx"> CheckBox</a>
                    </li>
                </ul>
            </div>
            <div class ="Tabla">
                <asp:GridView ID="gvGrupoAlumno" runat="server" AutoGenerateColumns="False" Width="1000px">
                    <Columns>
                        <asp:BoundField DataField="ID"       HeaderText="ID" />
                        <asp:BoundField DataField="Nombre"   HeaderText="Nombre" />
                        <asp:BoundField DataField="Edad"     HeaderText="Edad" />
                        <asp:BoundField DataField="AlumnoID" HeaderText="Numero de control" />
                        <asp:BoundField DataField="Grupo"    HeaderText="Grupo" />
                        <asp:BoundField DataField="Aula"     HeaderText="Aula" />
                        <asp:BoundField DataField="GrupoID"  HeaderText="ID Grupo" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
