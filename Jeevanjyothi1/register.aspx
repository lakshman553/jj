<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Jeevanjyothi1.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Donor Registration</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <link href="regass/css/bootstrap.css" rel="stylesheet" />

    <style>
        input[type=number]::-webkit-inner-spin-button,
        input[type=number]::-webkit-outer-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        ::-webkit-datetime-edit-year-field:not([aria-valuenow]),
        ::-webkit-datetime-edit-month-field:not([aria-valuenow]),
        ::-webkit-datetime-edit-day-field:not([aria-valuenow]) {
            color: transparent;
        }

        .regcenter {
     float: none;
     margin-left: auto;
     margin-right: auto;
}

        .centercontents {
    text-align: center !important;
}
    </style>

</head>
<body>
    <div class="container">
        <br />
        <div class="col-lg-offset-2  ">
        <div class="col-lg-10 col-sm-12 col-md-12">
            <div class="panel panel-danger">
                <div class="panel-heading">Register As Donor</div>
                <div class="panel-body">
                    <form class="form-horizontal" >

                            <div class="form-group">

                                <label for="fullName" class="col-lg-2 control-label">Name<span class="text-danger"><sup><b>*</b></sup></span></label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control " id="fullName" required="required" />
                                    <span class="help-block ">Enter your full name</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Blood Group<span class="text-danger"><sup><b>*</b></sup></span></label>
                                <div class="col-lg-8">
                                    <div class="btn-group " id="bloodGrpDiv" data-toggle="buttons"  >

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="1" required="required"/>
                                            O +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="2" required="required"/>
                                            O -
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="3" required="required"/>
                                            A +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="4" required="required"/>
                                            A -
                                        </label>
                                        
                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="5" required="required"/>
                                            B +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="6" required="required"/>
                                            B -
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="7" required="required"/>
                                            AB +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="bloodGrpRadio" value="8" required="required"/>
                                            AB -
                                        </label>

                                    </div>
                                    <span class="help-block">Select your blood group</span>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Mobile No.<span class="text-danger"><sup><b>*</b></sup></span></label>
                                <div class="col-lg-8">
                                    <div class="input-group">
                                        <span class="input-group-addon">+91</span>
                                        <input type="number" class="form-control" required="required" id="mobileNo"/>
                                    </div>
                                    <span class="help-block">Enter your mobile number without +91</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Current City<span class="text-danger"><sup><b>*</b></sup></span></label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" id="city"  required="required"/>
                                    <span class="help-block">Enter your City</span>
                                </div>

                            </div>

                            <div class="form-group">

                                <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                                <div class="col-lg-8">
                                    <input type="email" class="form-control" id="inputEmail" />
                                    <span class="help-block">Enter your email address</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Date of Birth</label>
                                <div class="col-lg-8">

                                    <input type="date" id="dob" class="form-control" />
                                    <span class="help-block">Select your date of birth</span>
                                </div>

                            </div>
                        <div class="form-group">
                                <label class="col-lg-2 control-label">Last Blood Donation</label>
                                <div class="col-lg-8">

                                    <input type="date" id="lastDonation" class="form-control" />
                                    <span class="help-block">Select the date when you last donated blood</span>
                                </div>

                            </div>
                              <%--<div class="form-group">
                                <label class="col-lg-2 control-label">&nbsp;</label>
                                <div class="col-lg-8">

                            <div class="g-recaptcha" data-size="normal" data-sitekey="6Lfsxw0TAAAAAMss0Bp_MXgkkokiHyIkfBISTz2X"></div>
                                    <span class="help-block">Please select the check-box </span>

                                    </div>  
                        </div>--%>
                            <br />
                            <div class="form-group">
                                <div class="col-lg-8 col-lg-offset-2">
                                    <button type="submit" id="submitButton" class="btn btn-danger">Register</button>
                                    <button type="reset" id="clearButton" class="btn btn-default">Cancel</button>
                                    <span class="help-block">By clicking on register, you agree to the Terms & Conditions of Jeevanjyothi.Org</span>
                                
                                </div>
                            </div>
                    </form>

                </div>
            </div>
        </div>
    </div>
        </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src='https://www.google.com/recaptcha/api.js'></script>

    <script>
        $(document).ready(function () {

            
            //});     
        });
        

        $(".form-horizontal").submit(function (e) {
            e.preventDefault();

            $('#clearButton').prop('disabled', true);
            $('#submitButton').prop('disabled', true);

            var posting = $.post('api/users', { fullname: $('#fullName').val(), mobile: $('#mobileNo').val(), bloodgroup: $('input[name=bloodGrpRadio]:checked').val(), email: $('#inputEmail').val(), city: $('#city').val(), dob: $('#dob').val(), lbd: $('#lastDonation').val() });

            posting.done(function (data) {
                if (data.Id == 0) {
                    alert("User Not Created");
                }
                else
                {
                    $(".form-horizontal").trigger("reset");
                    alert("User Created Successfully");

                    $('#submitButton').prop('disabled', false);
                    $('#clearButton').prop('disabled', false);

                }
            });
        });


       
    </script>

    

</body>
</html>
