var ProductController = function (service) {
    var renderProducts = function (products, shopTitle) {
        var divContainer = $('#productsContainer');
        divContainer.empty();
            var h = document.createElement('h3');
            h.innerText = 'Products in ' + shopTitle;
            divContainer.append(h);
            var table = document.createElement('table');
            table.className = 'table';
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
    }

    function renderTableHeader() {
        var trHeader = document.createElement('tr');
        var thTitle = document.createElement('th');
        thTitle.innerText = 'Title';
        trHeader.appendChild(thTitle);
        var thDescription = document.createElement('th');
        thDescription.innerText = 'Description';
        trHeader.appendChild(thDescription);
        return trHeader;
    }
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
    }

    var error = function() {
        alert("Failed to load products.");
    }
    var showProductsTable = function (shopId, shopTitle) {
        service.getProductsInTheShop(shopId, function(data) { renderProducts(data, shopTitle); }, error);
    };
    return {
        showProductsTable: showProductsTable
    }
}(ProductService)