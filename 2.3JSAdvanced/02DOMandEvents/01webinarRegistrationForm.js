function handleClick(cb) {
	if (cb.checked === true) {
		var container = document.getElementById("addition");
	    // create text
	    var text = document.createElement("label");
	    text.setAttribute("for", "company");
	    text.innerHTML = "<br>Фирма/Организация:<span>*</span><br><input type='text' id='company'><br><label for='mol'>МОЛ:<span>*</span></label><br><input type='text' id='mol'><br><label for='eik'>ЕИК:<span>*</span></label><br><input type='text' id='eik'><br><label for='dds'>ИН по ДДС:<span>*</span></label><br><input type='text' id='dds'><br><label for='companyAddress'>Адрес:<span>*</span></label><br><input type='text' id='companyAddress'>";
	    document.getElementById("addition").appendChild(text);
	} else {
		var container2 = document.getElementById("addition");
		container2.innerHTML = '';
	}
}