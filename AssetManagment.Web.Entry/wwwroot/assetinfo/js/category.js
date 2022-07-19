/*
function safeValue(value) {
    if (value == null || value == undefined) {
        return ""
    }
    return value;
}
function generateTable(list) {
    var str = "";
    list.forEach(data => {
        str += `<tr data-value="${safeValue(data.value)}"><td><input class="form-check-input" type="checkbox"/></td><td>${safeValue(data.code)}</td><td>${safeValue(data.name)}</td><td>${safeValue(data.note)}</td><td></td></tr>`
    });
    var tbody = document.querySelector("#tbody");
    var range = document.createRange();
    range.selectNodeContents(tbody);
    var doc = range.createContextualFragment(str);
    tbody.appendChild(doc);

}

var select_cbtn = document.querySelector('#select_cbtn');
registerSelectEvent(select_cbtn);
*/

var tbody = document.querySelector('tbody');
generateTableHead(headDefined.default, document.querySelector('thead'));

axios.get("/api/asset-api/category").then(response =>
{
    generateTableBody(headDefined.default, response.data.data, tbody);
   
}).catch(err => alert(err));

//registerSelectEvent(document.querySelector('table thead input[type="checkbox"]'));