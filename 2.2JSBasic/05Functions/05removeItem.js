Array.prototype.removeItem = function removeItem(value) {
    arr = arr.filter(function (elem)  {
       return value !== elem;
    });
    console.log(arr);
};

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeItem(1);

var arr = ['hi', 'bye', 'hello' ];
arr.removeItem('bye');