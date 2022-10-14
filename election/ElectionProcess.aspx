<%@ Page EnableViewStateMac="false" Language="C#" AutoEventWireup="true" CodeFile="ElectionProcess.aspx.cs"  MaintainScrollPositionOnPostback="true" Inherits="ElectionProcess" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="" />
    <meta name="google-site-verification" content="sKH6fAHJAmScENtPMN45EHUMJAnVRqsXj7gUZyFZArs" />
    <link rel="icon" href="https://pihmaa.org/images/favicon_icon.jpg" />
    <title>Welcome to PIHMAA</title>


   <%-- <link href="Content/responsive.css" rel="stylesheet" type="text/css">--%>

    <!-- bootsrap css links start -->
    <link href="Content/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- bootsrap css links end -->
    <!-- navigation js link start -->

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <%--  <script src="Scripts/jquery.min.js.download"></script>
    <script src="Scripts/script.js.download" type="text/javascript"></script>--%>
    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
       function calfun()
       {
           $.ajax({
                            type: "POST",
                            url: "ElectionProcess.aspx/IncreaseTime",
                            data: '{selected_candidate_ids: "jhjgh" }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",

                        });

       }

   </script>
    <!-- navigation js link end -->
    <style type="text/css">
        body {
        }

        header {
            width: 100%;
            margin: 0 auto;
            top: 0;
            background-color: #fff;
            z-index: 999;
            border-bottom: 2px solid #e5e5e5;
        }

        .page-header h1 {
            color: #0093dd;
        }

        .dropdown-submenu {
            position: relative;
        }

            .dropdown-submenu > .dropdown-menu {
                top: 0;
                left: 100%;
                margin-top: -6px;
                margin-left: -1px;
                -webkit-border-radius: 0 6px 6px 6px;
                -moz-border-radius: 0 6px 6px;
                border-radius: 0 6px 6px 6px;
            }

            .dropdown-submenu:hover > .dropdown-menu {
                display: block;
            }

            .dropdown-submenu > a:after {
                display: block;
                content: " ";
                float: right;
                width: 0;
                height: 0;
                border-color: transparent;
                border-style: solid;
                border-width: 5px 0 5px 5px;
                border-left-color: #ccc;
                margin-top: 5px;
                margin-right: -10px;
            }

            .dropdown-submenu:hover > a:after {
                border-left-color: #fff;
            }

            .dropdown-submenu.pull-left {
                float: none;
            }

                .dropdown-submenu.pull-left > .dropdown-menu {
                    left: -100%;
                    margin-left: 10px;
                    -webkit-border-radius: 6px 0 6px 6px;
                    -moz-border-radius: 6px 0 6px 6px;
                    border-radius: 6px 0 6px 6px;
                }
    </style>
    <!-- voting -->
    <style type="text/css">
        body {
            margin-top: 20px;
        }

        .panel-body:not(.two-col) {
            padding: 0px;
        }

        .glyphicon {
            margin-right: 5px;
        }

        .glyphicon-new-window {
            margin-left: 5px;
        }

        .panel-body .radio, .panel-body .checkbox {
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .panel-body .list-group {
            margin-bottom: 0;
        }

        .margin-bottom-none {
            margin-bottom: 0;
        }

        .panel-body .radio label, .panel-body .checkbox label {
            display: block;
        }

        .table > tbody > tr > td {
            border-top: none !important;
            vertical-align: middle;
        }
        /*model css*/
        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content/Box */
        .modal-content {
            background-color: #f1ebeb;
            margin: 11% auto;
            padding: 22px;
            border: 1px solid #888;
            width: 60%;
            line-height: 30px;
            color: #286090;
        }

        /* The Close Button */
        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: black;
                text-decoration: none;
                cursor: pointer;
            }

        /* On screens that are 992px or less */
        @media screen and (max-width: 1023px) {
            .modal-content {
                margin: 11% auto;
                width: 80%;
                line-height: 25px;
            }

            .custom {
                padding: 8px;
                margin-top: -44px;
            }
        }
          
    </style>
    <!-- voting end -->

</head>

