// TODO: 

var Event = (function() {

        function Event(options) {
            if (this.constructor === Event) {
                throw new Error("Can't instantiate abstract class Event.");
            }
            this.setName(name);
            this.setArea(area);
            this.setLocation(location);
            this.setIsFurnitured(isFurnitured);
        }

        

        return Event;
    }());