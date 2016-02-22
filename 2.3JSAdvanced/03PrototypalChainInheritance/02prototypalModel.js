Object.prototype.extend = function (properties) {
    function f() { }
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
};


var shapes = (function() {
	var point2D = {
		init: function(x, y) {
			this._x = x;
			this._y = y;
			return this;
		},
		toString: function() {
			return 'x: ' + this._x + ', y: ' + this._y;
		}
	};

	var shape = {
		init: function(point2D, color) {
			this._point2D = point2D;
			this._color = color;
			return this;
		},
		toString: function() {
			return '(' + this._point2D + '), color: ' + this._color;
		}
	};

	var circle = shape.extend({
		init: function(pointO, color, radius) {
			this._super.init.call(this, pointO, color);
			this._radius = radius;
			return this;
		},
		toString: function() {
			return 'Circle -> Point ' + this._super.toString.call(this) + ', radius: ' + this._radius;
		}
	});

	var rectangle = shape.extend({
		init: function(pointA, color, width, height) {
			this._super.init.call(this, pointA, color);
			this._width = width;
			this._height = height;
			return this;
		},
		toString: function() {
			return 'Rectangle -> Point ' + this._super.toString.call(this) + ', width: ' + this._width + ', height: ' + this._height;
		}
	});

	var triangle = shape.extend({
		init: function (pointA, pointB, pointC, color) {
			this._super.init.call(this, pointA, color);
			this._pointB = pointB;
			this._pointC = pointC;
			return this;
		},
		toString: function() {
			return 'Triangle -> PointA ' + this._super.toString.call(this) + ', pointB(' + this._pointB + '), pointC(' + this._pointC + ')';
		}
	});

	var line = shape.extend({
		init: function(pointA, pointB, color) {
			this._super.init.call(this, pointA, color);
			this._pointB = pointB;
			return this;
		},
		toString: function() {
			return 'Line -> PointA ' + this._super.toString.call(this) + ', pointB(' + this._pointB + ')';
		}
	});

	var segment = shape.extend({
		init: function(pointA, pointB, color) {
			this._super.init.call(this, pointA, color);
			this._pointB = pointB;
			return this;
		},
		toString: function() {
			return 'Segment -> PointA ' + this._super.toString.call(this) + ', pointB(' + this._pointB + ')';
		}
	});

	return {
		point2D: point2D,
		shape: shape,
		circle: circle,
		rectangle: rectangle,
		triangle: triangle,
		line: line,
		segment: segment
	};
}());

var pointO = Object.create(shapes.point2D).init(100, 175);
var pointA = Object.create(shapes.point2D).init(50, 20);
var pointB = Object.create(shapes.point2D).init(50, 25);
var pointC = Object.create(shapes.point2D).init(25, 30);

var circle = Object.create(shapes.circle).init(pointO, '#FF6347', 50);
var rect = Object.create(shapes.rectangle).init(pointA, '#ccff66', 22, 33);
var triangle = Object.create(shapes.triangle).init(pointA, pointB, pointC, '#aaa');
var line = Object.create(shapes.line).init(pointA, pointB, '#00ff00');
var segment = Object.create(shapes.segment).init(pointA, pointB, '#fff');

console.log(circle.toString());
console.log(rect.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());