function createParagraph(id, text) {
    var p = document.createElement("p");
    p.innerHTML = text;
    document.getElementById(id).appendChild(p);
}

createParagraph('wrapper', 'Some text');