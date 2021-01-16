// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

});

function changeSampleColor() {
    $("#sample-item").css("background-color", $("#Gender_GenderColor").val());
}

$('#Word_DeckId').change(function () {
    var selectedDeck = $("#Word_DeckId").val();
    var articlesSelect = $('#Word_ArticleId');
    articlesSelect.empty();
    if (selectedDeck != null && selectedDeck != "") {
        //$.getJSON("@Url.Action('GetArticlesByDeckId')", { deckId: selectedDeck }, function (articles) {
        //    if (articles != null && !jQuery.isEmptyObject(article)) {
        //        articlesSelect.append($('<option/>', {
        //            value: null,
        //            text: "-Select-"
        //        }));
        //        $.each(articles, function (index, article) {
        //            articlesSelect.append($('<option/>', {
        //                value: region.Value,
        //                text: region.Text
        //            }));
        //        });
        //    };
        //});

        $.ajax({
            url: "api/values",
            type: "get", //send it through get method
            data: {
                deckId: selectedDeck
            },
            success: function (response) {
                //Do Something
                console.log("success");
            },
            error: function (xhr) {
                //Do Something to handle error
                console.log("failure");
            }
        });
    }
});
