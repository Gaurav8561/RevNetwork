////$(document).ready(function () {
////    SearchText();
////    SearchCode();
////});
////function SearchText() {
////    debugger;
////    $("#ContentPlaceHolder1_txtVoucherName").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                type: "POST",
////                contentType: "application/json; charset=utf-8",
////                url: "Voucher.aspx/getVoucherNames",
////                data: "{'Vouchertext':'" + document.getElementById('ContentPlaceHolder1_txtVoucherName').value + "'}",
////                dataType: "json",
////                success: function (data) {
////                    response(data.d);
////                },
////                error: function (result) {
////                    alert("Error");
////                }
////            });
////        }
////    });
////};
////function SearchCode() {
////    $("#ContentPlaceHolder1_txtVoucherCode").autocomplete({
////        source: function (request, response) {
////            $.ajax({
////                type: "POST",
////                contentType: "application/json; charset=utf-8",
////                url: "Voucher.aspx/getVoucherCode",
////                data: "{'VoucherCode':'" + document.getElementById('ContentPlaceHolder1_txtVoucherCode').value + "'}",
////                dataType: "json",
////                success: function (data) {
////                    response(data.d);
////                },
////                error: function (result) {
////                    alert("Error");
////                }
////            });
////        }
////    });
////}

//$(document).ready(function () {
//    GetCustomers();
//});

$(function () {
    GetCustomers();
});

$("[id*=txtVoucherName]").live("keyup", function () {
    GetCustomers();
});


function SearchTerm() {
    return jQuery.trim($("[id*=txtVoucherName]").val());
};

function GetCustomers() {
    $.ajax({
        type: "POST",
        url: "Voucher.aspx/GetVoucherName",
        data: '{searchTerm: "' + SearchTerm() + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
}
var row;
function OnSuccess(response) {
    var xmlDoc = $.parseXML(response.d);
    var xml = $(xmlDoc);
    var customers = xml.find("tbl_Voucher");
    if (row == null) {
        row = $("#dvVoucher table").eq(0).clone(true);
    }
    $("#dvVoucher").empty();
    if (customers.length > 0) {
        customers.each(function () {
            var customer = $(this);
            $(".card-title", row).html(customer.find("VoucherName").text());
            $("#txtMaxDiscountValue", row).html(customer.find("VoucherDiscountAmount").text());
            $("#txtClaimableQuantity", row).html(customer.find("VoucherUsage").text());
            $("#txtMaxPerUser", row).html(customer.find("VoucherLimit").text());
            $("#txtValidFrom", row).html(customer.find("VoucherValidFrom").text());
            $("#txtExpiredDate", row).html(customer.find("VoucherValidTo").text());
            $("#dvVoucher").append(row).append("<br />");
            row = $("#dvVoucher table").eq(0).clone(true);
        });
    }
    else {
        //var empty_row = row.clone(true);
        //$("td:first-child", empty_row).attr("colspan", $("td", row).length);
        //$("td:first-child", empty_row).attr("align", "center");
        //$("td:first-child", empty_row).html("No records found for the search criteria.");
        //$("tr", empty_row).not($("tr:first-child", empty_row)).remove();
        //$("[id*=dvVoucher]").append(empty_row);
    }
}