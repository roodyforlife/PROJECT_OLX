function download(input)
{
    let block = document.querySelector('#upload-file__text');
    block.innerHTML = "";
    for(let i = 0; i < input.files.length; i++)
    {
    let file = input.files[i];
    let reader = new FileReader();
    reader.fileName = file.name;
    reader.readAsDataURL(file);
    reader.onload = function (readerEvt) {
        block.innerHTML += readerEvt.target.fileName + "</br>";
    }
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
    try
    {
        document.querySelector('.upload-file__text').innerHTML
    }
        catch(err){
console.log("fdgfdgfdgdfg");
            document.getElementById('upload-file__label').style.background = "#fff0f1";
        }
}