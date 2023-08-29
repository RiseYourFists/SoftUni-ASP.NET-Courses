const btnMappings = {
    quantityWrappers: document.querySelectorAll('.quantity-wrapper'),
    cardOpenFormBtn: document.querySelectorAll('.open-form'),
    cardAddCancel: document.querySelectorAll('.add-cancel'),
}

btnMappings.quantityWrappers.forEach(wrapper =>{
    const addButton = wrapper.querySelector('.btn-add');
    const subtractButton = wrapper.querySelector('.btn-subtract');
    const inputElement = wrapper.querySelector('.num-input');
  
    addButton.addEventListener('click', function(e) {
      if(e) {
          e.preventDefault();
      }
      inputElement.value = parseInt(inputElement.value) + 1;
    });
  
    subtractButton.addEventListener('click', function(e) {
      if(e){
          e.preventDefault();
      }
      inputElement.value = Math.max(parseInt(inputElement.value) - 1, 0);
    });

})

btnMappings.cardOpenFormBtn.forEach(btn =>{
    btn.addEventListener('click', (e)=>{
        const id = e.target.parentNode.parentNode.parentNode.id;
        const selector = `#${id} form`;
        const form = document.querySelector(selector);
        e.target.style.display = 'none';
        form.style.display = 'block';
    })
})

btnMappings.cardAddCancel.forEach(btn => {
    btn.addEventListener('click', (e)=>{
        e.preventDefault();
        const id = e.target.parentNode.parentNode.parentNode.parentNode.parentNode.id;
        const card = document.getElementById(id);
        const form = card.querySelector('form');
        const openFormBtn = card.querySelector('.open-form');

        form.style.display = 'none';
        openFormBtn.style.display = 'flex';
    })
})
function testHandler(){}

function createElement(type, content, parentNode, classes, id, useInnerHtml){
    const element = document.createElement(type);
    if(content && useInnerHtml){
        element.innerHTML = content;
    }
    else{
        if(content && type !== 'input'){
            element.textContent = content;
        }
        if(content && type === 'input'){
            element.value = content;
        }
    }
    if(classes && classes.length > 0){
        element.classList.add(...classes);
    }
    if(id){
        element.setAttribute('id', id);
    }
    if(parentNode){
        parentNode.appendChild(element);
    }
    return element;
}


