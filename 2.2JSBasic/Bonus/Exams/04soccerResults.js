function soccerResults(input) {
    var myRegexp = /\s*(\D+)\s*\/\s*(\D+):\s*(\d+)-(\d+)/;
    var statistic = {};
    for (var i = 0; i < input.length; i++) {
        var match = myRegexp.exec(input[i].trim());
        var hometeam = match[1].trim();
        var awayteam = match[2].trim();
        var hometeamgoals = parseInt(match[3]);
        var awayteamgoals = parseInt(match[4]);

        // HOME TEAM
        var team = hometeam;
        if (!statistic[team]) {
            statistic[team] = {};
        }
        if (!statistic[team]["goalsScored"]) {
            statistic[team]["goalsScored"] = hometeamgoals;
        } else {
            statistic[team]["goalsScored"] += hometeamgoals;
        }

        if (!statistic[team]["goalsConceded"]) {
            statistic[team]["goalsConceded"] = awayteamgoals;
        } else {
            statistic[team]["goalsConceded"] += awayteamgoals;
        }

        // PLAYED AGAINST
        if (!statistic[team]["matchesPlayedWith"]) {
            statistic[team]["matchesPlayedWith"] = [];
        }
        if (statistic[team]["matchesPlayedWith"].indexOf(awayteam) == -1) {
            statistic[team]["matchesPlayedWith"].push(awayteam);
        }
        
        
        // AWAY TEAM
        team = awayteam;
        if (!statistic[team]) {
            statistic[team] = {};
        }
        if (!statistic[team]["goalsScored"]) {
            statistic[team]["goalsScored"] = awayteamgoals;
        } else {
            statistic[team]["goalsScored"] += awayteamgoals;
        }

        if (!statistic[team]["goalsConceded"]) {
            statistic[team]["goalsConceded"] = hometeamgoals;
        } else {
            statistic[team]["goalsConceded"] += hometeamgoals;
        }

        // PLAYED AGAINST
        if (!statistic[team]["matchesPlayedWith"]) {
            statistic[team]["matchesPlayedWith"] = [];
        }
        if (statistic[team]["matchesPlayedWith"].indexOf(hometeam) == -1) {
            statistic[team]["matchesPlayedWith"].push(hometeam);
        }
        
    }

    for (var obj in statistic) {
        statistic[obj]["matchesPlayedWith"].sort();
    }

    statistic = sortByKeys(statistic);
    console.log(JSON.stringify(statistic));

    function sortByKeys(inputMap) {
        var resultMap = {};
        var keyArr = Object.keys(inputMap);
        keyArr.sort();
        for (var key in keyArr) {
            resultMap[keyArr[key]] = inputMap[keyArr[key]];
        }
        return resultMap;
    }
}

soccerResults(["Germany / Argentina: 1-0", "Brazil / Netherlands: 0-3", "Netherlands / Argentina: 0-0", "Brazil / Germany: 1-7", "Argentina / Belgium: 1-0", "Netherlands / Costa Rica: 0-0", "France / Germany: 0-1", "Brazil / Colombia: 2-1"]);
soccerResults(["Levski / CSKA: 0-2", "Pavlikeni / Loko Gorna: 4-2", "Loko Gorna / Levski: 1-4", "Litex / Loko Gorna: 0-0", "Beroe / Botev Plovdiv: 2-1", "Loko Gorna / Beroe: 3-1", "Pavlikeni / Ludogorets: 0-2", "Loko Sofia / Litex: 0-2", "Pavlikeni / Marek: 1-1", "Litex / Levski: 0-0", "Beroe / Litex: 3-2", "Litex / Beroe: 1-0", "Ludogorets / Litex: 3-0", "Litex / Ludogorets: 1-0", "CSKA / Beroe: 1-0", "Botev Plovdiv / CSKA: 1-1", "Ludogorets / Loko Sofia: 1-0", "Litex / CSKA: 0-1", "Marek / Haskovo: 0-1", "Levski / Loko Gorna: 1-1"]);

