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

    // Trigger button click on press enter
    $('#exam-form').keypress(function (e) {
        if ($("#vocabulary-exam-answer").val() != "" && e.keyCode == 13) {
            $('#submit-answer').click();
        }
    });

    function runValidation() {
        autoValidation = true;

        if (isValidForm()) {
            var deckId = $("#Deck_DeckId").val();

            // Disable the whole form
            setExamSettingsFormDisabled(true);

            callExamApi(deckId);
        }
    }

    function setExamSettingsFormDisabled(state) {
        $("*", "#exam-settings-form").prop('disabled', state);
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

    function callExamApi(deckId) {
        $.ajax({
            url: "../api/exam/GetExam/" + deckId,
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
        testTypeName = $("#LanguageTest_LanguageTestId option:selected").text();
        $("#exam-type").text(testTypeName);
        $("#total-words").val(vocabularyList.length.toString() + " total word(s)");

        setExamFormVisible(true);

        showNextWord();
    }

    function showNextWord() {
        // Check if submitted word is correct, unless it's the first word
        if (currentIndex > 0) {
            checkSubmittedAnswer();
        }

        // If the current word is the last one
        if (currentIndex == (vocabularyList.length - 1)) {
            // TODO: Finalize exam

            // disable controls

            // send result to API and store result in DB

            // show result (percentage) on screen

            return;
        }

        currentIndex++;

        singular = vocabularyList[currentIndex].singular;
        plural = vocabularyList[currentIndex].plural;
        article = vocabularyList[currentIndex].article;
        meaning = vocabularyList[currentIndex].meaning;

        $("#vocabulary-exam-meaning").val(meaning);
        $("#vocabulary-exam-answer").val("");

    }

    function checkSubmittedAnswer() {
        var answer = $("#vocabulary-exam-answer").val();
        var rightAnswer = "";
        var previousWord = "";

        if (testTypeName.toLowerCase() == "vocabulary") {
            rightAnswer = vocabularyList[currentIndex].singular;
            previousWord = vocabularyList[currentIndex].article + " " + vocabularyList[currentIndex].singular;
        } else if (testTypeName.toLowerCase() == "gender") {
            rightAnswer = vocabularyList[currentIndex].article;
            previousWord = vocabularyList[currentIndex].article + " " + vocabularyList[currentIndex].singular;
        } else if (testTypeName.toLowerCase() == "plural") {
            rightAnswer = vocabularyList[currentIndex].plural;
            previousWord = vocabularyList[currentIndex].plural;
        }

        if (answer == rightAnswer) {
            rightAnswers++;
            $("#right-answers").val(rightAnswers.toString() + " right answer(s)");
        } else {
            wrongAnswers++;
            $("#wrong-answers").val(wrongAnswers.toString() + " wrong answer(s)");
        }

        $("#previous-word").val(previousWord.trim());
    }
});
