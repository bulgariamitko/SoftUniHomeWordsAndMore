function xRemove(input) {
    var matrix = [];
    var output = "";

    for (var mrow = 0; mrow < input.length; mrow++) {
        matrix[mrow] = [];
        for (var mcol = 0; mcol < input[mrow].length; mcol++) {
            matrix[mrow][mcol] = input[mrow][mcol];
        }
    }

    for (var row = 0; row < input.length - 2; row++) {
        for (var col = 0; col < input[row].length; col++) {
            if (input[row][col] !== undefined && 
                    input[row][col+2] !== undefined &&
                    input[row+1][col+1] !== undefined &&
                    input[row+2][col] !== undefined &&
                    input[row+2][col+2] !== undefined) {
                var charIt = input[row][col].toLowerCase();
                var charIt2 = input[row][col+2].toLowerCase();
                var charIt3 = input[row+1][col+1].toLowerCase();
                var charIt4 = input[row+2][col].toLowerCase();
                var charIt5 = input[row+2][col+2].toLowerCase();
                if (charIt === charIt2 && charIt === charIt3 && charIt === charIt4 && charIt === charIt5) {
                    matrix[row][col] = "remove";
                    matrix[row][col+2] = "remove";
                    matrix[row+1][col+1] = "remove";
                    matrix[row+2][col] = "remove";
                    matrix[row+2][col+2] = "remove";
                }

                if (matrix[row][col] !== "remove") {
                    matrix[row][col] = input[row][col];
                }
            }
        }
    }

    for (var mmrow = 0; mmrow < matrix.length; mmrow++) {
        for (var mmcol = 0; mmcol < matrix[mmrow].length; mmcol++) {
            if (matrix[mmrow][mmcol] === "remove") {
                matrix[mmrow][mmcol] = "";
            }
            output += matrix[mmrow][mmcol];
        }
        output += "\n";
    }

    console.log(output);
}

xRemove(["abnbjs", "xoBab", "Abmbh", "aabab", "ababvvvv"]);
xRemove(["8888888", "08*8*80", "808*888", "0**8*8?"]);
xRemove(["^u^", "j^l^a", "^w^WoWl", "adw1w6", "(WdWoWgPoop)"]);
xRemove(["puoUdai", "miU", "ausupirina", "8n8i8", "m8o8a", "8l8o860", "M8i8", "8e8!8?!"]);
