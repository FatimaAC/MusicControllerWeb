$(window).on('load', function () {
    if (scheduleValues!='') {
        populatSchudle(scheduleValues);
    }
});
// todo: dailt no frequncy
$("#schedule").change(function () {
    populatSchudle(this.value);
});

// populating the case of schudle
function populatSchudle(value) {
    switch (value) {
        case "AlternativeDay":
            $("#specificDates").hide();
            $("#weekdays").hide();
            $("#evenOrdays").show();
            $("#evenOrday").prop('required', true);
            break;
        case "Weekly":
            $("#specificDates").hide();
            $("weekday").prop('required', true);
            $("#weekdays").show();
            $("#evenOrdays").hide();
            break;
        case "Yearly":
            $("#specificDates").show();
            $("specificDates").prop('required', true);
            $("#weekdays").hide();
            $("#evenOrdays").hide();
            break;
        default:
            $("#specificDates").hide();
            $("#weekdays").hide();
            $("#evenOrdays").hide();
            $("specificDates").prop('required', false);
            $("weekday").prop('required', false);
            $("#evenOrday").prop('required', false);
    }
}

function onPlaylistSubmitClick(item) {
    var schedule = item.schedule.value;
    debugger;
    if (item.schedule.value == "AlternativeDay" && item.evenOrday.value == "") {
        $("#errevenOrday").show();
        return false;
    }
    else if (item.schedule.value == "weekdays" && item.evenOrday.value == "") {
        $("#errweekdays").show();
    }
        // todo: Change name 
    else if (item.schedule.value == "weekdays" && item.evenOrday.value == "") {
        $("#errweekdays").show();
    }
    return true;
}
    $(function () {
        //$('#specificDate').datepicker({ format: "dd.mm.yyyy" }); 
        $('#specificDate').datepicker({
            changeMonth: true,
            changeYear: false,
            changeDay: true,
            showButtonPanel: false,
            dateFormat: 'dd/mm',
            //onClose: function (dateText, inst) {
            //    $(this).datepicker('setDate', new Date(ins.changeDay, inst.selectedMonth, 2020));
            //}
        });
    });
