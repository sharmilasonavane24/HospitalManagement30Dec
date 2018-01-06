

$(document).ready(function () {
    var currentYear = new Date().getFullYear();
    $("#BirthDate").datepicker({
        dateFormat: "dd-M-yy",        
        changeMonth: true,
        changeYear: true,
        maxDate: -0,
        yearRange: "1900:" + currentYear
    });
});