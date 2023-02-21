
/*
    DECLARACION DE VARIABLES
    - Palabras reservadas
     var: Usado para declarar variables en versiones anteriores
     let: Usado para declarar variables es nuevas versiones (ES5 en adelante)
*/
let a = 10, 
    b = 20, 
    c = 'Hola ', 
    d = 'Mundo', 
    x = a + b;

//Concatenacion de strings
const saludo = c + d;
/*
    CONSOLA
*/
console.warn(x);
console.error(x);
console.info(x);

//Muestra un texto personalizado con css en la consola
console.log("%c Mis variables", "color: pink; font-weight: bold;"); 
console.log({a});


//Mostrar una tabla con valores de variables
console.table([a, b, c, d, x]);


