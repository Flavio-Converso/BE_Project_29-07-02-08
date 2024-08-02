let firstPath = '/Order/GetProcessedOrdersCount';

let secondPath = '/Order/GetTotalIncome';
function getProcessedOrdersCount() {
    $.ajax({
        url: firstPath,
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

function getTotalIncome() {
    let date = $('#dateInput').val(); 
    if (!date) {
        alert('Seleziona una data');
        return;
    }

    $.ajax({
        url: `${secondPath}?date=${date}`, 
        method: 'GET',
        success: (data) => {
            const countElement = $('#totalIncome');
            countElement.addClass('border border-dark px-2 fs-4');
            countElement.text(`Incassi per il ${date}: €${data}`);
        },
        error: (err) => {
            console.error('Error fetching total income:', err);
        }
    });
}

$('#btnGetTotalIncome').on('click', () => {
    getTotalIncome();
});

$('#btnGetProcessedCount').on('click', () => {
    getProcessedOrdersCount();
});

