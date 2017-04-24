var symfonyController = {
	form : $("form[name=form]"),
	cat_name : $("input#form_name"),
	cat_favicon : $("input#form_favicon"),
	cat_description : $("textarea#form_description"),
	edit : function(id){
		this.generic.getAForm(id);		
	},
	delete : function(id){
		if (confirm("Procced with deleting?")) {
			this.generic.deleteCategory(id);
		}
	}
}

symfonyController.generic = {
	getAForm : function(id){
		$.ajax({
			url: global_variables.edit_path,
			type: "POST",
			data: {id: id},
		})
		.done(function(data) {
			symfonyController.generic.handleEditResponse(data,id);
		});	
	},
	handleEditResponse : function(data,id){
		if (data.status) {
			var result = data.result;
			result = JSON.parse(result);
			console.log(result);
			 if(result.name && result.description){
			 	// prepare an input field to tell the controller what we want to do..
			 	var hidden_input = "<input type='hidden' id='update_category' name='update_category' value='1'/>";
			 	var hidden_input_id = "<input type='hidden' id='update_category_id' name='update_category_id' value='" + id + "'/>";
			 	symfonyController.cat_name.val(result.name);
			 	symfonyController.cat_favicon.val(result.favicon);
			 	symfonyController.cat_description.val(result.description);
			 	$("button#form_save").text("Update");
			 	if ($("input[id=update_category]").length == 0) {
			 		symfonyController.form.append(hidden_input);
			 		symfonyController.form.append(hidden_input_id);
			 	}else{
			 		$("input#update_category_id").val(id);
			 	}
			 	return "";
			 }
		}
	  return alert("couldn't process this data.");
	},
	deleteCategory : function(id){
		$.ajax({
			url: global_variables.delete_path,
			type: "POST",
			data: {id: id},
		})
		.done(function(data) {
			alert(data);
		});
	},
	pagingTemplate : function(data){
		var html = "";
		$.each(data,function(index, category) {
			var delete_url = "/symfony/web/app_dev.php/Categories/deleteCategory";
			html+= '<li class="list-group-item"><span class="float-xs-left">' + category.name + '</span> <span class="float-xs-right">';
			html+= "<button type='button' onclick='symfonyController.edit("+category.id+")' class='btn btn-info control-buttons'><i class='fa fa-edit'></i></button>";
			html+= '<button type="button" onclick="symfonyController.delete('+category.id+')" class="btn btn-danger control-buttons"><i class="fa fa-trash"></i></button>';
			html+='</span> </li>';
		});
		return html;
	}
}

symfonyController.paginator = function(){
	var dataContainer = $("#categories-list");
	$('.pagination-container').pagination({
	    dataSource: global_variables.category_names,
	    className: 'paginationjs-theme-blue paginationjs-big',
	    pageSize : 5,
	    callback: function(data, pagination) {
	        // template method of yourself
	        var html = symfonyController.generic.pagingTemplate(data);
	        dataContainer.html(html);
	    }
	})

}

symfonyController.paginator2 = function(){
    var dataContainer = $("#promotions-list");
    $('.pagination-container').pagination({
        dataSource: global_variables.promotion_names,
        className: 'paginationjs-theme-blue paginationjs-big',
        pageSize : 5,
        callback: function(data, pagination) {
            // template method of yourself
            var html = symfonyController.generic.pagingTemplate(data);
            dataContainer.html(html);
        }
    })

}