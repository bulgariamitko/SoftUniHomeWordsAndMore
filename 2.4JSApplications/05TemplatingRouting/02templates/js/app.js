var app = app || {};

(function() {
	var selector = 'main';
	var json = {
       'header1': 'Name',
       'header2': 'Job Title',
       'header3': 'Website',
       'items': [
           {'name': 'Garry Finch', 'jobTitle': 'Front End Technical leade', 'website': 'http://website.com'},
           {'name': 'Bob McFray', 'jobTitle': 'Photographer', 'website': 'http://goo.gle'},
           {'name': 'Jenny O\'Sullivan', 'jobTitle': 'LEGO Geek', 'website': 'http://stackoverflow.com'}
       ]
   };

	$.get('templates/table.html', function(templ) {
		var rendered = Mustache.render(templ, json);
		$(selector).html(rendered);
	});
}());