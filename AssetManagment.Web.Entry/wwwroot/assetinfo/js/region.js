var header = [
    {
        key: 'code',
        text: '编码',
        width: '80px'
    }, {
        key: 'name',
        text: '名称',
        width: '320px'
    }, {
        key: 'note',
        text: '备注'
    }, {
        key: 'action',
        text: '操作',
        fixed: 'right',
        width: '160px',
        template: function (title, obj) {
            var edit_btn = document.createElement('button');
            edit_btn.title = "编辑";
            edit_btn.classList.add('btn', 'btn-primary', 'btn-sm', 'mx-2');
            edit_btn.setAttribute('data-bs-whatever', 'update');
            edit_btn.setAttribute('data-bs-toggle', 'modal');
            edit_btn.setAttribute('data-bs-target', '#myAddRegionModal');
            edit_btn.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" width="12" height="12" fill="currentColor" class="bi bi-pencil-fill" viewBox="0 0 16 16"><path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" /></svg>';
            edit_btn.addEventListener('click', event => {
                //update
            });

            var del_btn = document.createElement('button');
            del_btn.title = "删除";
            del_btn.classList.add('btn', 'btn-danger', 'btn-sm', 'mx-2');
            del_btn.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" width="12" height="12" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16"><path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" /><path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/></svg>';
            del_btn.addEventListener('click', event => {
                //delete
            });
            var div = document.createElement('div');
            div.setAttribute('data-value', obj.value);
            div.setAttribute('data-code', obj.code);
            div.setAttribute('data-name', obj.name);
            div.setAttribute('data-note', obj.note);
            div.appendChild(edit_btn);
            div.appendChild(del_btn);
            return div;

        }
    }
];

var input_search_name = document.querySelector('.input-search-name');
var input_search_code = document.querySelector('.input-search-code');
var table = document.querySelector('#maintable');
var btn_search = document.querySelector('.btn-search');
var btn_reset = document.querySelector('.btn-reset');

btn_search.addEventListener('click', () => {
    GridManager.setQuery(table);
});

btn_reset.addEventListener('click', () => {
    input_search_code.value = "";
    input_search_name.value = "";
    GridManager.setQuery(table);
});



table.GM({
    gridManagerName: 'demo1',
    supportAdjust: false,
    supportDrag: true,
    autoOrderConfig: {
        fixed: 'left'
    },
    ajaxData: (settings, params) => {
        console.log(settings, params);
        var _query = { 'name': input_search_name.value, 'code': input_search_code.value };

        const url = "/api/region/get";
        return fetch(url).then(res => res.json()).then(res => {
            var data = res.data;
          
            data = data.filter(item => {
                return item.code.indexOf(_query.code) >= 0 && item.name.indexOf(_query.name) >= 0;
            });
            res.data = data;
            return res;
        });
    },
    columnData: header
});

var input_code = document.querySelector('.modal .input-code');
var input_name = document.querySelector('.modal .input-name');
var input_note = document.querySelector('.modal .input-note');

var add_region_btn = document.querySelector('#add_region_btn');
add_region_btn.addEventListener('click', function (event) {
    fetch("/api/region/add", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: 0, name: safeValue(input_name.value),
            code: safeValue(input_code.value),
            note: safeValue(input_note.value)
        })
    }).then(res => res.json()).then(res => {
        if (res.code == 200) {
            console.log(res.message);
        } else {
            alert(res.message);
        }
       });
});

var add_region_modal = document.querySelector('#myAddRegionModal');
add_region_modal.addEventListener('shown.bs.modal', (event) => {
    var btn = event.relatedTarget;
    var type = btn.getAttribute('data-bs-whatever');

    var title = document.querySelector('.modal .modal-title');

    if (type == 'add') {
        title.textContent = "添加区域";

        input_code.setAttribute('disabled', 'true');
        fetch("/api/region/code").then(res => res.json()).then(res => {
            if (res.code == 200) {
                input_code.value = res.data;
            }
            input_code.removeAttribute('disabled');
        });
    } else {
        title.textContent = "修改区域";
        var div = btn.parentElement;
        var code = div.getAttribute('data-code');
        var name = div.getAttribute('data-name');
        var value = div.getAttribute('data-value');
        var note = div.getAttribute('data-note');

        input_code.value = code;
        input_name.value = name;
        input_note.value = note;
    }

    
})

