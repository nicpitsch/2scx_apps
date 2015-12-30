/*
 * This is an example of a CONFIGURABLE custom input type in 2sxc
 * It will create a number-input with a dropdown showing a few numbers
 *
 * Field: Number  - tosic-dropdown (the configurable edition...)
 */
(function() {
    "use strict";

    angular.module("NPiCustomInputString", [])

	    // this is the registration section, so that formly knows there is such a field
      .config(function(formlyConfigProvider, defaultFieldWrappers) {

          formlyConfigProvider.setType({
              // the name, so that formly can find this input type
              name: "string-npi-image",

              // templates can be inline - like this:
              // template: "<div>example how to place the html inline in your js code, not recommended. Preferr the templateCache instead</div>",

              // ...or templaces can come from the $templateCache (preferred)
              templateUrl: "fields/string-npi-image/string-npi-image.html",

              // the defaultFieldWrappers add the normal label, multi-language etc. incl. future enhancements. Only use your own if you have a good reason
              wrapper: defaultFieldWrappers,
              controller: "FieldTemplate-String-Image"
          });
      })

      // The controller section - more or less the initialization
      .controller("FieldTemplate-String-Image", function($scope, $filter, $modal, appId, debugState, eavAdminDialogs) {
        // you can add custom controller code here. For inspiration, check out the controllers in the eav-project
        //alert("hey, i\'m string-npi-image.js");
  			// this will retrieve the settings which were made for this fields
  			var imageinfo;
  			var controlSettings = $scope.to.settings["string-npi-image"];
  			if (controlSettings) {
          imageinfo = {
            title: controlSettings.Title || "title",
            file: controlSettings.File || "file"
          }
        }
      })

      // example using an inline-template-cache
      .run(
        function($templateCache) {
            $templateCache.put('fields/string-npi-image/string-npi-image.html',
                "<form class=\"form-inline\" role=\"form\">  <div class=\"form-group\"><label>Title:</label><input type=\"text\" ng-model=\"value.Value\" class=\"form-control input-lg\"></div> <div class=\"form-group\"><label>File:</label><input type=\"text\" ng-model=\"value.Value\" class=\"form-control input-lg\"></div> </form>"
            );
      })
})();
