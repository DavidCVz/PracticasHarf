
// DEVOLVIENDO OBJETO LITERAL
const crearPersona = (nombre, apellido) => {
    return {
        nombre: nombre,
        apellido: apellido,
    }
} 
console.log(crearPersona('David', 'Carrillo'));

/** PROTIP 1: Cuando el nombre de los argumentos coincide con el nombre
 * de las etiquetas de un objeto literal, se puede omitir dicha etiqueta
 * dejando solo el valor
 */
const crearPersonaPT = (nombre, apellido) => {
    return{
        nombre,
        apellido,
    }
}
console.log(crearPersonaPT('Katia', 'Carrillo'));


// IMPRIMIR ARGUMENTOS DE UNA FUNCION
// Funcion clasica que imprime los argumentos de una funcion
function argumentos(){
    console.log(arguments);
}
argumentos(10, true, 'Metricas', ['A', 'X', 'M']);


// PROTIP 2: Funcion de flecha para ver argumentos
/** Cuando se requiera ver los argumentos de una funcion de flecha
 *  se debe de agregar los ... (parametro rest) seguido de la palabra args
 *  Este indica que se debe de devolver todos los parametros ingresados
 */
const argumentos2 = (...args) => {
    console.log(args);
}
argumentos2(10, true, 'Metricas', ['A', 'X', 'M']);


/** PROTIP 3: Si se deseara extraer parametros individuales junto con la definicion rest
 *  se agrega el nombre del argumento que representa el parametro
 */
const argumentos3 = (edad, vivo, ...args) => {
    console.log({edad, vivo, args});
}
argumentos3(10, true, 'Metricas', ['A', 'X', 'M']);


/** PROTIP 4: Si se desea imprimir las propiedades de un objeto literal
 *  por medio de una funcion, entonces dichos nombres deberan de estar
 *  definidos en los argumentos de la funcion
*/
let lenovo = {
    nombre : 'Lenovo',
    activa : true,
    fundacion : 1984,
    industria : 'Electronica de consumo',
    fundador : 'Liu Chuanzhi',
}

// Para ser mostrados con los nombres de las propiedades en la consola se utilizan llaves
const imprimeMarca = ({nombre, activa, fundacion, industria, fundador}) => {
    console.log({nombre});
    console.log({activa});
    console.log({fundacion});
    console.log({industria});
    console.log({fundador});
}
imprimeMarca(lenovo);
