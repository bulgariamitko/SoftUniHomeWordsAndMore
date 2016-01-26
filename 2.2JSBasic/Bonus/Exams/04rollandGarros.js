function rollandGarros(input) {
    var output = [];

    for(var thing in input) {
        var myRegexp = /(\w+\s*\w+)\s*vs\.\s*(\w+\s*\w+)\s*:\s*([\d\-\d\s]{1,})/i;
        var match = myRegexp.exec(input[thing]);
        match[1] = match[1].trim().replace(/\s+/, " ");
        match[2] = match[2].trim().replace(/\s+/, " ");
        var results = match[3].split(/\s+/);
        var wonHomeSets = 0;
        var wonAwaySets = 0;

        if (!output[match[1]]) {
            output[match[1]] = 
                {"name": match[1],"matchesWon": 0,"matchesLost": 0,"setsWon": 0,"setsLost": 0,"gamesWon": 0,"gamesLost":0};
        }

        if (!output[match[2]]) {
            output[match[2]] = {"name": match[2],"matchesWon": 0,"matchesLost": 0,"setsWon": 0,"setsLost": 0,"gamesWon": 0,"gamesLost":0};
        }

        for(var result in results) {
            var sets = results[result].split("-");
            var homeSets = parseInt(sets[0]);
            var awaySets = parseInt(sets[1]);


            // games won home player
            output[match[1]]["gamesWon"] += homeSets;
            // games won away player
            output[match[2]]["gamesWon"] += awaySets;
            // games lost home player
            output[match[1]]["gamesLost"] += awaySets;
            // games lost away player
            output[match[2]]["gamesLost"] += homeSets;

            if (homeSets > awaySets) {
                // sets won home player
                output[match[1]]["setsWon"]++;
                // sets lost away player
                output[match[2]]["setsLost"]++;
                wonHomeSets++;
            } else {
                // sets lost home player
                output[match[1]]["setsLost"]++;
                // sets won away player
                output[match[2]]["setsWon"]++;
                wonAwaySets++;
            }
        }

        if (wonHomeSets > wonAwaySets) {
                output[match[1]]["matchesWon"]++;
                output[match[2]]["matchesLost"]++;
            } else {
                output[match[2]]["matchesWon"]++;
                output[match[1]]["matchesLost"]++;
            }
    }
    
    var resultOut = [];
    for(var out in output) {
        resultOut.push(output[out]);
    }

    resultOut.sort(function(p1, p2) {
        if (p1.matchesWon !== p2.matchesWon) {
            return p2.matchesWon - p1.matchesWon;
        }

        if (p1.setsWon !== p2.setsWon) {
            return p2.setsWon - p1.setsWon;
        }

        if (p1.gamesWon !== p2.gamesWon) {
            return p2.gamesWon - p1.gamesWon;
        }

        return p1.name.localeCompare(p2.name);
    });
    

    console.log(JSON.stringify(resultOut));
}

rollandGarros(["Novak Djokovic vs. Roger Federer : 6-3 6-3", "Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3", "Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7", "Andy Murray vs. David     Ferrer : 6-4 7-6", "Tomas   Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7", "Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2", "Pete Sampras vs. Andre Agassi : 2-1", "Boris Beckervs.Andre        Agassi:2-1"]);