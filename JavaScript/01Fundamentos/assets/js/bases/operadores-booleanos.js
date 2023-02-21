//** OPERADORES Y LOGICA BOOLEANA */

// Booleanos
console.log(true);
console.log(false);

// Operador de negación
console.log(!true);

// Conjucion
console.log(true && true);

// Disyuncion
console.log(true || false);


// ==== Orden de validacion y ejecucion con operadores ==== //

//Devuelve TRUE
function devuelveTrue(){
    console.log('Devuelve TRUE');
    return true;
}

// Devuelve false
function devuelveFalse(){
    console.log('Devuelve FALSE');
    return false;
}

/** Como se esta utilizando la conjucion y el primer metodo devuelve false, todo lo 
    demas despues del && no se ejecuta */
console.log(devuelveFalse() && devuelveTrue());


/** Como se esta utilizando la disyuncion y el primer metodo devuelve true, todo lo 
    demas despues del || no se ejecuta */
console.log(devuelveTrue() || devuelveFalse());



/** ====== ASIGNACIONES ====== */

const xUndefined = undefined;
const xNull = null;
const xFalse = false;

/** Se evalua cada termino y dado que cada valor es verdadero o tiene un valor definido
 *  entonces se asigna el ultimo valor de la operacion
 */
const a1 = true && 'Textox' && 150;
console.log({a1});

// Por otra parte si una evaluacion es falsa entonces se asigna dicho termino
const a2 = false && 'Textox' && 150;
console.log({a2});

const a3 = 'Hola' && 'Mundo' && xFalse;
console.log({a3});

// De manera contraria, cuando se usa OR, si se encuentra un valor definido o un TRUE
// entonces se realizara la asignacion en esa posicion
const a4 = false || 'Texto N' || 'ASD';
console.log({a4});

// Aunque en la ultima evaluacion haya un true, si antes existe otro valor definido o un true,
// Se realizara la signacion en esa posicion
const a5 = xFalse || xNull || xUndefined || 'Mensaje X' || true;
console.log({a5})

