$(document).ready(function () {
    // Initialize DataTables
    const table = $('.table').DataTable();

    // Verify if DataTables initialized correctly
    if (table) {
        console.log('DataTables se ha inicializado correctamente.');
    } else {
        console.log('Error al inicializar DataTables.');
    }

    // Column highlighting functionality
    const headerCells = document.querySelectorAll('.header-cell');
    headerCells.forEach(headerCell => {
        headerCell.addEventListener('click', function () {
            const columnIndex = headerCell.getAttribute('data-column-index');
            const columnCells = document.querySelectorAll('.column-' + columnIndex);
            columnCells.forEach(cell => {
                cell.classList.toggle('highlight');
            });
        });
    });
});