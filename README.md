Inicialización: El programa comienza en el método Main, donde se intenta ejecutar la prueba de la API de Pokémon dentro de un bloque try-catch. Si ocurre algún error durante la prueba, se imprime en la consola.

Prueba de la API de Pokémon: En el método TestPokemonApi, se define la URL base de la API de Pokémon y el endpoint que se quiere probar. Luego, se crea una instancia del WebDriver de Chrome y se crea una solicitud REST para el endpoint especificado. Esta solicitud se envía y se recibe una respuesta.

Creación de la solicitud REST: En el método CreateRequest, se crea una nueva solicitud REST con el endpoint y el método GET.

Envío de la solicitud REST: En el método SendRequest, se crea un nuevo cliente REST con la URL base y se envía la solicitud. La respuesta se devuelve para su posterior procesamiento.

Manejo de la respuesta: En el método HandleResponse, se verifica si la solicitud fue exitosa. Si lo fue, se deserializa la respuesta en un objeto dinámico y se imprimen los datos del Pokémon en la consola. Si la solicitud falló, se imprime el código de estado en la consola.

