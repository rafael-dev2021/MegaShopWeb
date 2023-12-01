
/*beginning GetProductsListModalPartial.cshtml*/
document.addEventListener('DOMContentLoaded', () => {
    const showDetailModels = document.querySelectorAll('.showDetailModel');

    showDetailModels.forEach(model => {
        model.addEventListener('click', (event) => {
            event.preventDefault(); // Evitar o comportamento padrão de âncoras

            const id = model.dataset.id;
            const modal = new bootstrap.Modal(document.getElementById(`showModal_${id}`));
            modal.show();
        });
    });
});

/*end GetProductsListModalPartial.cshtml*/