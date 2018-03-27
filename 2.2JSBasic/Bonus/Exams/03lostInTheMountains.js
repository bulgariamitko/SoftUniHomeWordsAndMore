function lostInTheMountains(input, input2) {
	let chars = input;
	let inputString = input2;
	
	let regex = /([e|E][a|A][s|S][t|T]|[n|N][o|O][r|R][t|T][h|H]).*?([0-9]{2}).*?,.*?([0-9]{6})/g;
	
	input = input.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&');
	let msg = input + "(.*?)" + input;
	let regexMsg = new RegExp(msg, "g");

	// remove input chars
	let regexRemove = new RegExp(input, "g");
	let matchMsg = regexMsg.exec(inputString);

	let tempEastCor = [];
	let tempNorthCor = [];
	let m;
	while ((m = regex.exec(inputString)) !== null) {
	    // This is necessary to avoid infinite loops with zero-width matches
	    if (m.index === regex.lastIndex) {
	        regex.lastIndex++;
	    }
	    
	    // The result can be accessed through the `m`-variable.
	    for (var i = 0; i < m.length; i++) {
	    	if (m[1].toLowerCase() == 'east') {
	    		tempEastCor[0] = m[2];
	    		tempEastCor[1] = m[3];
	    	}
	    	if (m[1].toLowerCase() == 'north') {
	    		tempNorthCor[0] = m[2];
	    		tempNorthCor[1] = m[3];
	    	}
	    }
	    // console.log(m);
	}

	let northCor = tempNorthCor[0] + '.' + tempNorthCor[1] + ' N';
	let eastCor = tempEastCor[0] + '.' + tempEastCor[1] + ' E';
	let message = "Message: " + matchMsg[0].replace(regexRemove, '');
	

	console.log(northCor);
	console.log(eastCor);
	console.log(message);
}

lostInTheMountains('<>', 'o u%&lu43t&^ftgv><nortH4276hrv756dcc,  jytbu64574655k <>ThE sanDwich is iN the refrIGErator<>yl i75evEAsTer23,lfwe 987324tlblu6b');
lostInTheMountains('4ds', 'eaSt 19,432567noRt north east 53,123456north 43,3213454dsNot all those who wander are lost.4dsnorth 47,874532');
lostInTheMountains('..', 'o u%&lu43t&^ftgv><nortH4276hrv756dcc,  jytbu64574655k ..ThE sanDwich is iN the refrIGErator..yl i75evEAsTer23,lfwe 987324tlblu6b');
