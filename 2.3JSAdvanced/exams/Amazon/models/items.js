var models = models || {};

(function (scope) {
	function Item(title, description, price) {
		this.title = title;
		this.description = description;
		this.price = price;
		this._customerReviews = [];
	}

	Item.prototype.addCustomerReview = function (customerReview) {
		this._customerReviews.push(customerReview);
	};

	Item.prototype.getCustomerReview = function () {
		return this._customerReviews;
	};

	function UsedItem (title, description, price, condition) {
		Item.call(this, arguments);
		this.condition = condition;
	}

	UsedItem.extend(Item);

	scope.getItem = function (title, description, price) {
		return new Item(title, description, price);
	};

	scope.getUsedItem = function (title, description, price, condition) {
		return new UsedItem(title, description, price, condition);
	};

}(models));