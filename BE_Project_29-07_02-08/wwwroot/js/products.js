let basePath = "/Products/GetProductsJson";

function getProductsList() {
    $.ajax({
        url: basePath,
        method: 'GET',
        success: (data) => {
            const productList = $('#productList');
            productList.empty(); 
            data.forEach(product =>
            {
                productList.append(`<li>${product.name} - $${product.price}</li>`);//todo
            });
        },
        error: (e) => console.log('Error fetching products:', e)
    });
}
$(document).ready(() => {
    getProductsList();
});

