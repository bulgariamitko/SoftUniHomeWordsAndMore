function replaceTag(input) {
	var output = input.replace(/(<a)( href=.*)(>)(\w+)(<\/a>)/g,  '[URL$2]$4[\/URL]');

	console.log(output);
}

replaceTag("<ul>\n <li>\n  <a href=http://softuni.bg>SoftUni</a>\n </li>\n</ul>"
);