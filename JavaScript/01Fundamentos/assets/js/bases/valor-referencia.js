
// ASIGNACION DE VALORES A TIPOS PRIMITIVOS
/** En los tipos de datos primitivos las asignaciones de valores 
 *  que toman como referencia a otros "b = a" permiten mantener un espacio
 *  en la memoria de manera independiente para este caso:
 *  - "a" se ubica en un espacio de memoria
 *  - "b" toma un valor a partir de "a" pero se ubica en otro espacio de memoria
 *  Por lo tanto si se realizan cambios sobre alguno de estos, los demas no se
 *  veran afectados
*/
let a = 10;
let b = a;
a = 30
console.log({a, b});


// REFERENCIA DE VALORES EN OBJETOS
/** Dentro de los objetos, cuando a un objeto "sam" se le asigna un valor de otro "david"
 *  los valores y/o propieades se compartiran debido a la propiedad de referencia en
 *  JavaScript, por lo que al intentar cambiar un valor, estas compartiran la misma
 *  localidad de memoria.
 */
let david = {nombre: "David"};
let sam = david;
sam.nombre = 'Sam';
console.log({sam, david});


// RUPTURA DE REFERENCIA CASO 1
/** Cuando se necesite asignar un valor a algun objeto a partir de otro donde se quiera que cada uno se ubique
 *  en un espacio de memoria independiente, la asignacion debe de estar encerrada entre llaves {} y con el
 *  operador spread "..." para indicar la separacion de los elementos en memoria.
 */
let juan = {nombre: "Juan"};
let ana = {...juan}; //Ruptura por medio del operador Spread
ana.nombre = 'Ana';
console.log({juan, ana});

// RUPTURA DE REFERENCIA CASO 2
/** Cuando se tenga que realizar la ruptura de referencia de objetos en alguna funcion, el argumento que
 *  hace referencia al objeto debe de ir encerrado entre llaves {} y contener el operador spread "..."
 *  antes de la definicion del argumento.
*/
const cambiarPuesto = ({...persona}) => {
    persona.puesto = 'Invitado';
    return persona;
}

let ami = {puesto: "Analista"};
let rod = cambiarPuesto(ami);
console.log({ami, rod});



// RUPTURA DE REFERENCIA EN ARREGLOS
/** En los arreglos a comparacion de otros objetos, la ruptura de la referencia en un objeto
 *  se deben de encerradar entre corchetes junto con el operador spread
 */
let frutas = ['Manzana', 'Pera', 'Uvas'];
//let otrasFrutas = frutas.slice();
let otrasFrutas = [...frutas];
otrasFrutas.push('Mango');
console.table({frutas, otrasFrutas});

// Otra manera de realizar la ruptura es utilizar el metodo .slice de un arreglo
// - let otrasFrutas = frutas.slice();





