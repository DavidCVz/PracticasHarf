class Persona{

    //Inicializando propiedades de clase
    nombre = '';
    codigo = '';
    frase  = '';
    comida = '';

    static _conteo = 0; // Atributos estaticos

    constructor(nombre, codigo, frase, comida){
        this.nombre = nombre;
        this.codigo = codigo;
        this.frase = frase;
        this.comida = comida;

        Persona._conteo++; // Acceso a atributo estatico en la clase
    }

    //SETS (No pueden tener el mismo nombre de la propiedad a tratar)
    set setComidaFavorita(comida){
        this.comida = comida.toUpperCase();
    }

    //GETS
    get getComidaFavorita(){
        return `La comida favorita de ${this.nombre} es ${this.comida}`;
    }

    static get getConteoInstancias(){
        return Persona._conteo + ' Instancias';
    }



    identidad(){
        console.log(`Soy ${this.nombre}, codigo: ${this.codigo}`);
    }

    mostrarIdentidad(){
        this.identidad();
    }
}

//Nueva instancia de clase
const david = new Persona('David', 'Massive', 'Hold closer');
// Acceso a atributos y metodos
david.identidad();

const marcos = new Persona('Marcos', 'Belmansin', 'Jig')
marcos.mostrarIdentidad();

david.setComidaFavorita = 'Filete empanizado';
console.log(david.getComidaFavorita);

// ACCESO A PROPIEDADES ESTATICAS
console.log('Conteo estatico:', Persona._conteo);
console.log('Conteo estatico con get:', Persona.getConteoInstancias);
