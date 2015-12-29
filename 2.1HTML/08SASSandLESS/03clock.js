function setCurrentTime() {
    var time, hour, minutes, seconds;
    time = new Date();
    hour = setZero(time.getHours());
    minutes = setZero(time.getMinutes());
    seconds = setZero(time.getSeconds());
	document.getElementById('clock').innerHTML = hour + ':' + minutes + ':' + seconds;
}
function setZero(num){
	if(num < 10) {
        num = '0' + num;
    }
	return num;
}
setInterval(function(){setCurrentTime()}, 2000);