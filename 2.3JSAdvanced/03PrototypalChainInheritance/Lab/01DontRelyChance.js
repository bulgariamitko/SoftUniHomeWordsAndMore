function getRandomNum() {
  var randomNum = Math.floor(Math.random() * 10);
  return randomNum;
}
var mysteryNum = getRandomNum();
for(var i = 0; i < 10; i++) {
  var currentMysteryNum = i;
  if(currentMysteryNum != mysteryNum) {
    throw new Error("No chance for you today!");
  }
}