$(document).ready(function () {
    
    var env = {
        staticMapKey: '',
    };

    // Import variables if present (from env.js)
    if (window.env) {
        Object.assign(env, window.env);
    }

    setTimeout(function () {
        var mapSrc = 'https://maps.googleapis.com/maps/api/staticmap?center=2500+Waters+Edge+Blvd+Columbus+OH+43209&zoom=12&size=500x300&maptype=roadmap&markers=color:red%7Clabel:A%7C2101+Integrity+Dr+S+Columbus+OH+43209&key=' + env.staticMapKey;

        $("#staticMap").attr("src", mapSrc);
    }, 300);
   

});
