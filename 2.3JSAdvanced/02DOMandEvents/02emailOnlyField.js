function handleClick() {
	var text = document.getElementById('email').value;
	var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var result = re.test(text);
    var validate = document.createElement("p");
    if (result) {
    	validate.innerHTML = "<span style='background-color: #66ff66'>" + text + "</span>";
    } else {
    	validate.innerHTML = "<span style='background-color: #ff6666'>" + text + "</span>";
    }
    document.getElementById("validating").appendChild(validate);
}