define(["item"], function(Item) {
	return (function() {
		function Section(title) {
			this._title = title;
			this._items = [];
		}

		Section.prototype.addItem = function(item) {
			this._items.push(item);
		};

		Section.prototype.getItem = function() {
			return this._items;
		};

		Section.prototype.addToDOM = function(selector) {
			var _this = this;
			var sectionsWrapper = document.querySelector(selector);
			var section = document.createElement("section");
			var sectionTitle = document.createElement("h2");
			sectionTitle.innerText = this._title;
			section.appendChild(sectionTitle);

			// add items
			var ul = document.createElement("ul");
			section.appendChild(ul);
			this._items.forEach(function(item) {
				item.addToDOM(ul);
			});

			var itemInput = document.createElement("input");
			itemInput.setAttribute("type", "text");
			itemInput.setAttribute("class", "item-input");

			var itemButton = document.createElement("button");
			itemButton.setAttribute("class", "item-button");
			itemButton.innerText = "Add item";

			section.appendChild(itemInput);
			section.appendChild(itemButton);
			sectionsWrapper.appendChild(section);

			itemButton.addEventListener("click", function(ev) {
				var content = this.parentElement.getElementsByClassName("item-input")[0].value;
				var item = new Item(content);
				_this.addItem(item);
				var ul = this.parentElement.getElementsByTagName("ul")[0];
				item.addToDOM(ul);
			});
		};
		return Section;
	}());
});