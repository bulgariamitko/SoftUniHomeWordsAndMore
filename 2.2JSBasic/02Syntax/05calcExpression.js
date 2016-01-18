document.getElementById("submit").onclick = function () {
    var input = document.getElementById("number").value;
    document.getElementById("result").innerText = eval(input);
};