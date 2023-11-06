const btnMappings = {
    categoryBtns: document.querySelectorAll('.category-btn'),
    dropdownCloseBtns: document.querySelectorAll('.dropdown-close')
}

const inputMappings = {
    previewImgInput: document.querySelector('.preview-img-input'),
    autoSelectSubmit: document.querySelectorAll('.on-change-select')
}

const elementMapping = {
    previewImg: document.querySelectorAll('.dropdown-wrapper'),
    dropdownElements: document.querySelectorAll('.dropdown-wrapper')
}

const modalBinders = {
    expansionWindows: document.querySelectorAll('.expansion-wrapper'),
    quantityWrappers: document.querySelectorAll('.quantity-wrapper'),
    searchBars: document.querySelectorAll('.search-bar'),
    pageBars: document.querySelectorAll('.pages-bar ul')
}

if (inputMappings.previewImgInput) { /*Custom functionality */
    changeImg();

    inputMappings.previewImgInput.addEventListener('change', () => {
        changeImg();
    });
    
    function changeImg(){
        const image = document.querySelector('.preview-img');
        image.style.display = 'block';
        const value = inputMappings.previewImgInput.value;
        image.setAttribute('src', value);
    }
}

inputMappings.autoSelectSubmit.forEach(select => { /* Custom functionality*/

    select.addEventListener('change', () => {
        let id = select.getAttribute('data-input')
        const input = document.getElementById(id);
        input.value = select.value;
        document.querySelector('.auto-submit').submit();
    })
})

btnMappings.dropdownCloseBtns.forEach(btn => {
    btn.addEventListener('click', (e) => {
        e.target.blur()
    })
})

btnMappings.categoryBtns.forEach(btn => { /*Custom functionality */
    btn.addEventListener('click', () => {
        const input = document.getElementById('category-id');
        document.querySelector('input[data-result-hook="1"]').value = '1';
        input.value = btn.getAttribute('data-value');
        document.querySelector('.auto-submit').submit();
    })
})

elementMapping.previewImg.forEach(img => { /*Default style modification */
    img.addEventListener('error', () => {
        img.style.display = 'none';
    })
});

elementMapping.dropdownElements.forEach(element => {
    const container = element.querySelector('.dropdown-container');
    const content = element.querySelector('.dropdown-content');
    container.addEventListener('transitionend', () => {

        if (container.clientHeight >= 300) {
            content.style.overflowY = 'auto';
        }
    })
})

modalBinders.expansionWindows.forEach(window => { /*Expanding window script */
    const button = window.querySelector('.expansion-window button');
    const expansionContainer = window.querySelector('.expansion-container');

    button.addEventListener('click', () => {
        const isFolded = window.getAttribute('data-att-folded');
        const foldIcon = window.querySelector('.expansion-window .fold-icon');
        const container = window.querySelector('.content');

        if (isFolded === "false") {
            container.style.display = 'none';
            window.setAttribute('data-att-folded', true);
            expansionContainer.classList.add('closed');
            foldIcon.classList.remove('rotate180');
        }
        else {
            window.setAttribute('data-att-folded', false);
            expansionContainer.classList.remove('closed')
            foldIcon.classList.add('rotate180');
            container.style.display = 'flex';
        }
    })
})

modalBinders.searchBars.forEach(bar => { /*Searchbar script */
    const clearBtn = bar.querySelector('.clear');
    const input = bar.querySelector('.wrapper input[type="text"]');
    
    clearBtn.addEventListener('click', (e) => {
        e.preventDefault();
        input.value = "";
        clearBtn.style.display = 'none';
    })

    input.addEventListener('keyup', ()=>{
        if(input.value.length > 0){
            clearBtn.style.display = 'flex';
            return;
        }
        
        clearBtn.style.display = 'none';
    })
})

modalBinders.quantityWrappers.forEach(wrapper => { /*Number input script*/
    const addButton = wrapper.querySelector('.btn-add');
    const subtractButton = wrapper.querySelector('.btn-subtract');
    const inputElement = wrapper.querySelector('.num-input');
    resize();

    if(inputElement.value === ''){
        inputElement.value = 0;
    }

    inputElement.addEventListener('keyup', ()=>{
        resize();
    })

    inputElement.addEventListener('change', () => {
        if (inputElement.value === '') {
            inputElement.value = 0;
        }
    });

    addButton.addEventListener('click', function (e) {
        if (e) {
            e.preventDefault();
        }
        inputElement.value = parseInt(inputElement.value) + 1;
        resize();
    });

    subtractButton.addEventListener('click', function (e) {
        if (e) {
            e.preventDefault();
        }
        inputElement.value = Math.max(parseInt(inputElement.value) - 1, 0);
        resize();
    });

    function resize(){
        if(inputElement.value === '') return;
        let width = inputElement.value.length * 16;
        width =  Math.max(40, Math.min(200, width));
        inputElement.style.width = width + 'px';
    }

})

modalBinders.pageBars.forEach(bar => { /*Pagination script*/
    const hook = bar.getAttribute('data-result-hook');
    let currentPage = Number(bar.getAttribute('data-current-page'));
    const lastPage = bar.getAttribute('data-last-page');

    const startBtn = bar.querySelector('.page-start');
    const endBtn = bar.querySelector('.page-end');

    startBtn.addEventListener('click', () => {
        const value = startBtn.getAttribute('data-page');
        changePage(value);
    })

    endBtn.addEventListener('click', () => {
        const value = endBtn.getAttribute('data-page');
        changePage(value);
    })

    bar.querySelector('.page-next').addEventListener('click', () => {
        let value = currentPage + 1;
        if (value > lastPage) {
            value = lastPage;
        }

        changePage(value);
    })

    bar.querySelector('.page-back').addEventListener('click', () => {
        let value = currentPage - 1;
        if (value < 1) {
            value = 1;
        }

        changePage(value);
    })

    bar.querySelectorAll('.page-option').forEach(btn => {
        btn.addEventListener('click', () => {
            const value = btn.getAttribute('data-page');
            changePage(value);
        })
    })

    function changePage(page) {
        const resultInput = document.querySelector(`input[data-result-hook="${hook}"]`);
        resultInput.value = page;
        document.querySelector('.auto-submit').submit();
    }
})

function createElement(type, content, parentNode, classes, id, useInnerHtml) {
    const element = document.createElement(type);
    if (content && useInnerHtml) {
        element.innerHTML = content;
    }
    else {
        if (content && type !== 'input') {
            element.textContent = content;
        }
        if (content && type === 'input') {
            element.value = content;
        }
    }
    if (classes && classes.length > 0) {
        element.classList.add(...classes);
    }
    if (id) {
        element.setAttribute('id', id);
    }
    if (parentNode) {
        parentNode.appendChild(element);
    }
    return element;
}