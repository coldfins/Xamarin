
function log(str) {
    $('#result').text($('#result').text() + str);
}

function logHtml(str) {
    $('#result').html($('#result').text() + "<br/>" + str);
}
function invokeCSCode() {
    try {
        debugger;
        var data = "tableId=" + 1 + "&groupName=" + 1 + "&sortOrder="
            + "Asc" + "&columnName=" + "test"
            + "&firstname=" + $('#firstname').val()
            + "&lastname=" + $('#lastname').val()
            + "&dateofBirth=" + $('#dateofBirth').val()
            + "&Gender=" + $('#gender').val()
            + "&employmentDate=" + $('#employmentDate').val()
            + "&employmentType=" + $('#employmentType').val()
            + "&hireDate=" + $('#hireDate').val()
            + "&joinDate=" + $('#joinDate').val();
        //logHtml("Sending Data:" + data);
        var jsonData = {
            tableId: 1,
            firstname: $('#firstname').val()
        }
        Native('callNative', jsonData);
    }
    catch (err) {
        log(err);
    }
}

//function invokeCSCode(fname, lname, dateofBirth, gender, employmentDate, employmentType, hireDate, joinDate) {
//    try {
//        debugger;
//        //log("Sending Data:" + data);
//        invokeCSharpAction(fname + "\t"
//            + lname + "\t"
//            + dateofBirth + "\t"
//            + gender + "\t"
//            + employmentDate + "\t"
//            + employmentType + "\t"
//            + hireDate + "\t"
//            + joinDate + "\t");
//    }
//    catch (err) {
//        log(err);
//    }
//}
function loadHtml(data) {
    console.log("loadHtml called");
    //logHtml("Receiving Data:" + data);
    document.getElementById("updateHtml").innerHTML = '<div>' + data + '</div>';
}

$(function() {
    
});
// JavaScript source code
