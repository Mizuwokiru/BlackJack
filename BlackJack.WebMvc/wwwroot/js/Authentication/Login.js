function changeUserName() {
    $('#user-name-input').dropdown('hide');
}

function chooseUserNameFromDropdown(userName) {
    changeUserName();
    $('#user-name-input').val(userName);
}

$(document).ready(() => {
    var userNames = $('#user-names-list > input');
    if (userNames.length !== 0) {
        $('#user-name-input').val(userNames[0].value);
    }
});