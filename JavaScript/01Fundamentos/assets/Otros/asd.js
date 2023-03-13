// Define the height of the tree
const height = 10;

// Loop through the rows of the tree
for (let i = 0; i < height; i++) {
  // Create an empty string for the current row
  let row = "";

  // Loop through the columns of the current row
  for (let j = 0; j < height - i; j++) {
    // Add spaces to the left side of the tree
    row += " ";
  }

  // Loop through the columns of the current row
  for (let j = 0; j <= i * 2; j++) {
    // Add a star to the tree
    row += "*";
  }

  // Print the current row to the console
  console.log(row);
}