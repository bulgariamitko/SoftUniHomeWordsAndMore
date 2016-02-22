var poppy = poppy || {};

// classes + abstract class
(function(scope) {
	var Notification = (function () {
		function Notification(title, message, position, type, closeButton, autoHide, timeOut, callback) {
			this._popupData= {
				"title": title,
				"message": message,
				"position": position,
				"type": type,
				"closeButton": closeButton,
				"autoHide": autoHide,
				"timeOut": timeOut,
				"callback": callback
			};
		}

		return Notification;
	}());

	var Success = (function () {
		function Success(title, message) {
			Notification.call(this, title, message, "bottomLeft", "success", false, false);
		}

		return Success;
	}());

	var Info = (function () {
		function Info(title, message) {
			Notification.call(this, title, message, "topLeft", "info", true, false);
		}

		return Info;
	}());

	var ErrorIt = (function () {
		function ErrorIt(title, message) {
			Notification.call(this, title, message, "topRight", "error", false, true, 2000);
		}

		return ErrorIt;
	}());

	var Warning = (function () {
		function Warning(title, message, callback) {
			Notification.call(this, title, message, "bottomRight", "warning", false, false, 0, callback);
		}

		return Warning;
	}());

	scope._models = {
		Success: Success,
		Info: Info,
		ErrorIt: ErrorIt,
		Warning: Warning
	};

}(poppy));