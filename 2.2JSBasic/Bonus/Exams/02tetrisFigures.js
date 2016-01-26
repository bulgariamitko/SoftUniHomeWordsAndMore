function tetrisFigures(input) {
    output = {"I":0,"L":0,"J":0,"O":0,"Z":0,"S":0,"T":0};
    matrix = [];

    for (var row = 0; row < input.length; row++) {
        matrix[row] = input[row];
        for (var col = 0; col < input[row].length; col++) {
            matrix[row][col] = input[col];
        }
    }

    // pieces "I"
    for (var rows = 0; rows < matrix.length - 3; rows++) {
        for (var cols = 0; cols < matrix[rows].length; cols++) {
            if (matrix[rows][cols] == "o" && matrix[rows+1][cols] == "o" && matrix[rows+2][cols] == "o" && matrix[rows+3][cols] == "o") {
                output["I"]++;
            }
        }
    }
    // pieces "L"
    for (var rows2 = 0; rows2 < matrix.length - 2; rows2++) {
        for (var cols2 = 0; cols2 < matrix[rows2].length - 1; cols2++) {
            if (matrix[rows2][cols2] == "o" && matrix[rows2+1][cols2] == "o" && matrix[rows2+2][cols2] == "o" && matrix[rows2+2][cols2+1] == "o") {
                output["L"]++;
            }
        }
    }

    // pieces "J"
    for (var rows3 = 0; rows3 < matrix.length - 2; rows3++) {
        for (var cols3 = 0; cols3 < matrix[rows3].length; cols3++) {
            if (matrix[rows3][cols3] == "o" && matrix[rows3+1][cols3] == "o" && matrix[rows3+2][cols3] == "o" && matrix[rows3+2][cols3-1] == "o") {
                output["J"]++;
            }
        }
    }

    // pieces "O"
    for (var rows4 = 0; rows4 < matrix.length - 1; rows4++) {
        for (var cols4 = 0; cols4 < matrix[rows4].length; cols4++) {
            if (matrix[rows4][cols4] == "o" && matrix[rows4][cols4+1] == "o" && matrix[rows4+1][cols4] == "o" && matrix[rows4+1][cols4+1] == "o") {
                output["O"]++;
            }
        }
    }

    // pieces "Z"
    for (var rows5 = 0; rows5 < matrix.length - 1; rows5++) {
        for (var cols5 = 0; cols5 < matrix[rows5].length; cols5++) {
            if (matrix[rows5][cols5] == "o" && matrix[rows5][cols5-1] == "o" && matrix[rows5+1][cols5] == "o" && matrix[rows5+1][cols5+1] == "o") {
                output["Z"]++;
            }
        }
    }

    // pieces "S"
    for (var rows6 = 0; rows6 < matrix.length - 1; rows6++) {
        for (var cols6 = 0; cols6 < matrix[rows6].length; cols6++) {
            if (matrix[rows6][cols6] == "o" && matrix[rows6][cols6+1] == "o" && matrix[rows6+1][cols6] == "o" && matrix[rows6+1][cols6-1] == "o") {
                output["S"]++;
            }
        }
    }

    // pieces "T"
    for (var rows7 = 0; rows7 < matrix.length - 1; rows7++) {
        for (var cols7 = 0; cols7 < matrix[rows7].length; cols7++) {
            if (matrix[rows7][cols7] == "o" && matrix[rows7][cols7-1] == "o" && matrix[rows7][cols7+1] == "o" && matrix[rows7+1][cols7] == "o") {
                output["T"]++;
            }
        }
    }

    console.log(JSON.stringify(output));

}

tetrisFigures(["--o--o-", "--oo-oo", "ooo-oo-", "-ooooo-", "---oo--"]);
tetrisFigures(["-oo", "ooo", "ooo"]);