function daggersSwords(input) {
	var bladeLengths = input.map(Number);
    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>');

    for (var i = 0; i < bladeLengths.length; i++) {
        bladeLengths[i] = Math.floor(bladeLengths[i]);
    }

    for (var i2 = 0; i2 < bladeLengths.length; i2++) {
        var bladeLength = bladeLengths[i2];
        if(bladeLength > 10) {
            var application = '';
            switch(remainderAfterDivisionWith5(bladeLength)) {
                case 1:
                    application = 'blade';
                    break;
                case 2:
                    application = 'quite a blade';
                    break;
                case 3:
                    application = 'pants-scraper';
                    break;
                case 4:
                    application = 'frog-butcher';
                    break;
                case 0:
                    application = '*rap-poker';
                    break;
                default:
                    application = 'ERROR';
            }

            var type = '';
            if(bladeLength > 40) {
                type = 'sword';
            } else{
                type = 'dagger';
            }

            console.log('<tr><td>' + bladeLength + '</td><td>' + type + '</td><td>' + application + '</td></tr>');
        }
    }
    console.log('</tbody>');
    console.log('</table>');

    function remainderAfterDivisionWith5(bladeLength) {
        var remainder = bladeLength % 5;
        return remainder;
    }
}

daggersSwords([17.8, 19.4, 13, 55.8, 126.96541651, 3]);
