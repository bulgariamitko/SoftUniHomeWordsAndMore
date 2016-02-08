function theNumbers(input) {
    var output = [];

    var myRegexp = /\d+/g;
    while (match = myRegexp.exec(input)) {
        var n = Number(match[0]);
        var hex = n.toString(16).toUpperCase();
        var withZeros = pad(hex, 4);
        output.push("0x" + withZeros);
    }

    console.log(output.join("-"));

    function pad(num, size) {
        var s = num+"";
        while (s.length < size) s = "0" + s;
        return s;
    }
}

theNumbers("5tffwj(//*7837xzc2---34rlxXP%$”.");
theNumbers("482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312");
theNumbers("20");
