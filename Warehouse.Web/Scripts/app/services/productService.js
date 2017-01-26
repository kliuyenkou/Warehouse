var ProductService = function() {
    var getProductsInTheShop = function(shopId, success, error) {
        $.get("/shop/" + shopId + "/products")
            .done(success).fail(error);
    };
    return {
        getProductsInTheShop: getProductsInTheShop
    };
}();