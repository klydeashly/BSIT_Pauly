const AddStudent = async (student) => {
    try {
        const result = await AjaxPOST('/Home/InsertStudent', student)
        if (result.success) {
            alert('Student Added Successfully!');
            window.location.href = '/Home/Index';
        }

        else {
            alert('Failed!');
        }
    }
    catch {
        alert('Error occurred!');
    }
}

$(document).ready(function (){
    $('#addStudentForm').on('submit', function (e) {
        e.preventDefault();
        const student = {
            StudentName: $('#StudentName').val(),
            Age: $('#Age').val(),
            Course: $('#Course').val(),
            Gender: $('#Gender').val(),
            Birthday: $('#Birthday').val(),
            Address: $('#Address').val()
        };
        AddStudent(student);
    })
})