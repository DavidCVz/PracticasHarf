// ===== DECLARACION DE OBJETOS LITERALES =====
let tecnologia = {
    marca : 'Lenovo',
    activa : true,
    fundacion : 1984,
    industria : 'Electronica de consumo',
    tiposDispositivos : {
        pc_tablets : ['Legion', 'Ideapad', 'Yoga'],
        smartphones : ['Motorola Edge 30 Neo', 'Moto G31', 'Moto G60'],
        smartDevices : 'ThinkSmart View',
        servidores: ['Servidores de bastidor', 'Servidores de torre', 'Servidores Edge', 'Servidores de misión crítica'],
    },
    ubicacion: {
        pais : 'China',
        ciudad : 'Pequin'
    },
    fundador : 'Liu Chuanzhi',
}

//ACCESO A OBJETOS LITERALES
console.log('Marca:',tecnologia.marca);
console.log('Fecha de fundacion:',tecnologia.fundacion);
console.log('Industria objetivo:',tecnologia['industria']);



console.log('Smartphones de la marca:');
for (let index = 0; index < tecnologia.tiposDispositivos.smartphones.length; index++) {
    console.log(tecnologia.tiposDispositivos.smartphones[index]);
}

// ===== OPERACIONES EN OBJETOS LITERALES =====

// Eliminación de propiedades
delete tecnologia.fundacion;
console.log('',tecnologia);

// Creacion de una nueva propiedad de un objeto
tecnologia.paises = ['China', 'EU', 'Mexico', 'Italia'];
console.log('',tecnologia);

// Ver las propiedades en pares de arreglos
const entriesPares = Object.entries(tecnologia);
console.log('',entriesPares);

// Hacer las propiedades de un objeto inmutables (Debe ser aplicado en cada nivel)
Object.freeze(tecnologia);

tecnologia.dinero = 1000000; // Intentando agregar propiedades
tecnologia.activa = false; // Intentando modificar propiedades

// Mas info. de objetos https://developer.mozilla.org/es/docs/Web/JavaScript/Reference/Global_Objects/Object