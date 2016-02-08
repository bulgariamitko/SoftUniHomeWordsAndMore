function testContext() {
	console.log(this);
}

function callFunction() {
	testContext();
}

testContext();
callFunction();
new testContext();
