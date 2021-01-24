function onAddTrackSubmitClick(item) {
    var startTime = $("#FormatedStartTime").val() ;
    var endTime = $("#FormatedEndTime").val();
    if (startTime==""|| endTime=="") {
        return false;
    }
    var beginningTime = moment(startTime, 'h:mm a');
    var endingTime = moment(endTime, 'h:mm a');

    if (beginningTime >= endingTime) {
        $("#ErrstartTime").show();
        $("#ErrEndTime").show();
        return false;
    }
    return true;
}

$(document).ready(function () {
    $('input.timepicker').timepicker({});
});