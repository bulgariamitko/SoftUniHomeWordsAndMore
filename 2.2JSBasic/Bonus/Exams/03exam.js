function exam(input) {
	var output = "";
	var bannedUsers = input[input.length - 1].split(/\s+/g);
	var bbUsers = [];
	var output2 = [];
	var output3 = [];
	var outoutToReg = "";
	var skipMin = -1;
	var skipMax = -1;
	var originalWords = [];
	var wordsToReplacesWith = [];
	var symbols = [];

	for (var i = 0; i < bannedUsers.length; i++) {
		bbUsers.push("#" + bannedUsers[i]);
	}

	for (var j = 0; j < input.length - 1; j++) {
		output += input[j] + "\n";
	}

	var words = output.split(" ");
	// put * instead of username!!!
	for (var i2 = 0; i2 < words.length; i2++) {
		if (isInArray(words[i2], bbUsers)) {
			var stars = "";
			for (var i3 = 0; i3 < words[i2].length - 1; i3++) {
				stars += "*";
			}
			output2.push(stars);
		} else {
			output2.push(words[i2]);
		}
	}




	var regInput = output2.join(" ").trim().split("\n");

	for (var j2 = 0; j2 < regInput.length; j2++) {
		if (regInput[j2] == "<code>") {
			skipMin = j2;
		}
		if (regInput[j2] == "</code>") {
			skipMax = j2;
		}
	}

	console.log(regInput);

	for (var j3 = 0; j3 < regInput.length - 1; j3++) {
		if (skipMin > j3 || skipMax < j3) {
			outoutToReg += regInput[j3] + "\n";
		}
		
	}

	// console.log(outoutToReg);

	var myRegexp = /(#[a-zA-Z][a-zA-Z0-9_\-]+[a-zA-Z0-9]\b)([\S]*)/g;
	while (match = myRegexp.exec(outoutToReg)) {
		// console.log(match[0], match[1], match[2]);
	    originalWords.push(match[1]);
	    var removeHashtag = match[1].replace("#", "");
	    wordsToReplacesWith.push('<a href="/users/profile/show/' + removeHashtag + '">' + removeHashtag + '</a>');
	    symbols.push(match[2]);
	}


	var lines = output2.join(" ").trim().split("\n");

	// console.log(lines);
	var counter = 0;
	for (var e = 0; e < lines.length; e++) {
		var wordIt = lines[e].trim().split(" ");
		for (var e2 = 0; e2 < wordIt.length; e2++) {
			var cleanWord = wordIt[e2].trim();
			cleanWord = cleanWord.replace(/[^#a-zA-Z0-9_\-]/g, "");
			// console.log(cleanWord, counter);
			if (isInArray(cleanWord, originalWords)) {
				output3.push(wordsToReplacesWith[counter] + symbols[counter]);
				counter++;
			} else {
				output3.push(wordIt[e2]);
			}	
		}
		output3.push("|||");
	}
	
	// console.log(originalWords, wordsToReplacesWith);

	var something = output3.join(" ").trim();
	var something2 = something.split(" ||| ");
	var rr = "";
	for (var ii = 0; ii < something2.length; ii++) {
		rr += something2[ii] + "\n";
	}

	str = rr.substring(0, rr.length - 4);
	console.log(str.trim());
	

	function isInArray(value, array) {
		return array.indexOf(value) > -1;
	}
}

// exam(["#RoYaL: I'm not sure what you mean,", "but I am confident that I've written", "everything correctly. Ask #iordan_93", "and #pesho if you don't believe me", "<code>", "#trying to print stuff", "print(\"yoo\")", "</code>", "pesho gosho"]);

// exam(["#RoYaL: I'm not sure what you mean,", "but I am confident that I've written", "everything correctly. Ask #iordan_93", "and #pesho if you don't believe me", "#RoYaL: I'm not sure what you mean,", "but I am confident that I've written", "everything correctly. Ask #iordan_93", "and #pesho if you don't believe me", "<code>", "#trying to print stuff", "print(\"yoo\")", "</code>>>>>>>>", "pesho gosho"]);
exam(["I'm not sure what you mean but #RoYaL", "says that I've written everything correctly. Ask ", "#iordan_93 and #pesho", "if you don't believe me", "<code>", "#trying to print stuff", "print(\"yoo\")", "</code>", "Yoo", "<code>", "#trying to print stuff", "#gosho", "print(\"yoo\")", "</code>", "pesho gosho"]);
