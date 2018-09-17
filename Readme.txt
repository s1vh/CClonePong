AVISO: es necesario instalar las fuentes incluídas en el directorio root para la correcta visualización del texto.

INSTRUCCIONES:

Seleccione "human" o "clone" para cada jugador; "clone" es la IA y "human" mueve con las teclas "W", "S", o "O","L" dependiendo del lado de la pantalla. La partida dura hasta que un jugador alcanza 20 puntos. El botón inferior de la pantalla pausa y reanuda la partida. Pulsar ESC mientras la partida está pausada, reseteará el marcador; volverlo a pulsar cuando la partida no ha empezado cerrará la aplicación (ésto es necesario ya que he eliminado el formato de botones por defecto de la ventana de windows). Nótese que la tecla ESC está desactivada durante el transcurso del juego para evitar pulsaciones por error.

NOTAS:

El primer lanzamiento de la bola se hace en una dirección aleatoria. La bola gana velocidad con cada bote y se resetea al anotar punto. Sin embargo, la dirección del eje X se guarda en memoria para lograr que, a partir del primer lanzamiento aleatorio, la bola salga una vez en cada dirección.

La posición de las raquetas se resetea cuando termina el juego, pero NO tras cada punto. Como se ha reseteado la velocidad base de la pelota, siempre es posible alcanzarla en la primera ronda.

La IA es difícil de vencer, pero NO imbatible. Su algoritmo consiste en seguir la posición Y de la bola siempre que ésta se desplaze hacia su dirección, y en volver a mitad de velocidad hacia el centro cuando la bola se aleje (inicialmente siempre perseguía la posición Y de la bola, pero resultaba humanamente imposible vencerla). Como la velocidad de la bola siempre va en aumento, pero la de las palas están capadas, llega un momento en que la IA no tiene tiempo para alcanzarla y deja pasar la bola. Ésto puede comprobarse fácilmente haciendo jugar a un clon contra otro clon.