function readUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(".employeeImgUrl").attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#employeeImg").change(function () {
    $(".imgArea").LoadingOverlay("show");
    readUrl(this);
    $(".imgArea").LoadingOverlay("hide");

})

var onFile = function () {
    $.LoadingOverlay("hide");
}
var onBegin = function () {
    $.LoadingOverlay("show");
}
var onSuccess = function (response) {
    $.LoadingOverlay("hide");
    if (response.success) {
        $(".nameSurnameArea").html(response.employee.name + " " + response.employee.surname);
        Swal.fire(
            'Başarılı',
            response.message,
            'success'
        )
    }
    else {
        Swal.fire(
            'Hata!',
            response.message,
            'error'
        )
    } 
}