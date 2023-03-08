import {heroes} from "../data/heroes";
/**
 * 
 * @param {HTMLDivElement} element 
 */
export const promesasComponent = (element) => {

    //Muestra el nombre del heroe, es llamado en findHero
    const Mostrarheroe = (hero) => {
        element.innerHTML = hero.name;
    }

    //Muestra un mensaje de error si no se encuentra, es llamado en findHero
    const MostrarError = (error) => {
        element.innerHTML = `
            <h3>${error}</h3>
        `;
    }

    //Muestrar dos heroes
    const MostrarDosHeroes = (heroe1, heroe2) => {
        element.innerHTML = `
            <h3>${heroe1.name}</h3>
            <h3>${heroe2.name}</h3>
        `;
    }

    const id1 = '5d86371f2343e37870b91ef1';
    const id2 = '5d86371f25a058e5b1c8a65e';


    //! -- Promesas El .then se puede simplificar como: .then(Mostrarheroe); lo mismo aplica para catch
/*     findHero(id1)
        .then((hero) => Mostrarheroe(hero))
        .catch((error) => MostrarError(error)); */
    
    //! --- Forma 1 Ejemplo de estructura Promise Hell
/*     findHero(id1)
        .then((heroe1) => {
            findHero(id2)
                .then(heroe2 => {
                    MostrarDosHeroes(heroe1, heroe2);
                })
                .catch(error => MostrarError(error));
        })
        .catch((error) => MostrarError(error));*/

    //! --- Forma 2 Retorno de promesa
/*     let hero1;
    findHero(id1)
        .then(hero => {
            hero1 = hero;
            return findHero(id2);
        }).then(hero2 => {
            MostrarDosHeroes(hero1, hero2);
        })
        .catch(error => MostrarError(error)) */
    
    //! Cuando se ocupen promesas donde sus resultados dependan
    //! entre si, se recomienda ocupar las formas 1 y 2 anteriores
    Promise.all([
        findHero(id1),
        findHero(id2),
    ])
    .then(([hero1, hero2]) => MostrarDosHeroes(hero1, hero2))
    .catch((error) => MostrarError(error));
}

/**
 * 
 * @param {String} id
 * @returns {Promise}
 */
const findHero = (id) => {
    return new Promise((resolve, reject) => {
        const hero = heroes.find(hero => hero.id === id);

        if (hero) {
            resolve(hero);
            return;
        }

        reject(`Hero with id ${id} not found`);
    });
}