<body>

    <form id="form1" runat="server">
        <div>

             <asp:ScriptManager ID="scriptManager1" runat="server" EnablePartialRendering="True"
            EnablePageMethods="true" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
            <asp:Timer ID="timer1" runat="server" Interval="1000" OnTick="timer1_tick"></asp:Timer>
            <script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(beginRequest);

    function beginRequest() {
        prm._scrollPosition = null;
    }
</script>
        </div>


    <asp:RadioButtonList ID="rblOptions" runat="server">
    </asp:RadioButtonList>
    <br />
       
   <%-- <asp:Button ID="btnNext" runat="server" Text="Next" OnClick = "OnNextClicked" />--%>
 
        <header>

               <div class="container-fluid">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-4 col-md-4">
                            <a href="https://pihmaa.org/">
                                <img src="images/logo.png" alt="PIHMAA Logo" class="img-responsive" />
                            </a>
                        </div>
                        <div class="col-lg-4 col-md-4 col-lg-offset-4 col-md-offset-4 pull-right">
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <h4>Online Voting for <br>Faculty of the Year<small>                                       
                                    </small>
                                    </h4>
                                </div>
                                <!--<div class="col-lg-6 col-md-6 list-inline">
                                      <a id="lbLoginLogout" class="btn btn-info" href="javascript:__doPostBack('ctl00$lbLoginLogout','')">Login</a> 
                                    <a class="btn btn-info btn-md" href="login.aspx" style="float: right; margin: 10px; padding: 10px;">Logout</a>
                                </div>-->
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </header>

        <div class="item active">
            <img class="first-slide" src="images/voting-img.jpg" alt="First slide" width="100%" />
        </div>
        <!-- Voting Panel -->
        <section style="padding: 8px; margin: 10px;">
            <div class="container">
                <div class="row">
                    <div>
<asp:UpdatePanel id="updPnl"

runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:Label ID="lblTimer" runat="server" Font-Bold="True" Font-Names="Arial"

        Font-Size="X-Large" ForeColor="#6600CC"></asp:Label>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="timer1" EventName ="tick" />
