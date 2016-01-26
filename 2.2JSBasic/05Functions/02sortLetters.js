function sortLetters(input, boolean) {

	function Sortasc(a,b){ 
		var lca = a.toLowerCase(), lcb = b.toLowerCase();
		return lca > lcb ? 1 : lca < lcb ? -1 : 0;
	}
	function Sortdes(a,b){ 
		var lca = b.toLowerCase(), lcb = a.toLowerCase();
		return lca > lcb ? 1 : lca < lcb ? -1 : 0;
	}
	if (boolean) {
		console.log(input.split('').sort(Sortasc).join(''));
	} else {
		console.log(input.split('').sort(Sortdes).join(''));
	}
	
}

sortLetters('HelloWorld', true);
sortLetters('HelloWorld', false);