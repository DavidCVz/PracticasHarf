
// ===== DEFINICION DE FUNCIONES =====

// Declaracion tradicional
function saludo() {
    console.log('Hello fellas');
}

// Declaracion con variable y funcion anonima
const msjDelDia = function(){
    console.log('Hello there');
}

saludo();
msjDelDia();


// ===== ARGUMENTOS =====

function persona(nombre){
    console.log('Nombre de la persona: ' + nombre);
}

persona('David');

function jugador(idPlayer){
    console.log(arguments); // Permite ver los argumentos entrantes
    console.log('Id del jugador: ' + idPlayer);   
}

jugador(172307);
jugador(1720, true, 'League', 'Mexico');



// ===== FUNCIONES LAMBDA O DE FLECHA =====

// Declaracion sin argumentos
const reproducir = () => {
    console.log('Reproduciendo musica...');
}

reproducir();

// Declaracion con argumentos
const reproducirCancion = ( nombreCancion ) =>{
    console.log('Reproduciendo: ' + nombreCancion + '...');
}

reproducirCancion('Worth Nothing');

// Declaracion con UN argumento simplificado
const agregarCancion = nombreCancion => {
    console.log(nombreCancion + ' agregada a la cola.');
}

agregarCancion('PYRO');

// Retorno en funciones
const suma = (num1, num2) => {
    let res = num1 + num2;
    return res;
}

console.log(suma(10,20));

// Retorno simplificado en funcion de flecha
const multip = (n1, n2) => n1 * n2;
console.log(multip(5,4));

const getAleatorio = () => Math.random();
console.log(getAleatorio());
