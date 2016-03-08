(function() {
	require.config({
		paths: {
			"container": "models/container",
			"item": "models/item",
			"section": "models/section"
		}
	});
}());

require(["container"], function (Container) {
	var container = new Container("SoftUni TODO App");
	container.addToDOM("#wrapper");
});