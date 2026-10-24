namespace Proyecto_1_Joxan_Vivas_Porras 
{
    public partial class Form1 : Form 
    {
        //variables globales
        float num1 = 0, num2 = 0, resultado = 0; // Variables para almacenar los números aleatorios y el resultado de la operación
        int op1 = 0, limite = 11; // Variables para el selector de operador aleatorio y el límite numérico
        char operador = ' '; // Carácter para almacenar el símbolo del operador matemático
        string dificultad = "", turno = ""; // Cadenas de texto para la dificultad actual y el turno del jugador
        Boolean jugador = false, bandera = true; // Banderas booleanas para controlar el turno y estados
        int[,] puntuaciones = new int[2, 3]; // Matriz para llevar el control de aciertos, errores y puntos de ambos jugadores

        float caso_inv = 0; // Variable auxiliar para procesar la entrada de texto del resultado
        public Form1() 
        {
            InitializeComponent(); 
        }

        private void SeleccionOperacion() // Método encargado de generar una nueva operación matemática
        {
            num1 = Random.Shared.Next(1, limite); // Genera un número aleatorio para num1 basado en el límite
            num2 = Random.Shared.Next(1, limite); // Genera un número aleatorio para num2 basado en el límite
            op1 = Random.Shared.Next(1, 5); // Genera un número aleatorio del 1 al 4 para elegir el operador
            switch (op1) // Estructura switch para determinar qué tipo de operación se realizará
            {
                case 1: // Caso 1: Suma
                    operador = '+'; // Asigna el símbolo de suma
                    resultado = num1 + num2; // Calcula el resultado de la suma
                    break; 
                case 2: // Caso 2: Resta
                    operador = '-'; // Asigna el símbolo de resta
                    resultado = num1 - num2; // Calcula el resultado de la resta
                    break; 
                case 3: // Caso 3: Multiplicación
                    operador = '*'; // Asigna el símbolo de multiplicación
                    resultado = num1 * num2; // Calcula el resultado de la multiplicación
                    break; 
                case 4: // Caso 4: División
                    operador = '/'; // Asigna el símbolo de división
                    resultado = num1 / num2; // Calcula el resultado de la división
                    break; 

                default: // Caso por defecto si ocurre un valor no esperado
                    MessageBox.Show("Operador invalido"); // Muestra un mensaje de error
                    break; 
            }

            n1.Text = num1.ToString(); // Muestra el primer número en la etiqueta n1
            n2.Text = num2.ToString(); // Muestra el segundo número en la etiqueta n2
            op.Text = operador.ToString(); // Muestra el símbolo del operador en la etiqueta op
        }

        private void Form1_Load(object sender, EventArgs e) // Evento que se ejecuta al cargar la ventana
        {
            SeleccionOperacion(); // llama al metodo SeleccionOperacion() que genera operaciones aleatoreas cada que se ejecuta la pagina
        }

        private void condicionesjuego(int jug) // Método para evaluar los cambios de nivel y las condiciones de derrota, recibe solo un valor, jug, que puede ser 1 o 0, (jugador 2 y 1 respectivamente)
        {
            if (puntuaciones[jug, 0] >= 5) // Si el jugador acumula 5 o más aciertos
            {
                limite = 51; // Incrementa el límite de los números aleatorios a 50
                dificultad = "Medio"; // Cambia el texto de dificultad a Medio
                lnivel.Text = dificultad; // Muestra la dificultad 
            }

            if (puntuaciones[jug, 0] >= 10) // Si el jugador acumula 10 o más aciertos
            {
                limite = 101; // Incrementa el límite de los números aleatorios a 100
                dificultad = "Dificil"; // Cambia el texto de dificultad a Difícil
                lnivel.Text = dificultad; // Muestra la dificultad 
            }

            if (puntuaciones[jug, 1] == 3) // Si el jugador acumula 3 errores (fin del juego)
            {
                MessageBox.Show("Fin del juego"); // Muestra el mensaje de fin de partida

                if (rdos.Checked) // evalua si esta activado el modo de 2 jugadores
                {
                    if (jug == 0) // Si el que perdió fue el Jugador 1
                    {
                        MessageBox.Show("Gana el jugador 2"); // Anuncia la victoria del Jugador 2
                        reinciarcontador(0); // Reinicia los contadores del jugador 1
                        reinciarcontador(1); // Reinicia los contadores del jugador 2
                    }
                    else if (jug == 1) // Si el que perdió fue el Jugador 2
                    {
                        MessageBox.Show("Gana el jugador 1"); // Anuncia la victoria del Jugador 1
                        reinciarcontador(0); // Reinicia los contadores del jugador 1
                        reinciarcontador(1); // Reinicia los contadores del jugador 2
                    }
                }

                puntuaciones[jug, 0] = 0; // Restablece los aciertos en la matriz
                puntuaciones[jug, 1] = 0; // Restablece los errores en la matriz
                puntuaciones[jug, 2] = 0; // Restablece los puntos en la matriz

                limite = 11; // Restablece el límite aleatorio a 11
                dificultad = "Facil"; // Restablece la dificultad a Fácil
                lnivel.Text = dificultad; // Actualiza el nivel en la interfaz


                if (jug == 0) //evalua si el jugador que perdio fue el uno,mediante la variable jug
                {

                    laciertos1.Text = "0"; // Limpia la etiqueta de aciertos del jugador 1
                    lerrores1.Text = "0"; // Limpia la etiqueta de errores del jugador 1
                    lpuntos1.Text = "0"; // Limpia la etiqueta de puntos del jugador 1
                }

                else if (jug == 1) //evalua si el jugador que perdio fue el dos,mediante la variable jug
                {
                    puntuaciones[jug, 0] = 0; // Limpia aciertos en la matriz
                    puntuaciones[jug, 1] = 0; // Limpia errores en la matriz 
                    puntuaciones[jug, 2] = 0; // Limpia puntos en la matriz

                    laciertos2.Text = "0"; // Limpia la etiqueta de aciertos del jugador 2
                    lerrores2.Text = "0"; // Limpia la etiqueta de errores del jugador 2
                    lpuntos2.Text = "0"; // Limpia la etiqueta de puntos del jugador 2
                }

                runo.Enabled = true; // Reactiva el radio button de un jugador para nueva partida
                rdos.Enabled = true; // Reactiva el radio button de dos jugadores para nueva partida

            }

        }
        private void unjugador(Boolean jugcontrario, int filajug) // Método para validar la respuesta ingresada por el usuario, ingresa el boolean del jugador contrario (false = jug 1, true = jug2) y su posicion, 1 o 0
        {

            if (float.TryParse(tresultado.Text, out caso_inv) && caso_inv.Equals(resultado)) // Comprueba si es un número válido y si coincide con el resultado exacto, si puede ranformarlo a flotante, se guarda en caso_inv
            {
                MessageBox.Show("Su respuesta es correcta!!"); // Muestra mensaje de acierto
                SeleccionOperacion(); // Genera la siguiente operación

                if (filajug == 0) //Evalua Si el turno corresponde al Jugador 1 
                {
                    puntuaciones[filajug, 0] += 1; // Suma 1 a los aciertos del jugador 1
                    puntuaciones[filajug, 2] += 5; // Suma 5 puntos al jugador 1

                    lpuntos1.Text = puntuaciones[filajug, 2].ToString(); // Actualiza los puntos en la interfaz del jugador 1
                    laciertos1.Text = puntuaciones[filajug, 0].ToString(); // Actualiza los aciertos en la interfaz del jugador 1
                }
                else if (filajug == 1) // Si el turno corresponde al Jugador 2
                {
                    puntuaciones[filajug, 0] += 1; // Suma 1 a los aciertos del jugador 2
                    puntuaciones[filajug, 2] += 5; // Suma 5 puntos al jugador 2

                    lpuntos2.Text = puntuaciones[filajug, 2].ToString(); // Actualiza los puntos en la interfaz del jugador 2
                    laciertos2.Text = puntuaciones[filajug, 0].ToString(); // Actualiza los aciertos en la interfaz del jugador 2
                }

                if (rdos.Checked) // Si está activo el modo de dos jugadores
                {
                    jugador = jugcontrario; // Cambia la bandera de turno al jugador contrario, esto para poder pasar de turno entre jugadores
                }
            }
            else // Si la respuesta ingresada es incorrecta
            {
                MessageBox.Show($"Incorrecto :(...La respuesta correcta es {resultado}"); // Muestra mensaje de error y la respuesta correcta, almacenada en resultado
                SeleccionOperacion(); // Genera la siguiente operación

                if (filajug == 0) // Si el fallo fue del Jugador 1
                {
                    puntuaciones[filajug, 1] += 1; // Suma 1 a los errores del jugador 1

                    lerrores1.Text = puntuaciones[filajug, 1].ToString(); // Actualiza los errores en la interfaz del jugador 1
                }
                else if (filajug == 1) // Si el fallo fue del Jugador 2
                {
                    puntuaciones[filajug, 1] += 1; // Suma 1 a los errores del jugador 2
                    lerrores2.Text = puntuaciones[filajug, 1].ToString(); // Actualiza los errores en la interfaz del jugador 2
                }

                if (rdos.Checked) //Evalua Si está activo el modo de dos jugadores
                {
                    jugador = jugcontrario; // Cambia la bandera de turno al jugador contrario
                }
            }

            condicionesjuego(filajug); // Evalúa si se cumplen condiciones de nivel o fin de juego,llamando al metodo Condiciones y asignandole fila jug, que es el numero de jugador
        }

        private void reinciarcontador(int coljug) // Método para reiniciar los contadores de un jugador específico
        {
            puntuaciones[coljug, 0] = 0; // Restablece aciertos a 0 en la matriz
            puntuaciones[coljug, 1] = 0; // Restablece errores a 0 en la matriz
            puntuaciones[coljug, 2] = 0; // Restablece puntos a 0 en la matriz

            if (coljug == 0) //Evalua Si se limpia al Jugador 1, ya que es 0
            {
                laciertos1.Text = puntuaciones[coljug, 0].ToString(); // Limpia etiqueta de aciertos del jugador 1
                lerrores1.Text = puntuaciones[coljug, 1].ToString(); // Limpia etiqueta de errores del jugador 1
                lpuntos1.Text = puntuaciones[coljug, 2].ToString(); // Limpia etiqueta de puntos del jugador 1
            }
            else if (coljug == 1) //Evalua Si se limpia al Jugador 2, ya que es 1
            {
                laciertos2.Text = puntuaciones[coljug, 0].ToString(); // Limpia etiqueta de aciertos del jugador 2
                lerrores2.Text = puntuaciones[coljug, 1].ToString(); // Limpia etiqueta de errores del jugador 2
                lpuntos2.Text = puntuaciones[coljug, 2].ToString(); // Limpia etiqueta de puntos del jugador 2
            }
        }

        private void multijugador() // Método para controlar la secuencia de turnos en modo multijugador
        {
            if (string.IsNullOrEmpty(turno)) // Si la variable turno está vacía (comienzo de partida)
            {
                jugador = false; // Define que inicia el jugador 1
                limite = 11; // Restablece el límite inicial
                reinciarcontador(0); // Reinicia datos del jugador 1
                reinciarcontador(1); // Reinicia datos del jugador 2
            }
            if (jugador == false) // Si es el turno del jugador 1
            {
                turno = "jugador 2"; // Define el texto del turno, dice jugador 2, por temas visuales.. en la aplicacion se entiende mejor.
                ljugadores.Text = turno.ToString(); // Muestra el turno en la interfaz
                unjugador(true, 0); // Llama a la validación para el jugador 1
            }
            else if (jugador == true) // Si es el turno del jugador 2
            {
                turno = "jugador 1"; // Define el texto del turno, pasa lo mismo que en el caso anterior
                ljugadores.Text = turno.ToString(); // Muestra el turno en la interfaz
                unjugador(false, 1); // Llama a la validación para el jugador 2
            }
        }

        private void radiobutton() // Método que verifica cuál cantidad de jugadores fue seleccionada
        {
            if (runo.Checked) // Si se seleccionó el modo de un jugador
            {
                ljugadores.Text = "Jugador 1"; // Establece el texto fijo del jugador 1
                jugador = false; // Asigna false a la bandera de jugador
                runo.Enabled = false; // Bloquea el radio button de 1 jugador para proteger la partida de bugs
                rdos.Enabled = false; // Bloquea el radio button de 2 jugadores para proteger la partida y evitar bugs
                unjugador(true, 0); // Ejecuta el flujo para un jugador
            }
            else if (rdos.Checked) // Si se seleccionó el modo de dos jugadores
            {
                runo.Enabled = false; // Bloquea el radio button de 1 jugador para proteger la partidade bugs
                rdos.Enabled = false; // Bloquea el radio button de 2 jugadores para proteger la partida de bugs
                multijugador(); // Ejecuta el flujo para multijugador
            }
            else // Si no se seleccionó ninguna opción
            {
                MessageBox.Show("Seleccione la cantidad de jugadores."); // Muestra aviso para que elijan un modo, si no, no podran continuar
            }
        }

        private void baceptar_Click(object sender, EventArgs e) // Metodo automatico del boton aceptar
        {
            radiobutton(); // Ejecuta la validación según el radio button seleccionado
        }

        private void ReiniciarOp_Click(object sender, EventArgs e) //metodo automatico del boton reiniciar
        {
            SeleccionOperacion(); // Genera una nueva operación sin alterar los puntajes, creo que hace el juego mas dinamico
        }
    }
}
