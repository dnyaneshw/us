


function makefalse(objlbl)
{
    var lblerror = document.getElementById(objlbl);
    lblerror.innerHTML = "";
    
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57) || charCode == 8)
        return true;

    return false;
}
function PhoneConvert(obj) {
    var val = obj.value.toString();
    if (val.length > 9) {
        var n = val.indexOf("(");
        if (n < 0) {
            var comma = "(" + val.substring(0, 3) + ") ";
            var dash = val.substring(3, 6) + "-";
            var remain = val.substring(6, val.length)
            //alert(comma + dash + remain);
            obj.value = comma + dash + remain;
        }
    }
}
function isNumberValidKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 32 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function morethat256(obj) {
    var txt = obj.value.toString();
    if (txt.length > 256) {
        obj.value = obj.value.substring(0, 256);
        alert("Text should not be more than 256 Characters.");
    }
}

function isKey(evt) {
    if (evt)
        return false;
    else
        return true;
}

/*Coverage Info Validation*/
function ValiDateCoverage(objCoverageDate, objInsurance) {
    var CovDate = document.getElementById(objCoverageDate);
    var Insurance = document.getElementById(objInsurance);

    if (CovDate.value == "") {
        alert('Please Enter Coverage Date.');
        CovDate.focus();
        return false;
    }

    if (Insurance.value == "--Select--") {
        alert('Please Select Insurance Type.');
        Insurance.focus();
        return false;
    }
}

/*Login Validation*/
function ValiDateLogin(objEmailID, objPass) {
    var EmailID = document.getElementById(objEmailID);
    var Pass = document.getElementById(objPass);

    if (EmailID.value == "") {
        alert('Please Enter Email ID for login.');
        EmailID.focus();
        return false;
    }

    if (Pass.value == "") {
        alert('Please Enter Password for Login.');
        Pass.focus();
        return false;
    }

    return true;
}

/*Forget Password Validation*/
function ValiDatePanel(objEmailID) {
    var EmailID = document.getElementById(objEmailID);

    if (EmailID.value == "") {
        alert('Please Enter Email ID.');
        EmailID.focus();
        return false;
    }

    if (!isemailid(EmailID.value)) {
        alert('Please Enter valid email address.');
        EmailID.focus();
        return false;
    }

    return true;
}

/*Propay Payment Validation*/
function ValiDatePayment(objCardType, objCardNo, objCardFName, objCardLName, objmnth, objYear, objCity, objCountry, objZip, objEmail, objlbl2, objlbl3, objlbl4) {
    var CardType = document.getElementById(objCardType);
    var CardNo = document.getElementById(objCardNo);
    var FirstName = document.getElementById(objCardFName);
    var LastName = document.getElementById(objCardLName);
    var ExpMonth = document.getElementById(objmnth);
    var ExpYear = document.getElementById(objYear);
    var City = document.getElementById(objCity);
    var Country = document.getElementById(objCountry);
    var Zip = document.getElementById(objZip);
    var Email = document.getElementById(objEmail);

    var lbl2 = document.getElementById(objlbl2);
    var lbl3 = document.getElementById(objlbl3);
    var lbl4 = document.getElementById(objlbl4);
//    lbl4.style.display = "none";
//    lbl3.style.display = "none";
//    lbl2.style.display = "none";

    if (CardType.value == "--Select--") {
        alert("allas");
        lbl4.style.display = "block";
        lbl4.innerHTML = "Please Select Card Type from List.";
        CardType.focus();
        return false;
    }

//    if (CardNo.value == "") {
//        alert('Please Enter Card Number.');
//        CardNo.focus();
//        return false;
//    }
//    
    if (FirstName.value == "" && LastName.value == "") {
        lbl3.style.display = "block";
        lbl3.innerHTML = "Please Enter Name On Card.";
        FirstName.focus();
        return false;
    }


    if (ExpMonth.value == "--Select--" && ExpYear.value == "--Select--") {
        lbl5.style.display = "block";
        lbl5.innerHTML = "Please Select Expiration Date and Month from List.";
        ExpMonth.focus();
        return false;
    }

//    if (City.value == "") {
//        alert('Please Select City.');
//        City.focus();
//        return false;
//    }
//    if (Country.value == "") {
//        alert('Please Select Country.');
//        Country.focus();
//        return false;
//    }

//    if (Zip.value == "") {
//        alert('Please Select Zip Code.');
//        Zip.focus();
//        return false;
//    }

//    if (!isZipCode(Zip.value)) {
//        alert('Please Enter valid Zip Code.');
//        Zip.focus();
//        return false;
//    }

//    if (Email.value == "") {
//        alert('Please Select Email.');
//        Email.focus();
//        return false;
//    }

//    if (!isemailid(Email.value)) {
//        alert('Please Enter valid email address.');
//        Email.focus();
//        return false;
//    }

    return true;
}


function isemailid(str) {
    var objRegExp = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    return (objRegExp.test(str)) ? true : false;
}

function isZipCode(str) {
    var objRegExp = /^[0-9]{5}(?:-[0-9]{4})?$/;
    return (objRegExp.test(str)) ? true : false;
}

function isPhone(str) {
    var objRegExp = /^[0-9]{3}-[0-9]{3}-[0-9]{4}$/;
    return (objRegExp.test(str)) ? true : false;
}


