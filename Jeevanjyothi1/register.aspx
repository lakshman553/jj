<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Jeevanjyothi1.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css"/>--%>
    <link href="regass/css/bootstrap.css" rel="stylesheet" />
    <!-- Latest compiled and minified JavaScript -->
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
    </style>
</head>
<body>
    <div class="container">
        <br />
        <div class="col-lg-8 col-sm-12 col-md-12">
            <div class="panel panel-danger">
                <div class="panel-heading">Register As Donor</div>
                <div class="panel-body">
                    <form class="form-horizontal">
                        <fieldset>

                            <div class="form-group">

                                <label for="inputName" class="col-lg-2 control-label">Name<span class="text-danger"><sup>*</sup></span></label>
                                <div class="col-lg-8">
                                    <input type="email" class="form-control " id="inputName" />
                                    <span class="help-block ">Enter your full name</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Blood Group<span class="text-danger"><sup>*</sup></span></label>
                                <div class="col-lg-8">

                                    <div class="btn-group " data-toggle="buttons">

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            O +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            O -
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            A +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            A -
                                        </label>
                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            B +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            B -
                                        </label>
                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            AB +
                                        </label>

                                        <label class="btn btn-danger active">
                                            <input type="radio" name="options" />
                                            AB -
                                        </label>


                                    </div>
                                    <span class="help-block">Select your blood group</span>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-2 control-label">Mobile No.<span class="text-danger"><sup>*</sup></span></label>
                                <div class="col-lg-8">
                                    <div class="input-group">
                                        <span class="input-group-addon">+91</span>
                                        <input type="text" class="form-control" />
                                    </div>
                                    <span class="help-block">Enter your mobile number without +91</span>
                                </div>

                            </div>

                            
                            
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Current City<span class="text-danger"><sup>*</sup></span></label>
                                <div class="col-lg-8">

                                    <input type="text" class="form-control" />
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

                                    <input type="date" class="form-control" />
                                    <span class="help-block">Select your date of birth</span>
                                </div>

                            </div>

                            <br />
                            <div class="form-group">
                                <div class="col-lg-8 col-lg-offset-2">
                                    <button type="submit" class="btn btn-danger">Register</button>
                                    <button type="reset" class="btn btn-default">Cancel</button>
                                </div>
                            </div>
                        </fieldset>
                    </form>

                </div>
            </div>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

</body>
</html>
