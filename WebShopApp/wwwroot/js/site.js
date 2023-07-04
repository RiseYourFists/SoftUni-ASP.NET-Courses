// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const openDialogBtn = document.querySelector('[data-open-modal]');
const closeDialogBtn = document.querySelector('[data-close-modal]');
const modal = document.querySelector("[data-modal]")

openDialogBtn.addEventListener('click', dialogHandler);
closeDialogBtn.addEventListener('click', closeDialogHandler);

function dialogHandler(){
    modal.showModal();
}

function closeDialogHandler(){
    modal.close();
}
