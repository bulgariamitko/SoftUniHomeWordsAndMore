String.prototype.startsWith = function startsWith(substring) {
    return this.indexOf(substring) === 0;
};

String.prototype.endsWith = function endsWith(substring) {
    return this.indexOf(substring) == this.length - substring.length;
};

String.prototype.left = function left(count) {
    var result = "";
    if (count > this.length) {
    	result = this.toString();
    } else {
    	result = this.substring(0, count);
    }
    return result;
};

String.prototype.right = function right(count) {
    var result = "";
    if (count > this.length) {
    	result = this.toString();
    } else {
    	result = this.substring(this.length - count, this.length);
    }
    return result;
};

String.prototype.padLeft = function padLeft(count, character) {
	var result = "";

    for (var i = 0; i < count; i++) {
    	if (character === undefined) {
    		character = " ";
    	}
		result += character;
    }
    result += this.toString();
    return result;
};

String.prototype.padRight = function padRight(count, character) {
	var result = this.toString();

    for (var i = 0; i < count; i++) {
    	if (character === undefined) {
    		break;
    	}
		result += character;
    }
    return result;
};

String.prototype.repeat = function repeat(count) {
	var result = "";
    for (var i = 0; i < count; i++) {
    	result += this.toString();
    }
    return result;
};

var example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith ("example"));
console.log(example.startsWith("something else"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));

// Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));

var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));

var hello = "hello";
console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

var character = "*";
console.log(character.repeat(5));
// Alternative syntax
console.log("~".repeat(3));

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
