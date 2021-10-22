

$(document).ready(function () {   
    //SearchText();
    //SearchCode();
    $("#txtVoucherName").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Voucher.aspx/getVoucherNames",
                data: "{'Vouchertext':'" + document.getElementById('txtVoucherName').value + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    });
});
function SearchText() {
    $("#txtVoucherName").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Voucher.aspx/getVoucherNames",
                data: "{'Vouchertext':'" + document.getElementById('txtVoucherName').value + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    });
};
function SearchCode() {
    $("#txtVoucherCode").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Voucher.aspx/getVoucherCode",
                data: "{'VoucherCode':'" + document.getElementById('txtVoucherCode').value + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    });
}