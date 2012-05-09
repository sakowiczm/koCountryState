/// <reference path="knockout-2.0.0.debug.js" />
/// <reference path="jquery-1.6.2.js" />

var my = {};

function MyViewModel() {
    var self = this;

    self.countries = ko.observableArray(countryList);
    self.choosenCountry = ko.observable();
    self.choosenState = ko.observable();
    self.states = ko.observable([]);

    self.choosenCountry.subscribe(function () {
        var country = self.choosenCountry();

        if (country != undefined) {
            $.getJSON('/Home/GetStates?countryCode=' + country.code, function (data) {
                self.states(data);
            });
        }

        self.states([]);
    });

    self.sendVisible = ko.computed(function () {
        return self.choosenCountry() != undefined && self.choosenState() != undefined;
    });

    self.sendSelection = function () {
        $.ajax({
            url: "/Home/SendSelection/",
            type: 'post',
            data: ko.toJSON({
                countryCode: self.choosenCountry().code,
                stateCode: self.choosenState().code
            }),
            contentType: 'application/json',
            success: function (result) {
                alert(result);
            },
            error: function (result) {
                alert('error:' + result);
            }
        });
    };
};


$(function () {
    ko.applyBindings(new MyViewModel());
});
