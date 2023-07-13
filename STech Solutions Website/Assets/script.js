// age from dob
document.getElementById('dateofbirth').addEventListener('change', calculateAge);

function calculateAge() {
  var dob = new Date(document.getElementById('dateofbirth').value);
  var today = new Date();
  var age = today.getFullYear() - dob.getFullYear();

  var monthDifference = today.getMonth() - dob.getMonth();
  if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < dob.getDate())) {
    age--;
  }
  document.getElementById('age').value = age;

  const agesmallTag = document.querySelector('#age + small');
  if (age < 18) {
    setError(agesmallTag, "Age must be greater than or equal to 18.");
  } else {
    setSuccess(agesmallTag);
  }
}

//future date disable
var todayDate = new Date();
var month = todayDate.getMonth()+1;
var year = todayDate.getUTCFullYear();
var date = todayDate.getDate();

if(month<10){
  month = "0" + month;
}
if(date<10){
  date = "0" + date;
}

var maxDate = year + "-" + month + "-" + date;
document.getElementById("dateofbirth").setAttribute("max",maxDate);

//validate name
function checkName() {
    const name = document.getElementById('name').value;
    const smallTag = document.querySelector('#name + small');
  
    if (name == null || name === "") {
      setError(smallTag, "Name field can't be Empty");
    } else {
      setSuccess(smallTag);
    }
  }
//validate message  
  function checkMessage() {
    const message = document.getElementById('message').value;
    const smallTag = document.querySelector('#message + small');
  
    if (message == null || message === "") {
      setError(smallTag, "Message field can't be Empty");
    } else {
      setSuccess(smallTag);
    }
  }
//validate email
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
  function isValidEmail(email) {
    const emailVal = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailVal.test(email);
  }

//validate username
  function checkUserName() {
    const username = document.getElementById('username').value.trim();
    const usernameSmallTag = document.querySelector('#username + small');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  
    if (username === '') {
      setError(usernameSmallTag, "Username cannot be empty.");
    } else if (!emailRegex.test(username)) {
      setError(usernameSmallTag, "Username must be in email format.");
    } else {
      setSuccess(usernameSmallTag);
    }
  }
  
//validate firstname
function checkLastName() {
  const name = document.getElementById('lastname').value;
  const smallTag = document.querySelector('#lastname + small');

  if (name == null || name === "") {
    setError(smallTag, "lastName field can't be Empty");
  } else {
    setSuccess(smallTag);
  }
}

//PHONE NUMBER VALIDATION

function checkPhone() {
  const phoneInput = document.getElementById('phone');
  const phonesmallTag = document.querySelector('#phone + small');

  if (phoneInput.value.length > 10) {
    phoneInput.value = phoneInput.value.slice(0, 10); // Truncate input to 10 digits
  }

  if (phoneInput.value.length < 10) {
    setError(phonesmallTag, "Please enter a 10-digit phone number");
  } else {
    setSuccess(phonesmallTag);
  }
}

// Function to validate 

  function setError(smallTag, message) {
    smallTag.innerText = message;
    smallTag.style.display = "block";
    smallTag.style.color = "red";
  }
  
  function setSuccess(smallTag) {
    smallTag.innerText = "";
    smallTag.style.display = "none";
  }
  
  // Function to set error message for password field
  function checkPassword() {
    const password = document.getElementById('password').value;
    const passwordSmallTag = document.querySelector('#password + small');
    const strongPasswordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$/;
  
    if (password == null || password === "") {
      setError(passwordSmallTag, "Password field can't be empty.");
    } else if (password.length < 8) {
      setError(passwordSmallTag, "Password must be at least 8 characters long.");
    } else if (!strongPasswordRegex.test(password)) {
      setError(
        passwordSmallTag,
        "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character (!@#$%^&*)."
      );
    } else {
      setSuccess(passwordSmallTag);
    }
  }
  
  // Function to set error message for password confirmation field
  
  function checkConfirmPassword() {
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirm_password').value;
    const confirmPwdSmallTag = document.querySelector('#confirm_password + small');
  
    if (confirmPassword == null || confirmPassword === "") {
      setError(confirmPwdSmallTag, "Confirm Password field can't be empty.");
    } else if (password !== confirmPassword) {
      setError(confirmPwdSmallTag, "Passwords do not match.Please re-enter the password.");
    } else {
      setSuccess(confirmPwdSmallTag);
    }
  }
// city from state

const stateDropdown = document.getElementById('state');
const cityDropdown = document.getElementById('city');

stateDropdown.addEventListener('change', function() {
  const selectedState = stateDropdown.value;
  
  // Clear all city options
  cityDropdown.innerHTML = '';
  
  // Create city options for the selected state
  if (selectedState === 'kerala') {
    addCityOption('Kasaragod');
    addCityOption('Kannur');
    addCityOption('Trivandrum');
    addCityOption('Ernakulam');
    
  } else if (selectedState === 'Karnataka') {
    addCityOption('Bangalore');
    addCityOption('Mysuru');
    addCityOption('Hubli');
    
  } else if (selectedState === 'Tamilnadu') {
    addCityOption('Chennai');
    addCityOption('Coimbatore');
    addCityOption('Madurai');
    
  } else if (selectedState === 'Maharashtra') {
    addCityOption('Mumbai');
    addCityOption('Pune');
    addCityOption('Nagpur');

  } else if (selectedState === 'Madhyapradesh') {
    addCityOption('Indore');
    addCityOption('Bhopal');
    addCityOption('Gwalior');
  }
});

function addCityOption(cityName) {
  const option = document.createElement('option');
  option.value = cityName.toLowerCase();
  option.textContent = cityName;
  cityDropdown.appendChild(option);
}

function alertBox() {
  var confirmation = confirm("Are you sure you want to know more about us? If yes you are free to contact us!!");
      if (confirmation) {
          window.location.href = "./contact.html";
}
} 

//gender validation

document.getElementById("myForm").addEventListener("submit", function(event) {
  if (!validateGender()) {
    event.preventDefault();
  }
});

function validateGender() {
  var genderFields = document.getElementsByName("gender");
  var isGenderSelected = false;

  for (var i = 0; i < genderFields.length; i++) {
    if (genderFields[i].checked) {
      isGenderSelected = true;
      break;
    }
  }

  if (!isGenderSelected) {
    alert("Please select a gender");
    return false;
  }

  return true;
}