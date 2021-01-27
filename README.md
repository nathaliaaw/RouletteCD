# RouletteCD

Puertos
1.Creación ruleta  <br/>
[POST] http://localhost:{{port}}/api/roulette <br/>
2. Abrir apuesta <br/>
[PUT] http://localhost:{{port}}/api/roulette/{{IdRouleta}}/openRoulette <br/>
3. Realizar apuesta <br/>
[POST] http://localhost:{{port}}/api/roulette/{{IdRouleta}}/betValues <br/>
~~~
  BODY
  {
    "numberBet":2,  --Numero que se apuesta
    "moneyBet":1000, --Cantidad a apostar
    "colorBet":"R", -- R-Rojo, N-Negro
    "UserId":"Usuario"  --Nombre del usuario  
  }
  ~~~
4.Cerrar ruleta y conocer ganador <br/>
[PUT] http://localhost:{{port}}/api/roulette/{{IdRouleta}}/closeRoulette <br/>
5. Consultar todas las ruletas y apuestas realizadas <br/>
[GET] http://localhost:{{port}}/api/roulette <br/>
</br>
 Para usar Redis descargar el .zip https://github.com/MicrosoftArchive/redis/releases?after=win-2.8.2101 <br/>
 Luego descomprimir el .zip </br> 
 Luego ejecutar el redis-cli.exe </br>
 Luego ejecutar redis-server.exe </br>
 </br>
 Para limpiar el cache de la aplicacion usar la terminal redis-cli escribir --> flushhall
 </br>
 </br>
 
 
 
 
