const loginApi = "api/Login";
const canContinueApi = "api/Game/CanContinue";
const newGameApi = "api/Game/New";
const continueGameApi = "api/Game/Continue";
const getRoundApi = "api/Game/GetRound";

const cardBack = "<span style=\"color: darkred\">&#x1F0A0;</span>";

let user = null;
let gameId = null;

$(document).ready(() => {
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
                user = acceptedUser;
                console.log(user);
                $("#choose-player-block").css({ display: "none" });
                $.get({
                    url: canContinueApi + "?playerId=" + user.playerId,
                    success: canContinue => {
                        console.log(canContinue);
                        if (canContinue) {
                            $("#continue-game-button").css({ display: "block" });
                        }
                        $("#game-menu-block").css({ display: "block" });
                    }
                });
            },
            error: xhr => {
                if (xhr.status === 400) {
                    $("#player-select-box").trigger("change");
                    alert("Invalid name");
                }
            }
        });
    });

    $("#start-game-button").click(() => {
        console.log("val of bot-count-select-box = ", $("#bot-count-select-box").val());
        $.get({
            url: newGameApi + "?playerId=" + user.playerId + "&botCount=" + $("#bot-count-select-box").val(),
            success: responseGame => {
                console.log(responseGame);
                $("#login-block").css({ display: "none" });
                gameId = responseGame.gameId;
                $("#game-cards-block").empty();
                responseGame.players.forEach(player => {
                    addPlayer(player);
                });
                $.get({
                    url: getRoundApi + "/" + gameId,
                    cache: false,
                    success: rounds => {
                        console.log(rounds);
                        rounds.forEach(round => {
                            addCards(round.playerId, round.cards);
                        });
                        $("#player-1-cards").append(cardBack);
                        $("#game-block").css({ display: "block" });
                    }
                });
            },
            error: xhr => {
                if (xhr.status == 400) {
                    console.error("Bot count is too much");
                }
            },
            complete: () => {
                $("#bot-count-modal").modal("hide");
            }
        });
    });

    $.get({
        url: loginApi,
        cache: false
    }).done(playerList => {
        $("#player-select-box").empty();
        playerList.forEach(playerName => {
            $("#player-select-box").append("<option>" + playerName + "</option>");
        });
        $("#player-select-box").trigger("change");
        $("#login-block").css({ display: "flex" });
    });
});

function addCards(playerId, cards) {
    let cardsHtml = cards.map(card => getUnicodeCard(card)).join("");
    $("#player-" + playerId + "-cards").append(cardsHtml);
}

function addCard(playerId, card) {
    let cardHtml = getUnicodeCard(card);
    $("#player-" + playerId + "-cards").append(cardHtml);
}

function addPlayer(player) {
    let htmlPlayer = "<div class=\"col-md-3\">" +
        "<div id=\"player-" + player.playerId + "\" class=\"card mb-4 shadow-sm\">" +
        "<div id=\"player-" + player.playerId + "-header\" class=\"card-header\">" + player.playerName + "</div>" +
        "<div class=\"card-body\">" +
        "<p id=\"player-" + player.playerId + "-cards\" class=\"card-text\"></p>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>";
    $("#game-cards-block").append(htmlPlayer);
}

function getUnicodeCard(card) {
    let cardValue = card.suit + card.rank;
    let color = "black";
    if ((cardValue > 0x1F0B0 && cardValue < 0x1F0D0)) {
        color = "darkred";
    }
    return "<span style=\"color: " + color + "\">&#" + cardValue + ";</span>";
}