//Mendapatkan User Agent User di Browser
window.getUserAgent = () => {
    let resource = navigator.userAgent;
    let startIndex = resource.indexOf('(');
    let stopIndex = resource.indexOf(')');
    let Hasil = resource.substring(startIndex, stopIndex)

    return Hasil;
}