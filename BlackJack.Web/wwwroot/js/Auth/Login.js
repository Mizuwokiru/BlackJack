$("#player-select-box").change(event => {
    if ($.trim($("#player-select-box").html()) != "") {
        $("#player-input-box").val(event.target.options[event.target.selectedIndex].innerText);
    }
});

$(document).ready(() => {
    $("#player-select-box").change();
});