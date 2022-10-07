function getLocation() {
    var errorMessage = '';
    var data = {
        Longitude: 0,
        Latitude: 0,
        Remarks: ""
    };
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var lat = position.coords.latitude;
            var long = position.coords.longitude;

            data = {
                Longitude: long,
                Latitude: lat,
                Remarks: "Sukses"
            };
            localStorage.setItem("Koordinat", JSON.stringify(data));
        },
            function (error) {
                if (error.code === 1) {
                    errorMessage = "User denied the request for Geolocation.";
                } else if (window.err.code === 2) {
                    errorMessage = "Location information is unavailable.";
                } else if (window.err.code === 3) {
                    errorMessage = "The request to get user location timed out.";
                } else {
                    errorMessage = "An unknown error occurred.";
                }
                data = {
                    Longitude: 0,
                    Latitude: 0,
                    Remarks: errorMessage
                };

                localStorage.setItem("Koordinat", JSON.stringify(data));
            });

    } else {
        errorMessage = "Geolocation is not supported by this browser.";

        data = {
            Longitude: 0,
            Latitude: 0,
            Remarks: errorMessage
        };
        localStorage.setItem("Koordinat", JSON.stringify(data));
    }

}