function buildTable(input) {

	function isFib(val) {
	 var prev = 0;
	 var curr = 1;
	 while(prev<=val){
	   if(prev == val){
	     return "yes";
	   }
	   curr = prev + curr;
	   prev = curr - prev;
	 }
	 return "no";
	}

	var startNum = parseInt(input[0]);
	var endNum = parseInt(input[1]);

	console.log("<table>");
	console.log("<tr><th>Num</th><th>Square</th><th>Fib</th></tr>");
	
	for (var i = startNum; i <= endNum; i++) {
		console.log("<tr><td>" + i + "</td><td>" + (i * i) + "</td><td>" + isFib(i) + "</td></tr>");
	}
	
	console.log("</table>");

}

buildTable([5, 10]);
buildTable([999999, 1000000]);