function stringMatrixRotation(input) {
    var rotarion = parseInt(input[0].match(/\d+/g));
    var resultArr = input.slice(1, input.length);
    var rotCount = (rotarion%360)/90;

    for(var count = 0 ; count < rotCount; count++){
        resultArr = rotate(resultArr);
    }
    
    printArr(resultArr);

    function rotate(arr){
        var maxlength = 0;
        for(var i in arr){
            if(arr[i].length > maxlength){
                maxlength = arr[i].length;
            }
        }
        //console.log(maxlength)
        var newArr = new Array(maxlength);
        for (var k = 0; k < maxlength; k++) {
            newArr[k] = new Array(arr.length);
        }

        var newRow = 0;
        var newCol = 0;
        for(var row = arr.length -1; row >= 0; row--){
            for(var col = 0; col < maxlength; col++){
                //console.log(arr[row][col]);
                newArr[newRow][newCol] = arr[row][col];
                newRow++;
            }
            newCol++;
            newRow = 0;
        }
        //printArr(newArr);
        return newArr;
    }
    function printArr(inputArr){
        for(var row = 0; row < inputArr.length; row++){
            var rowStr = "";
            for(var col = 0; col < inputArr[0].length; col++){
                if(inputArr[row][col] != undefined){
                    rowStr += inputArr[row][col];
                } else {
                    rowStr += " ";
                }
            }
            console.log(rowStr);
        }
    }
}

stringMatrixRotation(["Rotate(90)", "hello", "softuni", "exam"]);
stringMatrixRotation(["Rotate(180)", "hello", "softuni", "exam"]);
stringMatrixRotation(["Rotate(270)", "hello", "softuni", "exam"]);
stringMatrixRotation(["Rotate(720)", "js", "exam"]);
stringMatrixRotation(["Rotate(810)", "js", "exam"]);
stringMatrixRotation(["Rotate(0)", "js", "exam"]);