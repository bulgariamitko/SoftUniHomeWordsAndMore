function allThatLuggage(input) {
    var output = {};
    var filterInfo = input[input.length - 1];

    for (var i = 0; i < input.length - 1; i++) {
        var arr = input[i].split("*");

        var ownerName = arr[0].replace(/\./g, "");
        var luggageName = arr[1].replace(/\./g, "");
        var isFood = arr[2].replace(/\./g, "");
        var isDrink = arr[3].replace(/\./g, "");
        var isFragile = arr[4].replace(/\./g, "");
        isFragile = (isFragile === "true");
        var weightKg = arr[5].replace(/^\.+/, "");
        weightKg = Number(weightKg.replace(/\.+$/, ""));
        var transferWith = arr[6].replace(/\./g, "");

        var typeOfLugg = "";

        if (isFood === "true") {
            typeOfLugg = "food";
        } else if (isDrink === "true") {
            typeOfLugg = "drink";
        } else if (isDrink === "false" && isFood === "false") {
            typeOfLugg = "other";
        }

        // console.log(ownerName, luggageName, isFood, isDrink, isFragile, weightKg, transferWith, typeOfLugg);

        if (!(ownerName in output)) {
            output[ownerName] = {};
        }

        output[ownerName][luggageName] = {"kg": weightKg,"fragile": isFragile,"type": typeOfLugg,"transferredWith": transferWith};
        
    }

    if (filterInfo === 'luggage name') {
        var outputNameSort = {};
        Object.keys(output).forEach(function(key) {
            outputNameSort[key]={};
            var sortedInnerKeys = Object.keys(output[key]).sort();

            sortedInnerKeys.forEach(function (innerkey) {
                outputNameSort[key][innerkey] = output[key][innerkey];
            });
        });
        console.log(JSON.stringify(outputNameSort));
    } else if (filterInfo === 'weight') {
        var outputKgSort = {};
        Object.keys(output).forEach(function(key) {
            outputKgSort[key]={};
            var a = Object.keys(output[key]).sort(function (a,b) {
                return output[key][a].kg- output[key][b].kg;
            });
            a.forEach(function (value) {
                outputKgSort[key][value] = output[key][value];
            });
        });
        console.log(JSON.stringify(outputKgSort));
    } else if (filterInfo === 'strict') {
        console.log(JSON.stringify(output));
    }

    // console.log(JSON.stringify(output));
}

// allThatLuggage(["Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack", "Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack", "Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack", "Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV", "Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV", "Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV", "strict"]);
allThatLuggage(["Yana Slavcheva.....*....clothes.........*........false.....*..........false...*..false.*.2.2.*.backpack", "Kiko....*....socks.*.....false.....*.false.*......false......*.0.2.*....backpack", "Kiko.*...banana.*.true.*.....false......*.false.*.3.2.*.backpack", "Kiko.*..sticks.*.false......*.false.*.false....*.1.6.*.ATV", "Kiko.*.....glasses.....*..false......*.false.*...true.....*.3.....*....ATV", "Manov..*.socks.*.false.*...false.*.false.*.0.3.*.ATV", "Manov.*...condoms..*.false....*.false.*.false.*.8.3.*.ATV", "Manov...*.....nuts.....*.true....*.false.*.false.*.2.2.*.backpack", "Manov.*....salami.*....true.*...false..*.false.*.....6.4.....*.....ATV", "Manov....*.steak....*.true.*....false...*.false.....*.5.8.*...ATV", "Manov...*.laptop...*....false....*....false.....*.true.*.....2.5.*.backpack", "Manov.*...rakiya....*..false...*.true.*.false.*.5.8.*.backpack", "luggage name"]);
