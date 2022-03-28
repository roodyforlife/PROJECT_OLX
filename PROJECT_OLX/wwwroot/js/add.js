function download(input)
{
    let file = input.files[0];
    let reader = new FileReader();
    reader.fileName = file.name;
    reader.readAsDataURL(file);
    reader.onload = function (readerEvt) {
        document.getElementById("upload-file__text").innerHTML = readerEvt.target.fileName;
    }
}

function download_user(input)
{
    /*let file = input.files[0];
    let reader = new FileReader();
    reader.fileName = file.name;
    reader.readAsDataURL(file);
    reader.onload = function (readerEvt) {
        document.querySelector(".test__text").innerHTML = readerEvt.target.fileName;
    }*/

document.querySelector('.avatar__submit').click();
}

function search()
{
    let value = document.querySelector('.input__search').value;
    let route = "../Home/Index?search=" + value;
document.location.href = route;
}

function input_file_validation()
{
    let value = document.querySelector('.upload-file__text');
    if(value.length < 2)
    {
        document.querySelector('.upload-file__label').style.border = "#ff0000";
    }
}