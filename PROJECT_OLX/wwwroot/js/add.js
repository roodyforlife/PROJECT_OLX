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

function select__category()
{
    document.querySelector('.categories').classList.toggle("active__menu");
    document.querySelector(".select__categories").style.border = "2px solid #000;";
    var test = document.querySelectorAll(".li__block__category");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
}

function select__sort()
{
    document.querySelector('.sort').classList.toggle("active__menu");
    document.querySelector(".select__sort").style.border = "2px solid #000;";
    var test = document.querySelectorAll(".li__block__sort");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
}
function selected__category(category, categoryId)
{
    document.querySelector(".disabled__input__categories").value = category;
    document.querySelector(".select__categories").innerHTML = `<span>${category}</span>`
    if(categoryId == 0)
    document.querySelector(".disabled__input__categories").value = "";
    document.querySelector('.categories').classList.toggle("active__menu");
    // add / remove class .active__li
    var test = document.querySelectorAll(".li__block__category");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
};

function selected__sort(sort, sortName)
{
    document.querySelector(".disabled__input__sort").value = sort;
    document.querySelector(".select__sort").innerHTML = `<span>${sortName}</span>`
    document.querySelector('.sort').classList.toggle("active__menu");
    // add / remove class .active__li
    var test = document.querySelectorAll(".li__block__sort");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
};

function selected__categoryWhileAdd(category)
{
    document.querySelector(".disabled__input__categories").value = category;
    document.querySelector(".select").innerHTML = `<span>${category}</span>`
    document.querySelector('.categories').classList.toggle("active__menu");
    // add / remove class .active__li
    var test = document.querySelectorAll("li");
    test.forEach(function(item)
    {
        item.classList.toggle("active__li");
    });
};


