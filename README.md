# RouletteCD

Puertos
1.Creación ruleta  ~~~
[POST] http://localhost:{{port}}/api/roulette &nbsp;
2. Abrir apuesta
[PUT] http://localhost:{{port}}/api/roulette/{{IdRouleta}}/openRoulette
3. Realizar apuesta
[POST] http://localhost:{{port}}/api/roulette/{{IdRouleta}}/betValues
~~~
  BODY
  {
    "numberBet":2,  --Numero que se apuesta
    "moneyBet":1000, --Cantidad a apostar
    "colorBet":"R", -- R-Rojo, N-Negro
    "UserId":"Usuario"  --Nombre del usuario  
  }
  ~~~
4.Cerrar ruleta y conocer ganador
[PUT] http://localhost:{{port}}/api/roulette/{{IdRouleta}}/closeRoulette
5. Consultar todas las ruletas y apuestas realizadas
[GET] http://localhost:{{port}}/api/roulette
