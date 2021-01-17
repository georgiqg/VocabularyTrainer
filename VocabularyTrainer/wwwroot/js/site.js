// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    updateArticleDropdown($("#selected-article").val());

    $('#Word_DeckId').change(function () {
        updateArticleDropdown("");
    });

    // Setting the article for the Edit page (otherwise the value won't exist)
    if ($("#selected-article").val() != undefined && $("#selected-article").val() != "") {
        $("#Word_ArticleId").val($("#selected-article").val());
    }

    function updateArticleDropdown(selectValue) {
        var selectedDeck = $("#Word_DeckId").val();
        var articlesSelect = $('#Word_ArticleId');
        articlesSelect.empty();
        if (selectedDeck != null && selectedDeck != "") {
            $.ajax({
                url: "../api/values/GetArticlesByDeckId/" + selectedDeck,
                type: "get", //send it through get method
                success: function (response) {
                    console.log("success");

                    if (response != null && !jQuery.isEmptyObject(response)) {
                        articlesSelect.append($('<option/>', {
                            value: null,
                            text: "-not a noun-"
                        }));
                        $.each(response, function (index, article) {
                            articlesSelect.append($('<option/>', {
                                value: article.value,
                                text: article.text
                            }));
                        });

                        // For the Edit page, to select the correct value
                        if (selectValue != undefined && selectValue != "") {
                            $("#Word_ArticleId").val(selectValue);
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
