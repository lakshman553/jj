﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="donors.aspx.cs" Inherits="Jeevanjyothi1.donors" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Top Donors: Jeevanjyothi.org</title>
    
        <link href="regass/css/bootstrap.css" rel="stylesheet" />

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/jquery.dataTables.min.css" />


    <link href='http://fonts.googleapis.com/css?family=Limelight' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Nunito' rel='stylesheet' type='text/css'/>

    <link rel='stylesheet' href='css/animate.css' type='text/css' media='all' />
    <link rel="stylesheet" href="css/contact-buttons.css" />
    <link href="css/donoros.css" rel="stylesheet" />


</head>
<body>
<div class="container">

      <center>
      <img style="margin-top:5px;width:50%;height:120px" src="images/finalLogo.png" />
          </center>
</div>

    <br />
    <div class="container">
        <div class="row">
            <div class="titlebox animated fadeIn">
                    <h1 class="insetType">All Donors</h1>

        </div>
        </div>
        <div class="row">

            <div class="tablebox" >            <table id="example" class="table display " cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Name</th>
                <th>Mobile No</th>
                <th>Blood Group</th>
                <th>Donor City</th>
                <th>Donor Email</th>
                <th>Registered Date</th>
            </tr>
        </thead>

    </table>
        </div>
            </div>

        <br />
        <div class="row">
            <div class="titlebox animated fadeIn">
                    <h1 class="insetType">Top Donors</h1>

        </div>
        </div>
        <div class="row">

                <div class="col-lg-3 col-md-4 col-sm-6 animated flipInY">
                    <div id="card1">

                        <div class="front">
                            <div class="ribbon"><span>Top Donor</span></div>

                            <div class="box">
                                <img src="images/donoros/donor1.jpg" />
                                <div class="donorname text-center">Mahesh Kumar</div>
                            </div>

                        </div>
                        <div class="back">
                            <div class="box">
                                <div class="donorname text-center">Mahesh Kumar</div>
                                <div class="bloodgroup">AB+</div>
                                <div class="donationnum">4</div>
                                <div class="membersince">Aug 2015</div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-4 col-sm-6  animated flipInY">
                    <div id="card2">

                        <div class="front">
                            <div class="ribbon"><span>Top Donor</span></div>

                            <div class="box">
                                <img src="images/donoros/donor2.jpg" />
                                <div class="donorname text-center">Pinky Jain</div>
                            </div>

                        </div>
                        <div class="back">
                            <div class="box">
                                <div class="donorname text-center">Pinky Jain</div>
                                <div class="bloodgroup">B+</div>
                                <div class="donationnum">2</div>
                                <div class="membersince">Aug 2015</div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-4 col-sm-6  animated flipInY">
                    <div id="card3">
                        <div class="front">
                            <div class="ribbon"><span>Top Donor</span></div>

                            <div class="box">
                                <img src="images/donoros/donor3.jpg" />
                                <div class="donorname text-center">Kartik A</div>
                            </div>
                        </div>
                        <div class="back">
                            <div class="box">
                                <div class="donorname text-center">Kartik A</div>
                                <div class="bloodgroup">O+</div>
                                <div class="donationnum">6</div>
                                <div class="membersince">Aug 2014</div>

                            </div>
                        </div>
                    </div>
                </div>

        </div>

        


</div>


    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>

    <script type="text/javascript" src="js/jquery.backgroundPosition-1.21.js"></script>
    <script src="https://cdn.rawgit.com/nnattawat/flip/v1.0.16/dist/jquery.flip.min.js"></script>
    <script src="js/jquery.contact-buttons.js"></script>
    <script src="js/show-contact-buttons.js"></script>

    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>

    
    <script>

        $("#card1").flip({ trigger: 'hover' });
        $("#card2").flip({ trigger: 'hover' });
        $("#card3").flip({ trigger: 'hover' });

        $(document).ready(function () {
            var table = $('#example').DataTable({
                ajax: "getusers/",
                "columns": [
                { "data": "Name" },
                { "data": "Mobile_No" },
                { "data": "Blood_Group" },
                { "data": "Donor_City" },
                { "data": "Donor_Email" },
                { "data": "Registered_Date" }
                ]
            });

            //table.on('xhr', function () {
            //    var json = table.ajax.json();
            //    alert(json.data.length + ' row(s) were loaded');
            //});
        });

        

        //$("#card2").flip();
        //$("#card3").flip();

    </script>
</body>
</html>
