var HTMLGen = (function HTMLGen() {
	function createParagraph(id, text) {
	    var p = document.createElement("p");
	    p.innerHTML = text;
	    document.getElementById(id).appendChild(p);
	}

	function createDiv(id, classs) {
		var div = document.createElement("div");
	    div.setAttribute("class", classs);
	    document.getElementById(id).appendChild(div);
	}

	function createLink(id, text, url) {
		var a = document.createElement("a");
		a.setAttribute("href", url);
		a.innerHTML = text;
		document.getElementById(id).appendChild(a);
	}

	return {
		createParagraph: createParagraph,
		createDiv: createDiv,
		createLink: createLink
	};
})();

HTMLGen.createParagraph('wrapper', 'Soft Uni');
HTMLGen.createDiv('wrapper', 'section');
HTMLGen.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');
