function revealTriangles(input) {
	var output = [];
    for (var row = 0; row < input.length; row++) {
        output[row] = input[row].split('');
    }
    
    // Replace all triangles with '*' (with overlapping)
    for (var row = 1; row < input.length; row++) {
        var maxCol = Math.min(
            input[row - 1].length - 2,
            input[row].length - 3);
        for (var col = 0; col <= maxCol; col++) {
            var a = input[row][col];
            var b = input[row][col + 1];
            var c = input[row][col + 2];
            var d = input[row - 1][col + 1];
            if (a == b && b == c & c == d) {
                // Triangle found --> fill it with '*'
                output[row][col] = '*';
                output[row][col + 1] = '*';
                output[row][col + 2] = '*';
                output[row - 1][col + 1] = '*';
            }
        }
    }
    
    // Print the result
    for (var row = 0; row < input.length; row++) {
        console.log(output[row].join(''));
    }
}

revealTriangles(['abcdexgh', 'bbbdxxxh', 'abcxxxxx']);
revealTriangles(['aa', 'aaa', 'aaaa', 'aaaaa']);
revealTriangles(['ax', 'xxx', 'b', 'bbb', 'bbbb']);
revealTriangles(['dffdsgyefg', 'ffffeyeee', 'jbfffays','dagfffdsss', 'dfdfa', 'dadaaadddf', 'sdaaaaa', 'daaaaaaasf']);