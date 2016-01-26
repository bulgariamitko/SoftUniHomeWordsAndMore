function countOfDivs(input) {
	var regex = /(<div)/g;
    input = input.match(regex);
    console.log(input.length);
}


var input = '<!DOCTYPE html>\
<html>\
<head lang="en">\
<meta charset="UTF-8">\
<title>index</title>\
<script src="/yourScript.js" defer></script>\
</head>\
<body>\
<div id="outerDiv">\
<div\
class="first">\
<div><div>hello</div></div>\
</div>\
<div>hi<div></div></div>\
<div>I am a div</div>\
</div>\
</body>\
</html>';

countOfDivs(input);