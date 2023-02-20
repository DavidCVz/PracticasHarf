// Define una función llamada "printChristmasTree"
function printChristmasTree() {
    // Utiliza un bucle "for" para iterar sobre los niveles del árbol
    for (let i = 1; i <= 5; i++) {
      // Crea una cadena vacía para almacenar la línea del árbol
      let line = "";
      // Utiliza otro bucle "for" para agregar espacios en blanco al inicio de la línea
      for (let j = 1; j <= 5 - i; j++) {
        line += " ";
      }
      // Utiliza otro bucle "for" para agregar asteriscos a la línea
      for (let j = 1; j <= (2 * i - 1); j++) {
        line += "*";
      }
      // Imprime la línea del árbol
      console.log(line);
    }
    // Imprime las tres líneas del tronco del árbol
    console.log("   *");
    console.log("   *");
    console.log("   *");
  }
  
  // Llama a la función "printChristmasTree" para imprimir el árbol
  printChristmasTree();

  // Genera un número aleatorio entre 0 y 1 utilizando la función "Math.random()"
let randomNumber = Math.random();

// Multiplica el número aleatorio por 90 para obtener un número entre 0 y 90
randomNumber *= 90;

// Utiliza la función "Math.floor()" para redondear el número aleatorio hacia abajo y obtener un entero
randomNumber = Math.floor(randomNumber);

// Añade 1 al número aleatorio para obtener un número entre 1 y 90
randomNumber += 1;

// Imprime el número aleatorio
console.log(randomNumber);