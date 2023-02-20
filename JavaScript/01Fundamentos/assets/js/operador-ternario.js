
/** EJEMPLO CON EJERCICIO */

/** Un restaurante abre entre semana a las 9 am y los fines de semana a las 11 am 
 *  Si un usario ingresa el dia y hora actual se debera de devolver si esta abierto o cerrado.
*/
const horaActual = 10;
const diaActual = 1;

let horaApertura;
let mensaje;

// ======== USANDO IF ELSE ============== //

// if ([0,6].includes(diaActual)) {
//     horaApertura = 11;
// } else {
//     horaApertura = 9;
// }

// if (horaActual >= horaApertura) {
//     mensaje = `El dia ${diaActual} a las ${horaActual}, se encuentra abierto el restaurante`;
// } else {
//     mensaje = `El dia ${diaActual} a las ${horaActual}, no se encuentra abierto el restaurante`;
// }


// =================== USANDO OPERADOR TERNARIO ===================== //

horaApertura = ([0,6].includes(diaActual)) ? 11 : 9;
mensaje = (horaActual >= horaApertura) ? `El dia ${diaActual} a las ${horaActual}, se encuentra abierto el restaurante` : `El dia ${diaActual} a las ${horaActual}, no se encuentra abierto el restaurante`;

console.log(mensaje);



/** ====================== OTRAS FUNCIONES ============================= */

// Uso en funciones simplificadas

// Retorna el valor en base a la evaluacion
const evaluarMayor = (a, b) => (a > b) ? a : b;
console.log(evaluarMayor(100,15))

const tieneMembresia = (membresia) => (membresia) ? '5 Dolares' : '10 Dolares';
console.log(tieneMembresia(true));

// En asignaciones dentro de arreglos
const amigo = true;
personajes = [
    'Huguie',
    'L.M.',
    'Annie',
    amigo ? 'Butcher' : 'Homelander'
]

console.log({personajes});

// Anidar operadores ternarios

// Convirtiendo las calificaciones numericas a notacion norteamericana (A+, A, B+, B, C+, C ).

const calificacion = 87;

nota = calificacion >= 95 ? 'A+' :
       calificacion >= 90 ? 'A'  :
       calificacion >= 85 ? 'B+' :
       calificacion >= 80 ? 'B'  :
       calificacion >= 75 ? 'C+' :
       calificacion >= 70 ? 'C'  : "F";

console.log(nota);
