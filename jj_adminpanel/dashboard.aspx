<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="jj_adminpanel.dashboard" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/css/materialize.min.css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>

</head>
<body>
    <div class="container">
    <div class="row">
        <div class="col s12 m6 l6">
          <div class="card white darken-1">
            <div class="card-content ">
              <span class="card-title green-text">SMS Usage</span>
                        <div id="piechart" ></div>
            </div>
            
          </div>
        </div>
        <div class="col s12 m6 l12">
<div class="card white darken-1">
            <div class="card-content ">
                    

              <span class="card-title green-text">Donors by Blood Group</span>
                          <div id="chart_div"></div>

            </div>
            
          </div>




        </div>
      </div>

        <div class="row">
        <div class="col s12 m12 l12">
            <div class="card white darken-1">
            <div class="card-content ">
              <span class="card-title green-text">Documents List</span>

            <table class="bordered striped">
        <thead>
          <tr>
              <th data-field="id">No</th>
              <th data-field="name">Document Purpose</th>
              <th data-field="price">Upload Date</th>
              <th data-field="price">Download</th>
              <th data-field="price">Delete</th>

          </tr>
        </thead>

        <tbody>
          <tr>
            <td>1</td>
            <td>Account Statement 2015 - 16</td>
            <td>01-09-2015</td>
            <td class="centered">
              <i class="small material-icons">system_update_alt</i>

            </td>

            <td class="centered">
              <i class="small material-icons">delete</i>

            </td>
  
          </tr>
            <tr>
            <td>2</td>
            <td>Website Hosting Invoice</td>
            <td>22-05-2015</td>
                          <td class="centered">
              <i class="small material-icons">system_update_alt</i>

            </td>

            <td class="centered">
              <i class="small material-icons">delete</i>

            </td>
  
          </tr>
          <tr>
            <td>3</td>
            <td>SMS Package Invoice</td>

            <td>25-09-2015</td>
                        <td class="centered">
              <i class="small material-icons">system_update_alt</i>

            </td>

            <td class="centered">
              <i class="small material-icons">delete</i>

            </td>
  
          </tr>
        </tbody>
      </table>
        </div>
                <div class="card-action">
              <a href="#">Upload a new file</a>
            </div>
</div>
</div>
</div>

        <div class="row">
            <div class="col l12 s12 m12">
      <div class="card white darken-1">
            <div class="card-content ">

             <form action="#">
    <div class="file-field input-field">
      <div class="btn">
        <span>File</span>
        <input type="file"/>
      </div>
      <div class="file-path-wrapper">
        <input class="file-path validate" type="text"/>
      </div>
    </div>


  </form>
                <div class="row">
                 <div class="input-field col s8">
      <input  id="first_name2" type="text" class="validate"/>
      <label class=" active" for="first_name2">Document Title</label>
    <button class="btn col s4" value="">Upload</button>
                 </div>
                 </div>
                </div>
          </div>
                </div>
        </div>

        <div class="row">
        <div class="col s12 m12 l12">
            <div class="card white darken-1">
            <div class="card-content ">
              <span class="card-title green-text">Blood Request Report</span>

            <table class="bordered striped">
        <thead>
          <tr>
              <th data-field="id">No</th>
              <th data-field="name">Requester Name</th>
              <th data-field="price">Mobile No</th>
              <th data-field="price">City</th>
              <th data-field="price">Blood Group</th>
              <th data-field="price">Date Time</th>
              <th data-field="price">SMS Details</th>

          </tr>
        </thead>

        <tbody>
          <tr>
              <td>1</td>
              <td>Suresh Krishna</td>
              <td>8976435612</td>
              <td>Hyderabad</td>
              <td>B +Ve</td>
              <td>25-09-15 12:45 PM</td>
              <td><i class="small material-icons">trending_up</i></td>
          </tr>
                      <tr>
              <td>2</td>
              <td>Mahesh Kumar</td>
              <td>9976634336</td>
              <td>Hyderabad</td>
              <td>O +Ve</td>
              <td>25-09-15 11:15 AM</td>
              <td><i class="small material-icons">trending_up</i></td>
          </tr>
            <tr>
              <td>3</td>
              <td>Satish K</td>
              <td>8981068386</td>
              <td>Hyderabad</td>
              <td>O +Ve</td>
              <td>25-09-15 11:10 AM</td>
              <td><i class="small material-icons">trending_up</i></td>
          </tr>

            <tr>
              <td>4</td>
              <td>Pradeepta Kumari</td>
              <td>8985668386</td>
              <td>Hyderabad</td>
              <td>AB +Ve</td>
              <td>25-09-15 10:23 AM</td>
              <td><i class="small material-icons">trending_up</i></td>
          </tr>
        </tbody>
      </table>
        </div>
                
