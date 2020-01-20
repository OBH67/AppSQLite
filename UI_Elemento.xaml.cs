using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAndroidSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UI_Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Registro> UpdateRes;
        IEnumerable<Registro> DeleteRes;
        public UI_Elemento(int id)
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
            IdSeleccionado = id;
        }

        protected override void OnAppearing()
        {
            Mensaje.Text = "Se afectará al ID ["+IdSeleccionado+"]";
            base.OnAppearing();
        }

        private void Button_Clicked_Actualizar(object sender,  EventArgs e)
        {
          var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");
          var db = new SQLiteConnection(databasePath);
          UpdateRes = UpdateMethod(db, NombreElement.Text,UserElement.Text,PassElement.Text,IdSeleccionado);  
        }

        private void Button_Clicked_Eliminar(object sender, EventArgs e)
        {
          var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");
          var db = new SQLiteConnection(databasePath);
          DeleteRes = DeleteMethod(db, IdSeleccionado);  
        }


        public static IEnumerable<Registro> UpdateMethod(SQLiteConnection db, string nombre, string usuario, string password, int id)
        {
          return db.Query<Registro>("UPDATE Registro SET Nombre=?, Usuario=?, Password=? where Id=?",
                                    nombre, usuario, password, id);
        }

        public static IEnumerable<Registro> DeleteMethod(SQLiteConnection db, int id)
        {
           return db.Query<Registro>("DELETE FROM Registro where Id=?", id);        
        }

        

    }
}