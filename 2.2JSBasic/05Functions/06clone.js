function clone(obj) {
	if(obj === null || typeof(obj) !== 'object' || 'isActiveClone' in obj)
        return obj;

    var temp = obj.constructor(); // changed

    for(var key in obj) {
        if(Object.prototype.hasOwnProperty.call(obj, key)) {
            obj['isActiveClone'] = null;
            temp[key] = clone(obj[key]);
            delete obj['isActiveClone'];
        }
    }    

    return temp;
}

function compareObjects(obj, objCopy) {
	if (obj === objCopy) {
		console.log("a == b --> true");
	} else {
		console.log("a == b --> false");
	}
}

var a = {name: 'Pesho', age: 21};
var b = clone(a); // a deep copy 
compareObjects(a, b);  

var a2 = {name: 'Pesho', age: 21};
var b2 = a2; // not a deep copy
compareObjects(a2, b2);
