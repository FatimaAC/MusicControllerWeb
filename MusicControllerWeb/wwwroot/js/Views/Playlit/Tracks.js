function onAddTrackSubmitClick(item) {
    var starttime = item.StrartTimeWith.value;
    var endtime = item.EndTimeWith.value;
    var beginningTime = moment(starttime, 'h:mma');
    var endTime = moment(endtime, 'h:mma');

    if (beginningTime >= endTime) {
        $("#ErrstartTime").show();
        $("#ErrEndTime").show();
        return false;
    }
    return true;
}

$(document).ready(function () {
    $('input.timepicker').timepicker({});
});