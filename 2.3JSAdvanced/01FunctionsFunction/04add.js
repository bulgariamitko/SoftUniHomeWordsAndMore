function add(n) {
    var v = function (x) {
        return add(n + x);
    };

    v.valueOf = v.toString = function () {
        return n;
    };

    return v;
}

console.log(+add(1));
console.log(+add(2)(3));
console.log(+add(1)(1)(1)(1)(1));
console.log(+add(1)(0)(-1)(-1));

var addTwo = +add(2);
console.log(addTwo);
var addTwo = add(2);
console.log(+addTwo(3));
