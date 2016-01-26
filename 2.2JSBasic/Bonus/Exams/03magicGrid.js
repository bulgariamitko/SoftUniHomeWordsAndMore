function magicGrid(input) {
    var encryptedMessage = input[0];
    var magicNumber = Number(input[1]),
        matrix = [],
        rows = 0,
        cols = 0,
        allNumbers = [],
        sum = 0;

    for(var i = 2; i < input.length; i++) {
        var line = input[i];
        allNumbers = allNumbers.concat(line.split(' ').map(Number));
        matrix[i - 2] = line.split(' ').map(Number);
        rows++;
        cols = input[2].length;
    }

    var firstNumber = 0;
    var secondNumber = 0;
    for(var j = 0; j < allNumbers.length - 1; j++) {
        for(var k = j + 1; k < allNumbers.length; k++) {
            if (allNumbers[j] + allNumbers[k] === magicNumber) {
                firstNumber = allNumbers[j];
                secondNumber = allNumbers[k];
            }
        }
    }

    for(var row = 0; row < rows; row++){
        for(var col = 0; col < rows; col++) {
            var current = matrix[row][col];
            if (current === firstNumber || current === secondNumber) {
                sum += (row + col);
            }
        }
    }

    var result = [];
    for (i = 0; i < encryptedMessage.length; i++) {
        var numberCode = encryptedMessage.charCodeAt(i);
        var chr;

        if (i % 2 === 0) {
            chr = String.fromCharCode(numberCode + sum);
            result.push(chr);
        } else{
            chr = String.fromCharCode(numberCode - sum);
            result.push(chr);
        }
    }
    console.log(result.join(''));
}

magicGrid(["QqdvSpg", "400", "100 200 120", "120 300 310", "150 290 370"]);
magicGrid([">scsimh$deo$]$^mnxdh]}", "400", "200 100 120", "120 102 300", "150 290 370"]);
magicGrid(["EfqfNhmnkynn%`fn~", "100", "200 100 120 300", "100 90 300 100", "150 290 370 100", "10 11 100 100"]);
magicGrid(["Vi`ujr!sihtudts", "0", "0 0 120 300", "100 9 300 100", "1 290 370 100", "10 11 100 550"]);
