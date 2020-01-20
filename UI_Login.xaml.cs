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
	public partial class UI_Login : ContentPage
	{
		private SQLiteAsyncConnection _conn;
		public UI_Login()
		{
			InitializeComponent();
			_conn = DependencyService.Get<ISQLiteDB>().GetConnection();
		}
	private void Button_Clicked_Login(object sender, EventArgs e)
	{

	  try 
	{	   
	  string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MySQLite.db3");          
	  var db = new SQLiteConnection(databasePath);
      IEnumerable<Registro> resultado = SELECT_WHERE(db, UserLogin.Text, PasswordLogin.Text);		
	  if (resultado.Count()>0)
	{
       Navigation.PushAsync(new UI_ConsultaRegistro());
	 }
	  else
	{
			 DisplayAlert("Error", "Confirmar", "Usuario y/o password");
	}
    }
	catch (Exception)
	{
		throw;
	}
		}

    private void Button_Clicked_Registro(object sender, EventArgs e)
	{
			Navigation.PushAsync(new UI_Registrar());
		}

	public static IEnumerable<Registro>SELECT_WHERE(SQLiteConnection db, string usuario, string password)
     {
			return db.Query<Registro>("select * from Registro where Usuario=? and Password=?", db, usuario, password);
		}
	
	}
}