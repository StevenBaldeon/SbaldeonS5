using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SbaldeonS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarEliminar : ContentPage
    {
        public ActualizarEliminar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text= edad.ToString();
        }

        private  void btnActulizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.56.1/ws_uisrael/post.php?codigo="+txtCodigo.Text +"&nombre="+txtNombre.Text + "&apellido=" + txtApellido.Text + "&Edad=" + txtEdad.Text, "PUT", parametros);
                DisplayAlert("Alerta", "Dato Actualizado", "Cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }


        }

        private void btnELIMINAR_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
               
                cliente.UploadValues("http://192.168.56.1/ws_uisrael/post.php?codigo="+txtCodigo.Text, "DELETE", parametros);
                DisplayAlert("Alerta", "Dato Eliminado", "Cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}