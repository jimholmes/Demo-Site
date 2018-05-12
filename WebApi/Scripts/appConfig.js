var appConfig = function () {
    //var targetString = "http://demosite.com/api/contact/";

    //NOTE: https is **NOT** functional on Azure site at this time!
    var targetString = "http://jhdemos.azurewebsites.net/api/contact/";
       
    return {
        target: targetString
        // Examples of separating URLs out by function. Thanks to Ed Charbeneau
        //      for this entire example of separating out config settings.
        //readUri: readConnectionString //,
        // createUri: createConnectionString,
        // updateUri: updateConnectionString,
        // deleteUri: deleteConnectionString
    }
}();