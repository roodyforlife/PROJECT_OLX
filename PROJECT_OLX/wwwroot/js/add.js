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