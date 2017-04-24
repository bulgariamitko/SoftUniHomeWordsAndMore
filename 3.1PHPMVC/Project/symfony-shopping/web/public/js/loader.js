$(document).ready(function() {
	if(typeof(global_variables.page_hash) !== "undefined" && global_variables.page_hash == "/Categories/index"){
		symfonyController.paginator();	
	}
    if(typeof(global_variables.page_hash) !== "undefined" && global_variables.page_hash == "/Promotions/create"){
        symfonyController.paginator2();
    }
});