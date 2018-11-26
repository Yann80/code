// constants
const uri = "api/productdetails";
const labelRemove = "Remove from basket";
const labelAdd = "Add to shopping cart";

function buttonClick(productid) {
    switch ($(("#add-tocart-" + productid)).val()) {
        case labelAdd:
            addItem(productid);
            break;
        case labelRemove:
            deleteItem(productid);
            break;
    }
}

// Add product to shopping cart
function addItem(productid) {
    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(productid),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            $("#add-tocart-" + productid).prop('value', labelRemove);
            getCartContent();
        }
    });
}

// Remove product from shopping cart
function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id,
        type: "DELETE",
        success: function (result) {
            $("#add-tocart-" + id).prop('value', labelAdd);
            getCartContent();
        }
    });
}

// Clear shopping cart
function clearCart() {
    $.ajax({
        url: uri,
        type: "DELETE",
        success: function (result) {
            getCartContent();
            $("[id^=add]").prop('value', labelAdd);
        }
    });
}

// Get content of shopping cart
function getCartContent() {
    var contentString;
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            $('#cart-content').empty();
            $.each(data, function (i, item) {
                contentString += "<tr><td>" + data[i].productName + "</td></tr>";
            })
            $('#cart-content').html(contentString);
        }
    });
}