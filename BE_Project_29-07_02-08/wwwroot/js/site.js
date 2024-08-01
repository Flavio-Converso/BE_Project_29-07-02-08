let basePath = '/Order/GetProcessedOrdersCount';



function getProcessedOrdersCount() {
    $.ajax({
        url: basePath,
        method: 'GET',
        success: (data) => {
            const countElement = $('#processedOrdersCount');
            countElement.addClass('border border-dark px-2 fs-4');
            countElement.text(data); 
        },
        error: (err) => {
            console.error('Error fetching processed orders count:', err);
        }
    });
}


$('#btnGetProcessedCount').on('click', () => {
    getProcessedOrdersCount();
});