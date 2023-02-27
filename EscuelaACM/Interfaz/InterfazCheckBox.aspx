<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterfazCheckBox.aspx.cs" Inherits="EscuelaACM.Interfaz.InterfazCheckBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@latest/css/pico.min.css">  <!--vinculo de api-->
    <title>Asignar | CheckBox</title> 
    <link href="Styles/Style.css" rel="stylesheet" /> <!--vinculo a la hoja de estilos-->
</head>
<body>
    <div class ="container">
        <header>
            <h1>
                ASIGNAR GRUPO ALUMNO (CHECK-BOX)
            </h1>
        </header>
        <form id="form1" runat="server">
            <ul class="campos">
                <li>
                    <asp:DropDownList ID="DDLgrupo" runat="server" ></asp:DropDownList>
                </li>
            </ul>
            <div class ="TablasCheck">
                <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" Width="500px">
                    <Columns>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckAlumno" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Edad" HeaderText="Edad" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvRelacion" runat="server" AutoGenerateColumns="False" Width="500px">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Alumno" HeaderText="Alumno" />
                        <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Button class="" ID="BtnEnviar4"  runat="server" Text="Asignar" OnClick="BtnEnviar4_Click"/>
            </div>
            <div id="Cont-Buttom">
                <ul class="botones">
                    <li>
                        <a class="Btn" href="InterfazGrupoAlumno.aspx">Regresar</a>
                    </li>
                </ul>
            </div>
        </form>
    </div>
</body>
</html>
