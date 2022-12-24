
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});



function CalculateTotal() {
    var iPrice = document.getElementsByClassName('ItemPrice');
    var iCount = document.getElementsByClassName('ItemCount');
    var totalPrice = 0;
    var rowPrice = 0;
    var i;

    for (i = 0; i < iPrice.length; i++) {
        rowPrice = eval(iPrice[i].value) * eval(iCount[i].value);
        totalPrice = totalPrice + rowPrice;
    }

    document.getElementById('Invoice.Total').value = totalPrice

    return;

}
document.addEventListener('change', function (e) {
    if (e.target.classList.contains('ItemPrice', 'ItemCount')) {
        CalculateTotal();
    }
}
    , false);



function DeleteItem(btn) {

    var table = document.getElementById('ExpTable');
    var rows = table.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("حذف این سطر ممکن نیست");
        return;
    }

    $(btn).closest('tr').remove();
    CalculateTotal();
}

function AddItem(btn) {
    var table = document.getElementById('ExpTable');
    var rows = table.getElementsByTagName('tr');

    var rowOuterHtml = rows[rows.length - 1].outerHTML;


    var lastrowIdx = rows.length - 2; //document.getElementById('hdnLastIndex').value;

    var nextrowIdx = eval(lastrowIdx) + 1;

    //document.getElementById('hdnLastIndex').value = nextrowIdx;

    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;


    //var btnAddId = btn.id;
    //var btnDeleteId = btnAddId.replaceAll('btnadd', 'btnremove');

    //var delbtn = document.getElementById(btnDeleteId);
    //delbtn.classList.add("visible");
    //delbtn.classList.remove("invisible");

    //var addbtn = document.getElementById(btnAddId);
    //addbtn.classList.remove("visible");
    //addbtn.classList.add("invisible");
}