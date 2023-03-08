import {heroes} from "../data/heroes";
/**
 * 
 * @param {HTMLDivElement} element 
 */
export const callbackComponent = (element) => {
    const id = '5d86371f2343e37870b91ef1';
    findHero(id, (error, hero)=>{
        if (error) {
            element.innerHTML = error;
            return;
        }

        //element.innerHTML = hero?.name || 'No hay heroe';
        element.innerHTML = hero.name;
    });
}

/**
 * 
 * @param {String} id 
 * @param {(error: String|Null, hero: Object) => void} callback 
 */
const findHero = (id, callback) => {
    const hero = heroes.find(hero => hero.id === id);
    
    if (!hero) {
        callback(`Hero with ${id} not found`);
        return //Undefined
    }
    
    callback(null, hero);
}