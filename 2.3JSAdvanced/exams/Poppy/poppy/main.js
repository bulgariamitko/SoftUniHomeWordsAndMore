poppy.pop('success', 'Success!', 'You have successfully registered.');
poppy.pop('info', 'Information', 'Do you know you can do a lot more using our website?');
poppy.pop('error', 'A fatal error has occurred', 'The server has responded with 404.');
poppy.pop('warning', 'Warning', 'You will enter an area that is with restrict access', redirect);

function redirect() {
	window.location = 'http://nima.bg/';
}