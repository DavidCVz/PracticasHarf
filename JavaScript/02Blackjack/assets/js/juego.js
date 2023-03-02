/** 
 *  2C = Two of Clubs
 *  2D = Two of Diamons
 *  2H = Two of Hearts
 *  2S = Two of Spades
*/
const miModulo = (() => {
    'use strict';

    let deck = [];
    const tipos = ['C', 'D', 'H', 'S'],
          reyes = ['K', 'Q', 'J', 'A'];
    
    let puntosJugadores = [];
    
    //Referencias HTML
    const btnPedir = document.querySelector('#btnPedir');
    const btnDetener = document.querySelector('#btnDetener');
    const btnNuevoJuego = document.querySelector('#btnNuevoJuego');
    
    const divCartasJugadores = document.querySelectorAll('.divCartas');
    const puntajeHTML = document.querySelectorAll('small');

    //Inicializaciones
    btnDetener.disabled = true;
    btnPedir.disabled = true;  
    
        
    // Se crea un un nuevo DECK
    const crearDeck = () =>{
        deck = [];
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
        return _.shuffle(deck);
    }

    const inicializarJuego = (numJugadores = 2) => {
        deck = crearDeck();
        puntosJugadores = [];
        for (let i = 0; i < numJugadores; i++) {
            puntosJugadores.push(0);
        }

        //Puntaje en vista
        puntajeHTML.forEach(elem => elem.innerText = 0);
    
        //Divs de cartas
        divCartasJugadores.forEach(elem => elem.innerHTML = '');
        
        //Botones
        btnPedir.disabled = false;
        btnDetener.disabled = false;
        btnNuevoJuego.disabled = true;
    }
    
    crearDeck();
    // Funcion que pide carta
    const pedirCarta = () => {
        //console.log(deck); // Maso inicial
        if (deck.length === 0){
            throw "Ya no quedan cartas en el maso";
        }else {
            return deck.pop();
        }
    }
    
    const valorCarta = (carta) =>{
        const valor = carta.substring(0, carta.length-1);
        return (isNaN(valor)) ? ((valor == 'A') ? 11 : 10) : valor * 1;
    }
    
    const acumularPuntos = (carta, turno) => {
        puntosJugadores[turno] = puntosJugadores[turno] + valorCarta(carta);
        console.log({turno});
        puntajeHTML[turno].innerText = puntosJugadores[turno];
        return puntosJugadores[turno];
    }

    const crearCarta = (carta, turno) => {
        const imgCarta = document.createElement('img');
        imgCarta.src = `assets/cartas/${carta}.png`;
        imgCarta.classList.add('carta');
        divCartasJugadores[turno].append(imgCarta);
    }

    const turnoComputadora = (puntosMinimos) => {
        const turnoComputadora = puntosJugadores.length - 1;
        do {
            const carta = pedirCarta();

            acumularPuntos(carta, turnoComputadora);
            crearCarta(carta, turnoComputadora);
            console.log('Puntos de computadora:' + puntosJugadores[turnoComputadora]);
            if(puntosMinimos > 21){
                break;
            }
        } while((puntosJugadores[turnoComputadora] < puntosMinimos) && (puntosMinimos <= 21)); 
    
        setTimeout(() => {
            if (puntosJugadores[turnoComputadora] === puntosMinimos) {
                alert('Juego empatado');
            }else if (puntosMinimos > 21){
                alert('Gana la computadora');
            }else if (puntosJugadores[turnoComputadora] > 21){
                alert('Gana el jugador');
            }else if (puntosJugadores[turnoComputadora] < puntosMinimos){
                alert('Gana el jugador');
            }else{
                alert('Gana la computadora');
            }
            btnNuevoJuego.disabled = false;
        }, 10);
    }
    
    //EVENTOS
    btnPedir.addEventListener('click', () => {
        const carta = pedirCarta();
        const puntosJugador = acumularPuntos(carta, 0);

        crearCarta(carta, 0);

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
        turnoComputadora(puntosJugadores[0]);
        btnDetener.disabled = true;
    })
    
    btnNuevoJuego.addEventListener('click', () => {
        //RESET
        inicializarJuego();
    })

    return {
        JuegoNuevo : inicializarJuego,
    };
})();

// Algo
