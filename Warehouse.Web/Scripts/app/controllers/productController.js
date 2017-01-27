var ProductController = function (service) {
    var renderProducts = function (products, shopTitle, shopId) {
        var divContainer = $('#productsContainer');
        divContainer.empty();
        var h = document.createElement('h3');
        h.innerText = 'Products in "' + shopTitle + '"';
        divContainer.append(h);
        var table = document.createElement('table');
        table.className = 'table';
        table.dataset.shopId = shopId;
        var tbody = document.createElement("tbody");
        var trHeader = renderTableHeader();
        tbody.appendChild(trHeader);
        table.append(tbody);
        $.each(products,
            function (index, record) {
                if (record !== null) {
                    var tRow = renderRecord(record);
                    tbody.appendChild(tRow);
                }
            });
        divContainer.append(table);
        var hideLink = document.createElement('a');
        hideLink.href = '#';
        hideLink.className = 'js-clear-link pull-right';
        hideLink.innerText = "Hide";
        divContainer.append(hideLink);

        var addProductLink = document.createElement('a');
        addProductLink.href = '#';
        addProductLink.className = 'js-add-product-link pull-left';
        addProductLink.innerText = "Add product";
        divContainer.append(addProductLink);

    };

    function renderTableHeader() {
        var trHeader = document.createElement('tr');
        var thTitle = document.createElement('th');
        thTitle.innerText = 'Title';
        trHeader.appendChild(thTitle);
        var thDescription = document.createElement('th');
        thDescription.innerText = 'Description';
        trHeader.appendChild(thDescription);
        return trHeader;
    };

    function renderRecord(product) {
        var tRow = document.createElement('tr');
        tRow.dataset.productId = product.Id;
        var tdTitle = document.createElement('td');
        tdTitle.innerText = product.Title;
        tRow.appendChild(tdTitle);
        var tdDescription = document.createElement('td');
        tdDescription.innerText = product.Description;
        tRow.appendChild(tdDescription);
        return tRow;
    };

    // Show modal window to choose one of the new product for this shop. 
    // After user choose product, make ajax call to get product's data. 
    // Render it and append to the table.
    var showWhindowToChooseProduct = function (productsList) {

        var options = [{ text: "Choose one...", value: "" }];
        $.each(productsList,
            function (index, product) {
                options.push({ text: product.Title, value: product.Id });
            });

        bootbox.prompt({
            title: "Select new product",
            inputType: 'select',
            inputOptions: options,
            callback: function (result) {
                if (typeof result !== 'undefined' && result != null && result !== "") {
                    getProductsById(result);
                }
            }
        });
    };

    function apppendProductToTable(product) {
        var divContainer = $('#productsContainer');
        var tbody = divContainer.find('tbody');
        var tRow = renderRecord(product);
        tbody.append(tRow);
    };

    function getProductsById(productId) {
        var divContainer = $('#productsContainer');
        var table = divContainer.find('table');
        var shopId = table.attr('data-shop-id');
        service.getProductById( shopId, productId,
            function(result) {
                apppendProductToTable(result);
            },
            function() {
                bootbox.alert("Failed to get product.");
            });
    };


    var addProductOnClick = function (addProductLink) {
        /// Сделать ajax call и получить все товары которых нету у этого магазина
        /// Затем показать окно выбора товара и по нажатию на ок, добавить товар в таблицу товаров этого магазина и сохранить данные в базу данных
        var divContainer = addProductLink.parent();
        var table = divContainer.find('table');
        var shopId = table.attr('data-shop-id');
        service.getProductsNotInTheShop(shopId, showWhindowToChooseProduct, error);
    };


    function error() {
        bootbox.alert("Failed to load products.");
    }
    var showProductsTable = function (shopId, shopTitle) {
        service.getProductsInTheShop(
            shopId,
            function (data) {
                renderProducts(data, shopTitle, shopId);
                $('.js-clear-link ').click(function (e) {
                    e.preventDefault();
                    var divContainer = $('#productsContainer');
                    divContainer.empty();
                });
                $('.js-add-product-link').click(function (e) {
                    e.preventDefault();
                    addProductOnClick($(e.target));
                });
            },
            error);
    };
    return {
        showProductsTable: showProductsTable
    }
}(ProductService)