</Triggers>
</asp:UpdatePanel>
</div>
                    <div class="col-md-12">
                        <h1 style="text-align: center; padding: 10px 10px 1px 10px;"><asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" ForeColor="#6600CC"></asp:Label></h1>
                        <h6 style="text-align: center; padding: 10px 10px 1px 10px;">Total Batches : <asp:Label ID="lblEnabled" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="#6600CC"></asp:Label></h6> <h6 style="text-align: center; padding: 10px 10px 1px 10px;">Batches to be voted: <asp:Label ID="lblVoting" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="#6600CC"></asp:Label></h6>
					    <BR><BR>
                        <!-- modal -->
                        <!-- Trigger/Open The Modal -->
                        <%--  <input type="button" value="Click here for INSTRUCTIONS" onclick="window.open('test2.aspx','popUpWindow','height=500,width=400,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no, status=yes');" />
       --%>
                        <%-- <button id="myBtn" class="btn btn-primary btn-md custom" style="padding-bottom: 10px; margin-bottom: 10px; float: right;">Click here for INSTRUCTIONS</button>--%>
                      <%--  <button id="myBtn1" class="btn btn-primary btn-md custom" style="padding-bottom: 10px; margin-bottom: 10px; float: right;" onclick="window.open('test2.aspx','popUpWindow','height=500,width=400,left=100,top=100,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no, status=yes');"><%--Click here for INSTRUCTIONS</button>--%>
                        <input type="button" class="btn btn-primary btn-md custom" style="padding-bottom: 10px; margin-bottom: 10px; float: right;" value="Click here for INSTRUCTIONS" onClick="window.open('test2.aspx','popUpWindow','height=500,width=400,left=100,top=100,directories=no,titlebar=no,resizable=no,location=no,scrollbars=no,status=no,toolbar=no,menubar=no,location=0,directories=no,status=no');" /> 
                        <!-- The Modal -->
                        <div id="myModal" class="modal">
                            <!-- Modal content -->
                            <div class="modal-content">
                                <span class="close" style="color: #337ab7; opacity: 1; font-size: 53px;">×</span>
                                <p>
                                </p>
                                <h1 style="text-align: center;">Instruction for Votings</h1>
                                <ol>
                                    <li>Duis aute irure dolor in reprehenderit in voluptate velit esse 	cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    </li>
                                    <li>Duis aute irure dolor in reprehenderit in voluptate velit esse 	cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    </li>
                                    <li>Duis aute irure dolor in reprehenderit in voluptate velit esse 	cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    </li>
                                    <li>Duis aute irure dolor in reprehenderit in voluptate velit esse 	cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    </li>
                                    <li>Duis aute irure dolor in reprehenderit in voluptate velit esse 	cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    </li>
                                    <li>Duis aute irure dolor in reprehenderit in voluptate velit esse 	cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
                                    </li>
                                </ol>
                                <p></p>
                            </div>
                        </div>
                        <!-- //modal -->
                    </div>



                    <% if (dtBatch != null && dtBatch.Rows.Count > 0)
                        {
                            string disable_style;
                            string checked_style;
                            foreach (DataRow itemBatch in dtBatch.Rows)
                            {
                                disable_style = "";
                                checked_style = "";
                    %>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">

                                <table class="table" id="table_main_<%=itemBatch["BATCH_BLOCK_ID"]%>">
                                    <tbody>
                                        <tr>
                                            <td>Election:<%=itemBatch["BATCH_BLOCK_NAME"]%>
                                            </td>
                                            <td>Seat:<%=itemBatch["BATCH_BLOCK_SEATS"]%>
                                            </td>
                                        </tr>
										<tr>
										<td><%=itemBatch["BATCH_MESSAGE"]%>
                                            </td>
										</tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-hover" id="table_child_<%=itemBatch["BATCH_BLOCK_ID"]%>">
                                        <tbody>
                                            <% DataTable dtCandidate = GetCandidatesByBatchID(Convert.ToInt32(itemBatch["BATCH_BLOCK_ID"]));
                                                if (dtCandidate != null && dtCandidate.Rows.Count > 0)
                                                {

                                                    foreach (System.Data.DataRow itemCandidate in dtCandidate.Rows)
                                                    {
                                                         if (dtCandidate.Rows.Count <= int.Parse(itemBatch["BATCH_BLOCK_SEATS"].ToString()))
                                                        {
                                                            checked_style = "checked";
                                                        }
                                                        if (itemCandidate["Cand_ID2"].ToString() != "0")
                                                        {
                                                            //disable_style = "disabled";
                                                            checked_style = "checked";
                                                        }
                                                        if (IsVoted == 1)
                                                        { 
															disable_style = "disabled"; 
															//lblInform.Text = "Voting Closed for this Batch";
														}
                                                        else 
														{
                                                            disable_style = "";
															//lblInform.Text = "Click on Submit Button to Vote";
                                                        }


                                            %>
                                            <tr id="table_child_tr_<%=itemCandidate["CAND_ID"]%>">
                                                <td>
                                                    <input type="checkbox" process_id="<%=itemBatch["PROCESS_ID"]%>"  cand_id="<%=itemCandidate["CAND_ID"]%>" name="ckeck_<%=itemCandidate["CAND_ID"]%>" id="ckeck_<%=itemCandidate["CAND_ID"]%>" <%=checked_style %> />


                                                </td>
                                                <td>
                                                    <img src="images/candi/<%=itemCandidate["CAND_PIC"]%>" alt="Alt" width="50px" height="50px" />
                                                </td>
                                                <td><%=itemCandidate["CAND_NAME"]%>
                                                    <br />
                                                    <!--Batch--> <%=itemCandidate["CAND_YEAR"]%></td>
                                            </tr>
                                            <%
                                                        checked_style = "";
                                                    } //inner for
                                                }%>
                                        </tbody>
                                    </table>
                                   
                                    <input id="btnSave_<%=itemBatch["BATCH_BLOCK_ID"]%>" class="btn btn-primary btn-md" style="display:block; margin: 5px auto;" type="button" value="Submit" onClick="SaveElection(<%=itemBatch["BATCH_BLOCK_ID"]%>, <%=itemBatch["BATCH_BLOCK_SEATS"]%>)" <%=disable_style%> />

                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}
                        }%>





                    <!-- final sumbit -->
                     <asp:Button ID="btnFinish" class="btn btn-primary btn-md" style="display: block; margin: 5px auto;" runat="server" Text="Finish" OnClick="btnFinish_Click" />
                </div>
            </div>
        </section>





        <footer>


            <div class="container-fluid footer_cpy_right">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-md-6 text-right2">Copyright © 2019. PIHMAA, All Rights Reserved</div>
                        <div class="col-xs-12 col-md-6 text-right1">Powered By : <a href="http://odysseyin.com/" target="_blank">Odyssey</a></div>
                    </div>
                </div>
            </div>
        </footer>


        <!-- bootsrap js links start -->
      <%--  <script src="Scripts/bootstrap.min.js.download"></script>--%>
        <!-- bootsrap css links end -->
       <%-- <script src="Scripts/jquery.min.js(1).download"></script>--%>
        <script type="text/javascript">
            // Get the modal
            var modal = document.getElementById("myModal");

            // Get the button that opens the modal
            var btn = document.getElementById("myBtn");

            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];

           //  When the user clicks on the button, open the modal
            //btn.onclick = function () {
            //    modal.style.display = "block";
            //}

            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
        </script>



   
      <script type="text/javascript">
            var global_BATCH_BLOCK_ID;
            function SaveElection(BATCH_BLOCK_ID, BATCH_BLOCK_SEATS) {
                debugger;
                var selected_candidate_ids = "";
                var CAND_ID = 0;
               // var Noofseats = 0;
                var PROCESS_ID = 0;
                var selectedcount = 0;
				  var childtableid = '#table_child_' + BATCH_BLOCK_ID + ' tr';
              
                debugger;
               
                //alert(id);
                //collect all candidate ids
                $(childtableid).each(function () {
                    debugger;
                    //var ischecked = $(this).find('td').eq(0).find("input").prop("checked");
                    var ischecked = $(this).find('td').eq(0).find("input").attr("checked");
                    CAND_ID = $(this).find('td').eq(0).find("input").attr("CAND_ID");
                    PROCESS_ID = $(this).find('td').eq(0).find("input").attr("PROCESS_ID");

                    if (ischecked) {
                        if (selected_candidate_ids == "") {
                            selectedcount = selectedcount + 1;
                            selected_candidate_ids = CAND_ID;
                            global_BATCH_BLOCK_ID = BATCH_BLOCK_ID;
                        }
                        else
                        { selectedcount = selectedcount + 1;
                            selected_candidate_ids = selected_candidate_ids + "," + CAND_ID;
                            global_BATCH_BLOCK_ID=BATCH_BLOCK_ID;
                        }

                    }
                });

                if (selectedcount != BATCH_BLOCK_SEATS) {

                    alert("Invalid Selection. Kindly select number of candidates according to seats available in the batch");
                }
               
                else { debugger;
                    if (selected_candidate_ids != "") {
                        $.ajax({
                            type: "POST",
                            url: "ElectionProcess.aspx/SaveElectionDetails",
                            data: '{selected_candidate_ids: "' + selected_candidate_ids + '" }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: OnSuccess,
                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                    }
                    else {
                        alert("Please select candidates.");
                    }
                }

            } //end save


            function OnSuccess(response) {
                var button_id = '#btnSave_' + global_BATCH_BLOCK_ID + '';
                debugger;
                $(button_id).attr("disabled","disabled");
                global_BATCH_BLOCK_ID="";

				let lbl = document.getElementById('lblVoting');
    			var m = lbl.textContent.match(/^(.*)(\d+)$/);
    			lbl.textContent = m[1] + ((parseInt(m[2], 10) || 0) - 1);
				//alert(lbl.textContent);	
				if (lbl.textContent == '0')
				{
					$(btnFinish).removeAttr('disabled');
				}
				else
				{
                	$(btnFinish).attr("disabled","disabled");
				}
                alert(response.d);
            }

          

        </script>
        <script>
              function Finish() {
                $.ajax({
                    type: "POST",
                    url: "ElectionProcess.aspx/Logout",
                    data: '{selected_candidate_ids: 1 }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        debugger;
                        window.location = response.d;
                    },
                    failure: function (response) {
                        debugger;
                        alert(response.d);
                    }

                });
            }
        </script>
    </form>
</body>


</html>
