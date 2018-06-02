<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="application.aspx.cs" Inherits="try2.Application.application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Application</title>
     <!--Import Google Icon Font-->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
    <link href="style.css" rel="stylesheet" />
  

      <!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
     <!-- Dropdown Structure -->
    <ul id="dropdown1" class="dropdown-content">
        <li><a href="#!">Apply</a></li>
        <li><a  href="../Employee Login/employeeLogin.aspx">Employee Login</a></li>
         <li><a  href="../Admin Login/adminLogin.aspx">Admin Login</a></li>
        <li class="divider"></li>
        
    </ul>
    <div class="navbar-fixed">
        <nav>
            <div class="nav-wrapper white">
                <a href="#" class="brand-logo black-text darken-4">HMS</a>
                <ul class="right hide-on-med-and-down ">
                    <li><a class="black-text active" href="../home/home.aspx">Home</a></li>
                    <li><a href="../RoomInfo/roomInfo.aspx" class="black-text">Rooms</a></li>
                    <li><a href="#" class="black-text">Halls</a></li>
                      <li><a href="../Menu Info/menuInfo.aspx" class="black-text">Dinning</a></li>
                 
                    
                    <!-- Dropdown Trigger -->
                    <li><a class="dropdown-button black-text" href="#!" data-activates="dropdown1">Careers<i class="material-icons right">arrow_drop_down</i></a></li>
                    <li><a class="black-text " href="../signup/signup.aspx">Sign Up</a></li>
                     <li><a class="black-text " href="../login/login.aspx">Sign In</a></li>
                     </ul>
            </div>

        </nav>

    </div>


     

    <br /><br /><br /><br />

    <div class="center-align">
            <asp:Label class=" red-text" ID="er1" runat="server" Text=""></asp:Label>
          
            </div>
      <div class="center-align">
            <asp:Label class=" red-text" ID="er2" runat="server" Text=""></asp:Label>
          
            </div>
    <div class="row">
    <form runat="server" class="col s12">
       
      <div class="row">
          <div class="col s1"> </div>
        <div class="input-field col s5">
          <i class="material-icons prefix">account_circle</i>
          <input  runat="server" id="first_name" type="text" class="validate" maxlength="30">
          <label for="icon_prefix">First Name</label>
            <span class="helper-text" data-error="wrong" data-success="right"></span>

            <asp:CustomValidator
                ID="CustomValidatorFirstName" runat="server" 
                 ErrorMessage="Last Name Cannot be empty or have numbers" 
                ControlToValidate="first_name"
                
                ForeColor="Red"
                OnServerValidate="CustomValidatorFirstName_ServerValidate"
                ValidateEmptyText="true"
                ClientValidationFunction="FirstNameValidation">

            </asp:CustomValidator>
             
        </div>
          
          <div class="input-field col s5">
          <i class="material-icons prefix">account_circle</i>
         <input  runat="server" id="last_name" type="text" class="validate" maxlength="30">
          <label for="last_name">Last Name</label>
               <span class="helper-text" data-error="wrong" data-success="right"></span>
               <asp:CustomValidator 
                
                ID="CustomValidator2" runat="server" 
                ErrorMessage="Last Name Cannot be empty or have numbers" ControlToValidate="last_name" 
                ForeColor="Red"
                   ValidateEmptyText="true"
                OnServerValidate="CustomValidatorFirstName_ServerValidate">

              </asp:CustomValidator>
               
              
        </div>

        </div> 
        <div class="row"> 
          <div class="col s1"> </div>
          <div class="input-field col s5">
              
              <i class="material-icons prefix">info</i>
            <input id="cnumber" runat="server" type="text" maxlength="13" data-length="13">
            <label for="input_text">CNIC</label>

               <asp:CustomValidator 
                
                ID="CustomValidator3" runat="server" 
                ErrorMessage="CNIC Must have 13 Integers" ControlToValidate="cnumber" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorCNIC_ServerValidate">

              </asp:CustomValidator>

              
          </div>
          <div class="input-field col s5">
          <i class="material-icons prefix">phone</i>
          <input  runat="server" id="phone" type="tel" class="validate" maxlength="11" data-length="11">
          <label for="contact_phone">Phone</label>
              
              <asp:CustomValidator 
                
                ID="CustomValidator4" runat="server" 
                ErrorMessage="Phone must have more than 7 Integers" ControlToValidate="phone" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorPhone_ServerValidate">

              </asp:CustomValidator>
              
        </div>
          
          </div> 
        <div class="row"> 
            <div class="col s1"> </div>
        

            <div class="input-field col s5">
               <i class="material-icons prefix">email</i>
          <input  runat="server" id="email" type="email" class="validate">
          <label for="email">Email</label>
                
                <asp:CustomValidator 
                
                ID="CustomValidator5" runat="server" 
                ErrorMessage="Email is Invalid" ControlToValidate="email" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorEmail_ServerValidate">

              </asp:CustomValidator>
        </div>
            
    <div class="input-field col s5">
          <i class="material-icons prefix">date_range</i>
         <input  id="dating" runat="server" type="datetime" class="datepicker" required>
          <label for="icon_prefix"></label>
        </div>

         </div> 

        <div class="row">
            <div class="col s1"> </div>
            <div class="input-field col s5">
          <i class="material-icons prefix">home</i>
          <input  runat="server"  id="address" type="text" class="validate" maxlength="50">
          <label for="icon_prefix">Address</label>

                 <asp:CustomValidator 
                
                ID="CustomValidator7" runat="server" 
                ErrorMessage="Address Must Not Be Empty" ControlToValidate="address" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorAddress_ServerValidate">

              </asp:CustomValidator>
                
        </div>

          <div class="input-field col s5">
              <i class="material-icons prefix">accessibility</i>
    <select runat="server" id="gene">
      <option value="" disabled  selected>Choose your option</option>
      <option value="Male">Male</option>
      <option value="Female">Female</option>
      <option value="LGBT">LGBT</option>
    </select>
    <label for="icon_prefix">Gender</label>

              <asp:CustomValidator 
                
                ID="CustomValidator1" runat="server" 
                ErrorMessage="Address Must Not Be Empty" ControlToValidate="gene" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>

  </div>

        </div>

        <div class="row">
            <div class="col s1"> </div>
                    <div class="input-field col s5">
                        <i class="material-icons prefix">work</i>
                        <select id="jobType" runat="server" onchange="showPassword()">
                          <option value=""  selected>Choose your option</option>
                          <option value="1">Manager</option>
                          <option value="2">Receptionist</option>
                          <option value="3">Other</option>
                        </select>
                        <label>Job Type</label>
                        
                        <asp:CustomValidator 
                
                            ID="CustomValidator8" runat="server" 
                            ErrorMessage="Address Must Not Be Empty" ControlToValidate="jobType" 
                            ForeColor="Red"
                            OnServerValidate="CustomValidatorSelect_ServerValidate">

                     </asp:CustomValidator>

                    </div>

             <div class="input-field col s5">

                             <i class="material-icons prefix">fiber_pin</i>
                            <input runat="server" style="display:none"  id="passwordApp" type="password" class="validate" maxlength="20" data-length="20">
                  <asp:CustomValidator 
                
                ID="CustomValidator6" runat="server" 
                ErrorMessage="Password is Invalid" ControlToValidate="passwordApp" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorPassword_ServerValidate">

              </asp:CustomValidator>
                 
                </div>


            </div>

        <div class="row">
            <div class="col s1"> </div>
        <div class="input-field col s5">
          <i class="material-icons prefix">description</i>
          <input style="display:none" runat="server" id="description" type="text" class="validate" maxlength="30"/>
          <label for="icon_prefix">Job Description</label>
        </div>

            <div class="input-field col s5">
          <i class="material-icons prefix">account_circle</i>
          <input  runat="server" id="departmentName" type="text" class="validate" maxlength="30" required/>
          <label for="icon_prefix">Department Name</label>
            <span class="helper-text" data-error="wrong" data-success="right"></span>
             
        </div>
        </div>
      
        <br />
        <div class="row">
            <div class="col s5"> </div>
            <asp:Button runat="server" OnClick="Employee_Register" class="btn waves-effect waves-light " type="submit" Text="Submit" name="action"/>
             
        </div>
           
    </form>
  </div>

        
    <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 
     <!--Materializecss Slider-->
    <script src="script.js"></script>
</body>
</html>
