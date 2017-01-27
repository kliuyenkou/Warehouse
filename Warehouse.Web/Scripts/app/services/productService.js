var ProductService = function() {
    var getProductsInTheShop = function(shopId, success, error) {
        $.get("/shop/" + shopId + "/products")
            .done(success).fail(error);
    };
    var getProductsNotInTheShop = function (shopId, success, error) {
        $.get("/shop/" + shopId + "/products/add")
            .done(success).fail(error);
    };
    var getProductById = function(shopId, productId, success, error) {
        $.post("shop/addProduct", { shopId: shopId, productId: productId })
            .done(success).fail(error);
    };
    return {
        getProductsInTheShop: getProductsInTheShop,
        getProductsNotInTheShop: getProductsNotInTheShop,
        getProductById: getProductById
    };
}();