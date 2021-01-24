// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#Word_DeckId').change(function () {
        updateDropdownList(this.id, "Word_ArticleId", "values", "GetArticlesByDeckId", "-not a noun-");
    });

    $('#Language_LanguageId').change(function () {
        updateDropdownList(this.id, "Deck_DeckId", "values", "GetDecksByLanguageId", "-Select-");
        updateDropdownList(this.id, "LanguageTest_LanguageTestId", "values", "GetTestTypesByLanguageId", "-Select-");
    });

    // Setting the article for the Edit page (otherwise the value won't exist)
    if (document.getElementById("Word_DeckId")) {
        if ($("#Word_DeckId").val() != undefined && $("#Word_DeckId").val() != "") {
            // load the items in the Article dropdown:
            updateDropdownList("Word_DeckId", "Word_ArticleId", "values", "GetArticlesByDeckId", "-not a noun-");
        }
    }

    // Setting the deck in case of refreshing the Exam page and if the Language is selected
    if (document.getElementById("Language_LanguageId") && document.getElementById("LanguageTest_LanguageTestId")) {
        if ($("#Language_LanguageId").val() != undefined && $("#Language_LanguageId").val() != "") {
            // load the items in the Article dropdown:
            updateDropdownList("Language_LanguageId", "LanguageTest_LanguageTestId", "values", "GetTestTypesByLanguageId", "-Select-");
        }
    }

    // Setting the deck in case of refreshing the Exam page and if the Language is selected
    if (document.getElementById("Language_LanguageId") && document.getElementById("Deck_DeckId")) {
        if ($("#Language_LanguageId").val() != undefined && $("#Language_LanguageId").val() != "") {
            // load the items in the Article dropdown:
            updateDropdownList("Language_LanguageId", "Deck_DeckId", "values", "GetDecksByLanguageId", "-Select-");
        }
    }

    function updateDropdownList(primaryDropdown, secondaryDropdown, controllerName, methodName, textForEmptyValue) {
        var selectedId = $("#" + primaryDropdown).val();
        var secondarySelect = $("#" + secondaryDropdown);
        secondarySelect.empty();
        if (selectedId != null && selectedId != "") {
            $.ajax({
                url: "../api/" + controllerName + "/" + methodName + "/" + selectedId,
                type: "get", //send it through get method
                success: function (response) {
                    console.log("success");

                    if (response != null && !jQuery.isEmptyObject(response)) {
                        secondarySelect.append($('<option/>', {
                            value: "",
                            text: textForEmptyValue
                        }));
                        $.each(response, function (index, item) {
                            secondarySelect.append($('<option/>', {
                                value: item.value,
                                text: item.text
                            }));
                        });

                        // For the Edit page, to select the correct value
                        if (document.getElementById("selected-value")) {
                            $("#" + secondaryDropdown).val($("#selected-value").val());
                        }
                    };
                },
                error: function (xhr) {
                    console.log("failure");
                }
            });
        }
    }
});

document.onreadystatechange = function () {
    if (document.readyState === 'complete') {
        // Do stuff
    }
}

function changeSampleColor() {
    $("#sample-item").css("background-color", $("#Gender_GenderColor").val());
}
