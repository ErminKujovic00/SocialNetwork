import { Component, OnInit } from '@angular/core';
import { AxiosError, AxiosResponse } from 'axios';
import Swal from 'sweetalert2';
import { SignUpService } from 'src/app/services/signUpService/sign-up-service.service';
import { LoginService } from 'src/app/services/loginService/login-service.service';
import { AuthService } from 'src/app/services/AuthService/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  constructor(private _signUpService: SignUpService, private _loginService: LoginService, private _authService: AuthService, private _router: Router){}

  url = 'https://localhost:7297/api/Users';
  
  isChecked: boolean = false;
  toggleCheckbox() {
    this.isChecked = !this.isChecked;
  }

  //sign up
  fullname: string = "";
  username: string = "";
  email: string = "";
  pswd: string = "";
  pswdReenter: string = "";

  //login
  loginEmail: string = '';
  loginPassword: string = '';

  ngOnInit(): void {}

  dataValidator(fullname: string, username: string, email: string, pswd: string, pswdReenter: string) : boolean{
    if(fullname === "" || username  === "" || email  === "" || pswd  === "" || pswdReenter  === "") return false;
    return true;
  }

  separateFullName(fullName: string): [string, string] {
    let firstName = "";
    let lastName = "";
    if (fullName && fullName.trim() !== "") {
        const nameParts = fullName.trim().split(' ');
        if (nameParts.length > 0) {firstName = nameParts[0];}
        if (nameParts.length > 1) {lastName = nameParts.slice(1).join(' ');} // Combine remaining parts as the last name
    }
    return [firstName, lastName];
  }

  isValidEmail(email: string): boolean {
    // Regular expression pattern for a basic email validation.
    const emailPattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$/;
  
    // Use the test method of the regex pattern to check if the email is valid.
    return emailPattern.test(email);
  }

  isStrongPassword(password: string): boolean {
    // Define regular expressions to check for numbers, letters, and special characters
    const hasNumber = /\d/.test(password);
    const hasLetter = /[a-zA-Z]/.test(password);
    const hasSpecialChar = /[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]/.test(password);
  
    // Check if the password meets all the criteria
    const isLongEnough = password.length > 6;
  
    return hasNumber && hasLetter && hasSpecialChar && isLongEnough;
  }

  apiSignUpCall(fullname: string, username: string, email: string, pswd: string, pswdReenter: string){
    if(this.dataValidator(fullname, username, email, pswd, pswdReenter) == false){
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failure to signup! Empty fields.',
      });
      return;
    }
    if(this.isValidEmail(email) == false){
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Email is not valid',
      });
      return;
    }
    if(this.isStrongPassword(pswd) == false){
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Password must contain letters, numbers, special characters and be longer than six characters.',
      });
      return;
    }
    if(pswd != pswdReenter) {
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Failure to signup! Passwords do not match!',
      });
      return;
    }

    const [firstName, lastName] = this.separateFullName(fullname);

    this._signUpService.signUpUser(firstName, lastName, username, email, pswd)
    .then((response: AxiosResponse) => {
      if (response.status === 200) {
        //ovdje da se podigne login za dalje
        Swal.fire({
          icon: 'success',
          title: 'Success',
          text: 'Successful login.',
        });
        this.toggleCheckbox();
      } else {
        // Handle other status codes as needed
        console.log("Other Status Code:", response.status);
      }
    })
    .catch((error: AxiosError) => {
      if (error.response && error.response.status === 409) {
        const responseData = error.response.data;
        if (responseData) {
          // Explicitly cast responseData to string
          const responseText = responseData as string;
          Swal.fire({
            icon: 'question',
            title: 'Conflict',
            text: responseText,
            footer: '<a href="">Why do I have this issue?</a>'
          });
        }
      } else {
        Swal.fire({
          icon: 'error',
          title: 'Failure',
          text: 'Something went wrong!',
          footer: '<a href="">Why do I have this issue?</a>'
        })
      }
    });

    this.fullname = '';
    this.username = '';
    this.email = '';
    this.pswd = '';
    this.pswdReenter = '';
  }

  apiLoginCall(){
    this._loginService.userLogin(this.loginEmail, this.loginPassword)
    .then((response: AxiosResponse) => {
      Swal.fire({
        icon: 'success',
        title: 'Success',
        text: 'Logged in successfully!'
      });
      this._authService.setToken(response.data);
      console.log(response.data);
      this._router.navigate(['/home']);
    })
    .catch((error: AxiosError) => {
      Swal.fire({
        icon: 'error',
        title: 'Failure',
        text: 'Something went wrong!',
        footer: '<a href="">Why do I have this issue?</a>'
      });
    });
    this.loginEmail = '';
    this.loginPassword = '';
    console.log("Login");
  }

}
