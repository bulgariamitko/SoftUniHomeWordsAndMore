function linkStrings(input) {
    var output = [];
    var output2 = "";

    for (var i = 0; i < input.length; i++) {
        // var myRegexp = /([\w=\w]+)/gi;
        var justDoIT = input[i].replace(/.*?\?/, "");
        var splitter = justDoIT.split("&");
        
        for (var i2 = 0; i2 < splitter.length; i2++) {
            splitter[i2] = splitter[i2].replace(/\+/g, " ");
            splitter[i2] = splitter[i2].replace(/\s+/g, " ").trim();
            var makeIt = splitter[i2].split("=");

            for (var i3 = 0; i3 < makeIt.length; i3 += 2) {
                var key = makeIt[i3];
                var value = makeIt[i3+1].replace(/%20/g, " ");
                value = value.replace(/\s+/g, " ").trim();

                if (!(key in output)) {
                    output[key] = [];
                 }
                // if (!output[key]) {
                //     output[key] = [];
                // }
                // console.log(output[key]);
                output[key].push(value);
            }
        }
        for (var o in output) {
            output2 += o + "=[" + output[o].join(", ") + "]";
        }
        console.log(output2);
        output = [];
        output2 = "";
    }

    

    
}

// linkStrings(["login=student&password=student"]);
// linkStrings(["field=value1&field=value2&field=value3", "http://example.com/over/there?name=ferret"]);
// linkStrings(["foo=%20foo&value=+val&foo+=5+%20+203", "foo=poo%20&value=valley&dog=wow+", "url=https://softuni.bg/trainings/coursesinstances/details/1070", "https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php"]);
// linkStrings(["fantasy=lord%20of%the%rings&fantasy=the%20%20hobbit&fantasy=harry+potter+and++++the+++deathly%20hallows%20&autor=j.k.rowling&autor=j.r.r.tolkien", "fantasy=a%20%20dance+with+the+drag000ns&shitbooks=twilight+++"]);
// linkStrings(["first=this+is+a+field&second=was_it_already*", "workshop=canvas_in_js&lecture=flow+++++++control", "++++++and-there_should=be+one-&stup=id&id=line_of_&sy=Mb0l3Z++++++++", "l@nguag3-z=english&language=csharp&language=php&language=shliok@vica"]);
linkStrings(["http://lotr.wikia.com/wiki/Elves?find=elf&elves=amarie%20%20%20%20nimrodel&elves=gil-galad+galadriel&mortal=harry%20potter&elven=legolas&mortal=he-who-must-not-be-named+&mortal=boromir&immortal=spirit&mortal=bilbo+beggins&evil=sauron&answer%20of%20everything++++=42", "https://www.google.bg/search?q=whitespace&oq=whitespace&aqs=chrome.0.0l6.1165j0j7&sourceid=chrome&es_sm=93&ie=UTF-8", "numbers=20&symbols=#%*^(^("]);