</div>
</div>
</div>

        <div class="row">
        <div class="col s12 m12 l12">
            <div class="card white darken-1">
            <div class="card-content ">
              <span class="card-title green-text">SMS Delivery Status</span>

            <table class="bordered striped condensed">
        <thead>
          <tr>
              <th data-field="id">No</th>
              <th data-field="name"> Name</th>
              <th data-field="price">Mobile No</th>
              <th data-field="price">Date Time</th>
              <th data-field="price">SMS Status</th>

          </tr>
        </thead>

        <tbody>
          <tr>
              <td>1</td>
              <td>Madan Gopal</td>
              <td>8976435126</td>
              <td>25-09-15 12:45 PM</td>
              <td>Delivered</td>
          </tr>
                      <tr>
              <td>2</td>
              <td>O Kiran</td>
              <td>9976634336</td>
              <td>25-09-15 11:15 AM</td>
              <td>Sent</td>
          </tr>
            <tr>
              <td>3</td>
              <td>Kumar Raja</td>
              <td>8986568386</td>
              <td>25-09-15 11:10 AM</td>
              <td>Sent</td>
          </tr>

            <tr>
              <td>4</td>
              <td>Praveena</td>
              <td>8986837886</td>
              <td>25-09-15 10:23 AM</td>
              <td>Delivered</td>
          </tr>
        </tbody>
      </table>
        </div>
                
</div>
</div>
</div>
    </div>



     <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/js/materialize.min.js"></script>

    <script>
        google.setOnLoadCallback(drawChart);
        function drawChart() {

            var data = google.visualization.arrayToDataTable([
              ['Lable', 'Number'],
              ['Available', 43134],
              ['Used', 56866]

            ]);

            var options = {
                //title: ''
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }

        google.load('visualization', '1', { packages: ['corechart', 'bar'] });
        google.setOnLoadCallback(drawTitleSubtitle);

        function drawTitleSubtitle() {
            var data = google.visualization.arrayToDataTable([
                    ['Blood Groups', 'Donors', { role: 'style' }],
                    ['A +ve', 8.94, '#e5e4e2'],            // RGB value
                    ['A -ve', 10.49, 'silver'],            // English color name
                    ['B +ve', 19.30, 'color: black'],
                  ['B -ve', 21.45, 'color: #e5e4e2'], // CSS-style declaration
                 ['AB +ve', 31.45, 'color: #e5e4e2'], // CSS-style declaration
                 ['AB -ve', 15.45, 'color: #e5e4e2'], // CSS-style declaration
                 ['O +ve', 30.45, 'color: #e5e4e2'], // CSS-style declaration
                 ['O -ve', 21.45, 'color: #e5e4e2'], // CSS-style declaration

            ]);

            var options = {
                chart: {
                    subtitle: 'Numbers in 100s'
                },
                hAxis: {
                    title: 'Time of Day',
                    format: 'h:mm a',
                    viewWindow: {
                        min: [7, 30, 0],
                        max: [17, 30, 0]
                    }
                },
                vAxis: {
                    title: 'Rating (scale of 1-10)'
                }
            };

            var material = new google.charts.Bar(document.getElementById('chart_div'));
            material.draw(data, options);
        }
    </script>
</body>


</html>
