(function () {

    let oReq = new XMLHttpRequest();
    oReq.addEventListener("load", reqListener);
    oReq.open("GET", '/api/data.json');
    oReq.send();

    function reqListener () {
        outputList(JSON.parse(this.responseText));
    }

    function outputList (data) {
        const tableBody = document.querySelector('tbody');
        tableBody.innerHTML += generateList(data);
    }

    function generateList (data) {
        let list = '';
        for (let i = 0; i <= Object.keys(data).length - 1; i++) {
            list += generateListItem(data, i);
        }
        return list;

    }

    function generateListItem (data, i) {
        return (
            `<tr>
                <td>
                    <input ${data[i].complete ? 'checked' : ''} type="checkbox" />
                </td>
                <td>
                    ${data[i].description}
                </td>
                <td>
                    ${data[i].deadline}
                </td>
            </tr>`
        );
    }
}());