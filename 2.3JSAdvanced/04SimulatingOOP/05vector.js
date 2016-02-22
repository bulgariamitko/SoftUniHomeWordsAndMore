var Vector = function vectorInitialization() {
    this.dimensions = [];
    
    var array = [];
    for (var key in arguments[0]) {
      if (arguments[0].hasOwnProperty(key)) {
        array.push(arguments[0][key]);
      }
    }

    for (var i = 0; i < array.length; i++) {
        this.dimensions.push(parseInt(array[i]));
    }

    this.add = function add(vector) {
        if (!(vector instanceof Vector)) {
            throw new DOMException();
        }

        if (vector.dimensions.length != this.dimensions.length) {
            throw new DOMException();
        }

        var newDimensions = [];
        for (var i = 0; i < this.dimensions.length; i++) {
            newDimensions.push(this.dimensions[i] + vector.dimensions[i]);
        }

        var newVector = new Vector();
        newVector.dimensions = newDimensions;
        return newVector;
    };

    this.subtract = function subtract(vector) {
        if (!(vector instanceof Vector)) {
            throw new DOMException();
        }

        if (vector.dimensions.length != this.dimensions.length) {
            throw new DOMException();
        }

        var newDimensions = [];
        for (var i = 0; i < this.dimensions.length; i++) {
            newDimensions.push(this.dimensions[i] - vector.dimensions[i]);
        }

        var newVector = new Vector();
        newVector.dimensions = newDimensions;
        return newVector;
    };

    this.dot = function dot(vector) {
        if (!(vector instanceof Vector)) {
            throw new DOMException();
        }

        if (vector.dimensions.length != this.dimensions.length) {
            throw new DOMException();
        }

        var dotProduct = 0;
        for (var i = 0; i < this.dimensions.length; i++) {
            dotProduct += this.dimensions[i] * vector.dimensions[i];
        }

        return dotProduct;
    };

    this.norm = function norm() {
        var result = 0;
        for (var i = 0; i < this.dimensions.length; i++) {
            result += this.dimensions[i] * this.dimensions[i];
        }

        result = Math.sqrt(result);

        return result;
    };

};

Vector.prototype.toString = function() {
    return "(" + this.dimensions + ")";
};

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.toString());
console.log(c.toString());
// The following throw errors
// var wrong = new Vector();
// var anotherWrong = new Vector([]);

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
var result = a.add(b);
console.log(result.toString());
// a.add(c); // Error

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
var result = a.subtract(b);
console.log(result.toString());
// a.subtract(c); // Error

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
var result = a.dot(b);
console.log(result.toString());
// a.dot(c); // Error

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.norm());
console.log(b.norm());
console.log(c.norm());
console.log(a.add(b).norm());
