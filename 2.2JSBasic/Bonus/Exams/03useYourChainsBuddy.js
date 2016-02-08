function useYourChainsBuddy(input) {
    var myRe = /<p>(.*?)<\/p>/g;
    var myArray;
    var output = "";
    var result = "";
    while ((myArray = myRe.exec(input)) !== null) {
        var newString = myArray[0].replace("<p>", "");
        newString = newString.replace("</p>", "");
        newString = newString.replace(/([^a-z0-9\s+]+)/g, " ");
        output += newString;
        // console.log(newString);

    }

    for (var i = 0; i < output.length; i++) {
        var charAt = output[i].charCodeAt(0);
        if (charAt > 96 && charAt < 110) {
            charAt += 13;
        } else if (charAt > 109 && charAt < 123) {
            charAt -= 13;
        }
        var letter = String.fromCharCode(charAt);
        result += letter;
        // console.log(letter);
    }

    result = result.replace(/\s+/g, " ");
    console.log(result);
}

// useYourChainsBuddy("<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>");
// useYourChainsBuddy("<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>");
useYourChainsBuddy("<p>jura qevivat va jrg fyvccrel!@##$%%^&&&*!@##$%%^&&&* fabjl pbaqvgvbaf fabj !@##$%%^&&&*punvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx vagvzvqngvat gur!@##$%%^&&&*onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc!@##$%%^&&&* va pbyq jrg pbaqvgvbaf</p>");
