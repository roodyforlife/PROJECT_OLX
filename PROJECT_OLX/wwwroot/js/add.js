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

function select()
{
    document.querySelector('.categories').classList.toggle("active");
    document.querySelector(".select").style.border = "2px solid #000;";
    var test = document.querySelectorAll("li");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
}
function selected__category(category, categoryId)
{
    document.querySelector(".disabled__input__categories").value = category;
    document.querySelector(".select").innerHTML = `<span>${category}</span>`
    if(categoryId == 0)
    document.querySelector(".disabled__input__categories").value = "";
    document.querySelector('.categories').classList.toggle("active");
    // add / remove class .active__li
    var test = document.querySelectorAll("li");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
};


