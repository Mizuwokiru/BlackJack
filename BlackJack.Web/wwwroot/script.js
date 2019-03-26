$(document).ready(() => {
    let user = null;

    // Initial states
    $("#game-menu-block").css({ display: "none" });
    $("player-select-box").trigger("change");

    $("#player-select-box").change(event => {
        $("#player-input-box").val(event.target.options[event.target.selectedIndex].innerText);
    });

    $("#login-button").click(() => {
        //$.ajax({
        //    url: "/Home/PlayerByName/" + playerInputBox.value,
        //    type: "GET",
        //    contentType: "application/json",
        //    success: function (result) {
        //        console.log(result);
        //        user = result;
        //        choosePlayerBlock.style.display = "none";
        //        gameMenuBlock.style.display = "";
        //    }
        //});
        $("#choose-player-block").css({ display: "none" });
        $("#game-menu-block").css({ display: "" });
    });

    $("#start-game-button").click(() => {
        $("#login-block").css({ display: "none" });
        $("#bot-count-modal").modal("hide");
    });
});