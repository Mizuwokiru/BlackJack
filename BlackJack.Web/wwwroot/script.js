const loginApi = "api/Login";
const gameApi = "api/Game";
const createGameApi = gameApi + "/CreateGame";
const createRoundApi = gameApi + "/CreateRound";
const finishRoundApi = gameApi + "/FinishRound";
let user = null;

// Enums
// Maybe need to read it from server?...
const Suit = Object.freeze({
    "Hearts": 1,
    "Tiles": 2,
    "Clovers": 3,
    "Pikes": 4
});
const Rank = Object.freeze({
    "Two": 1,
    "Three": 2,
    "Four": 3,
    "Five": 4,
    "Six": 5,
    "Seven": 6,
    "Eight": 7,
    "Nine": 8,
    "Ten": 9,
    "Jack": 10,
    "Queen": 11,
    "King": 12,
    "Ace": 13
});

$(document).ready(() => {
    getPlayersNames();

    $("#player-select-box").change(event => {
        $("#player-input-box").val(event.target.options[event.target.selectedIndex].innerText);
    });

    $("#login-button").click(() => {
        $.post({
            url: loginApi,
            accepts: "application/json",
            contentType: "application/json",
            data: JSON.stringify({
                name: $("#player-input-box").val()
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
            url: createGameApi + "/" + $("#bot-count-select-box").val(),
            contentType: "application/json",
            data: JSON.stringify(user),
            success: gameId => {
                console.log(gameId);
                $.post({
                    url: createRoundApi + "/" + gameId,
                    accepts: "application/json",
                    success: round => {
                        console.log(round);
                        $.post({
                            url: finishRoundApi + "/" + gameId,
                            success: finishMessage => {
                                console.log(finishMessage);
                            }
                        });
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
                $("#player-select-box").append("<option value=\"" + element.id + "\">" + element.name + "</option>");
            });
            $("#player-select-box").trigger("change");
            $("#login-block").css({ display: "block" });
        }
    })
}

function getEnumName(enumeration, value) {
    return Object.keys(enumeration).find(index => enumeration[index] === value);
}

function getCardName(card) {
    if (card === undefined || card.suit === undefined || card.rank === undefined) {
        return undefined;
    }
    return getEnumName(Rank, card.rank) + " of " + getEnumName(Suit, card.suit);
}