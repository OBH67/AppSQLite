using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAndroidSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UI_Registrar : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public UI_Registrar()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

     protected void Button_Clicked_Agregar(object sender, EventArgs e)
      {
        var DatosRegistro = new Registro
        { 
           Nombre = NombreRegistro.Text,
           Usuario = UserRegistro.Text,
           Password = PasswordRegistro.Text
        };
            _conn.InsertAsync(DatosRegistro);  
            limpiarFormulario();
        }
        
        void limpiarFormulario()
        {
            NombreRegistro.Text="";
            UserRegistro.Text="";
            PasswordRegistro.Text = "";
            DisplayAlert("Se","Agrego","Correctamente");
        }
    }
}