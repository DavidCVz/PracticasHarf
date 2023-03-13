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

class Heroe extends Persona {
    clan = 'Sin clan';

    constructor(nombre, codigo, frase){
        super(nombre, codigo, frase);

    }

    identidad(){
        console.log(`Soy ${this.nombre}, del equipo ${this.clan}`);
        
        // Para llamar un metodo sobrescrito de la clase padre se usa super
        super.identidad();
    }
}

const david = new Heroe('David', 'Massive', 'Hold closer', 'Pescado empanizado');

const marcos = new Heroe();
console.log(david);
david.identidad();
