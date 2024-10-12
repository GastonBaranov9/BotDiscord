<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# Demo de bots de Discord

Pequeña demo de un bot de Discord en C#.

Para probar el bot:

1. Clona este repo.

2. Crea un nuevo bot en Discord siguiendo [estas instrucciones](https://docs.discordnet.dev/guides/getting_started/first-bot.html); anota el token que te muestra la página.
3. Crea un archivo `secrets.json` en las siguientes ubicaciones dependiendo de 
   tu sistema operativo; si no existe alguna de las carpetas en la ruta 
   deberás crearla;`%APPDATA%` en Windows siempre existe, así como `~` 
   siempre existe en Linux/macOS-:

   - **Windows**: `%APPDATA%\\Microsoft\\UserSecrets\\PII_TelegramBot_Demo\\secrets.json`
   - **Linux/macOs**: `~/.microsoft/usersecrets/PII_TelegramBot_Demo/secrets.json`

4. Edita el archivo `secrets.json` para que contenga la configuración que 
   aparece a continuación, donde reemplazas `<token>` por el que te dio el 
   Discord:
    ```json
    {
    "DiscordToken": "<token>"
    }
    ```

> 🤔 ¿Porqué la complicamos?
>
> De esta forma vas a poder subir el código de tu bot a repositorios públicos de
> GitHub sin compartir el token de tu bot. No vas a tener que hacerlo ahora,
> pero si en algún momento quieres ejecutar tu bot en otro ambiente como un
> servidor de producción o en Azure, podrás configurar el token secreto en forma
> segura.

En esta pequeña demo de un bot de telegram en C#, el bot responde a los 
siguientes mensajes:

- `!name {id}`: Devuelve el nombre del Pokémon con ese id.
- `!userinfo [{username}]`, `!who[{username}]`, o `!whois[{username}]`: 
  Devuelve información sobre el usuario que envía el mensaje o sobre el que se
  indica.
- `!join`: Une el jugador a la lista de jugadores esperando para jugar.
- `!leave`: Remueve el jugador de la lista de jugadores esperando para jugar.

> [!IMPORTANT]
> Este bot está basado en [este tutorial](https://blog.adamstirtan.
> net/2023/10/create-discord-bot-in-c-and-net-part-1.html).