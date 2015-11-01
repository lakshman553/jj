<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileUpload.aspx.cs" Inherits="Jeevanjyothi1.fileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="regass/css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form runat="server" id="formUID">
        <%
            
            if (!IsPostBack)
            {
        
        %>
    <h3 class="text-danger">Select an image and click upload</h3>

        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input-sm" />
        <asp:HiddenField runat="server" ID="userid" />
        <br />
        <div class="text-center">
        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-danger btn-xs" OnClick="Upload" />
        </div>        
                
        <%

            } 
            else
            {    
        %>
        
        <h3 class="text-center text-success">Image succesfully uploaded</h3>

        <%


        }

        %>

    </form>
    <script>
        document.getElementById("userid").value = localStorage.getItem("id");
    </script>
</body>

</html>
