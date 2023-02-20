
const deuda      = 2736;
const plazoPagos = 12;

const mes = deuda / plazoPagos;
const interesBase = 0.0406;

let mesTotal = 0;
let total = 0;

let interes = 0;
//console.log(interes,
// interesBase);
for (var i = 1; i <= plazoPagos; i++){
    interes += interesBase;
    console.log(`Interes del mes ${interes}`);
    mesTotal = mes + (mes*interes);
    total += mesTotal;
    console.log(`Total de mes ${i} : ${mesTotal}`);
    console.log('-----------------------------------');
}

console.log(`Total de pago: ${total}`);