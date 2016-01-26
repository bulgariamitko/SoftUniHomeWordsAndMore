function doubleRakiyaNumbers(input) {
    function isDoubleRakiyaNumber(num) {
        var regex = /(\d{2})\d*\1/g;
        if((num.toString()).match(regex)) {
            return true;
        }
        return false;
    }

    var start = parseInt(input[0]);
    var end = parseInt(input[1]);

    console.log("<ul>");
    for (var i = start; i <= end; i++) {
        if (isDoubleRakiyaNumber(i)) {
            console.log("<li><span class='rakiya'>" + i + "</span><a href=\"view.php?id=" + i + ">View</a></li>");
        } else {
            console.log("<li><span class='num'>" + i + "</span></li>");    
        }
    }
    console.log("</ul>");
}

// doubleRakiyaNumbers([5, 8]);
doubleRakiyaNumbers([11210, 11215]);
doubleRakiyaNumbers([55555, 55560]);