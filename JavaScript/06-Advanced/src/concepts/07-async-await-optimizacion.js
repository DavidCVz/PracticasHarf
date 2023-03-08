/**
 * 
 * @param {HTMLDivElement} element 
 */
export const asyncAwaitOptComponent = async(element) => {
    console.time('Start');

    //! Si se ejecutara de esta manera, el metodo tendria que esperar
    //! a que todos las promesas finalicen tardando la suma de los tiempos de cada uno
    //const value1 = await slowPromise();
    //const value2 = await mediumPromise();
    //const value3 = await fastPromise();

    const [value1, value2, value3] = await Promise.all([
        slowPromise(),
        mediumPromise(),
        fastPromise(),
    ]);

    element.innerHTML = `
        value1: ${value1}<br/>
        value1: ${value2}<br/>
        value1: ${value3}<br/>
    `;

    console.timeEnd('Start');
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