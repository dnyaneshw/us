<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificate.aspx.cs" Inherits="Insurance.Certificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Certificate</title>
    <link type="text/css" rel="Stylesheet" href="Styles/New.css" />


    <style type="text/css">
        .auto-style2
        {
            width: 71px;
        }

        .auto-style3
        {
            width: 70px;
        }

        .auto-style4
        {
            width: 292px;
        }

        .auto-style8
        {
            width: 36px;
        }

        .auto-style9
        {
            width: 69px;
        }

        .auto-style10
        {
            width: 72px;
        }

        .auto-style11
        {
            width: 65px;
        }

        .auto-style12
        {
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <%--Page 1...--%>
        <div style="text-align: right; padding-right: 12px; font-weight: bold;">
            <asp:Label ID="lblCertyNo" runat="server"></asp:Label>
        </div>
        <table border="0" align="center" width="100%" style="font-family: Tahoma">
            <tr>
                <td align="center" class="auto-style12">&nbsp;<%--<img src="Admin/Images/logo1.png">--%></td>
                <td style="text-align: center" class="auto-style12">
                    <h2 id="center">CERTIFICATE OF LIABILITY INSURANCE</h2>
                </td>
                <td style="text-align: right;" class="auto-style12">
                    <table border="1" width="170">
                        <tr>
                            <td align="center">
                                <span style="font-size: 13px; font-weight: bold">DATE(MM/DD/YYYY)</span>
                                <div style="text-align: center">
                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table border="1" width="100%" align="center" style="font-family: Tahoma;">
            <tr>
                <td colspan="2">
                    <span style="text-align: left; padding-left: 20px; font-size: 10px">THIS CERTIFICATE IS ISSUED AS A MATTER OF INFORMATION ONLY AND CONFERS NO RIGHTS
                    UPON THE CERTIFICATE HOLDER. THIS CERTIFICATE DOES NOT AFFIRMATIVELY OR NEGATIVELY
                    AMEND, EXTEND OR ALTER THE COVERAGE AFFORDED BY THE POLICIES BELOW. THIS CERTIFICATE
                    OF INSURANCE DOES NOT CONSTITUTE A CONTRACT BETWEEN THE ISSUING INSURER(S), AUTHORIZED
                    REPRESENTATIVE OR PRODUCER, AND THE CERTIFICATE HOLDER.</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="text-align: left; padding-left: 20px; padding-right: 2px; font-size: smaller">
                        <b>IMPORTANT: </b>If the certificate holder is an ADDITIONAL INSURED, the policy(ies) must be endorsed. If SUBROGATION WAIVED, subject to the terms and conditions of the policy, certain policies may require an endorsement. A statement on this certificate
                    does not confer rights to the certificate holder in lieu of such endorsement(s).</span>
                </td>
            </tr>
            <tr>
                <td width="400" valign="top" style="font-size: small; padding-left: 20px;">
                    <b>PRODUCER</b>
                    <br>
                    JOHN A PARKS CO.,INC.<br>
                    49 WEST WILLIS<br>
                    DETROIT, MI 48201<br>
                </td>
                <td style="font-size: small">
                    <table width="100%" style="padding-left: 20px;">
                        <tr>
                            <td style="width: 35%">CONTACT NAME :
                            </td>
                            <td>
                                <asp:Label ID="lblContactName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>PHONE(ac/no/ext):
                            </td>
                            <td>
                                <asp:Label ID="lblPhoneNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>FAX(ac/no):
                            </td>
                            <td>
                                <asp:Label ID="lblFaxNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>EMAIL ADDRESS:
                            </td>
                            <td>
                                <asp:Label ID="lblEmailAdd" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" style="font-size: small">
                    <b>INSURED</b><br />
                    <asp:Label ID="lblInsuredDetails" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-size: small">
                    <table border="1" width="100%" style="font-size: 13px">
                        <tr valign="bottom">
                            <th>INSURER(S) AFFORDING COVERAGE
                            </th>
                            <th>NAIC#
                            </th>
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <b>INSURER A:</b> ATAIN SPECIALTY INSURANCE COMPANY</td>
                            <td>..............
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <b>INSURER B:</b>
                            </td>
                            <td>..............
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <b>INSURER C:</b>
                            </td>
                            <td>..............
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <b>INSURER D:</b>
                            </td>
                            <td>..............
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <b>INSURER E:</b>
                            </td>
                            <td>..............
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <b>INSURER F:</b>
                            </td>
                            <td>..............
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table border="0" width="950" align="center" style="font-family: Tahoma">
            <tr valign="bottom" style="font-size: small">
                <td width="250">
                    <b>COVERAGES</b>
                </td>
                <td>
                    <b>CERTIFICATE NUMBER :&nbsp; </b>
                    <asp:Label ID="lblCertificateNo" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <b>REVISION NUMBER :&nbsp; </b>
                    <asp:Label ID="lblRevisionNo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table border="1" width="100%" align="center" style="font-family: Tahoma">
            <tr>
                <td colspan="8">
                    <span style="text-align: left; font-size: 9px; padding-left: 20px;">THIS IS TO CERTIFY THAT THE POLICIES OF INSURANCE LISTED BELOW HAVE BEEN ISSUED
                    TO THE INSURED NAMED ABOVE FOR THE POLICY PERIOD INDICATED. NOT WITHSTANDING ANY
                    REQUIREMENT, TERM OR CONDITION OF ANY CONTRACT OR OTHER DOCUMENT WITH RESPECT TO
                    WHICH THIS CERTIFICATE MAY BE ISSUED OR MAY PERTAIN, THE INSURANCE AFFORDED BY THE
                    DESCRIBED HEREIN IS SUBJECT TO ALL THE TERMS, EXCLUSIONS AND CONDITIONS OF SUCH
                    POLICIES. LIMITS SHOWN MAY HAVE BEEN REDUCED BY PAID CLAIMS.</span>
                </td>
            </tr>
            <tr style="font-size: smaller" valign="bottom">
                <th class="auto-style8">INSR LTR
                </th>
                <th class="auto-style4">TYPE OF INSURANCE
                </th>
                <th class="auto-style9">ADDL INSR
                </th>
                <th class="auto-style3">SUBR WVD
                </th>
                <th class="auto-style11">POLICY NUMBER
                </th>
                <th align="center" class="auto-style10">POLICY EFF <span style="font-size: 9px;">(MM/DD/YYYY)</span>
                </th>
                <th align="center" class="auto-style2">POLICY EXP <span style="font-size: 9px;">(MM/DD/YYYY)</span>
                </th>
                <th>LIMITS
                </th>
            </tr>
            <tr style="font-size: x-small">
                <td class="auto-style8">&nbsp;<span style="font-size: medium;">
                A</span></td>
                <td valign="top" class="auto-style4">
                    <b>GENERAL LIABILITY</b><br />
                    <input type="checkbox" name="c1" checked="checked" style="width: 30px; height: 20px;">COMMERCIAL
                GENERAL LIABILITY<br>
                    <input type="checkbox" name="c2" style="width: 30px; height: 20px;">CLAIMS-MADE
                <input type="checkbox" name="c3" checked="checked" style="width: 30px; height: 20px;">OCCURRENCE<br>
                    <input type="checkbox" name="c4" style="width: 30px; height: 20px;">....................................<br>
                    <input type="checkbox" name="c5" style="width: 30px; height: 20px;">....................................<br>
                    GEN'L AGGREGATE LIMIT APPLIES PER:<br />
                    <input type="checkbox" name="c6" checked="checked" style="width: 30px; height: 20px;">POLICY
                <input type="checkbox" name="c7" style="width: 30px; height: 20px;">PROJECT
                <input type="checkbox" name="c8" style="width: 30px; height: 20px;">LOC
                </td>
                <td align="center" class="auto-style9">
                    <asp:CheckBox ID="chkAddInsur" runat="server" />
                    <asp:Image ID="imgAddInsur" Visible="false" runat="server" ImageUrl="~/images/checked.png" />
                </td>
                <td align="center" class="auto-style3">
                    <asp:CheckBox ID="chkSubgrtion" runat="server" />
                    <asp:Image ID="imgSubgrtion" Visible="false" runat="server" ImageUrl="~/images/checked.png" />
                </td>
                <td valign="middle" align="center" class="auto-style11">CIP116614</td>
                <td class="auto-style10" align="center">
                    <asp:Label ID="lblPolicyStartDate" runat="server"></asp:Label>
                </td>
                <td class="auto-style2" align="center">
                    <asp:Label ID="lblPolicyEndDate" runat="server"></asp:Label>
                </td>
                <td>
                    <table border="1" style="font-family: Tahoma; font-size: 9px">
                        <tr valign="bottom">
                            <td style="width: 60%;">EACH OCCURANCE
                            </td>
                            <td>$2,000,000
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>DAMAGE TO RENTED PREMISES(Ea Occurence)
                            </td>
                            <td>$100,000
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>MED EXP (any one person)
                            </td>
                            <td>$5000
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>PERSONEL & ADV. INJURY
                            </td>
                            <td>$2,000,000
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>GENERAL AGGREGATE
                            </td>
                            <td>$2,000,000
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td>PRODUCTS - COMP/OP AGG
                            </td>
                            <td>$ NOT COVERED
                            </td>
                        </tr>
                        <tr valign="bottom">
                            <td></td>
                            <td>$
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr valign="bottom" style="font-size: x-small">
                <td class="auto-style8"></td>
                <td valign="top" align="left" class="auto-style4">
                    <table>
                        <tr>
                            <td colspan="2">
                                <b>AUTOMOBILE LIABILITY</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <input type="checkbox" name="c10">any auto
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" name="c11">all owned autos
                            </td>
                            <td>
                                <input type="checkbox" name="c12">scheduled autos
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" name="c13">hired autos
                            </td>
                            <td>
                                <input type="checkbox" name="c14">non-owned autos
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" name="c15">
                            </td>
                            <td>
                                <input type="checkbox" name="c16">
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="middle" align="center" class="auto-style9">
                    <input type="checkbox" name="c17" style="width: 30px; height: 20px;">
                </td>
                <td valign="middle" align="center" class="auto-style3">
                    <input type="checkbox" name="c18" style="width: 30px; height: 20px;">
                </td>
                <td class="auto-style11">&nbsp;
                </td>
                <td class="auto-style10">&nbsp;
                </td>
                <td class="auto-style2">&nbsp;
                </td>
                <td valign="top" align="left">
                    <table border="1" style="font-size: 9px" width="100%">
                        <tr valign="top">
                            <td style="width: 60%">COMBAINED SINGLE LIMIT (Ea Accident)
                            </td>
                            <td>$
                            </td>
                        </tr>
                        <tr>
                            <td>BODILY INJURY (Per Person)
                            </td>
                            <td>$
                            </td>
                        </tr>
                        <tr>
                            <td>BODILY INJURY (Per Accident)
                            </td>
                            <td>$
                            </td>
                        </tr>
                        <tr>
                            <td>PROPERTY DAMAGE (Per Accident)
                            </td>
                            <td>$
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>$
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr valign="bottom">
                <td class="auto-style8">&nbsp;
                </td>
                <td class="auto-style4" align="left">
                    <table width="300" style="font-size: x-small">
                        <tr>
                            <td>
                                <input type="checkbox" name="c19">UMBRELLA LIAB
                            </td>
                            <td>
                                <input type="checkbox" name="c20">OCCURRANCE
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" name="c21">EXCESS LIAB
                            </td>
                            <td>
                                <input type="checkbox" name="c22">CLAIMS-MADE
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="checkbox" name="c23">DED
                            </td>
                            <td>
                                <input type="checkbox" name="c24">RETENTION $
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="middle" align="center" class="auto-style9">
                    <input type="checkbox" name="c25" style="width: 30px; height: 20px;">
                </td>
                <td valign="middle" align="center" class="auto-style3">
                    <input type="checkbox" name="c26" style="width: 30px; height: 20px;">
                </td>
                <td class="auto-style11">&nbsp;
                </td>
                <td class="auto-style10">&nbsp;
                </td>
                <td class="auto-style2">&nbsp;
                </td>
                <td valign="top">
                    <table border="1" style="font-size: 9px" width="100%">
                        <tr>
                            <td style="width: 60%">EACH OCCURRENCE
                            </td>
                            <td>$..........
                            </td>
                        </tr>
                        <tr>
                            <td>AGRREGATE
                            </td>
                            <td>$..........
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>$..........
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr valign="bottom">
                <td class="auto-style8">&nbsp;
                </td>
                <td valign="top" style="font-size: x-small" class="auto-style4">
                    <table>
                        <tr>
                            <td>WORKERS COMPENSATION AND EMPLOYERS&#39; LIABILITY ANY PROPRIETOR/PARTNER/EXECUTIVE OFFICER/MEMBER
                            EXCLUDED? (Mandatory in NH) if yes, describe under DESCRIPTION OF OPERATION below
                            </td>
                            <td>
                                <b>Y/N</b><input type="checkbox" name="c27" style="width: 30px; height: 20px;">
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="middle" align="center" class="auto-style9">N/A
                </td>
                <td valign="middle" align="center" class="auto-style3">
                    <input type="checkbox" name="c28" style="width: 30px; height: 20px;">
                </td>
                <td class="auto-style11">&nbsp;
                </td>
                <td class="auto-style10">&nbsp;
                </td>
                <td class="auto-style2">&nbsp;
                </td>
                <td align="left">
                    <table border="1" style="font-size: 9px" width="100%">
                        <tr>
                            <td>
                                <input type="checkbox" name="c29">WC-STATU-TORY LIMITS<br>
                                <input type="checkbox" name="c30">OTHER<br>
                            </td>
                            <td>...........
                            </td>
                        </tr>
                        <tr>
                            <td>E.L EACH ACCIDENT
                            </td>
                            <td>$..........
                            </td>
                        </tr>
                        <tr>
                            <td>E.L DISEASE-EA EMPLOYEE
                            </td>
                            <td>$............
                            </td>
                        </tr>
                        <tr>
                            <td>E.L DISEASE-POLICY LIMIT
                            </td>
                            <td>$............
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%--<tr>
            <td height="30" style="font-size: small">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <input type="checkbox" name="c31">
            </td>
            <td>
                <input type="checkbox" name="c32">
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>
            <tr valign="bottom">
                <th colspan="8">
                    <span style="text-align: left; font-size: 10px; font-weight: bold; padding-left: 20px;">
                        <b>DESCRIPTION OF OPERATIONS/LOCATIONS/VEHICLES (ATTACH SCHEDULE A, ADDITIONAL REMARKS SCHEDULE)</b></span><br />
                    <span style="text-align: left; font-weight: bold; font-size: 10px; padding-left: 20px;">NOTE THIS CERTIFICATE IS ONLY GOOD FOR THE DATES OF THE EVENT SHOWN ON SCHEDULE A.
                    THIS DOCUMENT IS ONLY VALID WITH SCHEDULE A ATTACHED.</span>
                </th>
            </tr>
        </table>
        <h4 style="margin-left: 10px; font-size: small; display: inline;">CERTIFICATE HOLDER</h4>
        <h4 style="margin-left: 300px; font-size: small; display: inline;">CANCELLATION</h4>
        <table border="1" align="center" width="100%" style="font-family: Tahoma; font-size: small">
            <tr>
                <td rowspan="2" width="400" valign="top" style="padding-left: 20px; word-break: break-all; padding-right: 20px; height: auto;">
                    <asp:Label ID="lblCertiHolderDetails" runat="server"></asp:Label>
                </td>
                <td style="font-size: 12px; font-weight: bold">SHOULD ANY OF THE ABOVE DESCRIBED POLICIES BE CANCELLED BEFORE THE EXPIRATION DATE
                THEREOF, NOTICE WILL BE DELIVERED IN ACCORDANCE WITH THE POLICY PROVISIONS.
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <b style="font-size: small">AUHORIZED REPRESENTATIVE</b>
                    <br />
                    <br />
                    STEPHEN R. PARKS&nbsp;&nbsp; JOHN A. PARKS CO., INC
                </td>
            </tr>
        </table>
        <span style="padding-left: 500px; font-size: small; font-weight: bold">
            <%--© 1988-2010 ACORD CORPORATION. All rights reserved.--%></span>
        <table width="100%" style="font-size: small">
            <tr valign="middle">
                <td style="width: 40%" align="left">
                    <h4>
                        <%--Schedule A (2010/05)--%></h4>
                </td>
                <td align="right">
                    <h4>
                        <%--The ACORD name and logo are registered marks of ACORD--%></h4>
                </td>
            </tr>
        </table>

        <%--Page2....--%>

        <table border="0" align="center" width="100%" style="font-size: small">
            <tr>
                <td style="width: 70%" align="right">
                    <div style="text-align: right; padding-right: 12px; font-weight: bold;">
                        <asp:Label ID="lblCertyNopage2" runat="server"></asp:Label>
                    </div>

                </td>
            </tr>
        </table>

        <table border="0" align="center" width="100%">
            <tr>
                <td style="width:20%;" align="center">
                    <b>SCHEDULE A</b></td>
                <td style="text-align: right; width: 60%;">
                    <h2 id="H1">ADDITIONAL REMARKS SCHEDULE</h2>
                </td>
                <td style="text-align: right;width:20%;">&nbsp;</td>
            </tr>
        </table>
        <table border="1" align="center" width="100%" style="font-size: small; height: 100px">
            <tr valign="top">
                <td style="width: 50%" colspan="3">AGENCY :&nbsp; JOHN A. PARKS CO., INC
                </td>
                <td rowspan="2" style="width: 50%" colspan="3">
                    <b>NAMED INSURED :<br />
                        <asp:Label ID="lbl2nameInsured0" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr valign="top">
                <td colspan="3">POLICY NUMBER :&nbsp;
                CIP16614</td>
            </tr>
            <tr>
                <td colspan="2">CARRIER :&nbsp;
                    ATAIN</td>
                <td>NAIC CODE : 
                </td>
                <td>EFFECTIVE DATE :&nbsp;
                    <asp:Label ID="lblEffectDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <h4 style="margin-left: 15px;">ADDITIONAL REMARKS</h4>
        <table border="1" align="center" width="100%" style="font-size: small">

            <tr valign="top">
                <td style="height: 500px; padding: 20px 20px 20px 20px">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 60%;">
                                            <b>NAMED INSURED :&nbsp;<b>
                                        </td>
                                        <td>
                                            <b>Event From:&nbsp;<asp:Label ID="lblEventFrom" runat="server" Text=""></asp:Label>
                                                &nbsp;To 
                                        :-&nbsp; 
                                        <asp:Label ID="lblEventTo" runat="server" Text=""></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="word-break: break-all;">
                                            <asp:Label ID="lbl2nameInsured" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 500px; word-break: break-all;" valign="top">
                                <b>
                                    <br />
                                    <br />
                                    <br />
                                    ADDITIONAL INSURED LANGUAGE :</b><br />
                                <asp:Label ID="lblAdditionallang" runat="server" Text=""></asp:Label><br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="height: 200px" valign="top">
                                <b>RESTRICTIONS :</b><br />
                                <div class="Agrmnt">
                                    <p style="font-weight: bold">
                                        <span style="font-weight: bolder; color: Red; font-size: medium">Scope of coverage description:</span>
                                        Premises and operations General Liability excluding professional and products liability, Sales representative property floater coverage at premises and while in transit and Data Breach Expense. No Cell phone, computer or tablet coverage afforded. Note: Applicant
                                                must have paid premium, be in good standing with the represented company and doing
                                                a function as a sales representative for that company at the time of loss.
                                    </p>
                                    <p style="font-weight: bold; font-size: small; color: Red">
                                        <span style="font-weight: bolder; color: Red; font-size: medium">Coverage Territory:</span>
                                        USA only-excluding USA territories or possessions, Puerto Rico Hawaii, Canada.
                                    </p>
                                   
                                    <p style="font-weight: bold; font-size: smaller; color: Red">
                                        <span style="font-weight: bolder; color: Red; font-size: small">Disclaimer:</span> <br>
                                        It is unlawful to knowingly provide materially false, incomplete or misleading facts or information to an insurance company or another person
for the purpose of defrauding or attempting to defraud the company or the person; or to conceal, for the purpose of misleading, information
concerning any fact material thereto. Filing a false application or submitting false information may lead to penalties that include
imprisonment, fines, denial of insurance and civil damages.
                                    <br /> <br />
                                        Each certificate covers you and your spouse in your conduct as an independent sales representative for a specific member company. Any use or attempted use of this certificate for any other purpose is not permitted, and will subject your coverage to be cancelled and/or claim denial.
                                    </p>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table align="center" width="100%" style="font-size: small;">
            <tr valign="top">
                <td style="width: 50%">
                    <strong>POLICY NUMBER :&nbsp;
                CIP16614</strong></td>
                <td style="width: 50%" align="right">
                    <b>COMMERCIAL GENERAL LIABILITY<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        CG 20 26 07 04
                    </b></td>
            </tr>
             <tr>
                <td colspan="3" align="center"></td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <strong style="font-size: 18px;">THIS ENDORSMENT CHANGES THE POLICY. PLEASE READ IT CAREFULLY.</strong></td>

            </tr>
            <tr>
                <td colspan="3" align="center"></td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <strong style="font-size: 18px;">ADDITIONAL INSURED- DESIGNATED</strong></td>

            </tr>
            <tr>
                <td colspan="3" align="center">
                    <strong style="font-size: 18px;">PERSON OR ORGANIZATION</strong></td>

            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3" style="font-size: medium;">This endorsement modifies insurance provided under the following:
                </td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3">COMMERCIAL GENERAL LIABILITY COVERAGE PART
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <strong style="font-size: 12px;">SCHEDULE</strong></td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <table align="center" border="1" width="100%" style="font-size: small;">
                        <%--<tr>
                            <td align="left" style="word-break: break-all;">
                                <asp:Label Font-Bold="true" ID="lblAdditionalinsuredpage3" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" valign="top" style="word-break: normal; height: 300px;">ANY PERSON(S) OR ORGANIZATION(S) AS REQUIRED BY WRITTEN CONTRACT WITH THE "INSURED", MEANING "INDEPENDENT SALES REPRESENTATIVES" ACTIVELY ENGAGED IN "MEMBER COMPANY BUSINESS ACTIVITIES AND FUNCTIONS", PART OF INDEPENDENT DIRECT SELLERS INSURANCE PROGRAM.
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="word-break: break-all;">Information required to complete this Schedule, if not shown above, will be shown in the Declarations.
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
             <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>
                    <strong style="font-size: 12px;">Section II - Who Is An Insured </strong>is amended to include as an additional insured person(s) or organization(s) shown in schedule, 
                    but only with respect to liability for "bodily injury", "property damage" or "personal and advertising injury" caused, in whole or in 
                </td>
                <td>part, by your act or omissions or the acts or omissions of those acting on your behalf:
                    <br />
                    <strong style="font-size: 12px;">A. </strong>In the performance of your ongoing operations: or
                    <br />
                    <strong style="font-size: 12px;">B. </strong>In connection with your premises owned by or rented by you.
                </td>
            </tr>
        </table>
    </form>
</body>
</html>