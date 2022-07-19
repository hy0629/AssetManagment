var tablebody = document.querySelector("#tablebody");
axios.get("/api/asset-api/asset-infos").then(response => {
    var d = response.data.data;
    var html = "";
    for (var i = 0; i < d.length; i++) {
        html += TablebodyHtml(headerDefined, d[i]);
    }

    tablebody.innerHTML = html;


}).catch(err => {

});

var head = document.querySelector("#tablehead");
head.innerHTML = TableHeadHtml(headerDefined);


function TableHeadHtml(list) {
    if (list == undefined) return;
    var keys = Object.keys(list);
    var headlist = keys.map(key => `<th>${list[key]}</th>`);
    return `<tr>${headlist.join('')}</tr>`;
}



function TablebodyHtml(list, data) {
    if (list == undefined) return "";

    var keys = Object.keys(list);

    var items = keys.map(key => `<td>${data[key] == null ? '' : data[key]}</td>`)
    return `<tr>${items.join('')}</tr>`;
}

