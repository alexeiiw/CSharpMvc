using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

namespace HolaMundoMvc
{
    public partial class WFIngreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Configurar();

            LlenarTabla();

            if (Request.QueryString["code"] != null)
            {
                if (!IsPostBack)
                {
                    LlenarFormulario(Request.QueryString["code"]);
                }
            }

        }

        private void LimpiarFormulario()
        {
            Response.Redirect("/WfIngreso.aspx");
        }

        private void LlenarFormulario(String strId)
        {
            // Llena la vista
            Conexion con = new Conexion(Properties.Settings.Default.Conexion);
            DataTable tabla = new DataTable();
            tabla = con.LlenarTabla("Persona", "id = " + strId);

            // Llena los textbox
            TextBox1.Text = tabla.Rows[0].ItemArray[1].ToString();
            TextBox2.Text = tabla.Rows[0].ItemArray[2].ToString();
            TextBox3.Text = tabla.Rows[0].ItemArray[3].ToString();
        }

        private void Configurar()
        {
            // Configura las etiquetas
            lblTitulo.Text = "Formulario de Personas";
            Label1.Text = "Ingrese Nombre";
            Label2.Text = "Ingrese Apellido";
            Label3.Text = "Ingrese Edad";

            if (Request.QueryString["code"] != null)
            {
                Button1.Text = "Modificar";
                Button2.Text = "Eliminar";
                Button2.Visible = true;
            }
            else
            {
                Button1.Text = "Agregar";
            }
        }

        private void LlenarTabla()
        {
            // Llena la vista
            Conexion con = new Conexion(Properties.Settings.Default.Conexion);
            GridView1.DataSource = con.LlenarTabla("Persona");
            GridView1.DataBind();
         }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Creo el objeto de conexion
            Conexion con = new Conexion(Properties.Settings.Default.Conexion);

            if (Request.QueryString["code"] != null)
            {
                // Obtengo los valores de los textbox
                String strDatos = "Nombre='" + TextBox1.Text + "',Apellido='" + TextBox2.Text + "',Edad=" + TextBox3.Text;
                String strCondicion = "Id = " + Request.QueryString["code"];
                lblMensaje.Text = con.ModificarDatos("Persona", strDatos, strCondicion);
            }
            else
            {
                // Obtengo los valores de los textbox
                String strDatos = "'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text;
                lblMensaje.Text = con.InsertarDatos("Persona", "Nombre,Apellido,Edad", strDatos);
            }

            LimpiarFormulario();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Creo la conexion 
            Conexion con = new Conexion(Properties.Settings.Default.Conexion);
            lblMensaje.Text = con.EliminarDatos("Persona", "Id =" + Request.QueryString["code"]);

            LimpiarFormulario();
        }
    }
}