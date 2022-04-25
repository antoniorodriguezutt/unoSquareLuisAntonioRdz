using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using FormsIcons.Clases;



namespace FormsIcons
{
    public partial class MainPage : ContentPage
    {
        public IList<ClaseDatosPersonales> Ilist { get; set; }
        bool isRefreshing = false;
        List<ClaseDatosPersonales> listClaseDatosPers = new List<ClaseDatosPersonales>();
        System.IO.Stream IODeclarado = new System.IO.MemoryStream();


        public MainPage()
        {
            InitializeComponent();

            ClaseDatosPersonales claseDatosPers = new ClaseDatosPersonales();

            Ilist = new List<ClaseDatosPersonales>();
            Ilist.Add(new ClaseDatosPersonales {  nombre = "NOMBRE", edad = "EDAD", aniosexperiencia = "AÑOS DE EXP" });
            Ilist.Add(new ClaseDatosPersonales {  rutaImagen = "avatarMan.jpg",  nombre = "Luis Antonio Rodriguez", edad = "27", aniosexperiencia = "4" });
            
            claseDatosPers.nombre = "Luis Antonio Rodriguez";
            listClaseDatosPers.Add(claseDatosPers);

            Ilist.Add(new ClaseDatosPersonales {  rutaImagen = "avatarGirl.jpg" , nombre = "Laura Jessenia Sandoval", edad = "25", aniosexperiencia = "3" });
            claseDatosPers.nombre = "Laura Jessenia Sandoval";
            listClaseDatosPers.Add(claseDatosPers);

            BindingContext = this;

            txtEdadCalculada.Text = "";
            txtAniosExperiencia.Text = "";
            txtNombre.Text = "";
            try {
                var info = DependencyService.Get<IDeviceInfoService>();

                lblPckageBundleInfo.Text = info.obtenerPackageName();
            }
            catch (Exception ex) {
                ex.Message.ToString();
            }

                datePickerFormulario.DateSelected += Date_DateSelected;

          
        }

        async void btnCargarImagen_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();
                var stream = await result.OpenReadAsync();                
                resultImage.Source = ImageSource.FromStream(() => stream);
              
            }
            catch (Exception ex) {
                DisplayAlert("Alerta", "Error: " + ex.Message.ToString(), "Cerrar");
            }
            
        }

        private void btnGuardarDatos_Clicked(object sender, EventArgs e)
        {
            try
            {

                Ilist.Add(new ClaseDatosPersonales { nombre = txtNombre.Text, edad = txtEdadCalculada.Text, aniosexperiencia = txtAniosExperiencia.Text });
                BindingContext = this;
            }
            catch (Exception ex) {
                ex.Message.ToString();
            }
            
        }

        private void DatePicker_BindingContextChanged(object sender, EventArgs e)
        {
            
        }

        private void Date_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dia = Convert.ToInt32(datePickerFormulario.Date.Day);
            var mes = Convert.ToInt32(datePickerFormulario.Date.Month);
            var anio = Convert.ToInt32(datePickerFormulario.Date.Year);
         
            DateTime nacimiento = new DateTime(anio, mes, dia);
            DateTime hoy = DateTime.Today;

            var yearsOld = hoy - nacimiento;
            int years = (int)(yearsOld.TotalDays / 365.25);

            lblEdadCalculada.Text = "Edad Calculada: " + years;
            txtEdadCalculada.Text = "" + years;

        }

        private void btnGuardarDatosForm_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtAniosExperiencia.Text == "" || txtEdadCalculada.Text == "" || txtNombre.Text == "")
                {
                    DisplayAlert("Aviso", "Favor de completar los campos antes de continuar", "Cerrar");
                }
                else {

                    int nombreRepetido = 0;
                    foreach (var item in listClaseDatosPers) {
                        string nombreEach = item.nombre;
                        string nombreTxt = txtNombre.Text;
                        nombreEach = nombreEach.Replace(" ", "");
                        nombreEach = nombreEach.Replace(" ", "");
                        nombreEach = nombreEach.Replace(" ", "");
                        nombreEach = nombreEach.Replace(" ", "");
                        nombreEach = nombreEach.Replace(" ", "");
                        nombreTxt = nombreTxt.Replace(" ", "");
                        nombreTxt = nombreTxt.Replace(" ", "");
                        nombreTxt = nombreTxt.Replace(" ", "");
                        nombreTxt = nombreTxt.Replace(" ", "");
                        nombreTxt = nombreTxt.Replace(" ", "");
                        nombreEach = nombreEach.ToLower();
                        nombreTxt = nombreTxt.ToLower();

                        if (nombreEach == nombreTxt) {
                            nombreRepetido = 1;
                        }

                    }

                    if (nombreRepetido == 0)
                    {

                        var viewModel = BindingContext;
                        Ilist.Add(new ClaseDatosPersonales { nombre = txtNombre.Text, edad = txtEdadCalculada.Text, aniosexperiencia = txtAniosExperiencia.Text });

                        BindingContext = null;
                        BindingContext = viewModel;


                        ClaseDatosPersonales claseDatosPers = new ClaseDatosPersonales();
                        claseDatosPers.nombre = txtNombre.Text + "";
                        listClaseDatosPers.Add(claseDatosPers);

                        DisplayAlert("Aviso", "Usuario registrado correctamente", "Cerrar");
                        txtEdadCalculada.Text = "";
                        txtAniosExperiencia.Text = "";

                        txtNombre.Text = "";
                        lblEdadCalculada.Text = "Edad Calculada: X";

                    }
                    else {
                        DisplayAlert("Aviso", "El nombre ingresado ya ha sido registrado con anterioridad", "Cerrar");
                    }

                }



            }
            catch (Exception ex)
            {
                DisplayAlert("Aviso", "Error al capturar los datos", "Cerrar");
                ex.Message.ToString();
            }
        }
    }
}
