using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego_adivina__numero
{
    public partial class Form1 : Form
    {
        // Declaramos las variables que vamos a utilizar
        private int numeroSecreto;  // Variable para guardar el número secreto que el jugador debe adivinar
        private int intentos;       // Variable para contar la cantidad de intentos realizados
        private Random aleatorio;   // Instancia de la clase Random para generar números aleatorios

        // Constructor de la clase Form1, se ejecuta al iniciar la aplicación
        public Form1()
        {
            InitializeComponent();    // Inicializa los componentes del formulario (interfaz gráfica)
            aleatorio = new Random(); // Crea un nuevo generador de números aleatorios
            IniciarJuego();           // Llama al método que inicia el juego
        }

        // Método para iniciar el juego (se ejecuta cada vez que se reinicia el juego)
        private void IniciarJuego()
        {
            CajaTexto.Enabled = true;  // Habilita la caja de texto para que el jugador pueda ingresar un número
            button1.Enabled = true;    // Habilita el botón para hacer la adivinanza
            Lista_Intentos.Items.Clear();  // Limpia la lista de intentos previos
            CajaTexto.Clear();            // Limpia la caja de texto
            numeroSecreto = aleatorio.Next(1, 101); // Genera un número aleatorio entre 1 y 100 (ambos incluidos)
            intentos = 0; // Resetea el contador de intentos a 0
            Nro_Intentos.Text = "Intentos: 0"; // Muestra en el label la cantidad de intentos realizados (inicia en 0)
        }

        // Este método se ejecuta cuando el jugador hace clic en el botón de adivinar
        private void button1_Click(object sender, EventArgs e)
        {
            // Intentamos convertir el texto ingresado a un número entero
            if (int.TryParse(CajaTexto.Text, out int numeroIngresado))
            {
                // Aumentamos el contador de intentos
                intentos++;

                // Actualizamos el label para mostrar el número actual de intentos
                Nro_Intentos.Text = "Intentos: " + intentos;

                // Añadimos el número ingresado a la lista de intentos
                Lista_Intentos.Items.Add(numeroIngresado);

                // Verificamos si el número ingresado es el número secreto
                if (numeroIngresado == numeroSecreto)
                {
                    // Si el jugador adivinó correctamente, mostramos un mensaje de felicitación
                    MessageBox.Show("¡Felicidades! Adivinaste el número secreto en " + intentos + " intentos.");
                    CajaTexto.Enabled = false; // Deshabilita la caja de texto para evitar más intentos
                    button1.Enabled = false;   // Deshabilita el botón de adivinar
                }
                else if (numeroIngresado < numeroSecreto)
                {
                    // Si el número ingresado es menor que el número secreto, mostramos un mensaje
                    MessageBox.Show("El número secreto es mayor.");
                }

                else if (numeroIngresado > 100)
                {
                    MessageBox.Show("El numero ingresado es mayor que 100, ingrese un numero valido");
                }

                else
                {
                    // Si el número ingresado es mayor que el número secreto, mostramos otro mensaje
                    MessageBox.Show("El número secreto es menor.");
                }

                // Limpiamos la caja de texto para el siguiente intento
                CajaTexto.Clear();

                // Volvemos a poner el foco en la caja de texto
                CajaTexto.Focus();
            }
            else
            {
                // Si el texto ingresado no es un número válido, mostramos un mensaje de error
                MessageBox.Show("Por favor, ingresa un número válido.");




            }
        }

        // Este método se ejecuta cuando el jugador hace clic en el botón "Nuevo Juego"
        private void NuevoJuego_Click(object sender, EventArgs e)
        {
            // Llama al método IniciarJuego para reiniciar el juego con un nuevo número secreto
            IniciarJuego();
        }

        // Este método está vacío y no se utiliza, es probable que sea un evento no implementado
        private void Nro_Intentos_Click(object sender, EventArgs e)
        {

        }
    }
}
