class MuestraSingleton{
    
    static instancia // Bandera que indicara una inicializada de la clase
    nombre = '';
    constructor(nombre = ''){
        
        if(!!MuestraSingleton.instancia){ // Si existe una instancia la devuelve, en ves de crear una nueva
            return MuestraSingleton.instancia;
        }   
        MuestraSingleton.instancia = this; // Si no, entonces se crea una nueva, la clausula "if" previene que se pueda
                                           // crear una segunda o mas instancias de esta misma clase
        this.nombre = nombre;
        return this;
    }

}

const instancia1 = new MuestraSingleton('NombreMuestra');
const instancia2 = new MuestraSingleton('NombreMuestra2');
const instancia3 = new MuestraSingleton('NombreMuestra3');

console.log(`Nombre en la instancia 1: ${instancia1.nombre}`);
console.log(`Nombre en la instancia 1: ${instancia2.nombre}`);
console.log(`Nombre en la instancia 1: ${instancia3.nombre}`);