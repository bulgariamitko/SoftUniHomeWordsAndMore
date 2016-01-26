function fleaRacing(input) {
    var numsofjumps = parseInt(input[0]);
    var tracklength = parseInt(input[1]);
    var player = [];
    var winner;
    var farestPlayerSoFar = 0;
    for (var i = 2; i < input.length; i++) {
        var split = input[i].split(',');
        var playername = split[0].trim();
        var jumpDistanse = parseInt(split[1].trim());
        var playerLetter = playername.charAt(0).toUpperCase();
        player[i] = {"playername": playername, "letter": playerLetter, "jumpDistanse": jumpDistanse, "distance": 1};
    }

    // console.log(player);
    
    for (var i3 = 0; i3 < numsofjumps; i3++) {
        for (var play in player) {
            player[play]["distance"] += player[play]["jumpDistanse"];

            if (player[play]["distance"] >= tracklength) {
                if (player[play]["distance"] > tracklength) {
                    player[play]["distance"] = tracklength;
                }

                winner = player[play]["playername"];
                break;
            }
            // console.log(farestPlayerSoFar, player[play]["distance"]);
            if (player[play]["distance"] >= farestPlayerSoFar) {
                farestPlayerSoFar = player[play]["distance"];
                var farestPlayerSoFarWinning = player[play]["playername"];
                // console.log(farestPlayerSoFar);
            }
        }
        
        if (winner) {
            break;
        }
    }

    if (winner == undefined) {
        winner = farestPlayerSoFarWinning;
    }

    console.log(Array(tracklength+1).join("#"));
    console.log(Array(tracklength+1).join("#"));

    for(var playingIt in player) {
        var distancePlayerWhent = player[playingIt]["distance"];
        var dotsStart = distancePlayerWhent;
        var dotsEnd = tracklength - distancePlayerWhent + 1;
        var outputDots = Array(dotsStart).join(".");
        outputDots += player[playingIt]["letter"];
        outputDots += Array(dotsEnd).join(".");
        console.log(outputDots);
        // console.log(player[playingIt]["distance"]);
    }

    console.log(Array(tracklength+1).join("#"));
    console.log(Array(tracklength+1).join("#"));
    console.log("Winner: " + winner);

}

fleaRacing(["10", "19", "angel, 9", "Boris, 10", "Georgi, 3", "Dimitar, 7"]);
fleaRacing(["3", "5", "cura, 1", "Pepi, 1", "UlTraFlea, 1", "BOIKO, 1"]);
fleaRacing(["3", "40", "S, 5", "L, 1", "O, 7", "C, 3", "H, 10", "A, 12", "I, 5", "N, 8", "O, 0", "S, 6"]);