/// <reference path="knockout-2.0.0.debug.js" />

var my = {};
/*
var countryList = [
    { code: "CA", name: "Canada" },
    { code: "US", name: "United States" },
    { code: "UK", name: "United Kingdom" }
];
*/
var stateList = [
    { countryCode: "CA", code: "NU", name: "Nunavut" },
    { countryCode: "CA", code: "ON", name: "Ontario" },
    { countryCode: "CA", code: "QU", name: "Quebec" },
    { countryCode: "CA", code: "NS", name: "Nova Scotia" },
    { countryCode: "CA", code: "NB", name: "New Brunswick" },
    { countryCode: "CA", code: "MA", name: "Manitoba" },
    { countryCode: "CA", code: "PEI", name: "Prince Edward Island" },
    { countryCode: "CA", code: "SA", name: "Saskatchewan" },
    { countryCode: "CA", code: "AL", name: "Alberta" },
    { countryCode: "CA", code: "NL", name: "Newfoundland and Labrador" },

    { countryCode: "US", code: "NY", name: "New-York" },
    { countryCode: "US", code: "CA", name: "California" },
    { countryCode: "US", code: "WA", name: "Washington" },
    { countryCode: "US", code: "VE", name: "Vermont" },

    { countryCode: "UK", code: "BR", name: "Britian" },
    { countryCode: "UK", code: "NI", name: "Northern Ireland" },
    { countryCode: "UK", code: "SC", name: "Scotland" },
    { countryCode: "UK", code: "WA", name: "Wales" }
];

function MyViewModel() {
    this.countries = ko.observableArray(countryList);
    this.choosenCountry = ko.observable();
    this.choosenState = ko.observable();

    this.states = ko.computed(function () {
        var country = this.choosenCountry();

        if (country == undefined)
            return [];

        return ko.utils.arrayFilter(stateList, function (state) {
            return state.countryCode == country.code;
        });
    }, this);

    this.sendVisible = ko.computed(function () {
        return this.choosenCountry() != undefined && this.choosenState() != undefined;
    }, this);

    this.sendSelection = function () {
        $.ajax({
            url: "/Home/SendSelection/",
            type: 'post',
            data: ko.toJSON({
                countryCode: this.choosenCountry().code,
                stateCode: this.choosenState().code
            }),
            contentType: 'application/json',
            success: function (result) {
                alert(result);
            },
            error: function (result) {
                alert('error:' + result);
            }
        }, this);
    };
};

$(function () {
    ko.applyBindings(new MyViewModel());
});
