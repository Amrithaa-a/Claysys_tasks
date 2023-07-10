function alertBox() {
    var confirmation = confirm("Are you sure you want to know more about us? If yes you are free to contact us!!");
        if (confirmation) {
            window.location.href = "./contact.html";
}
}

//Contact us js
// function checkName()
// {
//     const name = document.getElementById('name').value;
//     if (name == null || name === "") {
//               setError(name,"Name field can't be blank....Please fill it....");
//             }
//     else
//     {
//         setSuccess(name)
//     }
// }

// function setError(input, message)
// {
//     let
// }
function checkName() {
    const name = document.getElementById('name').value;
    const smallTag = document.querySelector('#name + small');
  
    if (name == null || name === "") {
      setError(smallTag, "Name field can't be Empty");
    } else {
      setSuccess(smallTag);
    }
  }
  
  function checkMessage() {
    const message = document.getElementById('message').value;
    const smallTag = document.querySelector('#message + small');
  
    if (message == null || message === "") {
      setError(smallTag, "Message field can't be Empty");
    } else {
      setSuccess(smallTag);
    }
  }

  function checkEmail() {
    const email = document.getElementById('email').value;
    const emailSmallTag = document.querySelector('#email + small');
  
    if (email == null || email === "") {
      setError(emailSmallTag, "Email field can't be blank.Please fill it.");
    } else if (!isValidEmail(email)) {
      setError(emailSmallTag, "Invalid email format.Please enter a valid email address.");
    } else {
      setSuccess(emailSmallTag);
    }
  }
// Function to validate email format using regular expression
function isValidEmail(email) {
    const emailVal = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailVal.test(email);
  }

  function setError(smallTag, message) {
    smallTag.innerText = message;
    smallTag.style.display = "block";
    smallTag.style.color = "red";
  }
  
  function setSuccess(smallTag) {
    smallTag.innerText = "";
    smallTag.style.display = "none";
  }
  



const email = document.getElementById('email').value;
const message = document.getElementById('message').value;


// function formValidate() {
//     var name = document.getElementById('name').value;
    
//     if (name == null || name === "") {
//       alert("Name field can't be blank....Please fill it....");
//     }
//   }
  
//   function messageValidate() {
//     var message = document.getElementById('message').value;
//     if (message.trim() === '') {
//       alert("Empty message can't be submitted");
//     }
//      else if (message.length > 1000) {
//       alert("Message length is greater than 1000");
//     }
//   }    

//sign in js

function passwordValidate(element) {
    const minLength = 8;
    if (element.value.length < minLength) {
        alert("Password must be at least 8 characters long");
        return false
    }
}

function emailValidate() {
var email = document.getElementById('email').value;
if (email == null || email === "") {
    alert("Email field cant be Null!!....");
    return false;
}
}

//sign up js

function validatePasswordCount() {
    const password = document.getElementById('password').value;
    if (password.length < 8) {
        alert('Password must be at least 8 characters long');
    }
        }

function validatePasswordMatch() {
    const password = document.getElementById('password').value;
    const confirm_password = document.getElementById('confirm_password').value;
    if (password !== confirm_password) {
        alert('Passwords do not match');
    }
        }

// age from dob

document.getElementById('dob').addEventListener('change', calculateAge);

  function calculateAge() {
    var dob = new Date(document.getElementById('dob').value);
    var today = new Date();
    var age = today.getFullYear() - dob.getFullYear();

    var monthDifference = today.getMonth() - dob.getMonth();
    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < dob.getDate())) {
      age--;
    }
    document.getElementById('age').value = age;
  }

//future date disabled
  var todayDate = new Date();
  var month = todayDate.getMonth()+1;
  var year = todayDate.getUTCFullYear() - 18;
  var date = todayDate.getDate();

  if(month<10){
    month = "0" + month;
  }
  if(date<10){
    date = "0" + date;
  }

  var minDate = year + "-" + month + "-" + date;
  document.getElementById("dob").setAttribute("min",minDate);



  //password check
  // Function to set error message for password field
function checkPassword() {
    const password = document.getElementById('password').value;
    const passwordSmallTag = document.querySelector('#password + small');
  
    if (password == null || password === "") {
      setError(passwordSmallTag, "Password field can't be blank.Please fill it.");
    } else if (password.length < 8) {
      setError(passwordSmallTag, "Password must be at least 8 characters long.Please enter a valid password.");
    } else {
      setSuccess(passwordSmallTag);
    }
  }
  
  // Function to set error message for password confirmation field
  function checkConfirmPassword() {
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirm-password').value;
    const confirmPwdSmallTag = document.querySelector('#confirm-password + small');
  
    if (confirmPassword == null || confirmPassword === "") {
      setError(confirmPwdSmallTag, "Confirm Password field can't be blank....Please fill it....");
    } else if (password !== confirmPassword) {
      setError(confirmPwdSmallTag, "Passwords do not match....Please re-enter the password....");
    } else {
      setSuccess(confirmPwdSmallTag);
    }
  }
  
  // Rest of the JavaScript code remains the same...
  