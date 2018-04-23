<script type="text/javascript">
    function OnInit(s, e) {
        TrackLayout(s.cpClientLayout);
    }
    function OnEndCallback(s, e) {
        TrackLayout(s.cpClientLayout);
    }
    function TrackLayout(layout) {
        $("#LastLayout").text(layout)
    }
</script>

<span>Last Layout:</span>&nbsp;<span id="LastLayout"></span>
<br />
@Html.Action("GridViewPartial")