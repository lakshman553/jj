<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Jeevanjyothi1.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Donor Registration</title>
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

        .vertical-alignment-helper {
    display:table;
    height: 100%;
    width: 100%;
    pointer-events:none; /* This makes sure that we can still click outside of the modal to close it */
}
.vertical-align-center {
    /* To center vertically */
    display: table-cell;
    vertical-align: middle;
    pointer-events:none;
}
.modal-content {
    /* Bootstrap sets the size of the modal in the modal-dialog class, we need to inherit it */
    width:inherit;
    height:inherit;
    /* To center horizontally */
    margin: 0 auto;
    pointer-events: all;
}
 
      body
      {
          background-image:url('images/brushed-alum-dark.png');
        background-position:top left;
        background-repeat:repeat;
        background-color:wheat;
    }
  </style>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
</head>
<body>
  <div class="container">

      <center>
      <img style="margin-top:5px;width:50%;height:120px" src="images/finalLogo.png" />
          </center>
</div>

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
                                <label class="col-lg-2 control-label">Gender<span class="text-danger"><sup><b>*</b></sup></span></label>
                                <div class="col-lg-8">
                                    <div class="btn-group " id="gender" data-toggle="buttons"  >

                                        <label class="btn btn-danger  btn-xs active">
                                            <input type="radio" name="genderRadio" value="M" required="required"/>
                                            Male
                                        </label>

                                        <label class="btn btn-danger  btn-xs active">
                                            <input type="radio" name="genderRadio" value="F" required="required"/>
                                            Female
                                        </label>
</div>
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
                                        <%--<input type="number"  class="form-control" required="required" id="mobileNo"/>--%>
                                        <input class="form-control" required="required" id="mobileNo" type="text" title="Mobile number shouldn't start with 0 or +91 and is of 10 digits" maxlength="10" pattern="[123456789][0-9]{9}" name="cvv"/>
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
                                <label class="col-lg-2 control-label">Father's Name</label>
                                <div class="col-lg-8">
                                    <input type="text" class="form-control" id="fathername"  />
                                    <span class="help-block">Enter your City</span>
                                </div>

                            </div>



                            <div class="form-group">
                                <label class="col-lg-2 control-label">Date of Birth</label>
                                <div class="col-lg-8">

                                    <input type="date" id="dob" class="form-control" />
                                    <span class="help-block">Select your date of birth in DD/MM/YYYY format</span>
                                </div>

                            </div>
                        <div class="form-group">
                                <label class="col-lg-2 control-label">Last Blood Donation</label>
                                <div class="col-lg-8">

                                    <input type="date" id="lastDonation" class="form-control" />
                                    <span class="help-block">Select the date when you last donated blood in DD/MM/YYYY format</span>
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


    <div class="modal fade" id="myModal">
        <div class="vertical-alignment-helper">
  <div class="modal-dialog vertical-align-center">
    <div class="modal-content">
      
      <div class="modal-body">
        <div id="modalContent"></div>
      </div>
      
    </div><!-- /.modal-content -->
  </div>
            </div><!-- /.modal-dialog -->
</div><!-- /.modal -->


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src='https://www.google.com/recaptcha/api.js'></script>

    <script>

        
        $(document).ready(function () {

            
            //});     
        });
    
        

        $(".form-horizontal").submit(function (e) {

            $('#modalContent').html('<center><i class="fa fa-spinner fa-pulse fa-2x"></i><br />Please Wait</center>');

            $('#myModal').modal({
                backdrop: 'static',
                keyboard: false
            })

            $('#myModal').modal();

            e.preventDefault();

            $('#clearButton').prop('disabled', true);
            $('#submitButton').prop('disabled', true);

            var posting = $.post('api/users',
                {
                    fullname: $('#fullName').val(),
                    mobile: $('#mobileNo').val(),
                    bloodgroup: $('input[name=bloodGrpRadio]:checked').val(),
                    gender: $('input[name=genderRadio]:checked').val(),
                    email: $('#inputEmail').val(),
                    city: $('#city').val(),
                    fathername: $('#fathername').val(),
                    dob: $('#dob').val(),
                    lbd: $('#lastDonation').val()
                });

            posting.done(function (data) {
                if (data.Id == 0) {
                    alert("User Not Created");
                }
                else
                {
                    $(".form-horizontal").trigger("reset");
                    $('#modalContent').html('');
                    $('#modalContent').html('<center><p>User Created Successfully</p><br /><a href="register.aspx">New Registration</a> | <a href="login.aspx">View Profile</a></center>');

                    $('#submitButton').prop('disabled', false);
                    $('#clearButton').prop('disabled', false);

                }
            });
        });


       
    </script>

    

</body>
</html>
