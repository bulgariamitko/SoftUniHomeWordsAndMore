function plusRemove(input) {
    var matrix = [];
    var output = "";

    for (var rowDemo = 0; rowDemo < input.length; rowDemo++) {
        matrix[rowDemo] = [];
        for (var colDemo = 0; colDemo < input[rowDemo].length; colDemo++) {
            matrix[rowDemo][colDemo] = input[rowDemo][colDemo];
        }
    }

    for (var row = 0; row < input.length - 2; row++) {
        for (var col = 0; col < input[row].length; col++) {
            if (input[row][col] !== undefined &&
                    input[row+1][col] !== undefined &&
                    input[row+1][col-1] !== undefined &&
                    input[row+1][col+1] !== undefined &&
                    input[row+2][col] !== undefined) {
                var charIt = input[row][col].toLowerCase();
                var charIt1 = input[row+1][col].toLowerCase();
                var charIt2 = input[row+1][col-1].toLowerCase();
                var charIt3 = input[row+1][col+1].toLowerCase();
                var charIt4 = input[row+2][col].toLowerCase();
                if (charIt === charIt1 &&
                        charIt === charIt2 &&
                        charIt === charIt3 &&
                        charIt === charIt4) {
                    matrix[row][col] = "remove";
                    matrix[row+1][col] = "remove";
                    matrix[row+1][col-1] = "remove";
                    matrix[row+1][col+1] = "remove";
                    matrix[row+2][col] = "remove";
                }
            }
            
        }
    }

    for (var mrow = 0; mrow < matrix.length; mrow++) {
        for (var mcol = 0; mcol < matrix[mrow].length; mcol++) {
            if (matrix[mrow][mcol] === "remove") {
                matrix[mrow][mcol] = "";
            }
        }
    }

    for (var mrow2 = 0; mrow2 < matrix.length; mrow2++) {
        for (var mcol2 = 0; mcol2 < matrix[mrow2].length; mcol2++) {
            if (matrix[mrow2][mcol2] !== undefined) {
                output += matrix[mrow2][mcol2];
            }
        }
        output += "\n";
    }

    console.log(output);
}

plusRemove(["ab**l5", "bBb*555", "absh*5", "ttHHH", "ttth"]);
plusRemove(["888**t*", "8888ttt", "888ttt<<", "*8*0t>>hi"]);
plusRemove(["@s@a@p@una", "p@@@@@@@@dna", "@6@t@*@*ego", "vdig*****ne6", "li??^*^*"]);
