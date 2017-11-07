
var fetchInit = {
    method: 'GET',
    mode: 'cors',
    cache: 'no-cache'
};

var loadHtml = function (url, wrapper, currentCount, maxCount) {
    console.log(currentCount);
    if (currentCount >= maxCount) {
        return;
    }
    fetch(url, fetchInit)
        .then(function (response) {
            if (response.ok) {
                response.text().then(function (html) {
                    wrapper.innerHTML += html;
                });
                currentCount++;
                loadHtml(url, wrapper, currentCount, maxCount);
            }
            else {
                alert('Fetch failed!');
            }
        });
};

//var loadHtml = function (url, count, wrapper) {
//    for (var i = 0; i < count; i++) {
//        fetch(url, fetchInit)
//            .then(function (response) {
//                if (response.ok) {
//                    response.text().then(function (html) {
//                        wrapper.innerHTML += html;
//                    });
//                }
//                else {
//                    alert('Fetch failed!');
//                }
//            });
//    }
//};

var loadJSON = function (url, count, wrapper) {
    for (var i = 0; i < count; i++) {
        fetch(url, fetchInit)
            .then(function (response) {
                if (response.ok) {
                    response.json().then(function (json) {
                        wrapper.innerHTML += json;
                    });
                }
                else {
                    alert('Fetch failed!');
                }
            });
    }
};

document.getElementById("btnLoadHtmlLog").addEventListener("click", function (event) {
    loadHtml('/WithLog/GetChunk', document.getElementById('loggedHtmlList'), 0, 100);
    return false;
}, false);

document.getElementById("btnLoadHtmlNoLog").addEventListener("click", function (event) {
    loadHtml('/NoLog/GetChunk', document.getElementById('nonLoggedHtmlList'), 0, 100);
    return false;
}, false);