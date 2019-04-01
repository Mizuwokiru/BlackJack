const loginApi = "api/Login";
const gameApi = "api/Game";
const gameCreateApi = gameApi + "/Create";
const gameGetRoundApi = gameApi + "/GetRound";
let user = null;

$(document).ready(() => {
    getPlayersNames();

    $("#player-select-box").change(event => {
        if ($.trim($("#player-select-box").html()) != "") {
            $("#player-input-box").val(event.target.options[event.target.selectedIndex].innerText);
        }
    });

    $("#login-button").click(() => {
        $.post({
            url: loginApi,
            accepts: "application/json",
            contentType: "application/json",
            data: JSON.stringify({
                playerName: $("#player-input-box").val()
            }),
            success: acceptedUser => {
                console.log(acceptedUser);
                user = acceptedUser;
                $("#choose-player-block").css({ display: "none" });
                $("#game-menu-block").css({ display: "block" });
            }
        });
    });

    let logString = null;
    $("#start-game-button").click(() => {
        console.log(logString);
        $.post({
            url: gameCreateApi + "/" + $("#bot-count-select-box").val(),
            contentType: "application/json",
            data: JSON.stringify(user),
            success: game => {
                console.log(game);
                $.get({
                    url: gameGetRoundApi + "/" + game.gameId,
                    cache: false,
                    success: roundData => {
                        console.log(roundData);
                        for (let i = 0; i < roundData.length; i++) {
                            for (let j = 0; j < roundData[i].playerCards.length; j++) {
                                $("#game-menu-block").append(getUnicodeCard(roundData[i].playerCards[j]));
                            }
                        }
                    }
                });
                $("#bot-count-modal").modal("hide");
            }
        });
        //$("#login-block").css({ display: "none" });
        //$("#bot-count-modal").modal("hide");
    });
});

function getPlayersNames() {
    $.get({
        url: loginApi,
        cache: false,
        success: result => {
            console.log(result);
            $("#player-select-box").empty();
            result.forEach(element => {
                $("#player-select-box").append("<option>" + element + "</option>");
            });
            $("#player-select-box").trigger("change");
            $("#login-block").css({ display: "block" });
        }
    })
}

function getEnumName(enumeration, value) {
    return Object.keys(enumeration).find(index => enumeration[index] === value);
}

function getUnicodeCard(card, tag) {
    if (card == undefined) {
        return null;
    }
    if (tag == undefined) {
        tag = "span";
    }
    let cardValue = card.suit + card.rank;
    let color = "black";
    if (cardValue > 0x1F0B0 && cardValue < 0x1F0D0) {
        color = "darkred";
    }
    return "<" + tag + " style=\"color: " + color + "\">&#" + cardValue + ";</" + tag + ">";
}