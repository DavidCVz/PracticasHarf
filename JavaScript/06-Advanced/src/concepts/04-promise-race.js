import {heroes} from "../data/heroes";


/**
 * 
 * @param {HTMLDivElement} element 
 */
export const promiseRaceComponent = (element) => {
    
    element.innerHTML = 'Cargando...';

    const mostrarValor = (value) => {
        element.innerHTML = value;
    }

    Promise.race([
        slowPromise(),
        mediumPromise(),
        fastPromise(),
    ]).then((mensaje) => mostrarValor(mensaje));
}

const slowPromise = () => new Promise(resolve => {
    setTimeout(() => {
            resolve('Slow Promise')
        }, 2000);
})

const mediumPromise = () => new Promise(resolve => {
    setTimeout(() => {
            resolve('Medium Promise')
        }, 1500);
})

const fastPromise = () => new Promise(resolve => {
    setTimeout(() => {
            resolve('Fast Promise')
        }, 1000);
})