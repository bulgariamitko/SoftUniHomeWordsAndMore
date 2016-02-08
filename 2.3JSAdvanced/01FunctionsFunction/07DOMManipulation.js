var domModule = (function domModule() {
    function appendChild(element, child) {
        var elementType = typeof element;
        var childType = typeof child;

        if (childType === "string") {
            var foundElements = document.querySelectorAll(child);
            for (var i = 0; i <  foundElements.length; i += 1 ) {
                foundElements[i].appendChild(element);
            }
        } else {
            child.appendChild(element);
        }
    }

    function removeChild(element, child) {
        var elementType = typeof element;
        var childType = typeof child;

        if (elementType === "string") {
            var selectorElements = document.querySelectorAll(element);
            if (childType === "string") {
                for (var i = 0; i < selectorElements.length; i += 1) {
                    var childsFound = selectorElements[i].querySelector(child);
                    childsFound.parentNode.removeChild(childsFound);
                }
            } else {
                for (var i2 = 0; i2 < selectorElements.length; i2 += 1) {
                    selectorElements[i2].removeChild(child);
                }
            }
        } else {
            if (childType === "string") {
                var elementsFound = element.querySelectorAll(child);
                for (var node in elementsFound) {
                    element.removeChild(node);
                }
            } else {
                element.removeChild(child);
            }
        }
    }

    function addHandler(element, eventType, eventHandler) {
        if (typeof element === "string") {
            var elementsFound = document.querySelectorAll(element);
            for (var i = 0; i < elementsFound.length; i += 1) {
                elementsFound[i].addEventListener(eventType, eventHandler);
            }
        } else {
            element.addEventListener(eventType, eventHandler);
        }
    }

    function retrieveElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        retrieveElements: retrieveElements,
        addHandler: addHandler,
        removeChild: removeChild,
        appendChild: appendChild
    };
}());

var liElement = document.createElement("li");
// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");
// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");
// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function() { alert("I'm a bird!"); });
// Retrives all elements of class "bird"
elements = domModule.retrieveElements(".bird");