using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using static ListadoAlumnos.Persona;

namespace ListadoAlumnos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Alumno> Alumnos;
        List<Alumno> AlumnosAT;
        List<Alumno> AlumnosVO;
        List<Alumno> AlumnosFU;

        Alumno alumno;

        public MainWindow()
        {
            InitializeComponent();

            Alumnos = new List<Alumno>();
            AlumnosAT = new List<Alumno>();
            AlumnosVO = new List<Alumno>();
            AlumnosFU = new List<Alumno>();

            buttonEnviar.IsEnabled = false;
            brnAgregar.IsEnabled = false;

        }


        private void ButtonEnviar_Click(object sender, RoutedEventArgs e)
        {
            var curso = (Curso)Enum.Parse(typeof(Curso), cboCurso.Text);

            try
            {
                alumno = new Alumno(Convert.ToInt32(txbId.Text), txbNombre.Text, txbApellido.Text, curso);

                Alumnos.Add(alumno);

                //lbxLista.ItemsSource = Alumnos;
                lbxLista.Items.Add(alumno);

                brnAgregar.IsEnabled = true;
            }
            catch (Exception x)
            {
                _ = x.ToString();
            }
            
        }

        private void TxbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            var habilitar = !string.IsNullOrEmpty(txbNombre.Text) && !string.IsNullOrEmpty(txbApellido.Text) && !string.IsNullOrEmpty(txbId.Text) && !string.IsNullOrEmpty(cboCurso.Text);

            buttonEnviar.IsEnabled = habilitar;
        }

        private void BrnAgregar_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarLista(Alumnos, AlumnosAT, AlumnosVO, AlumnosFU);

            try
            {
                HelperDeArchivos.CargarArchivo("Atletismo.csv", AlumnosAT);
                HelperDeArchivos.CargarArchivo("Voley.csv", AlumnosVO);
                HelperDeArchivos.CargarArchivo("Futbol.csv", AlumnosFU);

                MessageBox.Show("Archivos Cargados con exito!!!");
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public static void SeleccionarLista(List<Alumno> listaCompleta, List<Alumno> LAT, List<Alumno> LVO, List<Alumno> LFU)
        {
            foreach (var alum in listaCompleta)
            {
                switch (alum.Curso)
                {
                    case Curso.Atletismo:
                        LAT.Add(alum);
                        break;
                    case Curso.Voley:
                        LVO.Add(alum);
                        break;
                    case Curso.Futbol:
                        LFU.Add(alum);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