/*Registration Validation*/
function Validate( objPersonalID, objFirstName, objLastName, objAddress, objEmailID, objphoneNo, objCity, objState, objZipCode, objCompnyAffil, objAgree) {
    var FirstName = document.getElementById(objFirstName);
    var LastName = document.getElementById(objLastName);
    var Address = document.getElementById(objAddress);
    var Email = document.getElementById(objEmailID);
    var PhoNo = document.getElementById(objphoneNo);
    var City = document.getElementById(objCity);
    var Zip = document.getElementById(objZipCode);
    var State = document.getElementById(objState);
    var ComAff = document.getElementById(objCompnyAffil);
    var Agree = document.getElementById(objAgree);
    var PersonalID = document.getElementById(objPersonalID);

    if (PersonalID.value == "") {
        alert('Please Enter Personal Id.');
        PersonalID.focus();
        return false;
    }

    if (FirstName.value == "") {
        alert('Please Enter First Name.');
        FirstName.focus();
        return false;
    }

    if (LastName.value == "") {
        alert('Please Enter Last Name.');
        LastName.focus();
        return false;
    }

    if (Address.value == "") {
        alert('Please Enter Address.');
        Address.focus();
        return false;
    }

    if (Email.value == "") {
        alert('Please Enter Email Address.');
        Email.focus();
        return false;
    }


    if (!isemailid(Email.value)) {
        alert('Please Enter valid email address.');
        Email.focus();
        return false;
    }

    if (PhoNo.value == "") {
        alert('Please Enter Phone Number.');
        PhoNo.focus();
        return false;
    }

    if (!isPhone(PhoNo.value)) {
        alert('Please Enter valid Phone Number');
        PhoNo.focus();
        return false;
    }

    if (City.value == "") {
        alert('Please Enter City.');
        City.focus();
        return false;
    }

    if (Zip.value == "") {
        alert('Please Enter Zip Code.');
        Zip.focus();
        return false;
    }


    if (!isZipCode(Zip.value)) {
        alert('Please Enter valid Zip Code.');
        Zip.focus();
        return false;
    }


    if (State.value == "") {
        alert('Please Enter State.');
        State.focus();
        return false;
    }

    if (ComAff.value == "--Select--") {
        alert('Please Select Company Affiliation.');
        ComAff.focus();
        return false;
    }

    if (Agree.checked == 0) {
        alert('Please read and accept Terms and Conditions to continue');
        Agree.focus();
        return false;
    }
    
    return true;

}


/*Validation for certificate Generation.*/
function ValidateCertificate(objFirstName, objLastName, objEmailID, objAddress, objphoneNo, objCity, objState, objZipCode, objSecCode, objHoldrname, objHoldradd, objEventfrm, objEventTo, objAgree) {
    var PersonalID = document.getElementById(objPersonalId);
    var FirstName = document.getElementById(objFirstName);
    var LastName = document.getElementById(objLastName);
    var Email = document.getElementById(objEmailID);
    var Address = document.getElementById(objAddress);
    var PhoNo = document.getElementById(objphoneNo);
    var City = document.getElementById(objCity);
    var State = document.getElementById(objState);
    var Zip = document.getElementById(objZipCode);
    
    var SecCode = document.getElementById(objSecCode);
    var Holdername = document.getElementById(objHoldrname);
    var HolderAdd = document.getElementById(objHoldradd);
    var EventFrm = document.getElementById(objEventfrm);
    var EventTo = document.getElementById(objEventTo);
    var Agree = document.getElementById(objAgree);


    if (PersonalID.value == "") {
        alert('Please Enter Personal Id.');
        PersonalID.focus();
        return false;
    }

    if (FirstName.value == "") {
        alert('Please Enter First Name.');
        FirstName.focus();
        return false;
    }

    if (LastName.value == "") {
        alert('Please Enter Last Name.');
        LastName.focus();
        return false;
    }

    if (Email.value == "") {
        alert('Please Enter Email Address.');
        Email.focus();
        return false;
    }


    if (!isemailid(Email.value)) {
        alert('Please Enter valid email address.');
        Email.focus();
        return false;
    }

    if (Address.value == "") {
        alert('Please Enter Address.');
        Address.focus();
        return false;
    }

    if (PhoNo.value == "") {
        alert('Please Enter Phone Number.');
        PhoNo.focus();
        return false;
    }

    if (!isPhone(PhoNo.value)) {
        alert('Please Enter valid Phone Number');
        PhoNo.focus();
        return false;
    }

    if (City.value == "") {
        alert('Please Enter City.');
        City.focus();
        return false;
    }

    if (Zip.value == "") {
        alert('Please Enter Zip Code.');
        Zip.focus();
        return false;
    }


    if (!isZipCode(Zip.value)) {
        alert('Please Enter valid Zip Code.');
        Zip.focus();
        return false;
    }


    if (State.value == "") {
        alert('Please Enter State.');
        State.focus();
        return false;
    }

    if (SecCode.value == "") {
        alert('Please Enter Security Code.');
        SecCode.focus();
        return false;
    }

    if (Holdername.value == "") {
        alert('Please Enter Certificate Holder Name.');
        Holdername.focus();
        return false;
    }

    if (HolderAdd.value == "") {
        alert('Please Enter Certificate Holder Address.');
        HolderAdd.focus();
        return false;
    }

    if (EventFrm.value == "") {
        alert('Please Select Event Date.');
        EventFrm.focus();
        return false;
    }

    if (EventTo.value == "") {
        alert('Please Select Event Date.');
        EventTo.focus();
        return false;
    }

    if (Agree.checked == 0) {
        alert('Please read and accept Terms and Conditions to continue');
        Agree.focus();
        return false;
    }

}