//Mendapatkan user Track or Not
window.doNotTrack = () => {
    if (window.doNotTrack || navigator.doNotTrack || window.doNotTrack) {
        // The browser supports Do Not Track!
        if (window.doNotTrack == "1" || navigator.doNotTrack == "yes" || navigator.doNotTrack == "1" || window.doNotTrack == "1") {
            // Do Not Track is enabled!
            return true
        } else {
            // Do Not Track is disabled!
            return false
        }
    } else {
        // Do Not Track is not supported
        return false
    }
}