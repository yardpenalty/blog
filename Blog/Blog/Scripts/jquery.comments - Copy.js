
///* JQuery script toggles replies*/
//function ToggleChildDivs(id) {
//    var count = $("." + id).length;
//    //expand or hide
//    $("." + id).toggle();
//    $(".reply-area").show();
//    // if === ? hide : expand
//    if ($("#" + id + " .replies").text() === ("+ Expand Replies(" + count + ")") && count >= 1) {
//        $("#" + id + " .replies").text("- Hide Replies").css("color", "#d12c2c");
//    }
//    else {
//        $("#" + id + " .replies").text("+ Expand Replies(" + count + ")").css("color", "#22582a");
//        $(".mod-btn").hide();
//        //$(".reply-box").hide(700);
//    }
//}
window.tHtml = '';



$.extend({

    //Toggles comments
    show_comments: function () {
        $("#comments-partial").toggle();
        if ($("#showNhide").text() === "Show Comments") {
            $("#showNhide").text("Hide Comments");
            $("#upNdown").css("background-position-x", "-34px").css("background-position-y", "-8px");
        }
        else {
            $("#showNhide").text("Show Comments");
            $("#post-box").fadeIn('slow');
            $("#comments-list").fadeIn('slow');
            $("#upNdown").css("background-position-x", "-66px").css("background-position-y", "-7px");
        }
    },

    /* JQuery script toggles replies*/
    ToggleChildDivs: function (id) {
        var count = $("." + id).length;
        //expand or hide
        $("." + id).toggle();
        $(".reply-area").show();
        // if === ? hide : expand
        if ($("#" + id + " .replies").text() === ("+ Expand Replies(" + count + ")") && count >= 1) {
            $("#" + id + " .replies").text("- Hide Replies").css("color", "#d12c2c");
        }
        else {
            $("#" + id + " .replies").text("+ Expand Replies(" + count + ")").css("color", "#22582a");
            $(".mod-btn").hide();
            //$(".reply-box").hide(700);
        }
    },

    //delete reply and make ajax callback
    del: function (aid, cid, pid) {
        $.get("/Article/DelCom?AId=" + aid + "&" + "CId=" + cid, function (result) {
            $('#comments-partial').html(result);
            $.ToggleChildDivs(pid);
            $(".mod-btn").hide();
        });
    },

    //delete post and make ajax callback
    delPar: function (aid, cid) {
        $.get("/Article/DelCom?AId=" + aid + "&" + "CId=" + cid, function (result) {
            $('#comments-partial').html(result);
        });
    },
    //Counts number of char in reply or post left
    comment: function (val, str) {
        var len = val.value.length;
        if (len >= 500) {
            val.value = val.value.substring(0, 500);
            $(str).css("color", "#d12c2c");
        } else {
            $(str).text(500 - len + " chars left...").css("color", "#22582a");
        }
    },
    /* REPLY ONLY!!
cid = ParentCommentId
JQuery script render post box below parent comment by ParentCommentId */
    reply: function (aid, cid) {
        $("#" + cid + " .mod-btn").hide();
        $("#" + cid + " .text-btn").hide();
        $(".reply-area").hide();
        var url = "/Article/AddComment?AId=" + aid + "&PId=" + cid;
        //This is reply with more than one sibling
        if ($("." + cid).length >= 1) {
            $.get(url, null, function (data) {
                $("." + cid + ":last").after(data);
                $("html, body").scrollTop($("." + cid + ":last").offset().top);
            });
        }
        else {
            $.get(url, null, function (data) {
                $(data).insertAfter("#" + cid);
                $("html, body").scrollTop($("#" + cid).offset().top - 160);
            });
        }
    },

    //vote on article
    vote: function (event) {

        alert("id: " + event.data.id + " like:" + true);
    },
    //get the comment's content and swaps out the tHtml data with new
    swap: function (cid) {
        // save the html within the div
        window.tHtml = $('#' + cid + " .content-box").html();
        $('#' + cid + " .content-box").prop('readonly', false).css("background-color", "#f2eeee").hide().fadeIn('slow').focus();
        $(".text-btn").hide();
        $("#" + cid + " button.mod-btn").show();
        $("#" + cid + " .replies").hide();
        // show char count
        $("#" + cid + " .replyNum").show();

    },

    cancelEdit: function (cid) {
        $('#' + cid + " .content-box").val(window.tHtml).hide().fadeIn('slow');
        $('#' + cid + " .content-box").prop('readonly', 'readonly').css("background-color", "#fff");
        $("#" + cid + " .mod-btn").hide();
        $(".text-btn").show();
        // show replies
        $("#" + cid + " .replies").show();
        // hide char count
        $("#" + cid + " .replyNum").hide();
    },

    saveEdit: function (cid) {
        var content = $('#' + cid + " .content-box").val();
        var url = "/Article/SaveEditByCommentId";
        $.ajax({
            url: url,
            data: { 'Cid': cid, 'content': content },
            type: "post",
            cache: false,
            success: function (savingStatus) {
                $(".mod-btn").hide();
                $(".text-btn").show();
                $("#" + cid + " .content-box").val(content).css("background-color", "#fff").prop("readonly", "readonly").hide().fadeIn('slow');
                // hide char count
                $("#" + cid + " .replyNum").hide();
                $("#" + cid + " .replies").show();

            },
            error: function (xhr, ajaxOptions, thrownError) {
                $('#' + cid + " .replyNum").text("Error encountered while saving the comments.");
            }

        });
    }


})

