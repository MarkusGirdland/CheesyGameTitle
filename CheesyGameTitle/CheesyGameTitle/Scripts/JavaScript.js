"using strict";


window.onload = function () {
    console.log("Hej");

    function disableButton() {
        var myBtn = document.getElementById('<%= button.NewTurnButton %>');

        myBtn.onclick = function (e) {
            myBtn.disabled = true;

            console.log("Disabled!");

            setTimeout(function () { myBtn.disabled = false; }, 3000);
        }

        console.log("3 sekunder?");
    }
        
}
