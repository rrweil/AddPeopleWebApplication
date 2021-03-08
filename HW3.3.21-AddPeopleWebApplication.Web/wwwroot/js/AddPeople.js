$(() => {

    let counter = 0;
    function addRows() {
        $("#ppl-rows").append(`<div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${counter+1}].firstname" placeholder="First Name" />
                            </div>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${counter + 1}].lastname" placeholder="Last Name" />
                            </div>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${counter+1}].age" placeholder="Age" />
                            </div>
                        </div>`)
        counter++;
    }

    $("#add-rows").on("click", function () {
        addRows();
    })
});