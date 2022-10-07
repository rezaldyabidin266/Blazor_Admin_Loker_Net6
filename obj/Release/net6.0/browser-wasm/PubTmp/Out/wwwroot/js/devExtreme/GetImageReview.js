function getImageBuffer() {

    var upload = document.querySelector('#uploadFile input');
    var textarea = document.querySelector('textarea');

    var arrayBuffer;

    upload.addEventListener('change', async (event) => {
        const buffer = await event.target.files[0].arrayBuffer()
        arrayBuffer = await new Int8Array(buffer);
        console.log(buffer)
        /*localStorage.setItem("arrayImage", arrayBuffer);*/
        try {
            var imgPreview = document.getElementById("imagePreview");
            imgPreview.src = URL.createObjectURL(event.target.files[0])
            const filereader = new FileReader();
            filereader.onload = function () {
                var comma = filereader.result.indexOf(',');
                var base64 = filereader.result.substr(comma + 1);
                console.log(filereader.result);
                localStorage.setItem("arrayImage", base64);
            }
            /*filereader.readAsText(event.target.files[0]);*/
            filereader.readAsDataURL(event.target.files[0])
        } catch (e) {

            DevExpress.ui.notify({
                message: "Tolong Pilih Gambar Kembali",
                type: "error",
                displayTime: 3000,
                width: 300
            });
            localStorage.setItem("errorUpload", "error");

        }
    }, false)


    return arrayBuffer
}