function AppViewModel() {
    var NumeroLinhasPorPagina = 10;

    var self = this;
    self.IdLink = ko.observable("");
    self.Url = ko.observable("");
    self.DescricaoLink = ko.observable("");
    self.ComentarioLink = ko.observable("");
    self.Links = ko.observableArray([]);

    self.clickModalInsert = function (data, event) {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: "/Link/CadastrarLink/",
            dataType: "html",
            success: function (data) {
                $("#DialogModalBody").html(data);
            }
        });
    };

    self.ClickEditarLink = function (id) {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: "/Link/EditarLink/",
            dataType: "html",
            data: { 'IdLink': id },
            success: function (data) {
                $("#DialogModalBody").html(data);
            }
        });
    };

    self.ClickExcluirLink = function (id) {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: "/Link/ExcluirLink/",
            dataType: "html",
            data: { 'IdLink': id },
            success: function (data) {
                $("#DialogModalBody").html(data);
                $("#FormAjax").removeData("validator");
                $("#FormAjax").removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse($("#FormAjax"));
            }
        });
    };

    self.ClickSaveLink = function () {
        alert("asdf");
        //$.ajax({
        //    type: $('#FormAjax').attr('method'),
        //    url: $('#FormAjax').attr('action'),
        //    dataType: "json",
        //    data: $('#FormAjax').serialize(),
        //    beforeSend: function() {
        //        $("#loading").show();
        //    },
        //    success: function(data) {
        //        CarregaDados();
        //    },
        //    complete: function() {
        //        $("#loading").hide();
        //    }
        //});
    };



    self.ClickFiltro = function () {
        CarregaDados();
    };

    if ($(".render-html").length > 0) {
        CarregaDados();

        function CarregaDados() {
            $.ajax({
                type: "GET",
                url: "/Link/index",
                dataType: "json",
                data: { 'filtro': $("#txtConsulta").val(), "Pagina": 1 },
                beforeSend: function () {
                    $("#loading").show();
                },
                success: function (data) {
                    self.Links(data);
                    Pagination(data[0].TotalPage, NumeroLinhasPorPagina);
                },
                complete: function () {
                    $("#loading").hide();
                }
            });
        };

        /*----- CARREGA A PAGINAÇÃO -------------------------------------------------------------------------------------------*/
        function Pagination(NumeroLinhasEncontradas, NumeroLinhasPorPagina) {
            $("#PaginationLink").html('');
            $("#PaginationLink").html('<ul id="pagination"></ul>');

            if (NumeroLinhasEncontradas < 1)
                NumeroLinhasEncontradas = 1;

            $('#pagination')
                .twbsPagination({
                    totalPages: Math.ceil(NumeroLinhasEncontradas / NumeroLinhasPorPagina),
                    initiateStartPageClick: false,
                    startPage: 1,
                    visiblePages: 5,
                    href: false,
                    hrefVariable: '{{number}}',
                    first: '««',
                    prev: '«',
                    next: '»',
                    last: '»»',
                    loop: false,
                    paginationClass: 'pagination pagination-lg',
                    nextClass: 'next',
                    prevClass: 'prev',
                    lastClass: 'last',
                    firstClass: 'first',
                    pageClass: 'page',
                    activeClass: 'active',
                    disabledClass: 'disabled',
                    onPageClick: function(event, page) {
                        $.ajax({
                            type: 'GET',
                            url: "/Link/index",
                            dataType: "json",
                            data: { 'filtro': $("#txtConsulta").val(), "Pagina": page },
                            beforeSend: function() {
                                $('#loading').show();
                            },
                            success: function(data) {
                                self.Links(data);
                            },
                            complete: function() {
                                $('#loading').hide();
                            }
                        });
                    },
                });
        };
    };
};

var vm = new AppViewModel();
ko.applyBindings(vm);