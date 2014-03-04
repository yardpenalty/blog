<script>
    /* JQuery script toggles replies*/
    function ToggleChildDivs(id) {
        $("."+id).toggle();
        $("." + id).focus(function () {
            $(id).css("display", "inline").fadeOut(1000);
        });}
</script>