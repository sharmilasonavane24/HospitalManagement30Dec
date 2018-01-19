

$(document).ready(function () {
    var currentYear = new Date().getFullYear();
    $("#BirthDate").datepicker({
        dateFormat: "dd-M-yy",        
        changeMonth: true,
        changeYear: true,
        maxDate: -0,
        yearRange: "1900:" + currentYear,
        onSelect: function (dateText) {
            if (dateText != null) {
                 
                $("#Age").val(getAge(dateText));
            }
        }
    });
});

function getAge(dateString) {
    debugger;
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m == 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}