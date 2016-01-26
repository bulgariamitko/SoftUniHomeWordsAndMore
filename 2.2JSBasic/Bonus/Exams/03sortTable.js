function sortTable(input) {
    var result = input.slice(2, input.length - 1 );
    result.sort(compare);
    console.log('<table>');
    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');
    for (var i in result) {
        console.log(result[i]);
    }
    console.log('</table>');

    function compare(a, b) {
        var first = a.match(/(<td>)(.*?)(<\/td>)/g);
        var second = b.match(/(<td>)(.*?)(<\/td>)/g);
        for (var i in first) {
            first[i] = first[i].replace(/[<td>/]+/g, '');
            second[i] = second[i].replace(/[<td>/]+/g, '');
        }
        if (parseFloat(first[1]) != parseFloat(second[1])) {
            return parseFloat(first[1]) - parseFloat(second[1]);
        } else {
            return first[0].localeCompare(second[0]);
        }
    }
}

sortTable(["<table>", "<tr><th>Product</th><th>Price</th><th>Votes</th></tr>", "<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>", "<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>", "<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>", "<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>", "<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>", "<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>", "</table>"]);