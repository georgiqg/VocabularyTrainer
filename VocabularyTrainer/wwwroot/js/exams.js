$(document).ready(function () {
    var autoValidation = false;
    var vocabularyList = [];
    var currentIndex = 0;
    var testTypeName = "";
    var rightAnswers = 0;
    var wrongAnswers = 0;

    $(document).on("change", "#Language_LanguageId, #Deck_DeckId, #LanguageTest_LanguageTestId", isValidForm);
    $(document).on("click", "#start-exam", runValidation);
    $(document).on("click", "#submit-answer", showNextWord);

    // Disable exam form
    setExamFormDisabled(true);

    // Trigger button click on press enter
    $('#exam-form').keypress(function (e) {
        if ($("#vocabulary-exam-answer").val() != "" && e.keyCode == 13) {
            $('#submit-answer').click();
        }
    });

    function runValidation() {
        autoValidation = true;

        if (isValidForm()) {
            currentIndex = 0;
            rightAnswers = 0;
            wrongAnswers = 0;

            testTypeName = $("#LanguageTest_LanguageTestId option:selected").text();
            var deckId = $("#Deck_DeckId").val();
            var nounsOnly = testTypeName.toLowerCase() != "vocabulary";

            // Disable the whole form
            setExamSettingsFormDisabled(true);

            callExamApi(deckId, nounsOnly);
        }
    }

    function setExamSettingsFormDisabled(state) {
        $("*", "#exam-settings-form").prop('disabled', state);
    }

    function setExamFormDisabled(state) {
        $("*", "#exam-form").prop('disabled', state);
    }

    function setExamFormVisible(state) {
        if (state) {
            $("#exam-div").show();
        } else {
            $("#exam-div").hide();
        }
    }

    function isValidForm() {
        var isValud = true;

        // Auto validate the form on selection change only after the first submit.
        if (!autoValidation) {
            isValud = false;
            return isValud;
        }

        var languageValue = $("#Language_LanguageId").val();
        var testTypeValue = $("#LanguageTest_LanguageTestId").val();
        var deckValue = $("#Deck_DeckId").val();

        if (languageValue == undefined || languageValue == "") {
            isValud = false;
            $("#warn-language").show();
        }
        else {
            $("#warn-language").hide();
        }

        if (testTypeValue == undefined || testTypeValue == "") {
            isValud = false;
            $("#warn-languagetest").show();
        }
        else {
            $("#warn-languagetest").hide();
        }

        if (deckValue == undefined || deckValue == "") {
            isValud = false;
            $("#warn-deck").show();
        }
        else {
            $("#warn-deck").hide();
        }

        return isValud;
    }

    function callExamApi(deckId, nounsOnly) {
        $.ajax({
            url: "../api/exam/GetExam/" + deckId + "/" + nounsOnly,
            type: "get", //send it through get method
            success: function (response) {
                if (response != null && !jQuery.isEmptyObject(response)) {
                    vocabularyList = response;
                    setExamSettingsFormDisabled(true);
                    startExam();
                } else {
                    setExamSettingsFormDisabled(false);
                }
            },
            error: function (xhr) {
                console.log("failed to call api " + apiUrl);
                setExamSettingsFormDisabled(false);
            }
        });
    }

    function startExam() {
        $("#exam-type").text(testTypeName);
        $("#total-words").val(vocabularyList.length.toString() + " total word(s)");
        $("#previous-word").val("");
        $("#exam-result").val("");
        $("#right-answers").val("0 right answer(s)");
        $("#wrong-answers").val("0 wrong answer(s)");

        setExamFormVisible(true);
        setExamFormDisabled(false);

        showNextWord();
    }

    function showNextWord() {
        // Check if submitted word is correct, unless it's the first word
        if (currentIndex > 0) {
            checkSubmittedAnswer();
        }

        // If the current word is the last one, finalize exam
        if (currentIndex == (vocabularyList.length)) {
            setExamFormDisabled(true);
            setExamSettingsFormDisabled(false);

            // show result (percentage) on screen
            var examResult = (rightAnswers / vocabularyList.length) * 100;
            $("#exam-result").val(examResult.toFixed(2) + "%");

            return;
        }

        if (testTypeName.toLowerCase() == "vocabulary") {
            $("#vocabulary-exam-meaning").val(vocabularyList[currentIndex].meaning);
        } else {
            $("#vocabulary-exam-meaning").val(vocabularyList[currentIndex].singular);
        }
        
        $("#vocabulary-exam-answer").val("");

        currentIndex++;
    }

    function checkSubmittedAnswer() {
        var answer = $("#vocabulary-exam-answer").val();
        var rightAnswer = "";
        var previousWord = "";
        var previousIndex = currentIndex - 1;

        if (vocabularyList[previousIndex].article != undefined && vocabularyList[previousIndex].article != "") {
            var singular = vocabularyList[previousIndex].singular;
            var plural = vocabularyList[previousIndex].plural;
            var article = vocabularyList[previousIndex].article;
            previousWord = article + " " + singular + " (" + plural + ")";
        } else {
            previousWord = vocabularyList[previousIndex].singular;
        }

        if (testTypeName.toLowerCase() == "vocabulary") {
            rightAnswer = vocabularyList[previousIndex].singular;
        } else if (testTypeName.toLowerCase() == "gender") {
            rightAnswer = vocabularyList[previousIndex].article;
        } else if (testTypeName.toLowerCase() == "plural") {
            rightAnswer = vocabularyList[previousIndex].plural;
        }

        if (answer == rightAnswer) {
            rightAnswers++;
            $("#right-answers").val(rightAnswers.toString() + " right answer(s)");
            $("#right-answers").fadeOut(250).fadeIn(250).fadeOut(250).fadeIn(250);
        } else {
            wrongAnswers++;
            $("#wrong-answers").val(wrongAnswers.toString() + " wrong answer(s)");
            $("#wrong-answers").fadeOut(250).fadeIn(250).fadeOut(250).fadeIn(250);
        }

        $("#total-words").val(vocabularyList.length.toString() + " total word(s), " + (vocabularyList.length - currentIndex) + " remaining");
        $("#previous-word").val(previousWord.trim());
    }
});
