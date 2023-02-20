let games = ['COD', 'Battlefield', 'Apex', 'Rocket League'];

//OBTENER TAMAÑO
console.log('Tamaño de arreglo: ' + games.length);

//OBTENER PRIMER Y ULTIMO ELEMENTO
console.log('Primero: ' + games[0]);
console.log('Ultimo: ' + games[games.length - 1]);

//OBTENER TODOS LOS ELEMENTOS RECORRIENDO EL ARREGLO
games.forEach((elemento, indice, arreglo) => {
    console.log({elemento, indice, arreglo});
});

//AGREGAR ELEMENTO A LO ULTIMO
games.push('Metro Exodus');

console.log(games);
games.push('The Day Before');
console.log(games);

//REMOVER EL ULTIMO ELEMENTO,
games.pop();

console.log(games);

//AGREGAR UN NUEVO ELEMENTO AL INICIO
games.unshift('State of Decay');
console.log(games[0]);

//REMOVER UNA SERIE DE ELEMENTOS CONSECUTIVOS
let posicion = 1
let juegosRemovidos = games.splice(posicion, 2); //Borra dos elementos a partir de la posicion
console.log(games);

//OBTENER INDICE DE UN ELEMENTO
let apexIndex = games.indexOf('Apex');
console.log('Indice de Apex: ' + apexIndex);



