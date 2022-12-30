# Maquina Estado Finito
## Modifica el proyecto de Línea de Visión para hacer que el NPC se controle a través de una máquina de estados. Los estados son:

## Patrol: implementa el método "wander". Si el jugador entra en el campo de visión del agente pasa el estado "Chase".

Primero añadimos un nav mesh al mapa, algunos obstáculos y hacemos Bake, para controlar al robot le añadimos tambien un componente nav mesh agent.

Para crear la máquina de estados, creo un animation controller Añadiendo un estado Patrol y con un Behaviour Wander.
Desde aquí en OnStateEnter(), simplemente decido una ubicación aleatoria en el plano XZ del mapa y le digo al agente que vaya a ese destino.
En OnStateUpdate(), compruebo la distancia del agente hasta el punto seleccionado, si esta es menor que 3 elijo una nueva ubicación aleatoria.
Aparte calculo una distancia y un ángulo respecto al jugador, en caso de que se cumpla una visión de distancia y de ángulo mínima, cambio al estado Chase.

-> GIF de ejemplo de Patrol:
![gif](./GIF/patrol.gif)

## Chase: implementa "Seek" o "Pursue" para seguir al jugador. Si el jugador está dentro de la distancia de tiro pasa al estado "Attack". Si el jugador deja de estar en el campo de visión, pasa al estado "Patrol".

-> GIF de ejemplo de Chase:
![gif](./GIF/patrol.gif)

## Attack: dispara al jugador. Si la distancia con el jugador es superior a la distancia de tiro, pasa al estado "Chase". Si la vida del NPC está por debajo de una cantidad, pasa al estado "Hide".

-> GIF de ejemplo de Attack:
![gif](./GIF/patrol.gif)

## Hide: implementa el método "Hide" o "CleverHide" y regenera la vida del NPC. Si la vida está por encima de un valor, pasa al estado "Patrol".

-> GIF de ejemplo de Hide:
![gif](./GIF/patrol.gif)
