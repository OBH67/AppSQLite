using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAndroidSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UI_ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Registro> _TablaRegistro;
        public UI_ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDB>().GetConnection();
            NavigationPage.SetHasBackButton(this,false);        
        }

        protected async override void OnAppearing()
        {
            var ResulRegistros = await _conn.Table<Registro>().ToListAsync();
            _TablaRegistro = new ObservableCollection<Registro>(ResulRegistros);
            ListaUsuarios.ItemsSource = _TablaRegistro;
            base.OnAppearing();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
          var Obj = (Registro)e.SelectedItem;
          var item = Obj.Id.ToString();
          int ID = Convert.ToInt32(item);
            try 
	        {	        
		       Navigation.PushAsync(new UI_Elemento(ID));
	        }
	        catch (Exception)
	        {
		        throw;
	        }
        }
    }
}