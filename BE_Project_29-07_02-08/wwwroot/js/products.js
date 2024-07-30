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
                    const name = product.name;
                    const price = product.price;
                    const image = product.image || 'https://placehold.co/200'; //placeholder se non c'è l'immagine
                    const deliveryTime = product.deliveryTimeMin;

                    const ingredients = product.ingredients;
                    const ingredientsList = ingredients.map(ingredient => ingredient.name).join(', ');
                    //map: Trasforma ogni oggetto in un valore specifico (in questo caso, il nome dell'ingrediente).
                    //join: Combina tutti i valori in una singola stringa, con un separatore specificato(,).

                    //todo:
                    //
                    //productList.append
                    //    (` 
                    //    <li> ${name} </li>
                    //    <li> ${price} </li>
                    //    <li> <img src="${image}" alt="${name}" /> </li>
                    //    <li> ${deliveryTime} </li>
                    //    <li> ${ingredientsList} </li>      
                    //`);
                });
            } else {
                productList.append('<li>No products available</li>');
            }
        },
        error: (e) => {
            console.log('Error fetching products:', e);
            productList.empty();
            productList.append('<li>Unable to load products. Please try again later.</li>');
        },
        complete: () => {
            loadingIndicator.hide();
        }
    });
}

$(document).ready(() => {
    getProductsList();
});
