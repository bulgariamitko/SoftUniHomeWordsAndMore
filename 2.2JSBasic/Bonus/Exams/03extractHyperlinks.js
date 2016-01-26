function extractHyperlinks(input) {
    var html = input.join('\n');
    var regex = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g;
    var match;
    while (match = regex.exec(html)) {
        var hrefValue = match[3];
        if (hrefValue == undefined) {
            hrefValue = match[4];
        }
        if (hrefValue == undefined) {
            hrefValue = match[5];
        }
        console.log(hrefValue);
    }
}

extractHyperlinks('<a href="http://softuni.bg" class="new"></a>');
extractHyperlinks('<p>This text has no links</p>');
var data = '<!DOCTYPE html> \n <html>\n <head>\n   <title>Hyperlinks</title>\n   <link href="theme.css" rel="stylesheet" />\n </head>\n <body>\n <ul><li><a   href="/"  id="home">Home</a></li><li><a\n  class="selected" href=/courses>Courses</a>\n </li><li><a href = \n \'/forum\' >Forum</a></li><li><a class="href"\n onclick="go()" href= "#">Forum</a></li>\n <li><a id="js" href =\n "javascript:alert(\'hi yo\')" class="new">click</a></li>\n <li><a id=\'nakov\' href =\n http://www.nakov.com class=\'new\'>nak</a></li></ul>\n <a href="#empty"></a>\n <a id="href">href=\'fake\'<img src=\'http://abv.bg/i.gif\' \n alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>\n <!-- This code is commented:\n   <a href="#commented">commentex hyperlink</a> -->\n </body>';
extractHyperlinks(data);