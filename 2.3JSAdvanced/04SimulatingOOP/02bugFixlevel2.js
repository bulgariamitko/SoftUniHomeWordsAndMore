var Person = (function() {
    function Person(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    Object.defineProperty(Person.prototype, "fullName", {
        get: function() {
            return this.firstName + " " + this.lastName;
        },
        set: function (value) {
            var fullNameString = value.split(" ");
            this.firstName = fullNameString[0];
            this.lastName = fullNameString[1];
        }
    });

    return Person;
})();

var person = new Person("Peter", "Jackson");
console.log(person.firstName);
console.log(person.lastName);
console.log(person.fullName);
// Changing values
person.firstName = "Michael";
console.log(person.firstName);
console.log(person.fullName);
person.lastName = "Williams";
console.log(person.lastName);
console.log(person.fullName);
// Changing the full name should work too
person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person.firstName);
console.log(person.lastName);
