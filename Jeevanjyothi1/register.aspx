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
</head>
<body>
    <div class="container">
        <br />
        <div class="col-lg-8 col-sm-12 col-md-12">
            <div class="panel"><div class="panel-body">    
                
                    <form class="form-horizontal">
  <fieldset>

    <div class="form-group">
      <label for="inputEmail" class="col-lg-2 control-label">Email</label>
      <div class="col-lg-10">
        <input type="text" class="form-control" id="inputEmail" />
          <span class="help-block">Enter your email address</span>
      </div>
    </div>
    <div class="form-group">
      <label class="col-lg-2 control-label">Blood Group</label>
      <div class="col-lg-10">

      <div class="btn-group" data-toggle="buttons">

      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> O +
      </label>

      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> O -
      </label>

      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> A +
      </label>

      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> A -
      </label>
      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> B +
      </label>

      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> B -
      </label>
      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> AB +
      </label>

      <label class="btn btn-primary active">
        <input type="radio" name="options"   /> AB -
      </label>


    </div>
    </div></div>
    <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
        <button type="reset" class="btn btn-default">Cancel</button>
        <button type="submit" class="btn btn-primary">Submit</button>
      </div>
    </div>
  </fieldset>
</form>
     </div></div></div>
  
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>


<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

</body>
</html>
