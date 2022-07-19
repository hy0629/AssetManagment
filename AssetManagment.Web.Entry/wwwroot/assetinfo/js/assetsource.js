initTable(document.querySelector('table'), headDefined.default);

axios.get("/api/asseetsource/get").then(response => {
    document.querySelector('table').initData(response.data.data);
}).catch(err => {

});