define([], function() {
	return (function() {
		function Item(content) {
			this._content = content;
			this._isCompleted = false;
		}

		Item.prototype.changeStatus = function() {
			this._isCompleted = !this._isCompleted;
		};

		Item.prototype.addToDOM = function(ul) {
			var item = document.createElement("li");
			item.innerHTML = "<input type='checkbox' class='tick'>";
			item.innerHTML += "<span>" + this._content + "</span>";
			ul.appendChild(item);
		};

		return Item;
	}());
});