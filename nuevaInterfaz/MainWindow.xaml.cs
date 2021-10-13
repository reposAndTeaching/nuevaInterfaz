using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nuevaInterfaz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //declaración de una lista de personas, que llevará el registro
        List<Persona> listaPersonas;
        //Objeto del tipo regex, que al inicializarlo, llevará todos las expresiones regulares que estarán permitidas en nuestro método para permitir solo números
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        //función que decide, según el objeto de ripo Regex y el texto entrante (en este caso el que escribamos por teclado)
        //solución encontrada en https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
        private static bool IsTextPermitido(string text)
        {
            return !_regex.IsMatch(text);
        }

        public MainWindow()
        {
            InitializeComponent();
            //se inicializa la lista que guardará los registros
            listaPersonas = new List<Persona>();
            //creamos algunos objetos y los añadimos a la lista para que tenga una población inicial
            Persona p1 = new Persona("Diego", "17966", 30);
            Persona p2 = new Persona("John", "11111", 50);
            listaPersonas.Add(p1);
            listaPersonas.Add(p2);
            actualizarListBox();
            //cambiamos la fuente a las letras de button, mediante una propiedad (FontSize)
            buttonRegistrar.FontSize = 26;
        }

        //función que se ejecuta al presionar un botón (registrar)
        //El evento click se desencadena al clickear el botón, y le hemos dado la instrucción de ejecutar ésta función al desencadenar ese evento
        private void buttonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            //obtenemos de los textbox, el contenido mediante la propiedad
            string nombreForm = textBoxNombre.Text;
            string rutForm = textBoxRut.Text;
            int edadForm;
            try
            {
                edadForm = Int32.Parse(textBoxEdad.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No está ingresando un número");
                edadForm = 0;
            }
            //creamos un objeto del tipo persona con los datos recolectadops del formulario, y lo añadimos a la lista
            Persona p = new Persona(nombreForm, rutForm, edadForm);
            listaPersonas.Add(p);
            //actualizamos nuestra lista visual
            actualizarListBox();

            //Después de registrar, dejamos las cajas de texto en blanco, y ubicamos el foco de escritura en el primera text box
            textBoxNombre.Text = "";
            textBoxRut.Text = "";
            textBoxEdad.Text = "";
            textBoxNombre.Focus();
        }

        //función que se ejecuta cada vez que previsualizamos la caja de texto, es decir, cada vez que fuera a cambiar.
        //y cada vez que pase ésto, se preguntará si está permitido que el carácter presionado se escriba.
        private void textBoxEdad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextPermitido(e.Text);
        }

        //método con el que actualizamos la lista de personas, en concreto, actualizamos la carga de la caja de lista (listBox)
        private void actualizarListBox()
        {
            listBoxPersonas.ItemsSource = listaPersonas.ToArray();
        }

        //método que activa o desactiva el botón registrar, dependiendo del contenido de las cajas de texto
        private void EnableButton()
        {
            string txtNombre = textBoxNombre.Text;
            string txtRut = textBoxRut.Text;
            string txtEdad = textBoxEdad.Text;

            bool isEnabled = false;

            if (txtNombre != "" && txtRut != "" && txtEdad != "")
            {
                isEnabled = true;
            }
            else
            {
                isEnabled = false;
            }
            buttonRegistrar.IsEnabled = isEnabled;
        }

        //método que controla el evento, cuando una caja de texto cambia, es decir cuando intrduzcamos o restemos contenido.
        private void textBoxAll_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButton();
        }
    }
}
