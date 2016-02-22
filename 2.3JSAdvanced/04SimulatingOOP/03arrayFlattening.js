Array.prototype.flatten = function flatten() {
    var flattenedArray = [];
    for (var i = 0; i < this.length; i++) {
        if (this[i] instanceof Array) {
            flattenedArray = flattenedArray.concat(this[i].flatten());
        } else {
            flattenedArray.push(this[i]);
        }
    }

    return flattenedArray;
};

var array = [1, 2, 3, 4];
console.log(array.flatten());

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
