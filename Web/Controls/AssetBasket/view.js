var api = {
    email: function (basket) {
        alert('send email');
    }
};

var documentBasket = function () {

    var view = this;
    var api = api;
    var downloadUri = 'service endpoint for downloads';

    view.documents = ko.observableArray([]);
    view.fromAddress = ko.observable('').extend({ email: true, required: true });
    view.emailRecipients = ko.observableArray([]).extend({ required: true });

    view.recipientList = ko.computed(
        {
            read: function () {
                return view.emailRecipients().join();
            },
            write: function (value) {
                var recipientArr = [];
                var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                var tmpArr = value.split(',');
                for (var x in tmpArr) {
                    var r = $.trim(tmpArr[x]);
                    if (r.length > 0 && emailReg.test(r)) {
                        recipientArr.push(r);
                    }
                }
                view.emailRecipients(recipientArr);
            },
            deferEvaluation: true
        }
    );

    view.downloadUrl = ko.computed(
        {
            read: function () {

                var documentArray = [];
                for (var x in view.documents()) {
                    var resource = view.documents()[x].Path()
                    documentArray.push(encodeURIComponent(resource));
                }

                var qs = ['res', documentArray.join()].join('=');
                return [downloadUri, qs].join('?');
            },
            deferEvaluation: true
        }
    );

    view.isValid = function () {
        return view.errors().length === 0;
    };
    view.canProcess = function () {
        return view.documents().length > 0;
    };

    view.addDocument = function (doc) {
        var self = doc || this;
        self = ko.mapping.fromJS(self);
        if (view.isInBasket({ Name: self.Name(), Path: self.Path() }))
            return;
        view.documents.push(self);
        $.cookie('ss_document_basket', ko.mapping.toJS(view.documents()), { expires: 7, path: '/' });
    };

    view.removeDocument = function (doc) {
        var self = doc || this;
        self = ko.mapping.fromJS(self);
        view.documents.remove(function (item) {
            return item.Name() === self.Name() && item.Path() === self.Path();
        });
        $.cookie('ss_document_basket', ko.mapping.toJS(view.documents()), { expires: 7, path: '/' });
    };

    view.toggleDocument = function (doc) {
        var self = doc || this;
        self = ko.mapping.fromJS(self);
        if (view.isInBasket(self)) {
            view.removeDocument(doc);
        } else {
            view.addDocument(doc);
        }
    };

    view.emptyBasket = function () {
        view.documents([]);
        $.removeCookie('ss_document_basket', { path: '/' });
    };

    view.isInBasket = function (doc) {
        doc = ko.mapping.fromJS(doc);
        for (x in view.documents()) {
            var Name = view.documents()[x].Name();
            var Path = view.documents()[x].Path();

            if (doc.Name() === Name && doc.Path() === Path) {
                return true;
            }
        }
        return false;
    };
    view.clearEmailControlData = function () {
        view.fromAddress('');
        view.emailRecipients([]);
    };
    view.activateEmailControl = function () {
        $('.email-links-control').slideDown(500, 'swing');
    };

    view.emailLinks = function () {
        if (view.errors().length > 0) {
            $('.email-links-status').html('Invalid').slideDown(500, 'swing').delay(3000).slideUp(500, 'swing');
            return;
        }

        $('.email-links-control').slideUp(500, 'swing');
        $('.email-links-status').html('Sending Emails').slideDown(500, 'swing');

        api.email(
            {
                "basket": {
                    "FromAddress": view.fromAddress(),
                    "Recipients": ko.mapping.toJS(view.emailRecipients()),
                    "Resources": ko.mapping.toJS(view.documents())
                }
            },
            function (response) {

                $('.email-links-status').html(response.EmailDocumentsResult.Message).delay(3000).slideUp(500, 'swing', function () {
                    if (response.EmailDocumentsResult.Status !== 0) {
                        $('.email-links-control').slideDown(500, 'swing');
                    } else {
                        view.clearEmailControlData();
                    }
                });


            }, function () {
                $('.email-links-status').html(ss.resources.strings.documentBasket.error).delay(3000).slideUp(500, 'swing', function () {
                    $('.email-links-control').slideDown(500, 'swing');
                });
            });
    };

    view.cancelEmail = function () {
        $('.email-links-control').slideUp(500, 'swing');
    };
};