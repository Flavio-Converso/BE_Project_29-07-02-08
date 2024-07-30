let basePath = "/Products/GetProductsJson";

function getProductsList() {
    const productList = $('#productList');
   
    const loadingIndicator = $('#loadingIndicator');
    loadingIndicator.show();

    $.ajax({
        url: basePath,
        method: 'GET',
        success: (data) => {
            productList.empty(); 
            if (data.length > 0) {
                data.forEach(product => {
                    productList.append(`<li>${product.name} - $${product.price}</li>`);
                });
            } else {
                productList.append('<li>No products available</li>');
            }
        },
        error: (e) => {
            console.log('Error fetching products:', e);
            productList.empty();
            productList.append('<li>Error fetching products. Please try again later.</li>');
        },
        complete: () => {      
            loadingIndicator.hide();
        }
    });
}

$(document).ready(() => {
    getProductsList();
});
