function parachute(input) {
    var parachutenistRow = 0;
    var parachutenistCol = 0;

    for (var row = 0; row < input.length; row++) {
        // console.log("before", parachutenistRow, parachutenistCol);

        for (var col = 0; col < input[row].length; col++) {

            if (input[row][col] === "o") {
                parachutenistRow = row;
                parachutenistCol = col;
            }

            // console.log("debugging", col, parachutenistCol);

            if (row !== 0) {
                // how much to move him left or right
                if (input[row][col] === "<") {
                    // move him left
                    if (parachutenistCol - 1 < 0) {
                        parachutenistCol = 0;
                    } else {
                        // console.log("moving left...");
                        parachutenistCol--;
                    }
                } else if (input[row][col] === ">") {
                    // move him right
                    if (parachutenistCol + 1 <= input[row].length - 1) {
                        // console.log("moving right...");
                        parachutenistCol++;
                    } else {
                        parachutenistCol = input[row].length - 1;
                    }
                }
            }
            
            // console.log("moving", col, moveLeft);
            // console.log(input[parachutenistRow][parachutenistCol]);

        }

        // landing...
        if (input[parachutenistRow][parachutenistCol] === "_") {
            console.log("Landed on the ground like a boss!");
            console.log(parachutenistRow, parachutenistCol);
            return;
        } else if (input[parachutenistRow][parachutenistCol] === "~") {
            console.log("Drowned in the water like a cat!");
            console.log(parachutenistRow, parachutenistCol);
            return;
        } else if (input[parachutenistRow][parachutenistCol] === "/" || input[parachutenistRow][parachutenistCol] === "\\" || input[parachutenistRow][parachutenistCol] === "|") {
            console.log("Got smacked on the rock like a dog!");
            console.log(parachutenistRow, parachutenistCol);
            return;
        }

        parachutenistRow++;

        // console.log("after", parachutenistRow, parachutenistCol);
    }
}

parachute(["--o----------------------", ">------------------------", ">------------------------", ">-----------------/\\-----", "-----------------/--\\----", ">---------/\\----/----\\---", "---------/--\\--/------\\--", "<-------/----\\/--------\\-", "\\------/----------------\\", "-\\____/------------------"]);
parachute(["-------------o-<<--------", "-------->>>>>------------", "---------------->-<---<--", "------<<<<<-------/\\--<--", "--------------<--/-<\\----", ">>--------/\\----/<-<-\\---", "---------/<-\\--/------\\--", "<-------/----\\/--------\\-", "\\------/--------------<-\\", "-\\___~/------<-----------"]);
