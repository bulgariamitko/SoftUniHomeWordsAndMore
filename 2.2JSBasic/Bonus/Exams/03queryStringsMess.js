function queryStringsMess(input) {
      var result = [];

    input.forEach(function (line) {
        var keys = {};

        line.replace(/.+?(?=\?)(\?)+/g, '') // Remove url and '?' symbol
            .replace(/([^=&]+)=([^&]*)/g,   // Regex to match key/value pairs
            function (full, key, value) {
                key = key
                    .split('%20').join(' ')  // Replace '%20' with empty space
                    .replace(/[\+]+/g, ' ')  // Replace '+' with empty space
                    .replace(/\s{2,}/g, ' ') // Replace multiple (2 or more) whitespaces with one
                    .trim();                 // Trim whitespaces at the beginning and at the end of the string

                value = value
                    .split('%20').join(' ')
                    .replace(/[\+]+/g, ' ')
                    .replace(/\s{2,}/g, ' ')
                    .trim();

                keys[key] = (keys[key] ? keys[key] + ', ' : '[') + value;
                return '';
            });

        for (var key in keys) {
            result.push(key + '=' + keys[key] + ']');
        }
        result.push('\r\n');
    });

    return result.join('').trim();
}

// queryStringsMess(["login=student&password=student"]);
// queryStringsMess(["field=value1&field=value2&field=value3", "http://example.com/over/there?name=ferret"]);
// queryStringsMess(["foo=%20foo&value=+val&foo+=5+%20+203", "foo=poo%20&value=valley&dog=wow+", "url=https://softuni.bg/trainings/coursesinstances/details/1070", "https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php"]);
// queryStringsMess(["fantasy=lord%20of%the%rings&fantasy=the%20%20hobbit&fantasy=harry+potter+and++++the+++deathly%20hallows%20&autor=j.k.rowling&autor=j.r.r.tolkien", "fantasy=a%20%20dance+with+the+drag000ns&shitbooks=twilight+++"]);
// queryStringsMess(["first=this+is+a+field&second=was_it_already*", "workshop=canvas_in_js&lecture=flow+++++++control", "++++++and-there_should=be+one-&stup=id&id=line_of_&sy=Mb0l3Z++++++++", "l@nguag3-z=english&language=csharp&language=php&language=shliok@vica"]);
queryStringsMess(["http://lotr.wikia.com/wiki/Elves?find=elf&elves=amarie%20%20%20%20nimrodel&elves=gil-galad+galadriel&mortal=harry%20potter&elven=legolas&mortal=he-who-must-not-be-named+&mortal=boromir&immortal=spirit&mortal=bilbo+beggins&evil=sauron&answer%20of%20everything++++=42", "https://www.google.bg/search?q=whitespace&oq=whitespace&aqs=chrome.0.0l6.1165j0j7&sourceid=chrome&es_sm=93&ie=UTF-8", "numbers=20&symbols=#%*^(^("]);
