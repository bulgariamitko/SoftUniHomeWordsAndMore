var symfonyController = {
	form : $("form[name=form]"),
	// category
	form_name : $("input#form_name"),
	form_favicon : $("input#form_favicon"),
	form_description : $("textarea#form_description"),
    // product
    form_categoryId : $("select#form_categoryId"),
    // form_image : $("input#form_image"),
    form_price : $("input#form_price"),
    form_promotionId : $("input#form_promotionId"),
    form_qtty : $("input#form_qtty"),
    form_visibility : $("input#form_visibility"),

	edit : function(id){
		this.generic.getAForm(id);		
	},
	delete : function(id){
		if (confirm("Procced with deleting?")) {
			this.generic.deleteCategory(id);
		}
	}
};

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
		console.log(data.status);
		console.log(id);
		if (data.status) {
			var result = data.result;
			result = JSON.parse(result);
			console.log(result);
			 if(result){
			 	// prepare an input field to tell the controller what we want to do..
			 	var hidden_input = "<input type='hidden' id='update_category' name='update_category' value='1'/>";
			 	var hidden_input_id = "<input type='hidden' id='update_category_id' name='update_category_id' value='" + id + "'/>";
			 	// category
			 	symfonyController.form_name.val(result.name);
			 	symfonyController.form_favicon.val(result.favicon);
			 	symfonyController.form_description.val(result.description);
                // product
                 symfonyController.form_categoryId.val(result.categoryId);
                 // symfonyController.form_image.val(result.image);
                 symfonyController.form_price.val(result.price);
                 symfonyController.form_promotionId.val(result.promotionId);
                 symfonyController.form_qtty.val(result.qtty);
                 symfonyController.form_visibility.val(result.visibility);
			 	$("button#form_save").text("Update");
			 	if ($("input[id=update_category]").length === 0) {
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
		// console.log(data);
		$.each(data,function(index, entity) {
		    // console.log(entity);
			html+= '<li class="list-group-item"><span class="float-xs-left">' + entity.name + '</span> <span class="float-xs-right">';
            // if (data[0].name === "Computer") {
            //     console.log("products");
            //     // html+= "<button type='button' onclick='' class='btn btn-info control-buttons'><i class='fa fa-edit'></i></button>";
            // } else if (data[0].name === "Computer") {
            //     console.log("promotions")
            // } else {
                html+= "<button type='button' onclick='symfonyController.edit("+entity.id+")' class='btn btn-info control-buttons'><i class='fa fa-edit'></i></button>";
            // }
			html+= '<button type="button" onclick="symfonyController.delete('+entity.id+')" class="btn btn-danger control-buttons"><i class="fa fa-trash"></i></button>';
			html+='</span> </li>';
		});
		return html;
	}
};

symfonyController.paginator = function(){
	var dataContainer = $("#categories-list");
	$('.pagination-container').pagination({
	    dataSource: global_variables.category_names,
	    className: 'paginationjs-theme-blue paginationjs-big',
	    pageSize : 5,
	    callback: function(data) {
	        var html = symfonyController.generic.pagingTemplate(data);
	        dataContainer.html(html);
	    }
	})
};

symfonyController.paginator2 = function(){
    var dataContainer = $("#promotions-list");
    $('.pagination-container').pagination({
        dataSource: global_variables.promotion_names,
        className: 'paginationjs-theme-blue paginationjs-big',
        pageSize : 5,
        callback: function(data) {
            var html = symfonyController.generic.pagingTemplate(data);
            dataContainer.html(html);
        }
    })
};

symfonyController.paginator3 = function(){
    var dataContainer = $("#products-list");
    $('.pagination-container').pagination({
        dataSource: global_variables.product_names,
        className: 'paginationjs-theme-blue paginationjs-big',
        pageSize : 5,
        callback: function(data) {
            var html = symfonyController.generic.pagingTemplate(data);
            dataContainer.html(html);
        }
    })
};