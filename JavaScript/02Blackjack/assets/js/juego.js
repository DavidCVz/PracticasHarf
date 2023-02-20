/** 
 *  2C = Two of Clubs
 *  2D = Two of Diamons
 *  2H = Two of Hearts
 *  2S = Two of Spades
*/

let deck = [];
const tipos = ['C', 'D', 'H', 'S'];
const reyes = ['K', 'Q', 'J', 'A']

let puntosJugador = 0;
let puntosComputadora = 0;

//Referencias HTML
const btnPedir = document.querySelector('#btnPedir');
const btnDetener = document.querySelector('#btnDetener');
const btnNuevoJuego = document.querySelector('#btnNuevoJuego');

const divCartasJugador = document.querySelector('#jugador-cartas');
const divCartasComputadora = document.querySelector('#computadora-cartas');

let puntajeSmall = document.querySelectorAll('small');

console.log(btnPedir);

// Se crea un un nuevo DECK
const crearDeck = () =>{
    for (let i = 2; i <= 10; i++) {
        for (let tipo of tipos) {
            deck.push(i + tipo);
        }
    }

    for (let tipo of tipos) {
        for (let rey of reyes) {
            deck.push(rey + tipo);
        }
    }
    //console.log(deck);
    return deck = _.shuffle(deck);
    //console.log(deck);
}

crearDeck();
// Funcion que pide carta
const pedirCarta = () => {
    let carta;
    //console.log(deck); // Maso inicial
    if (deck.length === 0){
        throw "Ya no quedan cartas en el maso";
    }else {
        carta = deck.pop();
    }
    return carta;
}

const valorCarta = (carta) =>{
    const valor = carta.substring(0, carta.length-1);
    return (isNaN(valor)) ? ((valor == 'A') ? 11 : 10) : valor * 1;
}

const turnoComputadora = (puntosMinimos) => {

    do {
        const carta = pedirCarta();
        puntosComputadora = puntosComputadora + valorCarta(carta);
    
        puntajeSmall[1].innerText = puntosComputadora;
        const imgCarta = document.createElement('img');
        imgCarta.src = `assets/cartas/${carta}.png`;
        imgCarta.classList.add('carta');
        divCartasComputadora.append(imgCarta);
        if(puntosMinimos > 21){
            break;
        }
    } while((puntosComputadora < puntosMinimos) && (puntosMinimos <= 21)); 

    setTimeout(() => {
        if (puntosComputadora === puntosMinimos) {
            alert('Juego empatado');
        }else if (puntosMinimos > 21){
            alert('Gana la computadora');
        }else if (puntosComputadora > 21){
            alert('Gana el jugador');
        }else{
            alert('Gana la computadora');
        }
    }, 10);
}

//EVENTOS
btnPedir.addEventListener('click', () => {
    const carta = pedirCarta();
    puntosJugador = puntosJugador + valorCarta(carta);

    puntajeSmall[0].innerText = puntosJugador;
    const imgCarta = document.createElement('img');
    imgCarta.src = `assets/cartas/${carta}.png`;
    imgCarta.classList.add('carta');
    divCartasJugador.append(imgCarta);

    if(puntosJugador > 21){
        console.warn('Partida perdida');
        btnPedir.disabled = true;
        btnDetener.disabled = true;
        turnoComputadora(puntosJugador);
    }else if (puntosJugador === 21){
        console.warn('Partida ganada');
        btnPedir.disabled = true;
        btnDetener.disabled = true;
        turnoComputadora(puntosJugador);
    }
});

btnDetener.addEventListener('click', () => {
    btnPedir.disabled = true;
    turnoComputadora(puntosJugador);
    btnDetener.disabled = true;
})

btnNuevoJuego.addEventListener('click', () => {
    //RESET
    //Deck de cartas
    deck = [];
    deck = crearDeck();

    //Puntajes
    puntosJugador = 0;
    puntosComputadora = 0;
    puntajeSmall[0].innerText = 0;
    puntajeSmall[1].innerText = 0;

    //Divs de cartas
    divCartasJugador.innerHTML = '';
    divCartasComputadora.innerHTML = '';
    
    //Botones
    btnPedir.disabled = false;
    btnDetener.disabled = false;

})