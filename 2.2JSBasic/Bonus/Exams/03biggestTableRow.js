function biggestTableRow(input) {
    var biggerstNum = -10000;
    var tempNum = 0;
    var numsArray = [];
    var popIn = [];

    for (var i = 2; i < input.length; i++) {
        var myRegexp = /<td>(\S+)<\/td>/g;
        var match = myRegexp.exec(input[i]);
        if (match) {
            var splitting = match[0].split("<td>");

            for(var s in splitting) {
                var num = splitting[s].replace("</td>", "").trim();
                var floatNum = parseFloat(num);
                // console.log(floatNum);
                if (!(isNaN(floatNum))) {
                    // console.log(tempNum, floatNum);
                    tempNum += floatNum;
                    numsArray.push(num);
                }
            }
        }

        // console.log(tempNum, biggerstNum);

        if (tempNum > biggerstNum) {
            biggerstNum = tempNum;
            popIn = [];
            popIn.push(numsArray);
        }

        numsArray = [];
        tempNum = 0;
    }
    
    // console.log(popIn[0] == "");

    if (popIn.length > 0) {
        if (popIn[0] != "") {
            var output = biggerstNum;
            output += " = " + popIn[0].join(" + ");
            console.log(output);
        } else {
            console.log("no data");
        }
    } 
}

biggestTableRow(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>", "<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>", "<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>", "<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>", "</table>"]);
biggestTableRow(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>", "</table>"]);
biggestTableRow(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>", "<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>", "<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>", "</table>"]);
biggestTableRow(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Pleven</td><td>-100</td><td>-200</td><td>-</td></tr>", "<tr><td>Varna</td><td>-100</td><td>-</td><td>-300</td></tr>", "<tr><td>Rousse</td><td>-</td><td>-200</td><td>-100</td></tr>", "</table>"]);
biggestTableRow(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>0</td><td>-</td><td>0.0</td></tr>", "<tr><td>Yambol</td><td>-</td><td>0</td><td>-</td></tr>", "<tr><td>Sliven</td><td>-</td><td>0</td><td>-</td></tr>", "<tr><td>Kaspichan</td><td>0</td><td>-</td><td>-</td></tr>", "<tr><td>Varnaxx</td><td>-</td><td>18.02</td><td>36.11</td></tr>", "<tr><td>Plevenpp</td><td>1</td><td>-</td><td>1</td></tr>", "<tr><td>Vidinee</td><td>-</td><td>-560</td><td>20833</td></tr>", "<tr><td>Rousseww</td><td>-</td><td>299.999999</td><td>-</td></tr>", "<tr><td>Bourgasmm</td><td>-</td><td>2500</td><td>-</td></tr>", "<tr><td>Yambolqq</td><td>-</td><td>-</td><td>-</td></tr>", "<tr><td>Plovdivee</td><td>17.2</td><td>-</td><td>6.4</td></tr>", "<tr><td>Sofiaoo</td><td>-</td><td>1</td><td>1</td></tr>", "<tr><td>Blagoevgradsdf</td><td>-</td><td>150</td><td>-</td></tr>", "</table>"]);
biggestTableRow(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>0</td><td>-</td><td>0.0</td></tr>", "<tr><td>Yambol</td><td>-</td><td>0</td><td>-</td></tr>", "<tr><td>Sliven</td><td>-</td><td>0</td><td>-</td></tr>", "<tr><td>Kaspichan</td><td>0</td><td>-</td><td>-</td></tr>", "</table>"]);
