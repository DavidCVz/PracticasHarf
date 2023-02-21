
/** ESTRUCTURA DE UN IF y ELSE */
let numero = 20;

if(numero >= 15){
    console.log('Numero mayor a 15');
}


let num = 401;

if (num % 2 == 0){
    console.log('El numero es par');
}else{
    console.log('El numero es impar');
}



/** ANOTACIONES */
let valor = '5';

// Cuando se usa doble igual, se evaluan los valores sin importar los tipos de datos
if(valor == 5){
    console.log('Valores similares');
}

// Las evaluaciones con 3 signos de igual se utilizan para casos mas estrictos
// donde se requiere que tanto los tipos de datos como los valores de una condicion sean los mismos
if(valor === 5){

}else{
    console.log("Valor similar pero tipos diferentes");
}



/** ALTERNATIVAS A IF ELSE */
// Obteniendo el dia del sistema
const fecha = new Date();
// 0 - Dom, 1 - Lunes, ..., 6 - Sabado
let diaActual = fecha.getDay();
console.log(diaActual); // Retorna un indice del dia actual

// Usando objetos
let diaSemana = {
    0: 'Domingo',
    1: 'Lunes',
    2: 'Martes',
    3: 'Miercoles',
    4: 'Jueves',
    5: 'Viernes',
    5: 'Sabado',
}
console.log(diaSemana[diaActual]);

// Usando Arreglos
let diaSemana2 = ['Domingo','Lunes','Martes','Miercoles','Jueves','Viernes','Sabado',]

console.log(diaSemana2[diaActual]);


