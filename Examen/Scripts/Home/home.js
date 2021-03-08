"use strict";
$(document).ready(function () {

    const CONTROLLER = "Home";

    const iniEventsTblProjecs = function () {
        $("#tblProjects").off("click", ".fa-edit")
        $("#tblProjects").on("click", ".fa-edit", function () {
            let idProject = $(this).attr("data-idproject")
            $.ajax({
                url: `${CONTROLLER}/EditProject`,
                data: { Id: idProject }
            }).done(function (response) {
                $("#dvAdd").hide();
                $("#dvEdit").html(response);
                $("#dvEdit").show();
                $("#addProject").modal("show")
            });
        })

        $("#tblProjects").off("click", ".fa-trash-alt")
        $("#tblProjects").on("click", ".fa-trash-alt", function () {
            let idProject = $(this).attr("data-idproject")
            console.log(idProject)
            $.confirm({
                title: "Eliminar proyecto",
                icon: "fa fa-question-circle",
                content: "¿Deseas eliminar el proyecto?",
                type: "red",
                typeAnimated: true,
                closeIcon: true,
                closeIconClass: "fa fa-close",
                columnClass: "col-md-4",
                buttons: {
                    cancelar: {},
                    eliminar: {
                        btnClass: "btn-danger",
                        action: function () {
                            $.ajax({
                                url: `${CONTROLLER}/DeleteProject`,
                                type: "POST",
                                data: { idProject: idProject }
                            }).done(function (response) {
                                if (response) {
                                    $.alert({
                                        title: "Proyecto eliminado",
                                        type: "green",
                                        content: "El proyecto se eliminó correctamente",
                                        buttons: {
                                            Ok: {
                                                action: function () {
                                                    window.location.reload();
                                                }
                                            }
                                        }
                                    })                                    
                                } else {
                                    $.alert({
                                        title: "Algo salió mal",
                                        type: "orange",
                                        content: "Intente más tarde"
                                    })
                                }
                            });
                        }
                    }
                }
            });


        })
    }

    $("#btnAddProject").click(function () {
        $("#frmAddProject").trigger("reset");
        $("#dvEdit").hide();
        $("#dvAdd").show();
    })

    $("#tblProjects").DataTable({
        "searching": true,
        "ordering": false,
        "info": false,
        "dom": "t<'bottom'ip>",
        "language": {
            "url": "/Content/plugins/datatable_language.json"
        },
        "ajax": {
            url: `${CONTROLLER}/LstProjects`,
            type: "POST",
            datatype: "json"
        },
        "columns": [
            {
                data: "NameProject",
            },
            {
                data: "Category.NameCategory",
            },
            {
                data: "ProjectID",
                render: function (data, type, row, meta) {
                    return '<i class="fas fa-edit" data-idproject=' + data + '></i>';
                },
            },
            {
                data: "ProjectID",
                render: function (data, type, row, meta) {
                    return '<i class="fas fa-trash-alt" data-idproject=' + data + '></i>';
                },
            }
        ],
        "columnDefs": [
            {
                targets: [2, 3],
                createdCell: function (td, cellData, rowData, row, col) {
                    $(td).addClass("text-center");
                }
            }
        ],
        "initComplete": function (settings, json) {
            iniEventsTblProjecs();
        }
    });
});