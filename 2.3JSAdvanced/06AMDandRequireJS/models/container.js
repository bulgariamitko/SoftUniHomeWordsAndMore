define(["section"], function(Section) {
	return (function () {
		Container = function Container(title) {
			this._title = title;
			this._sections = [];
		};

		Container.prototype.addSection = function(section) {
			this._sections.push(section);
		};

		Container.prototype.getSections = function() {
			return this._sections;
		};

		Container.prototype.addToDOM = function(selector) {
			var wrapper = document.querySelector(selector);
			var container = document.createElement("div");
			container.setAttribute("id", "container");
			var h1Title = document.createElement("h1");
			h1Title.innerHTML = this._title;
			container.appendChild(h1Title);

			var divSections = document.createElement("div");
			divSections.setAttribute("id", "sections");
			container.appendChild(divSections);

			// add section
			this._sections.forEach(function(section) {
				section.addToDOM("#sections");
			});

			var footer = document.createElement("footer");
			var sectionInput = document.createElement("input");
			sectionInput.setAttribute("type", "text");
			sectionInput.setAttribute("id", "section-input");
			var sectionButton = document.createElement("button");
			sectionButton.setAttribute("id", "section-button");
			sectionButton.innerText = "Add section";

			footer.appendChild(sectionInput);
			footer.appendChild(sectionButton);
			container.appendChild(footer);

			wrapper.appendChild(container);

			var _this = this;
			sectionButton.addEventListener("click", function(ev) {
				var sectionTitle = document.getElementById("section-input").value;
				var section = new Section(sectionTitle);
				_this.addSection(section);
				section.addToDOM("#sections");
			});

			wrapper.addEventListener("change", function(ev) {
				if (ev.target.getAttribute("class") === "tick") {
					if (ev.target.checked) {
						ev.target.nextElementSibling.setAttribute("class", "checked");
					} else {
						ev.target.nextElementSibling.removeAttribute("class");
						ev.target.nextElementSibling.setAttribute("class", "tick");
					}
				}
			});
		};
		return Container;
	}());
});